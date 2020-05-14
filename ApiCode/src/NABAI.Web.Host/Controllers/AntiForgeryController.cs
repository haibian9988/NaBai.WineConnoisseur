using Microsoft.AspNetCore.Antiforgery;
using NABAI.Controllers;

namespace NABAI.Web.Host.Controllers
{
    public class AntiForgeryController : NABAIControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
