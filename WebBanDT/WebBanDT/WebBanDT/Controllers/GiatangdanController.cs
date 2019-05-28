using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;

namespace WebBanDT.App_Start.Controllers
{
    public class GiatangdanController : Controller
    {
        
        // GET: Giatangdan
        public ActionResult Index()
        {
            Giatangdan strHome = new Giatangdan();
            List<Giatangdan> obj = strHome.GetHome();
            return View(obj);
        }
    }
}