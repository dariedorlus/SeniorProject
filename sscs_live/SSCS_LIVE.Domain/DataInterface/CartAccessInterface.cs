using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCS_LIVE.Domain.Entities;
using SSCS_LIVE.Domain.Context;

namespace SSCS_LIVE.Domain.DataInterface
{
    public interface CartInterface
    {
       
         IQueryable<CartLine> UserCart
        { 
            get;//{return Context.Users;} 
            
            set;
        }
    }
}
