-----------------------------------------------------------------------------------------------------------

- Overview

	- Short name is pub/sub

	- Asynchonously notify subscriber about any changes/events so that they (dependent object) can interact.

	- Similar to Observer pattern but has few difference and it is not GOF design pattern.

	- Publisher has no knowldge about its subscriber. It just brodecast the message.

	- Subscriber has no knowledge about message publisher.

	- Heavily use Event driven architecture.

	- 2 ways to implement i) Peer to Peer ii) With message broker

- Advantages:

	- Decouple objects 

	- Responsibilites are separated.

-----------------------------------------------------------------------------------------------------------