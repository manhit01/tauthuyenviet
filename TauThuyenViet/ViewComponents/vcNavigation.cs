using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TauThuyenViet.Models;

namespace TauThuyenViet.ViewComponents
{
    public class vcNavigation : ViewComponent
        
    {
        public IViewComponentResult Invoke()
        {
            DBContext db = new DBContext();
            var data = db.ProductMainCategories
                          .Include(x => x.ProductCategories)
                          .ToList();
            return View(data);
         
        }

    }
}
