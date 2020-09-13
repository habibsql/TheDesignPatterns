Overview:
- Structural design pattern
- Another name is wrapper.
- Match between incompatable interfaces similar to electrical plug/adapters
- Client make a request to the adapter & adapter translates that request on the adaptee using the adaptee interface.
- Actually convert one interface of a class to another clients expect.

Benifits:
- Without it 2 different classes can not work together(because of incompatible interface).
- Provide features that clients actual need. May be same feature or less.
- Instead of providing entire new interface it provides 2 exising imcompatable class can work together.
