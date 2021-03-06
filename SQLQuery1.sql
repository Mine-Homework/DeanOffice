﻿CREATE TABLE [Faculties] (
  Id int NOT NULL IDENTITY,
  Name nvarchar(100) NOT NULL UNIQUE,
  CONSTRAINT [PK_FACULTIES] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Subjects] (
  Id int NOT NULL IDENTITY,
  Name nvarchar(100) NOT NULL UNIQUE,
  CONSTRAINT [PK_SUBJECTS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Groups] (
  Id int NOT NULL IDENTITY,
  Name nvarchar(100) NOT NULL UNIQUE,
  FacultyId int NOT NULL,
  CONSTRAINT [PK_GROUPS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Students] (
  Id int NOT NULL IDENTITY,
  Name nvarchar(100) NOT NULL UNIQUE,
  GroupId int NOT NULL,
  Birth date NOT NULL,
  Phone nvarchar(50) NOT NULL UNIQUE,
  Email nvarchar(50) NOT NULL UNIQUE,
  CONSTRAINT [PK_STUDENTS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Grades] (
  Id int NOT NULL IDENTITY,
  SubjectId int NOT NULL,
  StudentId int NOT NULL,
  Rate float NOT NULL,
  CONSTRAINT [PK_GRADES] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO


ALTER TABLE [Groups] WITH CHECK ADD CONSTRAINT [Groups_fk0] FOREIGN KEY ([FacultyId]) REFERENCES [Faculties]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Groups] CHECK CONSTRAINT [Groups_fk0]
GO

ALTER TABLE [Students] WITH CHECK ADD CONSTRAINT [Students_fk0] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Students] CHECK CONSTRAINT [Students_fk0]
GO

ALTER TABLE [Grades] WITH CHECK ADD CONSTRAINT [Grades_fk0] FOREIGN KEY ([SubjectId]) REFERENCES [Subjects]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Grades] CHECK CONSTRAINT [Grades_fk0]
GO
ALTER TABLE [Grades] WITH CHECK ADD CONSTRAINT [Grades_fk1] FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Grades] CHECK CONSTRAINT [Grades_fk1]
GO