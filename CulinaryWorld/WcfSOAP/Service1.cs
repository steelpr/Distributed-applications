using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        ArticleManagementService articleService = new ArticleManagementService();
        EventManagementService eventService = new EventManagementService();
        LikeManagementService likeService = new LikeManagementService();
        RecipeManagementService recipeService = new RecipeManagementService();
             
        public string DeleteArticle(int id)
        {
            if (!articleService.Delete(id))
            {
                return "Article is not deleted!";
            }
            else
            {
                return "Article is deleted!";
            }
        }

        public string DeleteEvent(int id)
        {
            if (!eventService.Delete(id))
            {
                return "Event is not deleted!";
            }
            else
            {
                return "Event is deleted!";
            }
        }

        public string DeleteRecipe(int id)
        {
            if (!recipeService.Delete(id))
            {
                return "Recipe is not deleted!";
            }
            else
            {
                return "Recipe is deleted!";
            }
        }

        public List<ArticleDTO> GetArticle()
        {
            return articleService.Get();
        }

        public ArticleDTO GetArticleById(int id)
        {
            return articleService.GetById(id);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<EventDTO> GetEvent()
        {
            return eventService.Get();
        }

        public EventDTO GetEventById(int id)
        {
            return eventService.GetById(id);

        }

        public List<LikeDTO> GetLike()
        {
            return likeService.Get();

        }

        public List<RecipeDTO> GetRecipe()
        {
            return recipeService.Get();

        }

        public RecipeDTO GetRecipeById(int id)
        {
            return recipeService.GetById(id);

        }

        public string PostArticle(ArticleDTO articleDTO)
        {
            if (!articleService.Save(articleDTO))
            {
                return "Article is not saved!";
            }
            else
            {
                return "Articl is saved!";
            }
        }

        public string PostRecipe(RecipeDTO recipeDTO)
        {
            if (!recipeService.Save(recipeDTO))
            {
                return "Recipe is not saved!";
            }
            else
            {
                return "Recipe is saved!";
            }
        }

        public string PostEvent(EventDTO eventDTO)
        {
            if (!eventService.Save(eventDTO))
            {
                return "Event is not saved!";
            }
            else
            {
                return "Event is saved!";
            }
        }

        public string PostLike(LikeDTO likeDTO)
        {
            if (!likeService.Save(likeDTO))
            {
                return "Like is not saved!";
            }
            else
            {
                return "Like is saved!";
            }
        }

        public string EditArticle(ArticleDTO articleDTO)
        {
            if (!articleService.Save(articleDTO))
                return "Movie is not updated";

            return "Movie is updated";
        }

        public string EditEvent(EventDTO eventDTO)
        {
            throw new NotImplementedException();
        }
    }
}
