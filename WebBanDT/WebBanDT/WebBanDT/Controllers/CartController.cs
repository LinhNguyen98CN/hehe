using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDT.Models;
using WebBanDT.Models.Data;
using WebBanDT.Models.Function;

namespace WebBanDT.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            var cart = (Cart)Session["CartSession"];

            var list = new List<CartItem>();

            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult UpdateCart(string id, FormCollection fr)
        {

            var product = new PhoneF().FindEntity(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                int NewQuantity = int.Parse(fr["txtQuantity"].ToString());
                cart.UpdateItem(product, NewQuantity);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");

        }

        // GET: /Cart/Details/5//xóa hàng
        public ActionResult RemoveLine(string Id)
        {

            var product = new PhoneF().FindEntity(Id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddItem(string Id)
        {

            var product = new PhoneF().FindEntity(Id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");
        }
       
    }
}
