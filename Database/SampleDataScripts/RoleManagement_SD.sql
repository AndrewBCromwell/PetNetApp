/***************************************************************
Barry Mikulas
Created: 2023/02/12

Description:
File contains data for RoleManagement in UserRole table
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/
print '' print '*** using PetNet_db_am'
GO
USE [PetNet_db_am]
GO

print '' print '*** creating test data for Users (Barry)'
GO
INSERT INTO [dbo].[Users]
		(
		[GenderId], 
		[PronounId], 
		[ShelterId], 
		[GivenName], 
		[FamilyName], 
		[Email],
		[Address], 
		[AddressTwo], 
		[Zipcode], 
		[Phone]
		)
    VALUES
		("Male", "N/A", "999999", "Barry", "Mikulas", "bmikulas@company.com", "2 Kirkwood Parkway", "Apt 4", '50001', "3198675309"),
		("Male", "He/Him", "888888", "Stephen", "Jaurigue", "stephen@company.com", "123 Kirkwood Parkway", "Apt 210", "50001", "3195555555"),
		("Female", "She/Her", "777777", "Molly", "Meister", "molly@company.com", "456 Kirkwood Parkway", "Apt 256", "50001", "3196666666"),
		('Male', 'He/Him', '666666', 'Tyler', 'Hand', 'tyler@company.com', '789 Kirkwood Parkway', 'Apt 240', '50002', '3197777777')
GO

print '' print '*** Inserting Role Records'
GO
INSERT INTO [dbo].[Role]
		(
		[RoleId],
		[Description]
		)
	VALUES
		('Volunteer',''),
		('Admin',''),
		('Vet',''),
		('Manager',''),
		('Employee','')
GO

print '' print '*** Inserting UserRoles Data'
GO
INSERT INTO [dbo].[UserRoles]
		([RoleId], [UsersId])
	VALUES
		('Admin','100001'),
		('Employee','100001'),
		('Volunteer','100000')
GO