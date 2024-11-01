Feature: Product

# Users can add products to their cart, delete items they don't want, check out and enter their payment and shipping information,
# see the total number of items and price, and cancel their order before it's finalised.

Background: 
 Given the user is on the login page 
 When the user enters a valid username standard_user 
 And the user enters valid password secret_sauce
 And clicks the login button


Scenario: 04_Verify user can successfuly selects product item and add it to the cart
When user select a Sauce Labs Backpack item and click 'Add to Cart'
Then user should see the selected Sauce Labs Backpack item appears in the cart list

Scenario: 05_Verify user can remove product item from cart list
When user select a Sauce Labs Backpack item and click 'Add to Cart'
Then user should see the selected Sauce Labs Backpack item appears in the cart list
And user remove the Sauce Labs Backpack item 
And the removed Sauce Labs Backpack item should no longer appear in the cart list

Scenario: 06_Verify that a user can complete the checkout process after adding item to the cart
When user select a Sauce Labs Backpack item and click 'Add to Cart'
And the user proceed to checkout
And user fill in the required information <Firstname> <Lastname> <Postcode> and continue
And user complete the order and checkout process
Then verify redirection to the confirmation page and <OrderConfirmatorySummary> is displayed accurately
Examples: 
| Firstname | Lastname | Postcode | OrderConfirmatorySummary       |
| Kazeem    | Iyiola   | M244AU   | Your order has been dispatched |

Scenario: 07_Verify user can add multiple products to list and cart count increases
When user select a Sauce Labs Backpack item and click 'Add to Cart'
Then the cart count increases to '1' in the cart basket

Scenario: 08_Verify that a user can cancel inprogress order and return to product page
When user select a Sauce Labs Backpack item and click 'Add to Cart'
And the user proceed to checkout
And user fill in the required information <Firstname> <Lastname> <Postcode> and continue
And the user cancel the order
Then the user is redirected to the product page, and the Products is displayed
Examples: 
| Firstname | Lastname | Postcode | OrderConfirmatorySummary       |
| Kazeem    | Iyiola   | M244AU   | Your order has been dispatched |

Scenario: 09_Verify user can add, calculate and correctly display multiple items totalprice and tax
When user select a 'Sauce Lab Bike Light' item cost 9.99 each
And user select a 'Sauce Lab Bolt T-Shirt' item cost 15.99 each
And user click on cart
And the user proceed to checkout
And user fill in the required information <Firstname> <Lastname> <Postcode> and continue
Then the user is redirected to the Checkout Overview page and <ItemTotal> are correctly dislayed
Examples: 
| Firstname | Lastname | Postcode  | ItemTotal        | 
| Kazeem    | Iyiola   | M244AU    |Item total: $25.98| 