# CoursesPlatform
CoursesPatform is a web application built with ASP.NET Core that allows users to manage their Courses collection and favorite lists. The application provides features for managing Courses, Category, and user-specific favorite lists, along with a responsive user interface.

## Features
* User Authentication: Register, login, and logout functionality for users.
* Role-Based Authorization: Different access levels for admins and regular users.
* Course Management: Add, edit, and delete course information.
* Favorite Management: Create and manage users' favorite movie lists.
* Category  Management:Add, edit, and delete Category information..
* Search Functionality: Search for Courses and favorite lists.
* Validation: Client-side and server-side validation for forms.

# Project Structure
#### CoursePlatform.Core: Contains core domain entities, DTOs (Data Transfer Objects), enumerations, helpers, services, and service contracts.

- Entities: Domain entities like Movie, Favourite, Genre, MovieFavourite.
- DTO: Data Transfer Objects for communication between layers.
- Services: Business logic for managing movies , Category  and favorites.
- ServiceContracts: Interfaces for services.
- Helper: Utility classes like ValidationModel.

#### CoursePlatform.Infrastructure: Contains infrastructure-related classes like application context, configuration, migrations, and repositories.

- ApplicationDbContext: Database context class.
- Repositories: Data access logic for Courses , Category and favorites.
  
#### CoursePlatform.UI: The main web application project containing controllers, views, filters, middleware, and other UI-related components.

- Controllers: Handle HTTP requests and return views or data.
- Views: Razor views for displaying data.
- wwwroot: Static files like CSS, JS, and images.

## Installation
1. Clone the repository:
    ```git clone https://github.com/yourusername/MovieApp.git```
  

