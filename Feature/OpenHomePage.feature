Feature: Opening home page
	As user of online shop
	I want to enter home page of ReactShoppingCart and see product photos
	I want to see correct page title

@openpage
Scenario: As user I enter to home page and I see correct page title
	Given I enter to home page
	When Home page is loaded
	Then Home page title "React Shopping Cart" is correct
