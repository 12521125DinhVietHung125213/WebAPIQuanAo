using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
{
    public class GioHangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
