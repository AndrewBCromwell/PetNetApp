USE [PetNet_db_am]
GO


print '' print '*** Creating Images sample data'
GO

INSERT INTO [dbo].[Images]
(
	[ImageFileName]
)
VALUES
	("fido.png"), 
	("thisCat.png"),
	("superAwesomeDawg.png")
GO


print '' print '*** Creating MedicalRecord sample data'
GO

INSERT INTO [dbo].[MedicalRecord]
(
	[AnimalId], [MedicalNotes], [MedProcedure], [Test], [Vaccination], [Prescription], 
	[Images], [QuarantineStatus], [Diagnosis]			
)
VALUES
	(100001, "na", 0, 0, 1, 0, 1, 0, "healthy as a horse"),
	(100002, "na", 0, 1, 1, 0, 1, 0, "influenza"),
	(100003, "na", 0, 0, 1, 0, 1, 0, "pox")
GO


print '' print '*** Creating AnimalMedicalImage sample data'
GO

INSERT INTO [dbo].[AnimalMedicalImage]
(
	[ImageId], [MedicalRecordId]
	
)
VALUES
	(100001, 100000),
	(100002, 100001),
	(100003, 100002)
GO
