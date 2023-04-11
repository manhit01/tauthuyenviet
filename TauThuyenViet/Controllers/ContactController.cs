using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;

namespace TauThuyenViet.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        [Route("/lien-he", Name = "ConTact")]
        [Route("/contact")]
        public IActionResult Index()
        {
            ViewBag.Title = "Liên Hệ";
            ViewBag.MessageType = "alret alert-info";
            ViewBag.MessageText = "Mời nhập thông tin";
            return View();
        }
        [HttpPost]
        [Route("/lien-he", Name = "ConTact")]
        [Route("/contact")]
        public IActionResult Index(Contact item)
        {


            //Kiểm tra lỗi
            if(item == null)
            {
                ViewBag.MessageType = "alret alert-danger";
                ViewBag.MessageText = "Mời nhập thông tin";
                ViewBag.Title = "Liên Hệ";
                return View();
            }
            if (string.IsNullOrEmpty(item.FullName))
            {
                ViewBag.MessageType = "alret alert-danger";
                ViewBag.MessageText = "Mời nhập  họ tên";
                ViewBag.Title = "Liên Hệ";
                return View();
            }
            if (string.IsNullOrEmpty(item.Mobi))
            {
                ViewBag.MessageType = "alret alert-danger";
                ViewBag.MessageText = "Mời nhập số điện thoại";
                ViewBag.Title = "Liên Hệ";
                return View();
            }
            if (string.IsNullOrEmpty(item.Content))
            {
                ViewBag.MessageType = "alret alert-danger";
                ViewBag.MessageText = "Mời nhập nội dung";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            item.CreateTime = DateTime.Now;
            item.Status = false;

            DBContext db= new DBContext();
            db.Contacts.Add(item);
            db.SaveChanges();

            ViewBag.MessageType = "alret alert-success";
            ViewBag.MessageText = "Cảm ơn đã liên hện.Chúng tôi sẽ phản hồi sớm ";
            ViewBag.Title = "Liên Hệ";

            //xóa trawg form đã nhập
            ModelState.Clear();

            return View();
        }
    }
}
