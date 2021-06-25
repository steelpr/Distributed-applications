using Data.Entities;
using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            List<EventVM> recipes = new List<EventVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetEvent())
                {
                    recipes.Add(new EventVM(item));
                }
            }
            return View(recipes);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            EventVM eventVM = new EventVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var eventDto = service.GetEventById(id);
                eventVM = new EventVM(eventDto);
            }

            return View(eventVM);
        }

        // GET: Nationality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nationality/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventVM eventVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.EventDTO eventDTO = new ServiceReference1.EventDTO
                        {
                            Id = eventVM.Id,
                            Title = eventVM.Title,
                            Place = eventVM.Place,
                            Date = eventVM.Date,
                            Description = eventVM.Description,
                            Participant = eventVM.Participant,
                            Duration = eventVM.Duration,
                            UserId = eventVM.UserId,
                            User = new CulinaryWorldUser
                            {
                                Id = eventVM.UserId
                            }
                        };
                        service.PostEvent(eventDTO);
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
            EventVM articleVM = new EventVM();

            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {

                var articleDto = service.GetEventById(id);
                articleVM = new EventVM(articleDto);

                //service.EditArticle(articleDto);
            }

            return View();

        }

        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteEvent(id);
            }
            return RedirectToAction("Index");
        }
    }
}