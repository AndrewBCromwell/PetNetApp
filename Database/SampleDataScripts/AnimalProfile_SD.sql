/***************************************************************
Andrew Schneider
Created: 2023/02/10

Description:
File containing the event table
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/


USE [PetNet_db_am]
GO


/* Insert Into Animal table stored procedure */
/* Created by Andrew Schneider */
print '' print '*** adding Animal records (Andrew S.)***'
GO
INSERT INTO dbo.Animal
(	
	[AnimalName], [AnimalGender], [AnimalTypeId], [AnimalBreedId], [Personality], [Description], [AnimalStatusId],		
	[RecievedDate], [MicrochipSerialNumber], [Aggressive], [AggressiveDescription], [ChildFriendly], [NeuterStatus], [Notes]					
)
		
	VALUES
		('Max', 'Male', 'Dog', 'Lab', 'Friendly', 'Great dog rescued', 'Available', '2023-01-01',
		'15A73', 0, 'Not aggressive', 1, 1, 'N/A')
GO
	