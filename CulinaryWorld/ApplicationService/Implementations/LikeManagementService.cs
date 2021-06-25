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
    public class LikeManagementService
    {
        private CulinaryWorldDbContext dbContext = new CulinaryWorldDbContext();

        public List<LikeDTO> Get()
        {
            List<LikeDTO> likeDTO = new List<LikeDTO>();

            foreach (var item in dbContext.Likes.ToList())
            {
                likeDTO.Add(new LikeDTO
                {
                    Id = item.Id,
                    Likes = item.Likes,
                    ArticleId = item.ArticleId,
                    Article = new Article
                    {
                        Id = item.ArticleId
                    }
                    
                });
            }

            return likeDTO;
        }

     /*   public EventDTO GetById(int id)
        {
            EventDTO eventDTO = new EventDTO();

            Event item = dbContext.Events.Find(id);
            if (item != null)
            {
                eventDTO.Id = item.Id;
                eventDTO.Title = item.Title;
                eventDTO.Place = item.Place;
                eventDTO.Date = item.Date;
                eventDTO.Description = item.Description;
                eventDTO.Participant = item.Participant;
                eventDTO.Duration = item.Duration;
                eventDTO.UserId = item.UserId;
                eventDTO.User = new CulinaryWorldUser
                {
                    Id = item.UserId
                };
            };
            return eventDTO;
        }*/

        public bool Save(LikeDTO likeDTO)
        {


            Like like = new Like
            {
                Likes = likeDTO.Likes,
                ArticleId = likeDTO.ArticleId
            };

            try
            {
                dbContext.Likes.Add(like);
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
