### First-party dependency
The console application SimpleDependency(netcoreapp1.1) depends on the class library MessagePrinter(netstandard1.3). They both belong to the same solution. Source code is available. The dependency will be loded by the .net runtime the first time we use it, like a call to it in code.

### Framework dependencies
Automatically added depending on what framework and version selected.

### Third-party dependencies
Typically things added by nuget or "add reference to a dll".
