using TramitesVisas.Shared.Responses;

namespace TramitesVisas.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }
}
