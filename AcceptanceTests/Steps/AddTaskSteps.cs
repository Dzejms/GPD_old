using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AcceptanceTests.StepHelpers;
using NUnit.Framework;
using WatiN.Core;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class AddTaskSteps
    {
        [SetUp] 
        public void EachSetup()
        {
            Settings.AttachToBrowserTimeOut = 300;
            Settings.AutoCloseDialogs = true;
            Settings.WaitForCompleteTimeOut = 300;
            Settings.WaitUntilExistsTimeOut = 300;
        }

        [Given(@"I am viewing the ToDo list")]
        public void GivenIAmViewingTheToDoList()
        {
            WebBrowser.Current.GoTo("http://localhost:3592/tasks/");
            Assert.IsTrue(WebBrowser.Current.ContainsText("Tasks"));
        }

        [When(@"I click the Add Task Link")]
        public void WhenIClickTheAddTaskLink()
        {
            Link link = WebBrowser.Current.Link(Find.ById("addTaskLink"));
            if (!link.Exists)
                Assert.Fail("Add link was not found");
            link.Click();
        }

        [Then(@"I am taken to the New Task page")]
        public void ThenIAmTakenToTheNewTaskPage()
        {
            Assert.AreEqual("http://localhost:3592/tasks/new", WebBrowser.Current.Url);
            Assert.IsTrue(WebBrowser.Current.ContainsText("New Task"), "\"New Task\" wasn't on the page.");
        }


        [Given(@"I am viewing the New Task form")]
        public void GivenIAmViewingTheNewTaskForm()
        {
            WebBrowser.Current.GoTo("http://localhost:3592/tasks/new");
            Form form = WebBrowser.Current.Form("newTaskForm");
            if (!form.Exists)
                Assert.Fail("Add Task form was not found");
        }

        [Given(@"I have entered valid data in the form fields:")]
        public void GivenIHaveEnteredValidDataInTheFormFields(TechTalk.SpecFlow.Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var field = WebBrowser.Current.TextField(Find.ByName(tableRow["Field"]));
                if (!field.Exists)
                    Assert.Fail(String.Format("Could not find {0} field on page", field));

                field.TypeText(tableRow["Value"]);
            }
        }

        [When(@"I press create")]
        public void WhenIPressCreate()
        {
            Button createButton = WebBrowser.Current.Button("createTask");
            if (!createButton.Exists)
                Assert.Fail("Missing {0} button", createButton);
            createButton.Click();
        }

        [Then(@"I should be redirected to the ToDo List")]
        public void ThenIShouldBeRedirectedToTheToDoList()
        {
            Assert.AreEqual("http://localhost:3592/", WebBrowser.Current.Url);
        }

        [Then(@"The newly created Task is displayed in the list:")]
        public void ThenTheNewlyCreatedTaskIsDisplayedInTheList(TechTalk.SpecFlow.Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                Assert.IsTrue(WebBrowser.Current.ContainsText(tableRow["Value"]));
            }
        }

        

    }
}
