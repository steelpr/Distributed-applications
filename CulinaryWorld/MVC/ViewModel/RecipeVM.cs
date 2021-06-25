using ApplicationService.DTOs;
using Data.Entities;
using MVC.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModel
{
    public class RecipeVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Products { get; set; }

        [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$")]
        public string ImageUrl { get; set; }


        [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$")]
        public string VideoUrl { get; set; }

        public decimal Price { get; set; }

        public double Time { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public CulinaryWorldUser User { get; set; }


        public RecipeVM()
        {
                
        }
        public RecipeVM(ServiceReference1.RecipeDTO recipeDTO)
        {
            Id = recipeDTO.Id;
            Title = recipeDTO.Title;
            ImageUrl = recipeDTO.ImageUrl;
            Products = recipeDTO.Products;
            VideoUrl = recipeDTO.VideoUrl;
            Price = recipeDTO.Price;
            Time = recipeDTO.Time;
            Description = recipeDTO.Description;
            UserId = recipeDTO.UserId;
            User = new CulinaryWorldUser
            {
                Id = recipeDTO.UserId,
            };
        }
    }
}