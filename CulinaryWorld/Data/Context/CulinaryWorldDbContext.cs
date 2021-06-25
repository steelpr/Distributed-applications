using Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class CulinaryWorldDbContext : IdentityDbContext<IdentityUser>
      
    {
        public CulinaryWorldDbContext() : base(@"Server=(localdb)\mssqllocaldb;Database=Cul;Trusted_Connection=True;MultipleActiveResultSets=true")
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Like> Likes { get; set; }

       // public System.Data.Entity.DbSet<MVC.ViewModel.ArticleVM> ArticleVMs { get; set; }

        public System.Data.Entity.DbSet<Data.Entities.CulinaryWorldUser> IdentityUsers { get; set; }
    }
}
