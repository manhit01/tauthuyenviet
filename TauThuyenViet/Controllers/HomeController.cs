using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TauThuyenViet.Models;

namespace TauThuyenViet.Controllers
{
    public class HomeController : Controller
    {
        [Route("/" , Name="Home")]
        [Route("/home",Name = "HomeEngLish")]
        public IActionResult Index()
        {
            DBContext db= new DBContext();
            var data = db.ProductMainCategories
                         .Include(x=>x.ProductCategories)//muốn qua cấp 3 hóa gian bằng include
                         .ThenInclude(x=>x.Products.Take(3)) //qua cấp 3 bằng thenInclede
                         .Where(x => x.Status == true && x.Code != "hide")
                          .OrderBy(x => x.Position)
                          .ToList();



            ViewBag.Title = "Trang Chủ";
            return View(data);

        }
    }
}
