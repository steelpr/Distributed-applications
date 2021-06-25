using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class CulinaryWorldUser : IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}