using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;
using AcceptanceTests.StepHelpers;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class WorkPomodoroTests
    {
        [Given(@"I have tasks already entered")]
        public void GivenIHaveTasksAlreadyEntered()
        {
            var taskSetup = new AddTaskSteps();
            taskSetup.CreateTask();
        }

        [When(@"I press Start Timer")]
        public void WhenIPressStartTimer()
        {
            Button startButton = WebBrowser.Current.Button("startTimer");
            if (!startButton.Exists)
                Assert.Fail("Missing {0} button", startButton);
            startButton.Click();
        }

        [Then(@"the 25 minute timer should be on the screen")]
        public void ThenThe25MinuteTimerShouldBeOnTheScreen()
        {
            Assert.AreEqual("http://localhost:3592/timer", WebBrowser.Current.Url);
            Assert.IsTrue(WebBrowser.Current.ContainsText("Work Now!"), "\"New Task\" wasn't on the page.");
        }

    }
}
