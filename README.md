# LearnAdoDotnet

A basic web api project that is using ADO.NET

## Important Notes
- This project divide into services using some of the best practices
- The services folder contains DataAccessService and StudentsService
- This project using dependency injection at multi-levels 


## Development Dependencies

- [SQL Server or SQL Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient)

---

## Run locally
- Create SQL server database with the following command:
``` sql
USE [master]
GO
CREATE DATABASE [AdvancedProgramming2];

GO

USE [AdvancedProgramming2]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Studnets] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

USE [AdvancedProgramming2]
GO

INSERT INTO [dbo].[Students]
        ([Name]
        ,[Email])
    VALUES
    (1, 'John Doe', 'john.doe@email.com'),
    (2, 'Jane Smith', 'jane.smith@email.com'),
    (3, 'Bob Johnson', 'bob.johnson@email.com'),
    (4, 'Alice Williams', 'alice.williams@email.com'),
    (5, 'Tom Brown', 'tom.brown@email.com'),
    (6, 'Sara Davis', 'sara.davis@email.com'),
    (7, 'Mark Lee', 'mark.lee@email.com'),
    (8, 'Jenny Kim', 'jenny.kim@email.com'),
    (9, 'David Martin', 'david.martin@email.com'),
    (10, 'Karen Jones', 'karen.jones@email.com'),
    (11, 'Mike Adams', 'mike.adams@email.com'),
    (12, 'Laura Wilson', 'laura.wilson@email.com'),
    (13, 'Chris Davis', 'chris.davis@email.com'),
    (14, 'Lisa Thompson', 'lisa.thompson@email.com'),
    (15, 'Brian Johnson', 'brian.johnson@email.com');
```

- Change default connection stings in appsettings.json file
- Clone the repository

```bash
git clone https://github.com/ma7m00dma7m00d/LearnADOdotnet.git
```

- Install required package

```bash
dotnet restore
```

- Then run

```bash
dotnet run
```
