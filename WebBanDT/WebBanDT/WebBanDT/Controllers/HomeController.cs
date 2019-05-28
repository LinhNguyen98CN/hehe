using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models.Data;

namespace WebBanDT.Controllers
{
    public class HomeController : Controller
    {
        BanDT1 db = new BanDT1();
        // GET: Home
        public ActionResult Index(int? pageTemp, string searchString)
        {
            var phones = from l in db.Phones
                         select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                phones = phones.Where(s => s.Name.Contains(searchString));
            }
            int pageSize = 5;
            int pageNumber = pageTemp ?? 1;
            return View(phones.ToList().OrderBy(a => a.Id).ToPagedList(pageNumber, pageSize));


        }
        [HttpGet]
        public ActionResult Search(string searchString)
        {
            var phones = from l in db.Phones
                         select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                phones = phones.Where(s => s.Name.Contains(searchString));

            }
            return View(phones);

        }
    }
}