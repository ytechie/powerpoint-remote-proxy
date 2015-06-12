using System;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var sessionId = 1234; //(new Random()).Next(0, 9999);
            ViewBag.GeneratedSessionId = sessionId.ToString("0000");
            return View();
        }

        public ActionResult NextSlide(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult PrevSlide(int id)
        {
            return RedirectToAction("Index");
        }
    }
}