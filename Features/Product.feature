Feature: Product


Background: 
 Given the user is on the login page 
 When the user enters a valid username standard_user 
 And the user enters valid password secret_sauce
 And clicks the login button

@tag1
Scenario: 04_Verify user can successfuly selects product item and add it to the cart
When user select a Sauce Labs Backpack item and click 'Add to Cart'
Then user should see the selected Sauce Labs Backpack item appears in the cart list

Scenario: 05_Verify user can remove product item from cart list
When user select a Sauce Labs Backpack item and click 'Add to Cart'
Then user should see the selected Sauce Labs Backpack item appears in the cart list
And user remove the Sauce Labs Backpack item 
And the removed Sauce Labs Backpack item should no longer appear in the cart list

Scenario: 06_Verify user can complete the checkout process after adding products to the cart
When user select a Sauce Labs Backpack item and click 'Add to Cart'
And the user proceed to checkout
And user fill in the required information <Firstname> <Lastname> <Postcode> and complete the purchase
Then verify redirection to the confirmation page and <OrderConfirmatorySummary> is displayed accurately
Examples: 
| Firstname | Lastname | Postcode | OrderConfirmatorySummary       |
| Kazeem    | Iyiola   | M244AU   | Your order has been dispatched |


Scenario: 07_Verify user can add multiple products to list and cart count increases
When user select a Sauce Labs Backpack item and click 'Add to Cart'
Then the cart count increases in the cart basket


Scenario: 08_Verify user can add multiple items products to the cart and increases cart count
When user select a Sauce Bike Light item and click 'Add to Cart'
And user select a Sauce Bolt T-Shirt item and click 'Add to Cart'
And user select a Sauce Fleece Jacket item and click 'Add to Cart'
Then the cart count increases in the cart basket
#Then the cart count increases to 3 in the cart basket