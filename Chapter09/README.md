## The Liskov substitution principle (LSP)
This is the L in SO**L**ID

_You should be able to replace a type with a subtype instance wherever it is used without causing any sideeffects._

**Subtypes** FileStream and MemoryStream of **base type** Stream should work the same no matter which is used in the **context** of StreamReader(Stream).

* **Base type** is the type clients should use and have knowledge about.
* **Subtype** should not be known to clients.
* **Context** is how the client interacts with the subtypes.

### LSP Rules
#### Contract rules
Relates to the contract of the base type and restrictions on what can be added to subtypes:
* Preconditions cannot be strengthened
* Postconditions cannot be weakened
* Preserve base type conditions in subtypes (Invariant, unchanged, constant)

Interface tell you the correct argument type to pass in to a function and what to expect back as a return value. A contract go further and add other requirements, like value ranges. Naming the function arguments may give some hints, like Weight and Age should be gt 0. But this doesn't stopp the user form passing in negative values. We need preconditions checking input values, and postconditions checking return values. This is part of the contract. Invariants relate to the state of the object instance, like a Car instance should not suddenly have a negative weight. Protect data invariants in property setters/ctor.

#### Variance rules
Relates to generics/delegate subtypes
* Contravariance of method arguments
* Covariance for return types
* No new exception types thrown

Co=with, contra=against. Subtypes go with or against each other.