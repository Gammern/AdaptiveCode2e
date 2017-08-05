## Null Object Pattern
Main purpose is to avoid checking for null values in code like:
```C#
var user = userRepository.GetByID(userGuid);
if(user != null)
{
    user.IncrementSessionTicket();
}
```
The null object pattern will always return an object instance. Either the user found or a dummy-null-user if not found. 
With this pattern you can rewrite the above code:
```C#
var user = userRepository.GetByID(userGuid);
user.IncrementSessionTicket();
```
#### Changes to authors code
Did some small modifications making use of latest C# features. And, I did not like the 
authors use of "new NullUser()" each time the repository failed to find a user. 
Replaced it with a static NullUser get property in class User.
```C#
class User : IUser
{
    public static IUser NullUser { get; } = new NullUser();
```
