using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;

namespace TauThuyenViet.Controllers
{
    public class ArticleController : Controller
    {
        [Route("/tin-tuc", Name = "ArticleList")]
        [Route("/article")]
        public IActionResult Index()
        {
            DBContext db = new DBContext();
            var data = db.Articles.ToList();


            ViewBag.Title = "Tin Tức";
            return View(data);
        }

        [Route("/chi-tiet-tin-tuc/{ID}/{title}",Name ="ArticleDetail")]
        [Route("/article-detail")]
        public IActionResult Detail(int ID,string title)    

        {
            DBContext db = new DBContext();
            var data = db.Articles.Where(x => x.ArticleID == ID).FirstOrDefault();

            if(data!=null)
                ViewBag.Title = data.Title;

            return View(data);

        }
       

    }
}
