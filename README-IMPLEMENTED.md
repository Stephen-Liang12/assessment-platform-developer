## Assignment
1. Refactoring of the model code to follow the SOLID design principle

	1. Create IAddressInformation interface to abstract address information. This would allow extension on Address in the future
	2. Create USAddress and CanadianAddress classes that implement IAddressInformation interface. We have two different implementations of IAddressInformation and we could build different business logic on each of them.
	3. Create ContactInformation class. I am not so sure about the Contact information part on model. I think it can be abstracted for reuse.
	4. Build AddressFactory class to take care of the creation of derived classes of IAddressInformation interface.
	5. Create IAddressValidator interface to segregate the address validation business logic
	6. Build AddressValidator class to validate address
	7. Build AddressValidatorTests to verify the business logic

2. Refactoring of the Service and Repository objects to use the Command Query Responsibility Segregation pattern 

	1. Create ICustomerCommandService and ICustomerQueryService interfaces to separate command and query responsibility
	2. Create ICustomerCommandRepository and ICustomerQueryRepository interfaces to separate command and query responsibility
	3. Create CustomerCommandService and CustomerQueryService classes to implement ICustomerCommandService and ICustomerQueryService interfaces
	4. Update CustomerRepository class to implement ICustomerCommandRepository and ICustomerQueryRepository interfaces
	5. Update Customers page to use command interface for creating, updating and deleting customer, use query interface for querying customers
	6. Update Global.asax.cs to register CustomerCommandService, CustomerQueryService

3. Add intelligent validation to the fields on the form. IE If a US State is provided, the Postal Code/ZIP field should validate that the 
value matches the expected ZIP code formats of ##### or #####-#### and vice versa

	1. Add CustomerZipValidator to validate the the Postal Code/ZIP field

4. Allow updating and deletion of customer data listed in the customers drop down list

	1. Update CustomerRepository class to generate Customer Id when adding a new customer
	2. Update Customers page so user can view existing customers, and update or delete them