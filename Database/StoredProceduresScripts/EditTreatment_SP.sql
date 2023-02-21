/***************************************************************
Matthew Meppelink
Created: 2023/02/16

Description:
File containing the stored procedures for EditTreatment use case
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/
USE [PetNet_db_am]
GO

print '' print '*** creating sp_update_medical_treatment'
DROP PROCEDURE IF EXISTS [dbo].[sp_update_medical_treatment]  
GO
CREATE PROCEDURE [dbo].[sp_update_medical_treatment]
(
	@recordId				int,
    @newDiagnosis                      nvarchar(250),
    @newMedicalNotes                   nvarchar(250)
)
AS
	BEGIN
		UPDATE  [MedicalRecord] SET
        [Diagnosis] = @newDiagnosis,
        [MedicalNotes] = @newMedicalNotes
        WHERE @recordId = [MedicalRecordId]
	END
GO
