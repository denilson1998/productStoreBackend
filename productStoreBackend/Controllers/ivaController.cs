using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace productStoreBackend.Controllers
{
    public class ivaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public decimal ivaBolivia(decimal total)
        {
            return total + ((total) * Convert.ToDecimal(0.13));
        }
    }
}
