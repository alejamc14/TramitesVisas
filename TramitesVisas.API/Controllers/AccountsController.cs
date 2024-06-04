﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TramitesVisas.API.Helpers;
using TramitesVisas.Shared.DTOs;
using TramitesVisas.Shared.Entidades;
using TramitesVisas.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _dataContext;  
        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;
        private readonly IFileStorage _fileStorage;
        private readonly string _container;


        public AccountsController(IUserHelper userHelper, IConfiguration configuration, DataContext dataContext, IFileStorage fileStorage)
        {
            _dataContext = dataContext; 
            _userHelper = userHelper;
            _configuration = configuration;
            _fileStorage = fileStorage;
            _container = "users";

        }

        //[HttpPost("RecoverPassword")]
        //public async Task<ActionResult> RecoverPassword([FromBody] EmailDTO model)
        //{
        //    User user = await _userHelper.GetUserAsync(model.Email);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var myToken = await _userHelper.GeneratePasswordResetTokenAsync(user);
        //    var tokenLink = Url.Action("ResetPassword", "accounts", new
        //    {
        //        userid = user.Id,
        //        token = myToken
        //    }, HttpContext.Request.Scheme, _configuration["UrlWEB"]);

        //    var response = _mailHelper.SendMail(user.FullName, user.Email!,
        //        $"Sales - Recuperación de contraseña",
        //        $"<h1>Sales - Recuperación de contraseña</h1>" +
        //        $"<p>Para recuperar su contraseña, por favor hacer clic 'Recuperar Contraseña':</p>" +
        //        $"<b><a href ={tokenLink}>Recuperar Contraseña</a></b>");

        //    if (response.IsSuccess)
        //    {
        //        return NoContent();
        //    }

        //    return BadRequest(response.Message);
        //}

        //[HttpPost("ResetPassword")]
        //public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        //{
        //    User user = await _userHelper.GetUserAsync(model.Email);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var result = await _userHelper.ResetPasswordAsync(user, model.Token, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return NoContent();
        //    }

        //    return BadRequest(result.Errors.FirstOrDefault()!.Description);
        //}


        [HttpPost("changePassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ChangePasswordAsync(ChangePasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userHelper.GetUserAsync(User.Identity!.Name!);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userHelper.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault().Description);
            }

            return NoContent();
        }


        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Photo))
                {
                    var photoUser = Convert.FromBase64String(user.Photo);
                    user.Photo = await _fileStorage.SaveFileAsync(photoUser, ".jpg", _container);
                }

                var currentUser = await _userHelper.GetUserAsync(user.Email!);
                if (currentUser == null)
                {
                    return NotFound();
                }

           
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Address = user.Address;
                currentUser.PhoneNumber = user.PhoneNumber;
                currentUser.Nacionalidad = user.Nacionalidad;
                currentUser.Photo = !string.IsNullOrEmpty(user.Photo) && user.Photo != currentUser.Photo ? user.Photo : currentUser.Photo;
                

                var result = await _userHelper.UpdateUserAsync(currentUser);
                if (result.Succeeded)
                {
                    return Ok(BuildToken(currentUser));
                }

                return BadRequest(result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Get()
        {
            return Ok(await _userHelper.GetUserAsync(User.Identity!.Name!));
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO model)
        {
            User user = model;
            if (!string.IsNullOrEmpty(model.Photo))
            {
                var photoUser = Convert.FromBase64String(model.Photo);
                model.Photo = await _fileStorage.SaveFileAsync(photoUser, ".jpg", _container);
            }

            var result = await _userHelper.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _dataContext.Personas.AddAsync(new Persona
                {
                    Documento = model.Document,
                    Nombre = model.FirstName,
                    Apellido = model.LastName,
                    FechaNacimiento= model.FechaNacimiento,
                    Nacionalidad = model.Nacionalidad,
                    Email = model.Email,
                    Telefono=model.Telefono,
                        
                });
                await _dataContext.SaveChangesAsync();

                await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());
                return Ok(BuildToken(user));
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO model)
        {
            var result = await _userHelper.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await _userHelper.GetUserAsync(model.Email);
                return Ok(BuildToken(user));
            }

            return BadRequest("Email o contraseña incorrectos.");
        }

        private TokenDTO BuildToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim("Document", user.Document),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Address", user.Address),
                new Claim("Photo", user.Photo ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}