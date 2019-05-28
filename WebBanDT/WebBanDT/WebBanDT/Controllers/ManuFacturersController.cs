using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebBanDT.Models.Data;

namespace WebBanDT.Controllers
{
    public class ManuFacturersController : Controller
    {
        BanDT1 db = new BanDT1();
        // GET: ManuFacturers
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 10;
            int pageNumber = pageTemp ?? 1;
            return View(db.Manufacturers.ToList().OrderBy(a => a.Id).ToPagedList(pageNumber, pageSize));
        }
    }
}