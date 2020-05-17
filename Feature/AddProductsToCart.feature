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

Scenario Outline: As user I'm able to add product to cart and increase their quantity
	Given I enter to home page
	When Home page is loaded
		And I click on <number> random products
	Then Cart is opened
		And Selected product is present in cart
		And I increase quantity of products to <quantity>
		And Correct quantity of products is displayed
		And Correct total amount is displayed

	Examples:
	| number | quantity |
	| 1      | 2        |
	| 1      | 3        |
	| 1      | 4        |
	| 1      | 5        |