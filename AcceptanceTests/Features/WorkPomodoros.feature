Feature: Working Pomodoros
	In order get stuff done
	As user with existing tasks
	I want to click on Begin Pomodoro and see the timer and list of tasks

Scenario: Show Timer and List of Pomodoros
	Given I have tasks already entered
	When I press Start Timer
	Then the 25 minute timer should be on the screen
	And the list of tasks should be on the screen
