# Simple Test

Designed to demonstrate the basics of prescribed test for:

1. Querying capabilities with LINQ
2. Func's
3. Entity Framework Code First and ability to query live data
4. Unit testing and Database First examples are supplied as separate GitHub repositories written in the past 

## Structure

```
|   - Entities
|   - EntitiesService
|   - SimpleTest
```

### Entities

**Class library:** initial implementation of database entities. Includes entities and schema migrations.

- Student
- Faculty
- StudentFaculty
- Fluent Api
  - Constraints
  - Many to many configuration
  - Index's
  - Unique constraint
- Data annotations
  - Required
  - String lengths

Supports criteria - query students assigned to faculty: **Medicine** and demonstrates utilization of Func

### EntitiesService

**Class library:** initial implementation facilitating generic CRUD functionality and overrides the concrete implementation to demonstrate querying for Students by Faculty name.

Supports criteria - query students assigned to faculty: Medicine and demonstrates utilization of Func

### SimpleTest

**Console application:** demonstrating:

**Ability to filter a collection of numbers (odd and even) by:**

1. Even numbers - implementing the modulus operator: `collection.Where(p => p % 2 == 0)`
2. Sorted in ascending order: `collection.OrderBy(p => p)`


**Ability to understand Func's:**

Whilst I don't use this strategy on a regular basis, I do have an understanding of how to implement and create additional implementations for future use cases.

**Ability to Query Data:**

Above an beyond - implementing the ability to:

- Create a database - configured locally
- Automatically run Entity Framework schema migrations
- Seed data if none already exist
- TSQL scripts

All this to showcase real world use of querying data:

1. Student: A student can have 0, 1 or many Faculties
2. Faculty: A faculty can have 0, 1 or many Students

```
Students < 1 to many > StudentFaculty < many to 1 > Faculties
```

##  How To Run

Ensure you have:

- [.NET Core 8 installed](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Entity Framework 8](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install)
- Access to Docker or if on Windows access to your local SQL Sever as localhost

**SimpleTest Project:**

On line 37 the database is configured to use the connection string in `appsettings.json` 

```C#
// If you are using Docker, leave as is

options.UseSqlServer(
				hostContext.Configuration["ConnectionStrings:DockerConnection"],
				...

// If you are using Windows and can connect to your local SQL Server on localhost with Windows Authentication (I haven't used windows for a while)

options.UseSqlServer(
				hostContext.Configuration["ConnectionStrings:LocalWindowsConnection"],
				...

```
**Docker SQL Server Install:**

```bash

# Only use `sudo` if on a Mac

# Get the image
sudo docker pull mcr.microsoft.com/mssql/server:2022-latest

# Set password and configure port number
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Local@DevPa55word" \
   -p 1433:1433 --name sql1 --hostname sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest
```

## Local Connection

- Server: tcp:localhost
- U: sa
- P: Local@DevPa55word

Otherwise, update the connection string to what works for your local environment.

##  Additional Examples

For an example of Database First (reverse engineering) pleas look at my GitHub repo: [Entity Framework - Database First](https://github.com/lightspaceliam/database-first-reverse-engineering-poc)

For an example of Unit Testing  pleas look at my GitHub repo:
[Unit Testing Strategies](https://github.com/lightspaceliam/unit-testing-strategies/tree/main) 