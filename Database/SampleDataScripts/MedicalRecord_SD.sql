/***************************************************************
Andrew Cromwell
Created: 2023/02/10

Description:
File containing sample data for the MedicalRecordTable
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/

USE [PetNet_db_am]
GO

print '' print '*** Creating MedicalRecord name sample data'

GO
INSERT INTO [dbo].[MedicalRecord]
		(
		[AnimalId],
		[Date],
		[MedicalNotes], -- letting the bit feilds default to 0
		[Diagnosis]
		)
	VALUES
		(100000, '20230206 10:10:10 AM', "Notes", "Animal is healthy"),
		(100001, '20230207 10:10:10 PM', "Notes", "Animal can be adopted"),
		(100002, '20230208 11:11:11 AM', "No Notes", "More tests needed"),
		(100003, '20230209 11:11:11 AM', "More Notes", "A cat in disguise")
GO