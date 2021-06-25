using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class LikeDTO
    {
        public int Id { get; set; }
        public int Likes { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
