### Adapter Pattern

Adapt or wrap an exsisting class to a new interface expected by the client.

In this sample we have an expected interface and two types to adapt. For class Adaptee we have full source code, 
class Target we don't. I just stick sealed on that one for demonstration purposes.

This can be used in scenarios where you want to call a method on all instances in a collection. 
It is easy when they have been wrapped with an Adaptor. 

```C#
IExpectedInterface[] adaptedInstances =
{
    new AdapteeAdapter(),
    new TargetAdapter(new Target())
};

foreach (var adaptor in adaptedInstances)
{
    adaptor.MethodA();
}
```
Without the adapter pattern, you would have to abuse if-statement and do typechecking. 
Imagine the following for some 20 or more types.

```C#
foreach (object obj in objectInstances)
{
    if (obj is Adaptee)
        (obj as Adaptee).MethodB();
    else if (obj is Target)
        (obj as Target).MethodX();
    // and so on ....
}
```
It works, but ....
