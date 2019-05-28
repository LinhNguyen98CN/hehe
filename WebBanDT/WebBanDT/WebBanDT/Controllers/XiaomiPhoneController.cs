using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.Controllers
{
    public class XiaomiPhoneController : Controller
    {
        // GET: XiaimiPhone
        public ActionResult Index()
        {
            XiaomiPhone strHome = new XiaomiPhone();

            List<XiaomiPhone> obj = strHome.GetHome();
            return View(obj);
        }
    }
    }
