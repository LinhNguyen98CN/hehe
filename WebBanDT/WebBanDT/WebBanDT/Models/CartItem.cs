using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanDT.Models.Data;

namespace WebBanDT.Models
{
    [Serializable]
    public class CartItem
    {
        public Phone Sanpham { get; set; }
        public int Quantity { set; get; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(Phone sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Sanpham.Id == sp.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    Sanpham = sp,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.Sanpham.Id == sp.Id);
                }
            }
        }
        public void UpdateItem(Phone sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Sanpham.Id == sp.Id)
                .FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.Sanpham.Id == sp.Id);
                }
            }
        }
        public void RemoveLine(Phone sp)
        {
            lineCollection.RemoveAll(l => l.Sanpham.Id == sp.Id);
        }

        public double ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Sanpham.Price * e.Quantity);

        }
        public int ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}
