using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
     public class Article : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$")]
        public string ImageUrl { get; set; }

        [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$")]
        public string VideoUrl { get; set; }
        public double TimeToRead { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public string UserId { get; set; }
        public CulinaryWorldUser User { get; set; }

        public virtual ICollection<Like> Like { get; set; }

    }
}
