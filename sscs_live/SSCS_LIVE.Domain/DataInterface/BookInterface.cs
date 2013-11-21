using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCS_LIVE.Domain.Entities;

namespace SSCS_LIVE.Domain.DataInterface
{
   public interface BookInterface
    {
        IQueryable<Book> Books
       {
           get;
           set;
       }
    }
}
