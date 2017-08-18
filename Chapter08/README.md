## The open/closed principle
Software entities should be open for extensions, but closed for modification.

The TradeProcessor solution contains a mock version of an earlier sample. The initial version is not very extension friendly.

Simple option is to make TradeProcessor extensible by [making function ProcessTrades() virtual](https://github.com/Systemutvikler/AdaptiveCode2e/commit/86cc1faa9229fc7fc7f2065774a999ed0171670c?diff=split). We can now use inheritance in order to add new functionallity without modifing existing code. Obviously there is a problem reusing private functions in the base class. They will have to change to protected. But, unfortunately that is a modification (no-go closed). Result is that the new version of tradeprocessor has to re-implement everything. However, the client is unchanged.

A better option is to use [abstract TradeProcessorBase](https://github.com/Systemutvikler/AdaptiveCode2e/commit/a327db80acae18c596c913ae6421df8d2e22e07c?diff=split) and force inheriting classes to implement abstract methods. Having protected metods will make TradeProcessorVersion2 from the previous step a one function only implementation. We reuse most of the functionality from TradeProcessor. That is ok since TradeProcessor can't change according to open/closed principle (OCP). Client has changed to use the base.
 