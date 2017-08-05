## Strategy Pattern
Note! This sample is not from the book.

Suppose that you are building a door frame. Each of the four sides of the frame can be joined
to its neighbour with a flush or an angled cut. 

![Angleflush](images/angleflush.png)

Left, top and right side can have angled joins.
Bottom still must have flushed joins.

To solve this we attach a corner cutting strategy to each of the four sides. Bottom stil gets a 
flush corner cutting strategy, the others, angeled corner strategy. Flush corner cutting strategy gets highest priority.

![Doorframe](images/doorframe.png)

Output from program:
```
Processing part Bottom
        Processing join with Left Post: Cutting flush
        Processing join with Right Post: Cutting flush
Processing part Left Post
        Processing join with Bottom: Cutting flush
        Processing join with Top: Cutting an angle
Processing part Top
        Processing join with Left Post: Cutting an angle
        Processing join with Right Post: Cutting an angle
Processing part Right Post
        Processing join with Top: Cutting an angle
        Processing join with Bottom: Cutting flush
```