using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;
using WebBanDT.Models.Data;
using WebBanDT.Models.Function;
using System.IO;

namespace WebBanDT.Controllers
{
    public class CustomersController : Controller
    {
        public int MyCustomer { get; set; }
        BanDT1 db = new BanDT1();
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.customersid = new SelectList(db.Customers.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer, HttpPostedFileBase fileupload)
        {
            string filename = "";
            //lấy id lớn nhất rồi cộng thêm 1
            int lastId = int.Parse(db.Customers.ToList().OrderBy(e => int.Parse(e.Id.Trim())).Last().Id.Trim()) + 1;
            customer.Id = lastId.ToString();
            if (fileupload != null)
            {
                filename = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/imageTel"), filename);
                if (System.IO.File.Exists(path))
                {

                    filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + filename;
                    path = Path.Combine(Server.MapPath("~/imageTel"), filename);
                }
                fileupload.SaveAs(path);
            }
            customer.Name = filename;
            db.Customers.Add(customer);
            db.SaveChanges();
            

            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                cart.Clear();
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}