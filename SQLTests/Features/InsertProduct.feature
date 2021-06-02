@insert @product @database
Feature: InsertProduct
In order to display in the database
As a user
I want insert a product in the products table

@pozitive
Scenario: It is possible to insert row in the database table
	Given Establish a database connection
	When I insert row in table with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	Then Succesfully row inserted with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
Examples:
	| id | name     | count |
	| 4  | testName | 123   |

@pozitive
Scenario: It is possible to insert rows in the database table
	Given Establish a database connection
	When I insert rows in table with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
	Then Succesfully rows inserted with data
	| id   | name   | count   |
	| <id> | <name> | <count> |
Examples:
	| id | name       | count |
	| 10 | testName10 | 100   |
	| 11 | testName11 | 200   |
	| 12 | testName12 | 300   |
	| 13 | testName13 | 400   |
	| 14 | testName14 | 500   |