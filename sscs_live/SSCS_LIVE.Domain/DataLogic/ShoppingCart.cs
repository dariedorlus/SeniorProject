using SSCS_LIVE.Domain.Context;
using SSCS_LIVE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCS_LIVE.Domain.DataLogic
{
   public class ShoppingCart
    {
        private List<CartLine> cartItems = new List<CartLine>(); //Might be useless
       
        private StoreContext storeDB = new StoreContext();
        private int cartId = 0; 

        public ShoppingCart(int cartId)
        {
           this.cartId = cartId;//keeping each cartId Unique
        }
        
       public ShoppingCart()
        {
            // With that constructor ca
        }
       
       public int CartId
       {
           set
           {
               this.cartId = value;
           }
       }


        public void addToCart(Book newBook)
        {
            CartLine line = storeDB.Carts
                .Where(book => book.Book.BookId == newBook.BookId)
                .FirstOrDefault();
           
            if (line == null)
            {
                storeDB.Carts.Add(new CartLine 
                { 
                    CartID = cartId.ToString(),
                    Book = newBook
                    
                });

                storeDB.SaveChanges();
            }
            
            else 
            {
                throw new NotImplementedException("Book Already in cart");
            }
         }

        
          public void removeBook(Book bookRemoved) 
          {
             CartLine removedLine = storeDB.Carts.Where // might also need to add cardtId check 
                                      (line => line.Book.BookId == bookRemoved.BookId).First();

             if (removedLine == null)
             {
                 throw new NotImplementedException("Book not in cart");
             }
             else
             {
                 storeDB.Carts.Remove(removedLine);
                 storeDB.SaveChanges();
             }

          }
          public double cartTotal() 
          {
              double sum = 0; 
              foreach (CartLine line in storeDB.Carts.Where(t => this.cartId.ToString() == t.CartID))
              {
                  sum += line.Book.Price;
              }

              return sum;
          }
          
          public void clearCart() 
          {
              foreach (CartLine line in storeDB.Carts.Where(t => this.cartId.ToString() == t.CartID))
              {
                  storeDB.Carts.Remove(line);
              }
              storeDB.SaveChanges();
          }
          
        public IEnumerable<CartLine> Lines 
          {
              get { return storeDB.Carts; }
          } 
    }
    
         //public class CartLine 
         // {
         //     public Product Product { get; set; }
         //     public int Quantity { get; set; }
         //} 
  }


