Feature: OpenHomePage
	As user of online shop
	I want to enter home page of ReactShoppingCart and see correct page title

@mytag
Scenario: As user I enter to home page and I see correct page title
	Given I enter to "home" page
	When Home page is loaded
	Then Home page title "React Shopping Cart" is correct
