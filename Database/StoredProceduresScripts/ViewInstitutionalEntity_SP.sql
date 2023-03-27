print '' print '*** using PetNet_db_am'
GO
USE [PetNet_db_am]
GO


/* Created By: Asa Armstrong  */
print '' print '*** Creating sp_select_all_institutionalEntities_by_shelterId_and_contactType'
GO
CREATE PROCEDURE [dbo].[sp_select_all_institutionalEntities_by_shelterId_and_contactType]
(
	@ShelterId				int,
	@ContactType			nvarchar(15)
)
AS
	BEGIN
		SELECT InstitutionalEntityId, CompanyName, GivenName, FamilyName, Email, Phone, Address, AddressTwo, Zipcode, ContactType, ShelterId
		FROM [dbo].[InstitutionalEntity]
		WHERE @ShelterId = InstitutionalEntity.ShelterId
		AND @ContactType = ContactType
	END
GO

/*
print '' print '*** testing sp_select_all_institutionalEntities_by_shelterId_and_contactType'
GO
EXEC sp_select_all_institutionalEntities_by_shelterId_and_contactType @ShelterId = 100000, @ContactType = "Host"
GO
*/