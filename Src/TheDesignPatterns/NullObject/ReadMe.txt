----------------------------------------------------------------------------------------------

Overview:

- Simplify used dependencies that are still undefined.

- It uses instead of null reference.

- Null object is used and it does not contain any functionality.

Benifit:

- Safe from Runtime Null Reference exception. It is very dangeous type of exception and
  very difficult to trace when raised.

- No need to check null

- Null object can be used when need real object do nothing.

- More readable code.

Concern:

- This pattern should be used carefully as it can make erros as normal program execution.

----------------------------------------------------------------------------------------------