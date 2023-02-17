/* Created by: Molly Meister */
USE [PetNet_db_am]

print '' print '*** creating sp_view_all_animals'
GO
CREATE PROCEDURE [dbo].[sp_view_all_animals]
AS
	BEGIN
		SELECT AnimalId, AnimalName, AnimalTypeId, AnimalBreedId, Personality,
				Description, AnimalStatusId, RecievedDate, MicrochipSerialNumber, Aggressive, 
				AggressiveDescription, ChildFriendly, NeuterStatus, Notes
		FROM Animal
	END
GO