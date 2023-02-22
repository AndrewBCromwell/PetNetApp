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
		("Male", "He/Him", "100000", "Barry", "Mikulas", "bmikulas@company.com", "2 Kirkwood Parkway", "Apt 4", '50001', "3198675309")
GO
