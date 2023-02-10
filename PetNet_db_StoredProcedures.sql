 USE [PetNet_db_am]

DROP PROCEDURE IF EXISTS dbo.sp_select_users_by_roleId;  
GO

print '' print '*** creating sp_select_all_animals'
DROP PROCEDURE IF EXISTS [dbo].[sp_select_all_animals]  
GO
CREATE PROCEDURE [dbo].[sp_select_all_animals]
(
	@AnimalName			[nvarchar](50)
)
AS
	BEGIN
		SELECT  [Animal].[AnimalId], [Animal].[AnimalName] AS 'Animal Name'
        FROM    [dbo].[Animal]
		WHERE   [AnimalName] LIKE '%' + @AnimalName + '%'
	END
GO

print '' print '*** creting sp_insert_procedure_by_medical_record_id'
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_insert_procedure_by_medical_record_id] ;
GO
CREATE PROCEDURE [dbo].[sp_insert_procedure_by_medical_record_id]
(
	@MedicalRecordId	    	int,
	@UserId						int,
	@ProcedureName		    	nvarchar(50),
	@MedicationsAdministered 	nvarchar(100),
	@ProcedureNotes				nvarchar(500),
	@ProcedureDate				datetime,
	@ProcedureTime				TIME
)
AS
	BEGIN
		INSERT INTO [dbo].[MedProcedure]
			([MedicalRecordId],[UsersId],[MedProcedureName],[MedicationsAdministered],
				[MedProcedureNotes],[MedProcedureDate],[MedProcedureTime])
		VALUES
			(@MedicalRecordID,@UserID,@ProcedureName,@MedicationsAdministered,
			@ProcedureNotes,@ProcedureDate,@ProcedureTime)
		;
		
		UPDATE [dbo].[MedicalRecord]
		SET [MedProcedure] = 1
		WHERE [MedicalRecordId] = @MedicalRecordId
		;
	END
GO

print '' print '*** creating sp_select_last_medical_record_id_by_animal_id'
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_get_last_medical_record_by_animal_id]
GO 
CREATE PROCEDURE [dbo].[sp_get_last_medical_record_by_animal_id]
(
	@AnimalId					int 
)
AS
	BEGIN
		SELECT MAX([MedicalRecordId])
		FROM [MedicalRecord]
		WHERE [AnimalId] = @AnimalId
	END
GO