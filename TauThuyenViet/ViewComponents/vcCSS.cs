using Microsoft.AspNetCore.Mvc;

namespace TauThuyenViet.ViewComponents
{
    public class vcCSS : ViewComponent
        
    {
        public IViewComponentResult Invoke()
        {
            return View();
         
        }

    }
}
