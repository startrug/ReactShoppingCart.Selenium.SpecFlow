Feature: AddProductsToCart
	As user of online shop
	I want to be able to add products to cart
	I want to see added products in cart
	I want to see total amount of products added to cart

@addtocart
Scenario Outline: As user I'm able to add any number of products to cart
	Given I enter to home page
	When Home page is loaded
	And I click on <number> random products
	Then Cart is opened
	And Selected product is present in cart
	And Correct total amount is displayed

	Examples:
	| number |
	| 1      |
	| 2      |
	| 3      |
	| 4      |
