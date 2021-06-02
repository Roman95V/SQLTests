@delete @product @database
Feature: DeleteProduct
In order to not display in the database
As a user
I want delete a product in the products table

@pozitive
Scenario Outline: It is possible to update  product in the products table
	Given Establish a database connection
	And Created row in table with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	When I delete  product in the products table
	| id   | name   | count   |
	| <id> | <name> | <count> |
	Then Succesfully deleted product in the products table
	| id   | name   | count   |
	| <id> | <name> | <count> |
Examples:
	| id | name      | count |
	| 5  | testName2 | 222   |