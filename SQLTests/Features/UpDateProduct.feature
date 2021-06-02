@update @product @database
Feature: UpDateProduct
In order to display new poduct in the products table
As a user
I want update a product 

@pozitive
Scenario: It is possible to update  product in the products table
	Given Establish a database connection
	And Created row in table with data
	| id | name      | count |
	| 6  | testName4 | 444   |
	When I update  product in the products table
	| id | name      | count |
	| 6  | testName4 | 444   |
	| 7  | Product   | 777   |
	Then Succesfully updated product in the products table
	| id | name    | count |
	| 7  | Product | 777   |
