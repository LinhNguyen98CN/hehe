using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.Controllers
{
    public class SamSungPhoneController : Controller
    {
        // GET: SamSungPhone
        public ActionResult Index()
        {
            SamSungPhone strHome = new SamSungPhone();

            List<SamSungPhone> obj = strHome.GetHome();
            return View(obj);
        }
    }
}