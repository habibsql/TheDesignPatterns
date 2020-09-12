Overview:
- Ensure a class has only one instance.
- Make the class itself responsible for keeping track of its sole instance.
- There can be only one.

Disadvantages:
- Global state.
- Difficult to test.
- Violate single responsibility principle.
- Some experts called it is an anti pattern.

Solution:
- Instead of manualy create it is possible to create with the help of IOC container to avoid
  maintaining lifetime and also coupoing and testibility issue.