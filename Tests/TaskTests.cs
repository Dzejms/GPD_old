﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Web.Mvc;
using ProductivityApp.Controllers;
using ProductivityApp.Models;
using DomainModel.Entities;
using DomainModel.Concrete;

namespace UnitTests
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void Slash_Shows_Todo_List()
        {
            // Arrange
            TasksController controller = new TasksController();
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Tasks", result.ViewBag.Title);
        }

        [Test] 
        public void Slash_Tasks_Slash_New_Displays_New_Task_Form()
        {
            // Arrange
            TasksController controller = new TasksController();

            // Act
            ViewResult result = controller.New();
            
            // Assert
            Assert.AreEqual("New Task", result.ViewBag.Title);
        }

        [Test]
        public void Slash_Tasks_Slash_New_Has_Empty_View_Model()
        {
            // Arrange
            TasksController controller = new TasksController();

            // Act
            EditTaskViewModel viewModel = (EditTaskViewModel)controller.New().Model;

            // Assert
            Assert.IsNull(viewModel.Task.Description);
        }

        [Test]
        public void POST_To_Slash_Tasks_Slash_New_Redirects_To_Slash_Tasks()
        {
            // Arrange
            TasksController controller = new TasksController();
            Task newTask = new Task() { Description = "Description" };
            
            // Act
            RedirectToRouteResult result = controller.New(newTask) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("tasks", result.RouteValues["controller"]);
            Assert.AreEqual("index", result.RouteValues["action"]);
        }

        [Test]
        public void Slash_Tasks_Displays_Task()
        {
            // Arrange
            FakeTasksRepository repository = new FakeTasksRepository();
            repository.Save(new Task() { Description = "Description1" });
            TasksController controller = new TasksController(repository);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            Task task = ((List<Task>)result.Model).Single(x => x.Description == "Description1") as Task;

            // Assert
            Assert.AreEqual("Description1", task.Description);
        }
    }
}
