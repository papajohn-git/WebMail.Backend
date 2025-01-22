# WebMail.Backend.CodindFactory
WebMail is a web-based application designed to send emails efficiently. It provides a user-friendly interface for composing and sending emails, viewing sent email history,as well as creating folders to organize emails and managing TODO tasks. Note that WebMailer does not require a mail server to send emails.


## Technologies implemented:
* ASP.NET 8.0
* ASP.NET MVC Core
* ASP.NET WebApi Core with JWT Bearer Authentication
* Entity Framework Core 9.0
* AutoMapper
* Swagger UI with JWT support
* Serilog

## Architecture:
* Unit of Work
* Repository


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

The things you need before installing the software.

* Visual Studio 2022 
* the latest .NET Core SDK
* MS SQL Server

### Installation

To install and set up WebMail, follow these steps:

1.	Clone the repository:


```
git clone https://github.com/papajohn-git/WebMail.Backend.git
cd WebMail
```

2.	Install dependencies:
```
dotnet restore
```
3. Build the project
```
dotnet build
```
4.	Run the application:
```
dotnet run
```

## Database Migration
To set up the database and apply migrations, follow these steps:
1.	Update the connection string in the appsettings.json file to point to your database:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionString"
  }
}
```
2.	Update the database with the new migration:
```
dotnet ef database update
```



## Usage

To use WebMail, open your web browser and navigate to https://localhost:5001.

## Dummy Data

The dummy data is intended for testing purposes only and should not be used in a production environment.
You can copy the contents of the DataScript.sql file and paste it into your SQL client to execute it directly.
But you have change YourDatabaseName to the name of your actual database.

```
-- Use the database where you want to insert the dummy data

USE [YourDatabaseName]
GO
```
## Last but not least
To facilitate a smoother testing process for our application, we will temporarily relax the password complexity requirements while retaining the confirmation password field. The confirmation password will still be saved in the database during this testing phase.


## Contributing

Pull requests are welcome. Please open an issue first
to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/)
