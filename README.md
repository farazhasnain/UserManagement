User Management System
Overview
This User Management System is a web application developed using ASP.NET Core 3.1 MVC. The application allows users to sign up, log in, manage their profiles, and perform CRUD operations on users and roles. The system utilizes several technologies and libraries to ensure smooth functioning, including AutoMapper, Fluent Validation, and Role-based Access Control (RBAC).

The project is designed to manage user data and roles efficiently, providing the ability for administrators to control access to resources based on user roles. This application can be extended for larger enterprise applications requiring flexible and secure user role management.

The Repository Pattern is used in this project to separate the business logic and data access layers, ensuring a cleaner, more maintainable codebase. The Repository Pattern promotes the idea of decoupling the data access logic from the application's core functionality, allowing for easier testing and more manageable code.

This project provides functionalities such as:

User authentication (login and signup)
Role-based access control (assign roles to users)
User management (CRUD operations for users)
Role management (CRUD operations for roles)
Fluent validation for input validation
AutoMapper for object-to-object mapping
Secure user registration and password hashing
Repository pattern for clean architecture
Features
Login/Signup: Users can sign up with their credentials and log in to access their profiles.
User CRUD: Admin users can perform Create, Read, Update, and Delete operations on users.
Role CRUD: Admin users can manage roles by creating, updating, deleting, and viewing roles.
Role Assignment: Admin users can assign specific roles to users for access control.
AutoMapper: Used for mapping DTOs (Data Transfer Objects) to entities and vice versa to keep the code clean and maintainable.
Fluent Validation: Ensures that input data is validated before being processed, reducing the risk of errors and ensuring data consistency.
Password Hashing: User passwords are securely hashed using industry-standard algorithms before being stored in the database.
Repository Pattern: Implements a separation of concerns between the business logic and the data access layer, providing a cleaner, more maintainable application.
Technologies Used
ASP.NET Core 3.1: Framework for building the web application.
AutoMapper: Library for object mapping between domain models and DTOs.
Fluent Validation: Library used for implementing validations on user inputs.
Entity Framework Core: ORM for database interaction and migrations.
SQL Server: Database used for storing user and role information.
BCrypt: Password hashing algorithm used for securely storing user passwords.
Repository Pattern: Design pattern used to manage data access and abstract the interaction between the business logic and the database.
Installation
Prerequisites
Before running the application, ensure that you have the following installed:

.NET Core SDK 3.1 or higher: Required for building and running the application.
SQL Server or a compatible database engine: To store user and role information.
Visual Studio or Visual Studio Code: For code editing and development.
Postman (optional): For testing the API endpoints.
Steps to Run the Project
Clone the repository:

git clone https://github.com/farazhasnain/usermanagement.git
Navigate to the project directory: bash Copy code cd usermanagement

Install dependencies: bash Copy code dotnet restore

Apply migrations to the database: bash Copy code dotnet ef database update

5.Run the application: bash Copy code dotnet run After running the application, visit http://localhost:5000 in your browser.

