using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.Controllers
{
    public class SonyPhoneController : Controller
    {
        // GET: SonyPhone
        public ActionResult Index()
        {
            SonyPhone strHome = new SonyPhone();

            List<SonyPhone> obj = strHome.GetHome();
            return View(obj);
        }
    }
}