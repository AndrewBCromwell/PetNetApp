/***************************************************************
Hoang Chu
Created: 2023/02/16

Description:
File containing the stored procedures for Add_Event use case
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/

USE [PetNet_db_am]
GO

print '' print '*** creating sp_select_animal_profile_if_adoptable (Hoang Chu)'
GO
CREATE PROCEDURE [dbo].[sp_select_animal_profile_if_adoptable]
(
    @AnimalId                   [int]
)
AS
	BEGIN
		SELECT [AnimalId], [AnimalName], [AnimalGender], [AnimalTypeId], [AnimalBreedId],		
            [Personality], [Description], [AnimalStatusId], [RecievedDate], [MicrochipSerialNumber], 	
            [Aggressive], [AggressiveDescription], [ChildFriendly], [NeuterStatus], [Notes]		
        FROM [Animal]
        WHERE [AnimalId] = @AnimalId			
	END
GO