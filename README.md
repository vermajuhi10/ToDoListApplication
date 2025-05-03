# 📝 ASP.NET Core To-Do List Application
A simple To-Do List application built using **ASP.NET Core**, **Entity Framework Core**, and **Razor Pages** in .Net 9 . This application allows users to manage their tasks efficiently by providing features to create, edit, delete, and view tasks.

## 🚀 Features
- ✅ Create new tasks with relevant details
- 📋 View all to-do tasks
- ✏️ Edit existing tasks
- ❌ Delete tasks that are no longer needed
- ☑️ Mark tasks as complete/incomplete
- 🔤 Sort tasks by:
  - Title
  - Descrition
- 🔍 Filter tasks by:
  - Completed
  - Incomplete

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A local SQL Server instance or equivalent database setup.

## Getting Started
### Clone the Repository
git clone <repository-url> cd ToDoApplication

### Configure the Database
1. Open the `appsettings.json` file.
2. Update the `ConnectionStrings:ToDoContext` value to match your database configuration. The default connection string is:
 "ConnectionStrings": { "ToDoContext": "Data Source=localdb;Initial Catalog=ToDo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False" }

### Run Database Migrations
Run the following commands to apply migrations and set up the database: dotnet ef database update

### Run the Application
Start the application using the following command: dotnet run
The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## Project Structure
- **Models**: Contains the `ToDo` model and `ToDoContext` for database interaction.
- **Views**: Razor Pages for creating, editing, deleting, and viewing tasks.
- **Controllers**: The `ToDoController` handles the application logic.
- **Configuration**: The `appsettings.json` file contains application settings, including the database connection string.

## Dependencies
- Entity Framework Core for database operations.
- Razor Pages for the front-end.
- Microsoft.Extensions.Logging for logging.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Future Enhancements
- Authentication /Authorization
- Schedule notifications/reminders
- Export tasks to CSV or JSON format
- Test cases

👤 Author
Juhi Verma
Full Stack Developer | .NET | React | Azure | AWS
🔗 https://www.linkedin.com/in/juhiverma10

