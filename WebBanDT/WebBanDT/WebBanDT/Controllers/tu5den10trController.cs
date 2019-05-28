using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.Controllers
{
    public class tu5den10trController : Controller
    {
        // GET: tu5den10tr
        public ActionResult Index()
        {
            Tu5den10tr strHome = new Tu5den10tr();
            List < Tu5den10tr > obj = strHome.GetHome();
            return View(obj);
        }
    }
}