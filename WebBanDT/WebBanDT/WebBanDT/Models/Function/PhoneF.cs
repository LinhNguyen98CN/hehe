using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanDT.Models.Data;

namespace WebBanDT.Models.Function
{
    public class PhoneF
    {
        private BanDT1 context;

        public PhoneF()
        {
            context = new BanDT1();
        }

        // Trả về All record
        public IQueryable<Phone> DSSanPham
        {
            get { return context.Phones; }
        }
        // Trả về một đối tượng  khi biết Khóa
        public Phone FindEntity(string MaSP)
        {
            Phone dbEntry = context.Phones.Find(MaSP);
            return dbEntry;
        }
        // Thêm một đối tượng
        public bool Insert(Phone model)
        {
            Phone dbEntry = context.Phones.Find(model.Id);

            if (dbEntry != null)
            {
                return false;

            }
            context.Phones.Add(model);

            context.SaveChanges();

            return true;
        }

        // Sửa một đối tượng
        public bool Update(Phone model)
        {
            Phone dbEntry = context.Phones.Find(model.Id);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.Name = model.Name;
            dbEntry.Image = model.Image;
            dbEntry.Manufacturerid = model.Manufacturerid;
            dbEntry.Price = model.Price;
            dbEntry.Status = model.Status;
            dbEntry.Configuration = model.Configuration;
            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return true;
        }

        // Xóa một đối tượng
        public bool Delete(string MaSP)
        {
            Phone dbEntry = context.Phones.Find(MaSP);
            if (dbEntry == null)
            {
                return false;
            }
            context.Phones.Remove(dbEntry);

            context.SaveChanges();
            return true;
        }
    }
}