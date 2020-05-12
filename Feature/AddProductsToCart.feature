Feature: AddProductsToCart
	As user of online shop
	I want to be able to add products to cart
	I want to see added products in cart
	I want to see total amount of products added to cart

@addtocart
Scenario: Add one product to cart
	Given I enter to home page
	When Home page is loaded
	And I click on random product
	And I open cart
	Then Selected product is present in cart
	And Correct total amount is displayed
