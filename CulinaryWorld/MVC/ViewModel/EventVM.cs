using Data.Entities;
using MVC.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModel
{
    public class EventVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Place { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int Participant { get; set; }

        public double Duration { get; set; }

        public string UserId { get; set; }
        public CulinaryWorldUser User { get; set; }

        public EventVM()
        {

        }

        public EventVM(EventDTO eventDTO)
        {
            Id = eventDTO.Id;
            Title = eventDTO.Title;
            Place = eventDTO.Place;
            Date = eventDTO.Date;
            Description = eventDTO.Description;
            Participant = eventDTO.Participant;
            Duration = eventDTO.Duration;
            UserId = eventDTO.UserId;
            User = new CulinaryWorldUser
            {
                Id = eventDTO.UserId
            };
        }
    }
}