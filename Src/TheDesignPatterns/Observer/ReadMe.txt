-------------------------------------------------------------------------------------------------------------

- Overview:

	- Main intent is a machanism to notify one objects change to other objects  who are depends on it (One to Many).

	- After nofited dependent objects work accordingly.

	- Implementation would be dependent objects subscripe main objects events.

	- Synchonous by nature.

	- 2 main components i) Subject (Publisher who maintain observers collection and notify them) 
					    ii) Observer (subscribers who are listening)

	- Publisher-Subscripber pattern and Observer pattern has little difference.
      Pub/Sub is asynchonous and use Message Broker for communicating.
	
- Benenits:

	- Notifier objects and notifie object will be decoupled.

	- Easily manage one to many dependencies.

	- Responsibility can be separated between many objects.

- Disadvantages:
	
	- Subject & observer know each other (One kind of coupling is there).

-------------------------------------------------------------------------------------------------------------