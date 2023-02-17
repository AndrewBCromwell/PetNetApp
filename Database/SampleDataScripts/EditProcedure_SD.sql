/***************************************************************
Andrew Cromwell
Created: 2023/02/16

Description:
File containing sample data for the EditProcedureUseCase
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/

USE [PetNet_db_am]
GO

print '' print '*** Inserting MedProcedure Records'
GO
INSERT INTO [dbo].[MedProcedure]
		(
		[MedicalRecordId],
		[UsersId],
		[MedProcedureName],
		[MedicationsAdministered],
		[MedProcedureNotes],
		[MedProcedureDate],
		[medProcedureTime]
		)
	VALUES
		(100000, 100000, "Stitches", "anesthesia", "Went well", '2023-02-15', '04:35:22'),
		(100000, 100000, "Colonoscopy", "anesthesia, Laxitive", "Messy", '2023-02-16', '05:35:22'),
		(100001, 100003, "Heart Surgery", "anesthesia", "Messy", '2023-02-16', '03:35:22'),
		(100002, 100001, "Bone setting", "anesthesia", "Must wear a splint for 2 weeks", '2023-02-16', '05:35:22'),
		(100002, 100002, "Kidney transplant", "anesthesia, antibiotics", "minor complications", '2023-02-16', '03:35:22'),
		(100002, 100003, "Stitches", "anesthesia", "27 stitches", '2023-02-16', '07:35:22'),
		(100003, 100002, "Heart Surgery", "anesthesia", "Messy", '2023-02-16', '04:54:22')
GO