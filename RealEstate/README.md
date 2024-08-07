# RealEstateAPI 

## Table of Contents
- [Introduction](#introduction)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Configration](#database-configration)
- [Running the Application](#running-the-application)


## Introduction
This is a .NET 8 API project designed following the principles of comman clean Architecture.
The goal of this project is to provide a scalable, maintainable, and testable structure for building robust RealEstate APIs.

## Project Structure
The project is organized as follows:


### Folders Explanation
- **Application**: Contains the business logic and interfaces. This layer is independent of other layers.
- **Domain**: Contains the core entities and value objects. This layer is also independent of other layers.
- **Infrastructure**: Contains implementations of repository interfaces and data access logic.
- **Presentation**: Contains the API controllers and models. This layer interacts with the Application layer to handle HTTP requests and responses.

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any other database you prefer)


### Database Configration
1. Update the connection string in `appsettings.Development.json` to point to your database.
2. Apply migrations to create the database schema:
    ```sh
        Add-Migration Adduser -Context AppDbContext -OutputDir Domain/Migrations
        Update-Database -Verbose -Context ApplicationDbContext
    ```
### Running the Application
 Run the application:
    ```sh
    dotnet run --project RealEstateAPI
    ```



This `README.md` provides an overview of the project, explains the folder structure, and includes instructions for setting up, and running.

