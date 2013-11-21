using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCS_LIVE.Domain.DataInterface;
using SSCS_LIVE.Domain.Entities;

namespace SSCS_LIVE.Domain.Context

{
   public  class StoreDataAccess: UserInterface, BookInterface, CartInterface
    {

        // DEfine a context to give the outside access to the data
        private StoreContext dbContext = new StoreContext();



        public IQueryable<Entities.CartLine> UserCart
        {
            get
            {
                return dbContext.Carts;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Entities.Book> Books
        {
            get
            {
                return dbContext.Books;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Entities.UserInfo> Users
        {
            get
            {              
                    //// Console.WriteLine("Name");
                    //var usern = "Darie";
                    //// Console.WriteLine("ID");
                    //var id = "50";

                    //var user = new UserInfo { FirstN = usern, UserId = int.Parse(id) };
                    //dbContext.Users.Add(user);
                    //dbContext.SaveChanges();


                
                return dbContext.Users;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
