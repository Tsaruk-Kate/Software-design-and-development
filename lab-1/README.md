# A description of how I followed each programming principle that I used to complete the assignment.
### DRY (Don't Repeat Yourself):
The code is structured in such a way that code repetition is avoided. For example, the display() method is used in the Passport, DrivingLicense, and MilitaryID classes, which avoids code repetition for displaying documents.

### KISS: Keep it simple, stupid:
The code has a simple structure and is easy to understand. For example, the structure of HTML/CSS/JavaScript is clear and not overloaded with unnecessary details. Each part of the code performs its own simple function.

### Single Responsibility Principle:
Each class performs only one function, and changing it does not affect other parts of the code. For example, the Passport, DrivingLicense, and MilitaryID classes are only responsible for displaying their documents.

### Liskov Substitution Principle:
The subclasses Passport, DrivingLicense, and MilitaryID can be used instead of their parent class Document without changing the correctness of the program.

### Open/Closed Principle:
Changes in document ordering can be made without modifying existing code, for example, the changeOrder() method can be easily changed to sort documents in reverse order without modifying the method itself.

### YAGNI (You Ain't Gonna Need It):
My code only uses the functionality that is required to achieve the functionality of the application. For example, the functionality of QR code generation or vehicle registration is only activated by buttons when the user presses them.

### Composition Over Inheritance:
My code demonstrates this principle in that it uses object composition instead of deep class inheritance. Instead of creating complex class hierarchies through inheritance, I create simple classes (Document, Passport, DrivingLicense, MilitaryID) with different responsibilities. Then I organize these objects into a documents array that represents a collection of documents. This allows you to easily add new types of documents without modifying your existing code.

### SOLID: Interface Segregation Principle:
Although this principle is not directly used in JavaScript, code can be organized in such a way that interfaces are divided into smaller, specialized parts so that classes use only the information they need.