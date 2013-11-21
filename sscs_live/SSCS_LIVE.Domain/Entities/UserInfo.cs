using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace SSCS_LIVE.Domain.Entities
{
    public class UserInfo
    {
        public string FirstN
        {
            get;
            set;
        }

        public string LastN
        {
            get;
            set;
        }

        [Key][Required]
        public int UserId
        {
            get;
            set;
        }
       
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string School
        {
            get;
            set;
        }
        
        public int ZipCode
        {
            get;
            set;
        }
        
        public virtual List<Book> Books {get; set;}
            
        public UserInfo()
        { }

    }
}
