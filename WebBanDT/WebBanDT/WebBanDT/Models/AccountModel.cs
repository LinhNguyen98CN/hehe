using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanDT.Models.Data;

namespace WebBanDT.Models
{
    public class AccountModel
    {
        private BanDT1 context = null;
        public AccountModel()
        {
            context = new BanDT1();
        }
        public bool Login(string userName, string passWord)
        {
            object[] sqlPara =
            {
                new SqlParameter("@Username",userName),
            new SqlParameter("@Password", passWord),
            };
            var res = context.Database.SqlQuery<bool>("AccountLogin @Username,@Password", sqlPara).SingleOrDefault();
            return res;
        }
    }
}