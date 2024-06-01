using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace TramitesVisas.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider

    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity(); 
            var zuluUser = new ClaimsIdentity(new List<Claim>
            {
            new Claim("FirstName", "Paula"),
            new Claim("LastName", "Calderon"),
            new Claim(ClaimTypes.Name, "calderonpaula781@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(zuluUser)));
        }

    }
}
