/***************************************************************
Mads Rhea
Created: 2023/02/01

Description:
File contains sample data to test the parts of the application i built.
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/

USE [PetNet_db_am]
GO

print '' print '*** creating test data for Zipcode (Mads)'
INSERT INTO [dbo].[Zipcode]
	([Zipcode], [City], [State], [Latitude], [Longitude])
	VALUES
	("52404", "Cedar Rapids", "Iowa", "41.9779", "91.6656")
GO

print '' print '*** inserting test records for ROLE (mads)'
GO
INSERT INTO [dbo].[Role]
	([RoleId], [Description])
	VALUES
	("Admin", "God"),
	("Manager", "Lowly worm"),
	("Vet", "Animal doctor"),
	("User", "Welcome to Pet.Net!")
GO


print '' print '*** inserting test records into USERROLES (mads)'
GO
INSERT INTO [dbo].[UserRoles]
	([RoleId], [UsersId])
	VALUES
	("User", 100000),
	("User", 100001),
	("User", 100002),
	("User", 100003),
	("User", 100004),
	("User", 100005)
	
GO