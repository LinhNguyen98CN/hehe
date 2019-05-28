using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.App_Start.Controllers
{
    public class Tren10trController : Controller
    {
        // GET: Tren10tr
        public ActionResult Index()
        {
            Tren10tr strHome = new Tren10tr();
            List<Tren10tr> obj = strHome.GetHome();
            return View(obj);
        }
    }
}