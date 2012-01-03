using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel.Abstract;
using DomainModel.Concrete;
using DomainModel.Entities;
using ProductivityApp.Models;

namespace ProductivityApp.Controllers
{
    public class TimerController : Controller
    {
        private readonly ITasksRepository repository;

        public TimerController()
        {
            repository = new FakeTasksRepository();
        }

        public TimerController(ITasksRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            TimerPageViewModel viewModel = new TimerPageViewModel() 
                { 
                    PageTitle = "Work Now!", 
                    Tasks = repository.Tasks.ToList(), 
                    TimerMinutes = "25:00"
                };
            return View(viewModel);
        }
    }
}
