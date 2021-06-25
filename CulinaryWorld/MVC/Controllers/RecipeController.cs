using Data.Entities;
using MVC.ServiceReference1;
using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            List<RecipeVM> recipes = new List<RecipeVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetRecipe())
                {
                    recipes.Add(new RecipeVM(item));
                }
            }
            return View(recipes);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            RecipeVM recipeVM = new RecipeVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var recipeDto = service.GetRecipeById(id);
                recipeVM = new RecipeVM(recipeDto);
            }

            return View(recipeVM);
        }

        // GET: Nationality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nationality/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeVM recipeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.RecipeDTO recipeDTO = new ServiceReference1.RecipeDTO
                        {
                            Id = recipeVM.Id,
                            Title = recipeVM.Title,
                            ImageUrl = recipeVM.ImageUrl,
                            Products = recipeVM.Products,
                            VideoUrl = recipeVM.VideoUrl,
                            Price = recipeVM.Price,
                            Time = recipeVM.Time,
                            Description = recipeVM.Description,
                            UserId = recipeVM.UserId,
                            User = new CulinaryWorldUser
                            {
                                Id = recipeVM.UserId
                            }
                        }
                        ;
                        service.PostRecipe(recipeDTO);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            RecipeVM recipeVM = new RecipeVM();

            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {

                var recipeDto = service.GetRecipeById(id);
                recipeVM = new RecipeVM(recipeDto);

             //   service.EditArticle(recipeDto);
            }

            return View();

        }

        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteRecipe(id);
            }
            return RedirectToAction("Index");
        }
    }
}