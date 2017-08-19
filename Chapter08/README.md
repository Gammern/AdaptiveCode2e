## The open/closed principle (OCP)
OCP is the O in SOLID.

> Software entities should be open for extensions, but closed for modification. 
> 
> <cite>Bertrand Meyer</cite> (1988 [Object Oriented Software Contruction](https://www.amazon.co.uk/Object-oriented-Software-Construction-Prentice-International/dp/0136290493))

The TradeProcessor solution contains a dummy version of an earlier sample. I start off with a version that is extension unfriendly. 

A simple option to make TradeProcessor more extensible is by [making function ProcessTrades() virtual](https://github.com/Systemutvikler/AdaptiveCode2e/commit/86cc1faa9229fc7fc7f2065774a999ed0171670c?diff=split). We can now use inheritance to add new functionality without modifying existing code. Obviously there is a problem reusing private functions in the base class. They will have to change to protected. But, unfortunately that is modification of existing code (no-go closed). Result is that the new version TradeProcessorVersion2 has to re-implement everything. However, the client is unchanged. You do not want to do this.

A better extension option is to use _implementation inheritance_ and introduce [abstract TradeProcessorBase](https://github.com/Systemutvikler/AdaptiveCode2e/commit/a327db80acae18c596c913ae6421df8d2e22e07c?diff=split) and force inheriting classes to implement abstract methods. Having protected methods will make TradeProcessorVersion2 from the previous step a simple one function only implementation. We reuse most of the functionality from TradeProcessor. That is ok since TradeProcessor can't change according to open/closed principle (OCP). The client has to change in order to make use of the new abstract base (TradeProcessorBase) which will now be its only dependency. This is looking nice and maintainable. Number of files/entities is kept low. I used this kind of (Template Method) pattern some 20 years ago with Delphi and a reporting solution. 

Next extension option is to use _interface inheritance_. The client will rely on a simple [factory and interface ITradeProcessor](https://github.com/Systemutvikler/AdaptiveCode2e/commit/bdc5e385434dd8ea2bccae4778d7faca4b01cf31) instead of abstract TradeProcessorBase. We also introduce e new ITradeProcessor type, TradeProcessorAudit. You are pretty much **free** on how to design the backing class hierarchy (inheritance/standalone) as long as you satisfy the interface. The factory can be easily be mocked as long as the Create() method is virtual.