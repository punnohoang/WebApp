using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlbanVaLiContext _context;

        public HomeController(QlbanVaLiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetLoai()
        {
            var loai = _context.TLoaiSps
                .AsNoTracking()
                .Select(x => new
                {
                    maLoai = x.MaLoai,
                    loai = x.Loai
                })
                .ToList();

            return Json(loai);
        }

        public IActionResult GetProducts(string maLoai)
        {
            var products = _context.TDanhMucSps
                .AsNoTracking()
                .Where(x => x.MaLoai == maLoai)
                .ToList();

            return PartialView("_ProductList", products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
