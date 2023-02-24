USE [PetNet_db_am]

DROP PROCEDURE IF EXISTS dbo.sp_insert_medical_record;  
GO
print '' print '*** Creating sp_insert_medical_record'
GO
CREATE PROCEDURE [dbo].[sp_insert_medical_record]
(
	@AnimalId					int
)
AS
	BEGIN
		INSERT INTO [dbo].[MedicalRecord]
			([AnimalId],[MedicalNotes],[Vaccination],[Diagnosis])
		VALUES
			(@AnimalId,'Empty', 1, 'Empty')
			SELECT SCOPE_IDENTITY()
	END
GO
