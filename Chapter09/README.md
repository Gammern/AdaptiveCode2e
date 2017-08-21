## The Liskov substitution principle (LSP)
This is the L in SO**L**ID

You should be able to replace a type with a sub type instance wherever it is used without causing any sideeffects.

FileStream and MemoryStream are subclasses of Stream. StreamReader should work the same no matter which of the two subclass instances are used as a ctor parameter.
