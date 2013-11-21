using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCS_LIVE.Domain.Entities
{
   public class Book
    {
       [DisplayName("Title")] 
       public string Title
        {
            get;
            set;
        }

        [DisplayName("ISNB-10")]
        public string ISBN
        {
            get;
            set;
        }

        [DisplayName("Author")]
        public string AuthorFirstN
        {
            get;
            set;
        }

        public string AuthorLastN
        {
            get;
            set;
        }

        public string Condition
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        [DisplayName("For Sale?")]
        public bool IsForsale
        {
            get;
            set;
        }

        public bool IsSold
        {
            get;
            set;
        }

        public string Picture
        {
            get;
            set;
        }

        
        public string BookId
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
