using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.Controllers
{
    public class AsusPhoneController : Controller
    {
        // GET: AsusPhone
        public ActionResult Index()
        {
            AsusPhone strHome = new AsusPhone();

            List<AsusPhone> obj = strHome.GetHome();
            return View(obj);
        }
    }
    }
