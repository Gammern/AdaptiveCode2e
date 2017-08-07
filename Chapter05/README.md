## Testing
Banking solution contains AccountLibrary (netstandard1.1) and AccountLibrary.Tests (netcoreapp1.1) using MS Test and Moq.

Don't overspecify mock tests. Avoid testing internal functionality, will make later refactoring painful. 
Only test expected behaviour. 

Fluent Builder Pattern is a great way to document test with code that is expressive. 
"Mock this, and mock that" is not easy to read and understand. 
Remember, you are writing code that will be read by a psychopathic killer that knows your home address.

