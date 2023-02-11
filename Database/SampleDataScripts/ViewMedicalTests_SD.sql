USE [PetNet_db_am]
GO


print '' print '*** Using PetNet_db_am'
USE [PetNet_db_am]
GO 


print '' print '*** creating Shelter sample data'
GO 
INSERT INTO [dbo].[Shelter]
	(
    [ShelterName],
    [Address],
    [Zipcode],
    [Phone],
    [Email],
    [Areasofneed],
    [ShelterActive]
    )
VALUES
("S1", "111 Shelter Drive", 50001, "123-123-1111", "shelter1@shelter.com", "Animal Food", 1),
("S2", "112 Shelter Drive", 50002, "123-123-1112", "shelter2@shelter.com", "Animal Medicine", 1),
("S3", "113 Shelter Drive", 50001, "123-123-1113", "shelter3@shelter.com", "Kitty Litter", 1)
GO


print '' print '*** creating Animal Type sample data'
GO 
INSERT INTO [dbo].[AnimalType]
([AnimalTypeId])
VALUES
("Bird"),
("Rodent"),
("Alpacha")
GO

print '' print '*** creating AnimalBreed sample data'
GO 
INSERT INTO [dbo].[AnimalBreed]
([AnimalBreedId])
VALUES
("Rabbit"),
("Dragon"),
("Unknown")

print '' print '*** creating Animal sample data'
GO 
INSERT INTO [dbo].[Animal]
([AnimalName],[AnimalGender],[AnimalTypeId],[AnimalBreedId],[Personality],[Description],[AnimalStatusId],[MicrochipSerialNumber],[Aggressive],[AggressiveDescription],[ChildFriendly],[NeuterStatus],[Notes])
VALUES
("Fred","Male","Rodent","Rabbit","Friendly","Loves chasing cats","Healthy",'15afg23bd7qrty9',0,"",1,0,"Loves Bubbles"),
("Xander","Male","Alpacha","Unknown","Friendly","Loves other Alpacha","Healthy",'15afg23bd7qrtz0',0,"",1,0,"Isn't a llama"),
("Nicholas","Male","Bird","Dragon","Friendly","Best Pokemon Trainer","Healthy",'15afg23bd7qrtz1',0,"",1,0,"Can transform into a human")
GO

print '' print '*** creating MedicalRecord sample data'
GO 
INSERT INTO [dbo].[MedicalRecord]
([AnimalId],[MedicalNotes],[MedProcedure],[Test],[Vaccination],[Prescription],[Images],[QuarantineStatus],[Diagnosis])
VALUES
(100000,"Routine Checkup",0,1,0,0,0,0,"Alls well that ends well"),
(100000,"Routine Checkup",0,1,0,0,0,0,"Ditto"),
(100001,"Alpacha my bags",0,1,0,0,0,0,"and go"),
(100000,"Slight sickness",0,1,0,0,0,1,"Covid 19"),
(100002,"Coughing Fireballs",0,1,0,0,0,0,"Normal Dragon Stuff"),
(100002,"Stopped Coughing Fireballs",0,1,0,0,0,0,"Okay now we worry")
GO

print '' print '*** creating Test sample data'
GO 
INSERT INTO [dbo].[Test]
([MedicalRecordId],[UsersId],[TestName],[TestAcceptableRange],[TestResult],[TestNotes])
VALUES
(100000,100000,"General Sickness Check","negative on all accounts","negative","Animal is healthy"),
(100001,100000,"General Sickness Check","negative on all accounts","negative","Animal is still healthy"),
(100002,100000,"General Sickness Check","negative on all accounts","negative","Animal is healthy"),
(100003,100000,"General Sickness Check","negative on all accounts","Covid 19 tested positive","Animal is quaranteened"),
(100004,100000,"Throat infection Check","negative on all accounts","negative","Animal is healthy"),
(100005,100000,"Throat infection Check","negative on all accounts","Has Strep","Animal has been prescribed medicine")
GO
