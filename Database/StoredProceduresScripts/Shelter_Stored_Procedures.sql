print '' print '*** Using PetNet_db_am'
USE [PetNet_db_am]
GO

/* This stored procedure is for populating a list of Shelter Objects to perform menu operations on */
print '' print '*** Creating sp_select_shelter_all (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_select_shelter_all]
AS
	BEGIN
		SELECT
			[ShelterId],
			[ShelterName],
			[Address],
			[AddressTwo],
			[Zipcode],
			[Phone],
			[Email],
			[Areasofneed],
			[ShelterActive]
		FROM [dbo].[Shelter]
		ORDER BY [ShelterId] DESC
	END
GO

/* Select a single shelter by Shelter ID ShelterNetwork-614 */
print '' print '*** Creating sp_select_shelter_by_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_select_shelter_by_id]
(
	@ShelterId		[int]
)
AS
	BEGIN
		SELECT
			[ShelterId],
			[ShelterName],
			[Address],
			[AddressTwo],
			[Zipcode],
			[Phone],
			[Email],
			[Areasofneed],
			[ShelterActive]
		FROM	[dbo].[Shelter]
		WHERE	@ShelterId		=	[ShelterId]
		ORDER BY [ShelterId] DESC
	END
GO

/* Add a shelter AddShelter-615 */
print '' print '*** Creating sp_add_shelter (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_add_shelter]
(
	@ShelterName	[nvarchar](50),
	@Address		[nvarchar](50),
	@AddressTwo		[nvarchar](50),
	@Zipcode		[char](9),
	@Phone			[nvarchar](13),
	@Email			[nvarchar](254),
	@Areasofneed	[nvarchar](max),
	@ShelterActive	[bit]
)
AS
	BEGIN
		INSERT INTO [dbo].[Shelter]
		([ShelterName],		[Address],		[AddressTwo],		[Zipcode],		[Phone],	[Email],	[Areasofneed],		[ShelterActive])
		VALUES(
		@ShelterName,	@Address,	@AddressTwo,	@Zipcode,	@Phone,	@Email,	@Areasofneed,	@ShelterActive
		);
		SELECT
			[ShelterId],
			[ShelterName],
			[Address],
			[AddressTwo],
			[Zipcode],
			[Phone],
			[Email],
			[Areasofneed],
			[ShelterActive]
		FROM [dbo].[Shelter]
		WHERE	@ShelterName = ShelterName
		RETURN	@@ROWCOUNT
	END
GO

/* Edit selected shelter EditShelter-616 */

/* Edit shelter Name */
print '' print '*** Creating sp_edit_shelter_name_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_shelter_name_by_shelter_id]
(
	@ShelterId		[int],
	@oldName		[nvarchar](50),
	@newName		[nvarchar](50)
)
AS
	BEGIN
		UPDATE		[dbo].[Shelter]
			SET		[ShelterName]	=	@newName
		WHERE		@ShelterId		=	[ShelterId]
			AND		@oldName		=	[ShelterName]
		RETURN	@@ROWCOUNT
	END
GO


/* Edit shelter Address */
print '' print '*** Creating sp_edit_address_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_address_by_shelter_id]
(
	@ShelterId		[int],
	@oldAddress		[nvarchar](50),
	@newAddress		[nvarchar](50)
)
AS
	BEGIN
		UPDATE		[dbo].[Shelter]
			SET		[Address]		=	@newAddress
		WHERE		@ShelterId		=	[ShelterId]
			AND		@oldAddress		= [Address]
		RETURN	@@ROWCOUNT
	END
GO

/* Edit shelter AddressTwo */
print '' print '*** Creating sp_edit_addresstwo_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_addresstwo_by_shelter_id]
(
	@ShelterId			[int],
	@newAddressTwo		[nvarchar](50)
)
AS
	BEGIN
		UPDATE	[dbo].[Shelter]
			SET	[AddressTwo]	=	@newAddressTwo
		WHERE	@ShelterId		=	[ShelterId]
		RETURN	@@ROWCOUNT
	END
