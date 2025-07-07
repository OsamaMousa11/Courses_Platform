# CoursesPlatform
CoursesPlatform is a web application built with **ASP.NET Core MVC** and Clean Architecture.  
It allows users to manage their course collections and favorite lists, with role-based access for admins and users.


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

#### Screenshots
* Unauthenticated View: The landing page for users who are not logged in.
  
  <img width="1878" height="917" alt="Image" src="https://github.com/user-attachments/assets/2c42d93f-5e53-43e6-9379-14635e701838" />
  
  
  <img width="1692" height="787" alt="Image" src="https://github.com/user-attachments/assets/1d918a98-bdd7-4065-8a56-318029b42820" />
  

  <img width="1667" height="760" alt="Image" src="https://github.com/user-attachments/assets/6542cb8b-e7a3-4daf-9914-f061ecb12079" />
  
* Register Page: The registration page for new users to sign up.
    
  <img width="1885" height="911" alt="Image" src="https://github.com/user-attachments/assets/a7a78464-5148-449b-b56d-91568320fd28" />
  
* Login Page: The login page for users to access their accounts.

  <img width="1883" height="795" alt="Image" src="https://github.com/user-attachments/assets/3357e692-2a60-409d-b93a-63f67e32c1f1" />

* User View: The main interface for regular users.

  <img width="1893" height="913" alt="Image" src="https://github.com/user-attachments/assets/08d0f89d-4679-4a8f-bc63-f8c4dee4ab1d" />

* Wishlist Page for User: The interface where users can manage their favorite movies.
   
  <img width="1842" height="762" alt="Image" src="https://github.com/user-attachments/assets/cee46573-6885-4662-8783-b38abbec8e3d" />

* Details for Course: Detailed view of a movie's information.

  <img width="1852" height="891" alt="Image" src="https://github.com/user-attachments/assets/883f093c-ad8b-4f48-b9ac-eea34984149f" />

* Admin View: Admin interface for managing the application.

  <img width="1825" height="910" alt="Image" src="https://github.com/user-attachments/assets/192f8a7b-0a5b-452c-be5e-390b6fa56e04" />

* Admin Dashboard: Dashboard showing various administrative controls.

  <img width="1908" height="846" alt="Image" src="https://github.com/user-attachments/assets/67b99918-5e0c-4ac6-bac1-8c581fa132eb" />

* Create New Course by Admin: Interface for admins to create a new Course entry.

  <img width="1691" height="712" alt="Image" src="https://github.com/user-attachments/assets/3f70efad-ba98-43d6-8aad-ac9fca0e7484" />

* Edit Existing Course by Admin: Interface for admins to edit existing Course details.

  <img width="1541" height="915" alt="Image" src="https://github.com/user-attachments/assets/95c165e4-daad-4acb-952e-2e35b7a76d9a" />


* Manage Category by Admin

  <img width="1830" height="727" alt="Image" src="https://github.com/user-attachments/assets/e37c9a94-bcbe-4871-91cb-8d43a0a1668e" />
  
* Add Category
 <img width="1357" height="332" alt="Image" src="https://github.com/user-attachments/assets/cf7ab104-f2b7-4671-b193-04c38666ac7e" />

* Edit Category

 <img width="1842" height="365" alt="Image" src="https://github.com/user-attachments/assets/6b543063-7663-4912-982b-3e85d75f5dd7" />

 

  


 



  
  

 
  

