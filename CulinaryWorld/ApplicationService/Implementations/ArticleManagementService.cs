using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class ArticleManagementService
    {
        private CulinaryWorldDbContext dbContext = new CulinaryWorldDbContext();

        public List<ArticleDTO> Get()
        {
            List<ArticleDTO> articleDTO = new List<ArticleDTO>();

            foreach (var item in dbContext.Articles.ToList())
            {
                articleDTO.Add(new ArticleDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    ImageUrl = item.ImageUrl,
                    VideoUrl = item.VideoUrl,
                    Like = item.Like,
                    TimeToRead = item.TimeToRead,
                    Description = item.Description,
                    UserId = item.UserId,
                    User = new CulinaryWorldUser
                    {
                        Id = item.UserId
                    }

                });
            }

            return articleDTO;
        }

        public ArticleDTO GetById(int id)
        {
            ArticleDTO articleDTO = new ArticleDTO();

            Article item = dbContext.Articles.Find(id);
            if (articleDTO != null)
            {
                articleDTO.Id = item.Id;
                articleDTO.Title = item.Title;
                articleDTO.ImageUrl = item.ImageUrl;
                articleDTO.VideoUrl = item.VideoUrl;
                articleDTO.Like = item.Like;
                articleDTO.TimeToRead = item.TimeToRead;
                articleDTO.Description = item.Description;
                articleDTO.UserId = item.UserId;
                articleDTO.User = new CulinaryWorldUser
                {
                    Id = item.UserId
                };
            };
            return articleDTO;
        }

        public bool Save(ArticleDTO articleDTO)
        {


            Article article = new Article
            {
                Title = articleDTO.Title,
                ImageUrl = articleDTO.ImageUrl,
                VideoUrl = articleDTO.VideoUrl,
                Like = articleDTO.Like,
                TimeToRead = articleDTO.TimeToRead,
                Description = articleDTO.Description,
                UserId = articleDTO.UserId
            };

            try
            {
                dbContext.Articles.Add(article);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Article nationality = dbContext.Articles.Find(id);
                dbContext.Articles.Remove(nationality);
                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
