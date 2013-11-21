using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace SSCS_LIVE.Domain.Entities
{
   public class CartLine
    {
       [Key] //Primary key to uniquely identify each item in the cart table 
       public int UniqueID
       {
           get;
           set;
       }


        [Required]// Helps identify each shopping cart
        public string CartID
        {
            get;
            set;
        }

       //Change to a string containing BookID instead -- Done
        public virtual Book Book
        {
            get;
            set;
        }

        public virtual UserInfo User
        {
            get;
            set;
        }


    }
}
