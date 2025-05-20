# Windows Forms Blog Application

A complete Windows Forms blog application with user authentication, post management, and administrative features built with C# and SQLite.

## Features

### User Authentication
- Login and registration system
- Secure password storage with SHA-256 hashing
- Role-based access control (admin vs. regular users)
- Session management

### Blog Post Management
- Create, read, update, and delete blog posts
- Search and filter posts by category
- Permission-based editing (users can only edit their own posts)
- Post publishing control

### User Management (Admin only)
- View and manage all user accounts
- Create new user accounts
- Modify existing users
- Delete users
- Assign admin privileges

### Modern UI
- Clean, responsive Windows Forms interface
- Blue-themed color scheme
- Consistent styling across all forms
- Status bar with user info
- Easy-to-use navigation

## Application Structure

The application follows a structured architecture:

- **Data Layer**: BlogRepository class for database operations using SQLite
- **Model Layer**: Contains BlogPost and User classes representing data entities
- **UI Layer**: Windows Forms interfaces for user interaction with permission controls

## User Interface

### Authentication Forms
- **Login Form**: Secure authentication with username and password
- **Register Form**: User registration with validation

### Main Window
- Search box to find posts
- Category filter dropdown
- List of blog posts with details
- Buttons for CRUD operations (permission controlled)
- Status bar showing logged-in user
- Menu system with File, Admin (for admins only), and Help options

### Blog Management
- **Edit Post Form**: Create or modify posts with title, content, category
- **View Post Form**: Display post details in a read-only format

### User Management (Admin Only)
- **User Management Form**: List all users with admin controls
- **User Edit Form**: Add or modify user accounts with permission settings

## Getting Started

### Prerequisites
- .NET 9.0 or higher
- Windows 7 or higher

### Installation
1. Clone this repository or download the ZIP file
2. Open the solution in Visual Studio
3. Build the solution
4. Run the application

### Default Admin Login
- Username: `admin`
- Password: `admin123`

## Database

The application automatically creates and initializes a SQLite database file (blog.db) with:
- BlogPosts table for storing blog content
- Users table for storing user accounts and credentials
- Default admin user for initial access

## Security Features
- Password hashing using SHA-256
- Permission checking before edit/delete operations
- Protection of admin account
- Input validation

## Usage

### Managing Blog Posts
1. Log in to the application
2. View all posts on the main screen
3. Create a new post using the "New Post" button
4. Edit your own posts by selecting them and clicking "Edit"
5. Delete your own posts with the "Delete" button
6. Filter posts by category using the dropdown
7. Search for posts using the search box

### Managing Users (Admin Only)
1. Log in as administrator
2. Access user management through the "Admin" menu
3. View all registered users
4. Add, edit, or delete users as needed
5. Assign administrator privileges to trusted users

## Tips
- Double-click on a post in the list to view it
- Admin users can edit and delete any post
- Regular users can only edit and delete their own posts
- Use the search feature to quickly find posts
- Create meaningful categories to organize your blog content

## Future Enhancements
1. Rich text editor for blog posts
2. Image upload capabilities
3. Comment system for blog posts
4. Blog categories management
5. Export/import functionality
6. User profile pages
7. Password reset functionality
- Use the search box to quickly find specific posts
- Create categories to keep your blog organized

## Requirements

- .NET 9.0 or later
- Windows operating system
