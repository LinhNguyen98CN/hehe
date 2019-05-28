using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.Controllers
{
    public class ApplePhoneController : Controller
    {
        // GET: ApplePhone
        public ActionResult Index()
        {
            ApplePhone strHome = new ApplePhone();

            List<ApplePhone> obj = strHome.GetHome();
            return View(obj);
        }
    }
}