using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;
using WebBanDT.Models.Code;
using WebBanDT.Models.Data;

namespace WebBanDT.Controllers
{
    public class LoginsController : Controller
    {
        [HttpGet]
        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index( Account model)//   các trường tu form tương ứng vs các trường trong Account
        {
            var result = new AccountModel().Login(model.Username, model.Password);//AccountModel có các pt xli việc login
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.Username });
                return RedirectToAction("Phones", "Index");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản không đúng");
            }
            return View(model);
        }
    }
}