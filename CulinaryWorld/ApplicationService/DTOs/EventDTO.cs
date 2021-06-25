﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Place { get; set; }

        public DateTime Date { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int Participant { get; set; }

        public double Duration { get; set; }

        public string UserId { get; set; }
        public CulinaryWorldUser User { get; set; }
    }
}
