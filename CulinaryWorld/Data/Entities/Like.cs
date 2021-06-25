using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
      public class Like : BaseEntity
    {
        public int Likes { get; set; }

        public int ArticleId { get; set; }
        public  Article Article { get; set; }
    }
}
