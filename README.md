User Management System
Overview
The User Management System is a web application developed using ASP.NET Core 3.1 MVC. It allows users to sign up, log in, manage their profiles, and perform CRUD operations on users and roles. The system integrates several technologies and libraries to ensure efficient functionality, including AutoMapper, Fluent Validation, and Role-based Access Control (RBAC).

This system is designed to manage user data and roles, providing administrators with control over access to resources based on user roles. The application is extendable, making it suitable for large-scale enterprise applications that require flexible and secure user role management.

The Repository Pattern is employed to separate business logic from data access, ensuring a cleaner and more maintainable codebase. This pattern promotes decoupling data access from the application's core functionality, making testing and code management easier.

Features:
User Authentication: Allows users to sign up with credentials and log in to access their profiles.
User CRUD Operations: Admin users can create, read, update, and delete user records.
Role CRUD Operations: Admin users can create, update, delete, and view roles.
Role Assignment: Admin users can assign specific roles to users for access control.
AutoMapper Integration: Used for mapping Data Transfer Objects (DTOs) to entities and vice versa, keeping the code clean and maintainable.
Fluent Validation: Validates user input before processing, ensuring data consistency and reducing errors.
Password Hashing: User passwords are securely hashed using industry-standard algorithms before being stored in the database.
Repository Pattern: Implements a clean architecture by separating concerns between business logic and the data access layer.
Technologies Used
ASP.NET Core 3.1: The framework for building the web application.
AutoMapper: A library used for object-to-object mapping between domain models and DTOs.
Fluent Validation: A library for implementing input validations.
Entity Framework Core: ORM for database interaction and migrations.
SQL Server: The database used to store user and role data.
BCrypt: A password hashing algorithm used to securely store user passwords.
Repository Pattern: A design pattern used to abstract data access and manage business logic.
Installation
Prerequisites
Before running the application, ensure you have the following installed:

.NET Core SDK 3.1 or higher: Required to build and run the application.
SQL Server or a compatible database engine: Required to store user and role information.
Visual Studio or Visual Studio Code: For editing and developing the application.
Postman (optional): For testing the API endpoints.
Steps to Run the Project

1. Clone the repository:
bash
Copy code
git clone https://github.com/farazhasnain/usermanagement.git


2. Navigate to the project directory:
bash
Copy code
cd usermanagement

3. Install the dependencies:
bash
Copy code
dotnet restore

4. Apply migrations to the database:
bash
Copy code
dotnet ef database update
5. Run the application:
bash
Copy code
dotnet run

After running the application, visit http://localhost:5000 in your browser.
