Feature: Basket Service

Scenario: Basic Purchase 1
  Given the basket has 1 bread, 1 butter and 1 milk 
  When I total the basket 
  Then the total should be £2.95
  
Scenario: Basic Purchase 2
  Given the basket has 2 butter and 2 bread
  When I total the basket
  Then the total should be £3.10

  Scenario: Basic Purchase 3
  Given the basket has 4 milk
  When I total the basket
  Then the total should be £3.45

Scenario: Basic Purchase 4
  Given the basket has 2 butter, 1 bread and 8 milk
  When I total the basket
  Then the total should be £9.00