GO

/*
OMITTING THIS BECAUSE CITY/STATE ARE NOT PROPERTIES OF SHELTER
Thesre are supposed to be pulled from Zipcode, I think
sp_edit_state_by_shelter_id
*/

/*
OMITTING THIS BECAUSE CITY/STATE ARE NOT PROPERTIES OF SHELTER
Thesre are supposed to be pulled from Zipcode, I think
sp_edit_city_by_shelter_id
*/

/* Edit Shelter Zipcode */
print '' print '*** Creating sp_edit_zipcode_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_zipcode_by_shelter_id]
(
	@ShelterId		[int],
	@oldZipcode		[char](9),
	@newZipcode		[char](9)
)
AS
	BEGIN
		UPDATE	[dbo].[Shelter]
			SET [Zipcode]		=	@newZipcode
		WHERE	@ShelterId		=	[ShelterId]
			AND	@oldZipcode		=	[Zipcode]
		RETURN	@@ROWCOUNT
	END
GO

/* Edit Shelter Phone Number */
print '' print '*** Creating sp_edit_phone_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_phone_by_shelter_id]
(
	@ShelterId		[int],
	@newPhone		[nvarchar](13)
)
AS
	BEGIN
		UPDATE	[dbo].[Shelter]
			SET [Phone]		=	@newPhone
		WHERE	@ShelterId	=	[ShelterId]
		RETURN	@@ROWCOUNT
	END
GO

/* Edit Shelter Email Address */
print '' print '*** Creating sp_edit_email_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_email_by_shelter_id]
(
	@ShelterId		[int],
	@newEmail		[nvarchar](254)
)
AS
	BEGIN
		UPDATE	[dbo].[Shelter]
			SET [Email]		=	@newEmail
		WHERE	@ShelterId	=	[ShelterId]
		RETURN	@@ROWCOUNT
	END
GO

/*
This is a separate workload for someone else to take up
sp_edit_hours_of_operation_by_shelter_id
*/

/*
OMITTING THIS BECAUSE MISSION STATEMENT IS NO LONGER PART OF SHELTER
sp_edit_mission_statement_by_shelter_id
*/

/* Update Shelter Areas of Need */
print '' print '*** Creating sp_edit_areas_of_need_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_areas_of_need_by_shelter_id]
(
	@ShelterId		[int],
	@newAreasofneed	[nvarchar](max)
)
AS
	BEGIN
		UPDATE	[dbo].[Shelter]
			SET [Areasofneed]		=	@newAreasofneed
		WHERE	@ShelterId			=	[ShelterId]
		RETURN	@@ROWCOUNT
	END
GO

/* Update Shelter Active */
print '' print '*** Creating sp_edit_shelter_active_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_edit_shelter_active_by_shelter_id]
(
	@ShelterId			[int],
	@oldShelterActive	[bit],
	@newShelterActive	[bit]
)
AS
	BEGIN
		UPDATE	[dbo].[Shelter]
			SET [ShelterActive]		=	@newShelterActive
		WHERE	@ShelterId			=	[ShelterId]
			AND	@oldShelterActive	=	[ShelterActive]
		RETURN	@@ROWCOUNT
	END
GO

/*
Delete (Disable) a shelter DeleteShelter-617
This is somewhat redundant with sp_edit_shelter_active_by_shelter_id, so this simply sets the ShelterActive bit to false
*/
print '' print '*** Creating sp_deactivate_shelter_by_shelter_id (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_deactivate_shelter_by_shelter_id]
(
	@ShelterId		[int]
)
AS
	BEGIN
		UPDATE	[dbo].[Shelter]
			SET [ShelterActive]		=	0
		WHERE	@ShelterId			=	[ShelterId]
		RETURN	@@ROWCOUNT
	END
GO