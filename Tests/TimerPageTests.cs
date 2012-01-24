using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ProductivityApp.Controllers;
using System.Web.Mvc;
using ProductivityApp.Models;
using DomainModel.Entities;
using DomainModel.Abstract;

namespace UnitTests
{
    [TestFixture]
    public class TimerPageShould
    {
        [Test]
        public void DisplayAListOfTasks()
        {
            // Arrange
            List<Task> tasks = new List<Task>() {new Task() {Description = "First Task"}, new Task() {Description = "Second Task"}};
            Mock<ITasksRepository> repository = new Mock<ITasksRepository>();
            repository.Setup(x => x.Tasks).Returns(tasks.AsQueryable());

            TimerController controller = new TimerController(repository.Object);


            // Act
            TimerPageViewModel viewModel = ((ViewResult) controller.Index()).Model as TimerPageViewModel;
            
            // Assert
            Assert.IsNotNull(viewModel, "View Model was null");
            Assert.AreEqual(2, viewModel.Tasks.Count);
        }

        [Test]
        public void HaveADefaultTimerOf25Minutes()
        {
            // Arrange
            List<Task> tasks = new List<Task>() {new Task() {Description = "First Task"}, new Task() {Description = "Second Task"}};
            Mock<ITasksRepository> repository = new Mock<ITasksRepository>();
            repository.Setup(x => x.Tasks).Returns(tasks.AsQueryable());

            TimerController controller = new TimerController(repository.Object);


            // Act
            TimerPageViewModel viewModel = ((ViewResult) controller.Index()).Model as TimerPageViewModel;
            
            // Assert
            Assert.IsNotNull(viewModel, "View Model was null");
            Assert.AreEqual("25:00", viewModel.TimerMinutes);
        }

        [Test]
        public void HaveASpecificTitle()
        {
            // Arrange
            List<Task> tasks = new List<Task>() { new Task() { Description = "First Task" }, new Task() { Description = "Second Task" } };
            Mock<ITasksRepository> repository = new Mock<ITasksRepository>();
            repository.Setup(x => x.Tasks).Returns(tasks.AsQueryable());

            TimerController controller = new TimerController(repository.Object);

            // Act
            TimerPageViewModel viewModel = ((ViewResult)controller.Index()).Model as TimerPageViewModel;

            // Assert
            Assert.IsNotNull(viewModel, "View Model was null");
            Assert.AreEqual("Work Now!", viewModel.PageTitle);
        }

    }
}
