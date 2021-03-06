--
-- This script was generated by Valentina Studio
-- Application homepage: http://www.valentina-db.com/
--


-- --------------------------------------------------------------------------------
-- Create Schemas
-- --------------------------------------------------------------------------------

BEGIN TRANSACTION;

-- CREATE SCHEMA "dbo" -----------------------------------------
IF NOT EXISTS ( 
	SELECT sys_sch.name 
	FROM sys.schemas sys_sch 
	WHERE sys_sch.name = N'dbo' )
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA [dbo] AUTHORIZATION dbo'
END
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO


-- --------------------------------------------------------------------------------
-- Create Tables
-- --------------------------------------------------------------------------------

BEGIN TRANSACTION;

-- CREATE TABLE "__EFMigrationsHistory" ------------------------
CREATE TABLE [dbo].[__EFMigrationsHistory] ( 
	[MigrationId] NVARCHAR( 150 ) NOT NULL, 
	[ProductVersion] NVARCHAR( 32 ) NOT NULL,
	PRIMARY KEY ( [MigrationId] ) )
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE TABLE "Faculties" ------------------------------------
CREATE TABLE [dbo].[Faculties] ( 
	[Id] INT IDENTITY ( 1, 1 )  NOT NULL, 
	[NameOfFaculty] NVARCHAR( max ) NULL,
	PRIMARY KEY ( [Id] ) )
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE TABLE "Departments" ----------------------------------
CREATE TABLE [dbo].[Departments] ( 
	[Id] INT IDENTITY ( 1, 1 )  NOT NULL, 
	[NameOfDepartment] NVARCHAR( max ) NULL, 
	[FacultyId] INT NOT NULL,
	PRIMARY KEY ( [Id] ) )
GO;
-- -------------------------------------------------------------

-- CREATE INDEX "IX_Departments_FacultyId" ---------------------
CREATE  INDEX [IX_Departments_FacultyId] ON [dbo].[Departments]( [FacultyId] ASC )
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE TABLE "Specialities" ---------------------------------
CREATE TABLE [dbo].[Specialities] ( 
	[Id] INT IDENTITY ( 1, 1 )  NOT NULL, 
	[NameOfSpeciality] NVARCHAR( max ) NULL, 
	[DepartmentId] INT NOT NULL,
	PRIMARY KEY ( [Id] ) )
GO;
-- -------------------------------------------------------------

-- CREATE INDEX "IX_Specialities_DepartmentId" -----------------
CREATE  INDEX [IX_Specialities_DepartmentId] ON [dbo].[Specialities]( [DepartmentId] ASC )
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE TABLE "Groups" ---------------------------------------
CREATE TABLE [dbo].[Groups] ( 
	[Id] INT IDENTITY ( 1, 1 )  NOT NULL, 
	[NameOfGroup] NVARCHAR( max ) NULL, 
	[SpecialityId] INT NOT NULL,
	PRIMARY KEY ( [Id] ) )
GO;
-- -------------------------------------------------------------

-- CREATE INDEX "IX_Groups_SpecialityId" -----------------------
CREATE  INDEX [IX_Groups_SpecialityId] ON [dbo].[Groups]( [SpecialityId] ASC )
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE TABLE "Students" -------------------------------------
CREATE TABLE [dbo].[Students] ( 
	[Id] INT IDENTITY ( 1, 1 )  NOT NULL, 
	[NameOfStudent] NVARCHAR( max ) NULL, 
	[FirstName] NVARCHAR( max ) NULL, 
	[LastName] NVARCHAR( max ) NULL, 
	[Address] NVARCHAR( max ) NULL, 
	[Phone] NVARCHAR( max ) NULL, 
	[DateOfBirth] DATETIME2 NOT NULL, 
	[GroupId] INT NOT NULL,
	PRIMARY KEY ( [Id] ) )
GO;
-- -------------------------------------------------------------

-- CREATE INDEX "IX_Students_GroupId" --------------------------
CREATE  INDEX [IX_Students_GroupId] ON [dbo].[Students]( [GroupId] ASC )
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO


-- --------------------------------------------------------------------------------
-- Create Links
-- --------------------------------------------------------------------------------

BEGIN TRANSACTION;

-- CREATE LINK "FK_Students_Groups_GroupId" --------------------
ALTER TABLE [dbo].[Students]
	ADD CONSTRAINT [FK_Students_Groups_GroupId]
	FOREIGN KEY ([GroupId])
	REFERENCES [dbo].[Groups]( [Id] )
	ON DELETE Cascade
	ON UPDATE No Action
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE LINK "FK_Departments_Faculties_FacultyId" ------------
ALTER TABLE [dbo].[Departments]
	ADD CONSTRAINT [FK_Departments_Faculties_FacultyId]
	FOREIGN KEY ([FacultyId])
	REFERENCES [dbo].[Faculties]( [Id] )
	ON DELETE Cascade
	ON UPDATE No Action
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE LINK "FK_Specialities_Departments_DepartmentId" ------
ALTER TABLE [dbo].[Specialities]
	ADD CONSTRAINT [FK_Specialities_Departments_DepartmentId]
	FOREIGN KEY ([DepartmentId])
	REFERENCES [dbo].[Departments]( [Id] )
	ON DELETE Cascade
	ON UPDATE No Action
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

BEGIN TRANSACTION;

-- CREATE LINK "FK_Groups_Specialities_SpecialityId" -----------
ALTER TABLE [dbo].[Groups]
	ADD CONSTRAINT [FK_Groups_Specialities_SpecialityId]
	FOREIGN KEY ([SpecialityId])
	REFERENCES [dbo].[Specialities]( [Id] )
	ON DELETE Cascade
	ON UPDATE No Action
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO

