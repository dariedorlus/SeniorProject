using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCS_LIVE.Domain.Entities;
using System.Data.Entity;

namespace SSCS_LIVE.Domain.Context
{
    class StoreDbContext 
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
