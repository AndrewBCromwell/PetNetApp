print '' print '*** using PetNet_db_am'
GO
USE [PetNet_db_am]
GO

/* Created By: Asa Armstrong */
print '' print '*** Creating sp_add_animal_dod_by_medical_record_id'
GO
CREATE PROCEDURE [dbo].[sp_add_animal_dod_by_medical_record_id]
(
	@UsersId int,
	@AnimalId int,
	@DeathDate datetime,
	@DeathCause nvarchar(100),
	@DeathDisposal nvarchar(100),
	@DeathDisposalDate datetime,
	@DeathNotes nvarchar(500)
)
AS
	BEGIN
		INSERT INTO [dbo].[Death]
			([UsersId], [AnimalId], [DeathDate], [DeathCause], [DeathDisposal], [DeathDisposalDate], [DeathNotes])
		VALUES
			(@UsersId, @AnimalId, @DeathDate, @DeathCause, @DeathDisposal, @DeathDisposalDate, @DeathNotes)
	END
GO

/* Created By: Asa Armstrong */
print '' print '*** Creating sp_edit_animal_dod_by_medical_record_id'
GO