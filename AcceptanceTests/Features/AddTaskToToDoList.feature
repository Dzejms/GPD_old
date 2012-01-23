Feature: Add an item to today's Task list
	In order to work a pomodoro
	As a site user
	I want to add a task to today's todo list

Scenario: Go to the New Task page
	Given I am viewing the ToDo list
	When I click the Add Task Link
	Then I am taken to the New Task page

Scenario: Submit a new Task with Valid Data
	Given I am viewing the New Task form
	And I have entered valid data in the form fields:
	| Field | Value        |
	| Task.Description  | Task Description |
	When I press create
	Then I should be redirected to the ToDo List
	And The newly created Task is displayed in the list:
	| Field | Value        |
	| Task.Description  | Task Description |