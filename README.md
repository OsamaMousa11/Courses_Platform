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
```bash
    https://github.com/OsamaMousa11/Courses_Platform.git
```
2.Navigate to the project directory:
```bash
  cd Courses_Platfrom
  ```
3. Restore the dependencies:
```bash
dotnet restore
```
4. Update the database:
```bash
   dotnet ef database update --project CoursesPlatform.Infrastructure
```
   
5. Run the application:
```bash
 dotnet run --project CoursesPlatform.UI
 ```
## Usage
* Register a new user: Go to the /Account/Register endpoint and create a new user.
* Login: Go to the /Account/Login endpoint to login with your registered credentials.
####  manage Course
* Add a new Course : Navigate to the Course section and click on the "Add Course" button.
* Edit a Course: Click on the "Edit" button next to a Course in the list.
* Delete aCourse: Click on the "Delete" button next to a Course in the list.
#### Manage Favorites
* Create a new favorite list: Go to the favorites section and click on the "Create Favorite List" button.
* Add Course to favorites: Open a favorite list and click on the "Add Course" button.
* Remove Course from favorites: Click on the "Remove" button next to a Course in the favorite list. 

  


  
  

 
  

