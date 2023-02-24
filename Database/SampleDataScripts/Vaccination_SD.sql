/*Created by Zaid Rachman*/
USE [PetNet_db_am]


print '' print '*** Inserting sample vaccine data'
GO
INSERT INTO [dbo].[Vaccination]
	([MedicalRecordID],[UsersId],[VaccineName],[VaccineAdminsterDate])
	VALUES
	(100000, 100000, 'Testing', '2018-09-23'),
	(100000, 100000, 'Testing, ', '2018-09-25'),
	(100001, 100000, 'test2', '2018-10-23'),
	(100002, 100000, 'test3', '2018-11-23')
GO