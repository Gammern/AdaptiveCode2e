## Refactoring TradeProcessor
This is the road to refactoring the TradeProcessor so that it has only one reason to change. 
You need the book to follow all the details of the steps.

The initial version needed some mods for decimal separator and connection string.

1. Refactoring for clarity. Split up ProcessTrades() function into three new functions for the tasks; 
reading, processing and storing.
2. Refactoring for abstraction. Introduce interfaces for the three high level tasks, and some. 
This is a massive undertaking. Going from one unmaintainable file to 6 new interfaces, 
6 new classes and two new projects. (Should have been split to several smaller steps)

