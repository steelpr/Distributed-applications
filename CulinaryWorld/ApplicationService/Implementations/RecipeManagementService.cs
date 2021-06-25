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
    public class RecipeManagementService
    {
        private CulinaryWorldDbContext dbContext = new CulinaryWorldDbContext();

        public List<RecipeDTO> Get()
        {
            List<RecipeDTO> recipeDTO = new List<RecipeDTO>();

            foreach (var item in dbContext.Recipes.ToList())
            {
                recipeDTO.Add(new RecipeDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Products = item.Products,
                    ImageUrl = item.ImageUrl,
                    VideoUrl = item.VideoUrl,
                    Price = item.Price,
                    Time = item.Time,
                    Description = item.Description,
                    UserId = item.UserId,
                    User = new CulinaryWorldUser
                    {
                        Id = item.UserId
                    }
                });
            }

            return recipeDTO;
        }

        public RecipeDTO GetById(int id)
        {
            RecipeDTO recipeDTO = new RecipeDTO();

            Recipe recipe = dbContext.Recipes.Find(id);
            if (recipe != null)
            {
                recipeDTO.Id = recipe.Id;
                recipeDTO.Title = recipe.Title;
                recipeDTO.Products = recipe.Products;
                recipeDTO.ImageUrl = recipe.ImageUrl;
                recipeDTO.VideoUrl = recipe.VideoUrl;
                recipeDTO.Price = recipe.Price;
                recipeDTO.Time = recipe.Time;
                recipeDTO.Description = recipe.Description;
                recipeDTO.UserId = recipe.UserId;
                recipeDTO.User = new CulinaryWorldUser
                {
                    Id = recipe.UserId
                };
            }
            return recipeDTO;
        }

        public bool Save(RecipeDTO recipeDTO)
        {
            Recipe recipe = new Recipe
            {
                Title = recipeDTO.Title,
                Products = recipeDTO.Products,
                ImageUrl = recipeDTO.ImageUrl,
                VideoUrl = recipeDTO.VideoUrl,
                Price = recipeDTO.Price,
                Time = recipeDTO.Time,
                Description = recipeDTO.Description,
                UserId = recipeDTO.UserId,
            };

            try
            {
                dbContext.Recipes.Add(recipe);
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
                Recipe recipe = dbContext.Recipes.Find(id);
                dbContext.Recipes.Remove(recipe);
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
