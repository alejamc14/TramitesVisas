using TramitesVisas.Shared.Entidades;
using TramitesVisas.Shared.Enums;
using TramitesVisas.API.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace TramitesVisas.API.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {

            await _context.Database.EnsureCreatedAsync();

            await CheckPersonasAsync();

            await CheckTipoVisasAsync();

            await CheckSolicitudesAsync();

            await CheckRenovacionesAsync();

            await CheckDocumentosAsync();

            await CheckPagosAsync();

            await CheckRoleAsync();

            await CheckUserAsync("10235", "Paula", "Calderon", "calderonpaula781@gmail.com", "3135555555", "Cr 25 8965", UserType.Admin);


        }

        private async Task CheckPersonasAsync()
        {
            if (!_context.Personas.Any())
            {
                _context.Personas.Add(new Persona
                {
                    Documento = "1023523",
                    Nombre = "Paula",
                    Apellido = "Calderon",
                    FechaNacimiento = new DateTime(2004,11,26),
                    Nacionalidad = "Colombiana",
                    Email = "Calderonpaula@gmail.com",
                    Telefono = 12435

                });

                _context.Personas.Add(new Persona
                {
                    Documento = "2045637",
                    Nombre = "Alejandra",
                    Apellido = "Madrid",
                    FechaNacimiento = new DateTime(1995, 7, 22),
                    Nacionalidad = "Colombiana",
                    Email = "AlejaMadrid@gmail.com",
                    Telefono = 98765
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTipoVisasAsync()
        {
            if (!_context.TipoVisas.Any())
            {
                _context.TipoVisas.Add(new TipoVisa
                {
                    Tipo = "Turismo",
                    Costo = 100.50,
                    Duracion = "6 meses",
                    Requisitos = "Pasaporte, Foto"
                });
                _context.TipoVisas.Add(new TipoVisa
                {
                    Tipo = "Residencia",
                    Costo = 250.75,
                    Duracion = "1 año",
                    Requisitos = "Pasaporte, Pruebas de residencia"
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckSolicitudesAsync()
        {
            if (!_context.Solicitudes.Any())
            {
                _context.Solicitudes.Add(new Solicitud {
                    TipoSolicitud = "Renovacion",
                    Estado = "Pendiente",
                    FechaSolicitud = new DateTime(2024, 5, 28),
                    Comentario = "Renovación de visa de trabajo",
                    PersonaId = 1,
                    TipoVisaId = 1
                });
                _context.Solicitudes.Add(new Solicitud {
                    TipoSolicitud = "Visa Nueva",
                    Estado = "Aprobada",
                    FechaSolicitud = new DateTime(2024, 5, 1),
                    Comentario = "Solicitud de visa de turismo",
                    PersonaId = 2,
                    TipoVisaId =2 
                });
            }
            await _context.SaveChangesAsync();
        }


        private async Task CheckRenovacionesAsync()
        {
            if (!_context.Renovaciones.Any())
            {
                _context.Renovaciones.Add(new Renovacion
                {
                    FechaRenovacion = new DateTime(2023, 12, 1),
                    Costo = 200.00,
                    Descripcion = "Renovación anual de visa de trabajo",
                    SolicitudId = 1
                });
                _context.Renovaciones.Add(new Renovacion{
                    FechaRenovacion = new DateTime(2024, 6, 15),
                    Costo = 300.00,
                    Descripcion = "Renovación de visa de residencia",
                    SolicitudId = 2
                });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckDocumentosAsync()
        {
            if (!_context.Documentos.Any())
            {
                _context.Documentos.Add(new Documento
                {
                    TipoDocumento = "Pasaporte",
                    FechaSubida = new DateTime(2024, 5, 28),
                    URL = "https://example.com/pasaporte.pdf",
                    SolicitudId = 1

                });

                _context.Documentos.Add(new Documento {
                    TipoDocumento = "Foto",
                    FechaSubida = new DateTime(2024, 5, 28),
                    URL = "https://example.com/foto.jpg",
                    SolicitudId = 2
                });
            }

        }
        private async Task CheckPagosAsync()
        {
            if (!_context.Pagos.Any())
            {
                _context.Pagos.Add(new Pago
                {
                    Monto = 150.00,
                    MetodoPago = "Tarjeta de Crédito",
                    FechaPago = new DateTime(2024, 06, 11),
                    SolicitudId = 1
                });

                _context.Pagos.Add(new Pago
                {
                    Monto = 200.00,
                    MetodoPago = "Transferencia",
                    FechaPago = new DateTime(2024,10, 16),
                    SolicitudId = 2

                });
            }

        }

        private async Task CheckRoleAsync()
        {

            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }

        private async Task<User> CheckUserAsync(string document, string firstname, string lastname, string email, string phone, string address, UserType userType)
        {


            var user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {



                user = new User
                {

                    Document = document,
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    PhoneNumber = phone,
                    UserName = email,
                    Address = address,
                    UserType = userType ,



                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());



            }


            return user;



        }
    }
}
