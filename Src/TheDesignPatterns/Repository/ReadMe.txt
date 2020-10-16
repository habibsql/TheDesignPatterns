----------------------------------------------------------------------

Overview:

- A data access pattern

- Introduced as a part of DDD (Domain Driven Design)

- Separate persistence responsibility from UI/Business classes.

Advantages:

- Enable single responsibility principle.

- Promote separation of concern.

- Reducing coupling to persistence details.

- Improve testibility.

Implementation Approaches:

- Organized by CQRS (Read/Write)
	- IReadRepository<T>
	- IWriteRepository<T>

- Per Bounded Context

- Per Aggregate 
    - Prevent ability to persist any entity outside of its aggregate

- Per Entity
	- Customer Repository, Order Repository, Product Repository

- Always should return Domain Entity

- Generic Repository IRepository<TEntity>

----------------------------------------------------------------------

