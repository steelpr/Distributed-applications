using Data.Entities;
using Microsoft.Web.Services3.Messaging;
using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MVC.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {

            List<ArticleVM> articles = new List<ArticleVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetArticle())
                {
                    articles.Add(new ArticleVM(item));
                }
            }
            return View(articles);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            ArticleVM articleVM = new ArticleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var articleDto = service.GetArticleById(id);
                articleVM = new ArticleVM(articleDto);
            }

            return View(articleVM);
        }

        // GET: Nationality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nationality/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleVM articleVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.ArticleDTO articleDTO = new ServiceReference1.ArticleDTO
                        {
                            Id = articleVM.Id,
                            Title = articleVM.Title,
                            ImageUrl = articleVM.ImageUrl,
                            VideoUrl = articleVM.VideoUrl,
                            TimeToRead = articleVM.TimeToRead,
                            Description = articleVM.Description,
                            UserId = articleVM.UserId,
                            User = new CulinaryWorldUser
                            {
                                Id = User.Identity.GetUserId(),
                            }
                        };
                        service.PostArticle(articleDTO);
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
            ArticleVM articleVM = new ArticleVM();
            using (ServiceReference1.Service1Client service = new  ServiceReference1.Service1Client())
            {
                var articleDto = service.GetArticleById(id);
                articleVM = new ArticleVM(articleDto);
            }

            return View(articleVM);
        }

        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteArticle(id);
            }
            return RedirectToAction("Index");
        }

    }


}