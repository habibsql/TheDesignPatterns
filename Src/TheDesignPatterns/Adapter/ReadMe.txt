-----------------------------------------------------------------------------------------------------------------

Overview:

- Structural design pattern

- Another name is wrapper.

- Matches between incompatable interfaces. Very similar to electrical plug/adapters

- Client make a request to the adapter and adapter translates that request on the adaptee using the adaptee interface.

- Actually convert one interface of a class into another interface that clients expect.

- Adapter can be classified in 2 ways i) Class adapter: Implement based on inheritence. 
  and ii) Object adapter: Implement based on composition.

Benifits:

- Without adapter, 2 different classes can not work together(because of incompatible interface).

- Provide features that clients actual need. May be same feature or less.

- Instead of providing entire new interface it provides 2 exising imcompatable class can work together.

-----------------------------------------------------------------------------------------------------------------