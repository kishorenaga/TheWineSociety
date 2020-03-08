Feature: User can buy wines from wine society

@e2e
Scenario Outline: User can buy Red wines from the wine society products page
	Given I am on the products page
	And I select Red wines
	When I filter red wines based on <Country> and <Region>
	Then the i see applied filter selections are displayed
Examples: 
| Country | Region |
| FRANCE  | RHONE  |