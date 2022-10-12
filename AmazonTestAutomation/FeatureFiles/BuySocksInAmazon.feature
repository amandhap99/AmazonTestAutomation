@SmokeTest
Feature: BuySocksInAmazon
Background: 
	Given user launch the amazon web page
	And user click on 'Sign in' button
	Then user should see sign in user id page details
	When user enter email id into user id field
	| EMail                    |
	| rajeshvarma919@yahoo.com | 
	And user click on 'Continue' button
	Then user should see sign in password page details
	When user enter password into the field
	| Password  |
	| =oKLX84_hecimEj=maX1 |  
	And user click on sign in button
	Then user should see amazon home page details

Scenario Outline: BuySocksInAmazonAsaRegisteredUser
	Given user enter product details in search field '<ItemName>'
	And user click on search button
	Then user should see search results related to item name
	When user click on the category link
	And user click on the selected item
	And user selects the size of the socks
	And user click on add to cart button
	And user click on proceed to checkout button
	Then user should see checkout page details
	When user click on use this payment method button
	Then Then user should see place your order button
	Examples:
	| ItemName    |
	| Hanes Socks | 