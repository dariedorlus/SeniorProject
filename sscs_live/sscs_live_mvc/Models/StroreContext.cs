using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SSCS_LIVE.Domain.Entities;
using System.IO;
using System.Diagnostics;

namespace SSCS_LIVE.MVC.Model
{

    public class StroreContext: DbContext
    {   
        
        
        public DbSet<UserInfo> Users
        {
            get;
            set;
        }

        public DbSet<Book> Books
        {
            get;
            set;
        }

        public DbSet<CartLine> Carts
        {
            get;
            set;
        }


    }
}
