using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductivityApp.Models;
using DomainModel.Entities;
using DomainModel.Abstract;
using DomainModel.Concrete;

namespace ProductivityApp.Controllers
{
    public class TasksController : Controller
    {
        private ITasksRepository repository;

        public TasksController()
        {
            this.repository = new FakeTasksRepository();
        }

        public TasksController(ITasksRepository tasksRepository)
        {
            this.repository = tasksRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Tasks";
            return View(repository.Tasks.ToList());
        }

        public ViewResult New()
        {
            ViewBag.Title = "New Task";
            return View(new EditTaskViewModel(new Task()));
        }

        [HttpPost]
        public RedirectToRouteResult New(Task task)
        {
            repository.Save(task);
            return RedirectToRoute(new { controller = "tasks", action = "index" });
        }
    }
}
