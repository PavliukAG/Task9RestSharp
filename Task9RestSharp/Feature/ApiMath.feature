Feature: ApiMath with RestSharp


Scenario Outline: Add two numbers
	Given the first number is <first number>
	And the second number is <second number>
	When the two numbers are added
	Then the result should be <result>

	Examples: 
	| first number | second number | result |
	| 1            | 1             | 2      |
	| 2            | 0             | 2      |
	| 4            | -1            | 3      |

Scenario Outline: Subtract two numbers
	Given the first number is <first number>
	And the second number is <second number>
	When the two numbers are subtracted
	Then the result should be <result>

	Examples: 
	| first number | second number | result |
	| 1            | 1             | 0      |
	| 2            | 0             | 2      |
	| 4            | -1            | 5      |

Scenario Outline: Multiplication of two numbers
	Given the first number is <first number>
	And the second number is <second number>
	When the two numbers are multiplied
	Then the result should be <result>

	Examples: 
	| first number | second number | result |
	| 1            | 1             | 1      |
	| 2            | 0             | 0      |
	| 4            | -1            | -4     |

Scenario Outline: Division of two numbers
	Given the first number is <first number>
	And the second number is <second number>
	When the two numbers are divided
	Then the result should be <result>

	Examples: 
	| first number | second number | result |
	| 1            | 1             | 1      |
	| 10           | 2             | 5      |
	| 4            | -1            | -4     |

Scenario Outline: Squaring a number
	Given the number is <number>
	When the number are squared
	Then the result should be <result>

	Examples: 
	| number | result |
	| 9      | 3      |
	| 16     | 4      |
	| 4      | 2      |
