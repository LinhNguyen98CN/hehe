using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models.Data;

namespace WebBanDT.App_Start.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult Index()
        {
            BanDT1 dt = new BanDT1();
            return View();
        }
    }
}