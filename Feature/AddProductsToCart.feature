Feature: AddProductsToCart
	As user of online shop
	I want to be able to add products to cart
	I want to see added products in cart
	I want to see total amount of products added to cart

@addtocart
Scenario: As user I'm able to add any single product to cart
	Given I enter to home page
	When Home page is loaded
	And I click on random product
	Then Cart is opened
	And Selected product is present in cart
	And Correct total amount is displayed

@addtocart
Scenario: As user I'm able to add more than one product to cart
	Given I enter to home page
	When Home page is loaded
	And I click on "2" random products
	Then Cart is opened
	And Selected product is present in cart
	And Correct total amount is displayed
