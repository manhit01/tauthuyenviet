using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;

namespace TauThuyenViet.ViewComponents
{
    public class vcProductTab : ViewComponent
        
    {
        public IViewComponentResult Invoke()
        {
            DBContext db = new DBContext();
            var data= db.ProductMainCategories
                        .OrderBy(x=> x.Position)
                        .ToList();
            return View(data);
         
        }

    }
}
