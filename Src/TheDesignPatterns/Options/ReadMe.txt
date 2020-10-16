-----------------------------------------------------------------------------------------------------------------

Overview:

- Invented my Microsoft

- Configuration related pattern.

- Provide strongly typed access to groups of related settins.

Befinifits:

- ISP (Interface Segrfation Principle) support or Encaptulation feature.. Classes that depend on configuration settings.

  depends only on the configurations settings that they really use.

- Separation of Concern: Settings for defferent parts are not couple to one another.

- Provide to validate configuration data.


Options class concerns:

- Must be non-abstract with a public parameterless constructor.

- Singleton by nature.

- BuildersBuilder can be used to build an option object at runtime.

- Options validation should be possible.

-----------------------------------------------------------------------------------------------------------------