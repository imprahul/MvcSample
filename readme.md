Instructions
==============

The idea of this example project is to gain insight into how you as a developer think about problem solving while accomplishing a few keys things:
 
 * Application of solid principles
 
 * A good understanding on separation of concerns without over engineering
 
 * Overall approach to Unit testing

 * Correct use of source control

The test and it's content is not a direct reflection of the work that will be undertaken at Bauer Media but is aimed as a technical screen to see how candidates solve problems.

There are no enforced frameworks or tools that *have* to be used. With the idea being that candidates are free to use whatever feels most comfortable.

When you have completed the task please zip up the entire solution, including the git folder to demonstrate check-in history, and return it to the contact you have been given.

The Brief
------------------------

"...
You have inherited a legacy restaurant guide application that requires some upgrades to bring it up to speed with modern techniques and practices while taking into account separation of concerns, unit testability and the ease of post deployment database tuning and optimisation. Any UI considerations are a value add, but will also be seen in a positive light..."

1. Taking the legacy code in HomeController, refactor the application, shifting it to a layered architecture using the Restaurant domain model object as a base, and the provided AppData database as a data store. Use any preferred data access/ORM framework. Scope for demonstrating the following:
  
    * Creation of a Data access layer taking into account web security best practices. Feel free to use any appropriate design patterns you feel comfortable implementing.
  
    * The potential definition of a unit testable business logic layer to sit between your controller and your data layer.
  
    * The use of dependency injection for better unit testing.
  
    * Creating a strongly-typed ViewModel

2.	Implement the Save method at /Restaurant/Edit. 
  
    * As with task 1, show a layered architecture. Refactor as you see fit.
  
    * At minimum, support edit of the currently shown fields (Title, Phone number). 
  
    * The phone number must be validated and stored correctly according to rules listed below. Server side validation is a bare minimum, progressive enhancement preferred. Consider unit testing this logic. 
  
    * The database update MUST be implemented using a stored procedure, but can be abstracted in anyway you see fit.

3. Bonus points for show-offs. Extend the /Restaurant/Edit form to include any other fields in a domain specific way, e.g. 
    
    * Cuisine (a dropdown list)
  
    * Rating fields (any UI idiom that constrains input to numbers 0-3)
  
    * Address fields
  
    * Latitude/longitude.
  
    * Review text in an easy to edit and format way.
  
    * Photo upload

Phone number rules 
---------------------------
(phone numbers are assumed to be valid within Australia area code never international)

 * Any non-digit characters should be ignored/stripped out during parsing. 

 * If less than 9 significant digits are entered, the number is rejected as invalid

 * Any digits beyond the 9th-most-significant are ignored/dropped

 * The resulting 9-digit number must be stored in PhoneNumberKey field

 * The resulting 9-digit number must be formatted as (00) 0000 0000 before storing in PhoneNumberText field
