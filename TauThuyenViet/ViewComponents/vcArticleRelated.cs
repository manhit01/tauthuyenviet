using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;
namespace TauThuyenViet.ViewComponents
{
    public class vcArticleRelated : ViewComponent
        
    {
        public IViewComponentResult Invoke(int? catID)
        {
            DBContext db = new DBContext();
            var data = db.Articles
                         .Where(x => x.Status == true
                               && x.ArticleCategoryID == catID)
                .OrderByDescending(x => x.CreateTime) // giảm dần thời gian chạy trang tin tức
                .Take(6)
                .ToList();

            return View(data);
         
        }

    }
}
