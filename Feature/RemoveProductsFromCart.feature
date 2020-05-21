Feature: Removing products from cart
	As user of online shop
	I want to be able to remove selected product from cart
	I want to be able to remove all products from cart
	I want to see expected message if the cart is empty

	Background: As user I open store home page and add one product to cart
		Given I enter to home page
		When Home page is loaded
			And I click on 1 random products
		Then Cart is opened
			And Selected product is present in cart

	Scenario: As user I'm able to remove the only product from cart and I can see expected message
		Given I select product to remove
		When I click on delete button
		Then Product is removed from cart
			And Expected message is present in cart
			And Correct total amount is displayed
