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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Task taskToEdit = repository.Tasks.FirstOrDefault(x => x.ID == id);
            ViewBag.Title = "Edit Task";
            EditTaskViewModel model = new EditTaskViewModel {PageTitle = ViewBag.Title, Task = taskToEdit};
            if (taskToEdit == null)
                return View("Error", model);
            return View(model);
        }

        [HttpPost]
        public ViewResult Edit(Task task)
        {
            bool result = false;
            Task taskToSave = repository.Tasks.FirstOrDefault(x => x.ID == task.ID);
            if (taskToSave != null)
                result = repository.Save(taskToSave);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
