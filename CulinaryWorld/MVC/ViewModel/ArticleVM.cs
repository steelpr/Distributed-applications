using Data.Entities;
using MVC.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModel
{
    public class ArticleVM
    {
        public int Id { get; set; }

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

        public ArticleVM()
        {

        }

        public ArticleVM(ArticleDTO articleDTO)
        {
            Id = articleDTO.Id;
            Title = articleDTO.Title;
            ImageUrl = articleDTO.ImageUrl;
            VideoUrl = articleDTO.VideoUrl;
            TimeToRead = articleDTO.TimeToRead;
            Description = articleDTO.Description;
            UserId = articleDTO.UserId;
            User = new CulinaryWorldUser
            {
                Id = articleDTO.UserId,
            };
        }
    }
}