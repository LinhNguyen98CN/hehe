using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models.Data;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebBanDT.Controllers
{
    public class PhonesController : Controller
    {
        public int MyProperty { get; set; }
        BanDT1 db = new BanDT1();
        // GET: Phones
        public ActionResult Index(int? pageTemp)
        { 
            int pageSize = 5;
            int pageNumber = pageTemp ?? 1;
            return View(db.Phones.ToList().OrderBy(a => a.Id).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Manufacturerid = new SelectList(db.Manufacturers.ToList(), "Id", "Name");
            return View();
        }

        // POST: Phones/Create
        [HttpPost]
        public ActionResult Create(Phone phone, HttpPostedFileBase fileupload)
        {
            string filename = "";
            // Lấy id lớn nhất rồi công thêm 1
            int lastId = int.Parse(db.Phones.ToList().OrderBy(e => int.Parse(e.Id.Trim())).Last().Id.Trim()) + 1;
            phone.Id = lastId.ToString();
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
            phone.Image = filename;
            db.Phones.Add(phone);
            db.SaveChanges();
            return RedirectToAction("Index", "Phones");
        }

        public ActionResult Edit(string Id)
        {
            Phone ph = db.Phones.SingleOrDefault(x => x.Id == Id);
            SelectList lst = new SelectList(db.Manufacturers.ToList(), "Id", "Name");
            ViewBag.Manufacturerid = lst;
            return View(ph);
        }

        [HttpPost]
        public ActionResult Edit(Phone phone, HttpPostedFileBase fileupload)
        {
            string filename = "";
            // Lấy id lớn nhất rồi công thêm 1
            int lastId = int.Parse(db.Phones.ToList().OrderBy(e => int.Parse(e.Id.Trim())).Last().Id.Trim()) + 1;
            phone.Id = lastId.ToString();
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
            Phone ph = db.Phones.Find(phone.Id);
            ph.Image = filename;
            ph.Manufacturerid = phone.Manufacturerid;
            ph.Name = phone.Name;
            ph.Price = phone.Price;
            ph.Status = phone.Status;
            ph.Configuration = phone.Configuration;
            db.SaveChanges();
            return RedirectToAction("Index", "Phones");
        }
        public ActionResult Delete(string id)
        {
            Phone ph = db.Phones.SingleOrDefault(x => x.Id == id);
            //db.Phones.Remove(ph);

            //db.


            //ViewBag.Manufacturerid = lst;
            return RedirectToAction("Index", "Phones");
        }
    }
}