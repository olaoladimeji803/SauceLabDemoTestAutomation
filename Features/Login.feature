Feature: Login

A short summary of the feature

@tag1
Scenario: 01_Verify that a user can successful login with Valid Credentials
    Given the user is on the login page
    When the user enters a valid username standard_user
    And the user enters valid password secret_sauce
    And clicks the login button
    Then the user is redirected to the product page, and the Products is displayed

    Scenario: 01_Verify that different users can successful login with Valid Credentials
    Given the user is on the login page
    When the user enters valid <Username> and <Password>
    And clicks the login button
    Then the user is redirected to the product page, and the <ExpectedProductHeader> is displayed
    Examples: 
	| Username                | Password     | ExpectedProductHeader |
	| standard_user           | secret_sauce | Products              |
	| problem_user            | secret_sauce | Products              |
	| performance_glitch_user | secret_sauce | Products              |

    Scenario: 02_Verify that different users can unsuccessful login with invalid Credentials
    Given the user is on the login page
    When the user enters invalid <Username> and <Password>
    And clicks the login button
    Then the user is unsuccessful login and the <ErrorMessage> is displayed    
    Examples: 
	| Username        | Password     | ErrorMessage                                                              |
	| locked_out_user | secret_sauce | Epic sadface: Sorry, this user has been locked out.                       |
	|                 | secret_sauce | Epic sadface: Username is required                                        |
	| standard_user   |              | Epic sadface: Password is required                                        |
	| standoood_user  | screeeetars  | Epic sadface: Username and password do not match any user in this service |
           



    

