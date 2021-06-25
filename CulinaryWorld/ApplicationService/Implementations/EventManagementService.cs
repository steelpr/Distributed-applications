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
    public class EventManagementService
    {
        private CulinaryWorldDbContext dbContext = new CulinaryWorldDbContext();

        public List<EventDTO> Get()
        {
            List<EventDTO> eventDTO = new List<EventDTO>();

            foreach (var item in dbContext.Events.ToList())
            {
                eventDTO.Add(new EventDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Place = item.Place,
                    Date = item.Date,
                    Description = item.Description,
                    Participant = item.Participant,
                    Duration = item.Duration,
                    UserId = item.UserId,
                    User = new CulinaryWorldUser
                    {
                        Id = item.UserId
                    }

                });
            }

            return eventDTO;
        }

        public EventDTO GetById(int id)
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
        }

        public bool Save(EventDTO eventDTO)
        {


            Event events = new Event
            {
                Title = eventDTO.Title,
                Place = eventDTO.Place,
                Date = eventDTO.Date,
                Description = eventDTO.Description,
                Participant = eventDTO.Participant,
                Duration = eventDTO.Duration,
                UserId = eventDTO.UserId
            };

            try
            {
                dbContext.Events.Add(events);
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
                Event events = dbContext.Events.Find(id);
                dbContext.Events.Remove(events);
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
