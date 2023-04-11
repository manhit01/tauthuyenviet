using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TauThuyenViet.Models;

namespace TauThuyenViet.Controllers
{
    public class ProductController : Controller
    {
        [Route("/san-pham", Name = "ProductList")]
        [Route("/san-pham/{mid}/{cid}/{title}", Name = "ProductListByID")]
        public IActionResult Index(int mid, int cid, string title)
        {
            DBContext db = new DBContext();
            var data = db.Products.AsQueryable();

            //Nếu có cid, mà có mid thì load sp theo menu cấp 2
            if (cid > 0)
            {
                data = data.Where(x => x.ProductCategoryID == cid);
                //Query lấy cat title để show lên tiêu của tab
                var catItem = db.ProductCategories
                                .Where(x => x.ProductCategoryID == cid)
                                .FirstOrDefault();
                if (catItem != null)
                    ViewBag.Title = catItem.Title;
            }
            //nế kh có cudmaf có mid thì load sp theo kiểu menu cấp 1
            else if (mid > 0)
            {
                data = data.Include(x => x.ProductCategory)
                     .Where(x => x.ProductCategory.ProductMainCategoryID == mid);

                //query lấy main cat title để show lên tiêu đồ menu cấp 1
                var mainItem = db.ProductMainCategories
                                .Where(x => x.ProductMainCategoryID == mid)
                                .FirstOrDefault();
                if (mainItem != null)
                    ViewBag.Title = mainItem.Title;
            }
            //Ngược lại : kh có mid ,cũng kh có mid,thì load tất cả

            else
            {
                ViewBag.Title = "Sản Phẩm";
            }
            return View(data.ToList());
        }

        [Route("/chi-tiet-san-pham/{ID}/{title}", Name = "ProductDetail")]
        [Route("/product-detail")]
        public IActionResult Detail(int ID, string title)
        {
            DBContext db = new DBContext();
            var data = db.Products.Where(x => x.ProductID == ID).FirstOrDefault();

            if (data != null)
                ViewBag.Title = data.Title;

            return View(data);
        }
    }
}
