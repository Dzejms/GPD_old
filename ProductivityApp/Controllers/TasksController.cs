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
        private readonly ITasksRepository repository;

        public TasksController()
        {
            this.repository = new FakeTasksRepository();
        }

        public TasksController(ITasksRepository tasksRepository)
        {
            this.repository = tasksRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Tasks";
            return View(repository.Tasks.ToList());
        }

        public ViewResult New()
        {
            ViewBag.Title = "New Task";
            return View(new EditTaskViewModel() {Task = new Task(), PageTitle = ViewBag.Title});
        }

        [HttpPost]
        public RedirectToRouteResult New(Task task)
        {
            repository.Save(task);
            return RedirectToRoute(new { controller = "tasks", action = "index" });
        }
    }
}
