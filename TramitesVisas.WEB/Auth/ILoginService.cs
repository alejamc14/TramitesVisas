﻿using System.Threading.Tasks;

namespace TramitesVisas.Web.Auth
{
    public interface ILoginService
    {
        Task LoginAsync(string token);
        Task LogoutAsync();

    }
}
