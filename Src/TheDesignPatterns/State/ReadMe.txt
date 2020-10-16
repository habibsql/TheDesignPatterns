-------------------------------------------------------------------------------

- Overview:
	
	- It is a behavioural pattern.

	- Object behavior is changed based on object state change.
	
	- 2 Components 1) Context 2) State.  Context hold State reference.

	- 2 challenges: 
		i) How can an object change its behavior when its internal state changes
		ii) How can state-specific behaviors be defined in a way that states can 
		    be added without altering the behaviors of existing states?

	- The pattern does not specify where the state transition will be defined.
	  2 places are there i) Context object and ii) Each State object

- Advantages:

	- Easily changable & flexible.

	- Easily Extendable.

	- Allow pollymorphic behaviour.
	

-------------------------------------------------------------------------------
