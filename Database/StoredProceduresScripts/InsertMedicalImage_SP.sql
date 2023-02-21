USE [PetNet_db_am]

/* created by Molly Meister */
print '' print '*** Creating sp_insert_animal_medical_images_by_medical_animal_id'
GO

CREATE PROCEDURE [dbo].[sp_insert_animal_medical_images_by_animal_id]
(
	@AnimalID			[int],
	@ImageFileName		[nvarchar](50)
)
AS
	BEGIN
	DECLARE @MedicalRecordID	[int]
	DECLARE @ImageID			[int]
		INSERT INTO [dbo].[MedicalRecord]
		(
			[AnimalId], [MedicalNotes], [Images], [Diagnosis]	
		)
		VALUES
			(@AnimalID, "Uploaded Medical Images", 1, "")
			set @MedicalRecordID = SCOPE_IDENTITY()
			
		INSERT INTO [dbo].[Images]
		(
			[ImageFileName]
		)
		VALUES
		(@ImageFileName)
		set @ImageID = SCOPE_IDENTITY()
		
		INSERT INTO [dbo].[AnimalMedicalImage]
		(
			[ImageId], [MedicalRecordId]
		)
		VALUES
		(@ImageID, @MedicalRecordID)
		
		RETURN @@ROWCOUNT
	END
GO