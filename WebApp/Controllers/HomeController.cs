using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using var context = new QlbanVaLiContext();
            var valiProducts = (from sp in context.TDanhMucSps.AsNoTracking()
                                join loai in context.TLoaiSps.AsNoTracking()
                                    on sp.MaLoai equals loai.MaLoai
                                where loai.Loai != null && loai.Loai.Trim() == "Va li"
                                select sp)
                .ToList();

            return View(valiProducts);
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
