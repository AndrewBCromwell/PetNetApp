print '' print '*** using PetNet_db_am'
GO
USE [PetNet_db_am]
GO


/* Created By: Asa Armstrong */
print '' print '*** Creating sp_remove_animal_from_animalkenneling_by_kennelId_and_animalId'
GO
CREATE PROCEDURE [dbo].[sp_remove_animal_from_animalkenneling_by_kennelId_and_animalId]
(
	@KennelId	int,
	@AnimalId	int
)
AS
	BEGIN
		DELETE FROM [dbo].[AnimalKenneling]
		WHERE KennelId 		= @KennelId
			AND AnimalId 	= @AnimalId
		RETURN @@ROWCOUNT
	END
GO

/*
print '' print '*** INSERT'
GO
INSERT INTO AnimalKenneling (KennelId, AnimalId)
VALUES (100001, 100001)
GO


print '' print '*** exec'
GO
EXEC sp_remove_animal_from_animalkenneling_by_kennelId_and_animalId
@KennelId = 100001,
@AnimalId = 100001
GO
*/