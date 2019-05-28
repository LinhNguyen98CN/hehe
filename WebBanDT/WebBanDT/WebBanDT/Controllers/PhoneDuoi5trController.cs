using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.Controllers
{
    public class PhoneDuoi5trController : Controller
    {
        // GET: PhoneDuoi5tr
        public ActionResult Index()
        {
            PhoneDuoi5tr strHome = new PhoneDuoi5tr();

            List<PhoneDuoi5tr> obj = strHome.GetHome();
            return View(obj);
        }
    }
}