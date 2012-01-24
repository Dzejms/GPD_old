using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using DomainModel.Abstract;
using DomainModel.Entities;
using ProductivityApp.Controllers;
using System.Web.Mvc;
using ProductivityApp.Models;

namespace UnitTests
{
    [TestFixture]
    public class SlashTaskSlashEditShould
    {
        private Mock<ITasksRepository> repository;

        [SetUp]
        private void SetUp()
        {
            List<Task> tasks = new List<Task> { new Task { ID = 1, Description = "Task1" }, new Task { ID = 2, Description = "Task2" } };
            repository = new Mock<ITasksRepository>();
            repository.Setup(x => x.Tasks).Returns(tasks.AsQueryable());
        }

        [Test]
        public void Display_Get_The_Correct_Task_From_The_Repository()
        {
            // Arrange
            TasksController controller = new TasksController(repository.Object);

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;
            EditTaskViewModel model = result.Model as EditTaskViewModel;

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Task.ID);
        }

        [Test]
        public void Redirect_To_The_List_When_Valid_Task_Is_Posted()
        {
            // Arrange
            TasksController controller = new TasksController(repository.Object);

            // Act
            ViewResult result = controller.Edit(new Task {ID = 1, Description = "Changed Description"}) as ViewResult;

            // Assert
            Assert.IsTrue((bool)result.Model);
        }

        [Ignore]
        [Test]
        public void Redirect_To_Error_Page_When_Id_Is_Null()
        {
            
        }
    }
}