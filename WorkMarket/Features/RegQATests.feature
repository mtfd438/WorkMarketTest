Feature: RegQATests
	Scenario: RegTst_01 A user is able to joing as an individual
	Given User is on registration page
	And User registers as an individual account "John" "Doe" "test" "xderftghy1"
	Then User is redirected to "Work Market | Thank you" page 

Scenario: RegTst_02 A user is not able to register more than once 
	Given User is on registration page
	And User registers as an individual account "Michael" "Mittiga" "mmittiga17@gmail.com" "xderftghy1"
	Then "The email address mmittiga17@gmail.com is already being used." should be displayed to the user

##Test could also be modified to check regsister button is disabled for all or any 1 field left blank
Scenario: RegTst_03 A user is not able to register account unless all inputs are filled in
	Given User is on registration page
	And User tried to submit an incomplete registraction form
	Then The Register button is dissabled

Scenario: RegTst_04 A new user password must meet the minumn requirements
	Given User is on registration page
    And User registers as an individual account "John" "Doe" "test" "xdey1"
	Then "Your password entered is not allowed because it is too simple" should be displayed to the user

Scenario: RegTst_05 User is able to review the Terms of Use Agreement
	Given User is on registration page
    And User clicks the Terms of Use Agreement
	Then User is redirected to new "WorkMarket Terms Of Use Agreement For&nbsp;Users | WorkMarket" tab

Scenario: RegTst_06 User is able to review the Terms of Use Agreement
	Given User is on registration page
    And User clicks the Privacy Statement
	Then User is redirected to new "Privacy Statement | WorkMarket" tab