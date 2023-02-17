/***************************************************************
Andrew Cromwell
Created: 2023/02/10

Description:
File containing sample data for the AddProcedureUseCase
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/

USE [PetNet_db_am]
GO

print '' print '*** Inserting Pronoun Records'
GO
INSERT INTO [dbo].[Pronoun]
		(
		[PronounId]
		)
	VALUES
		("They/Them"),
		("He/She"),
		("He/They"),
		("She/They"),
		("Any/All"),
		('Other')
GO

print '' print '*** creating test data for Users '
GO
INSERT INTO [dbo].[Users]
		(
		[GenderId], 
		[PronounId], 
		[ShelterId], 
		[GivenName], 
		[FamilyName], 
		[Email],
		[Address], 
		[AddressTwo], 
		[Zipcode], 
		[Phone]
		)
    VALUES
		("Unknown", "He/She", 100000, "Mads", "Rhea", "madsrhea@company.com", "811 Kirkwood Parkway", "Apt 207", '50001', "3195943138"),
		("Male", "He/Him", 100000, "Stephen", "Jaurigue", "stephenjaurigue@company.com", "123 Kirkwood Parkway", "Apt 210", "50001", "3195555555"),
		("Female", "She/Her", 100000, "Molly", "Meister", "mollymeister@company.com", "456 Kirkwood Parkway", "Apt 256", "50001", "3196666666"),
		('Male', 'He/Him', 100000, 'Tyler', 'Hand', 'tylerhand@company.com', '789 Kirkwood Parkway', 'Apt 240', '50002', '3197777777')
GO

print '' print '*** creating Animal sample data'
GO 
INSERT INTO [dbo].[Animal]
		(
		[AnimalName], 
		[AnimalGender], 
		[AnimalTypeId], 
		[AnimalBreedId], 
		[Personality], 
		[Description], 
		[AnimalStatusId],		
		[RecievedDate], 
		[MicrochipSerialNumber], 
		[Aggressive], 
		[AggressiveDescription], 
		[ChildFriendly], 
		[NeuterStatus], 
		[Notes], 
		[AnimalShelterId]
		)
	VALUES
		("Bart", "Female", "Dog", "Lab", "Friendly", "Great dog rescued", "Healthy", "2022-12-15", "dhqaf2", 0, "Not aggressive", 1, 1, "Very Cute", 100000), 
		("Spot", "Female", "Dog", "Lab", "Friendly", "Great dog rescued", "Healthy", "2022-12-15", "afthee", 0, "Not aggressive", 1, 1, "Very Cute", 100000),
		("Ruffer", "Male", "Dog", "Lab", "Friendly", "Great dog rescued", "Healthy", "2022-12-15", "yrqwgh", 0, "Not aggressive", 1, 1, "Very Cute", 100000),
		("Buddy", "Male", "Dog", "Lab", "Friendly", "Great dog rescued", "Healthy", "2022-12-15", "jdfghjt", 0, "Not aggressive", 1, 1, "Very Cute", 100000)
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