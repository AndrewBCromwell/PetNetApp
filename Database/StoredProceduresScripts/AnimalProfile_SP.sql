USE [PetNet_db_am]
GO

/***************************************************************
Andrew Schneider
Created: 2023/02/10

Description:
File containing the stored procedures for Animal Profile use cases
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description:
****************************************************************/


/* SelectAllAnimalBreeds */
/* Created by Andrew Schneider on 2/8/23 */
print '' print '*** creating sp_select_all_animal_breeds (Andrew S.)'
GO
CREATE PROCEDURE [dbo].[sp_select_all_animal_breeds]
AS
	BEGIN
		SELECT [AnimalBreedId], [AnimalBreed].[AnimalTypeId]
		FROM [AnimalBreed]
	END
GO


/* SelectAllAnimalGenders */
/* Created by Andrew Schneider on 2/8/23 */
print '' print '*** creating sp_select_all_animal_genders (Andrew S.)'
GO
CREATE PROCEDURE [dbo].[sp_select_all_animal_genders]
AS
	BEGIN
		SELECT [GenderId]
		FROM [Gender]
	END
GO


/* SelectAllAnimalTypes */
/* Created by Andrew Schneider on 2/8/23 */
print '' print '*** creating sp_select_all_animal_types (Andrew S.)'
GO
CREATE PROCEDURE [dbo].[sp_select_all_animal_types]
AS
	BEGIN
		SELECT [AnimalTypeId]
		FROM [AnimalType]
	END
GO


/* SelectAllAnimalStatuses */
/* Created by Andrew Schneider on 2/8/23 */
print '' print '*** creating sp_select_all_animal_statuses (Andrew S.)'
GO
CREATE PROCEDURE [dbo].[sp_select_all_animal_statuses]
AS
	BEGIN
		SELECT [AnimalStatusId]
		FROM [AnimalStatus]
	END
GO


/* UpdateAnimal stored procedure */
/* Created by Andrew Schneider on 2/8/23 */
print '' print '*** creating sp_update_animal (Andrew S.)'
GO
CREATE PROCEDURE [dbo].[sp_update_animal]
(
	@AnimalId					[int],
	@AnimalShelterId			[int],
	@OldAnimalName				[nvarchar](50),
	@OldAnimalGender			[nvarchar](50),
	@OldAnimalTypeId			[nvarchar](50),
	@OldAnimalBreedId			[nvarchar](50),
	@OldPersonality				[nvarchar](500),
	@OldDescription				[nvarchar](500),
	@OldAnimalStatusId			[nvarchar](50),
	@OldReceivedDate			[date],
	@OldMicrochipSerialNumber	[char](15),
	@OldAggressive				[bit],
	@OldAggressiveDescription	[nvarchar](500),
	@OldChildFriendly			[bit],
	@OldNeuterStatus			[bit],
	@OldNotes					[nvarchar](500),
	@NewAnimalName				[nvarchar](50),
	@NewAnimalGender			[nvarchar](50),
	@NewAnimalTypeId			[nvarchar](50),
	@NewAnimalBreedId			[nvarchar](50),
	@NewPersonality				[nvarchar](500),
	@NewDescription				[nvarchar](500),
	@NewAnimalStatusId			[nvarchar](50),
	@NewReceivedDate			[date],
	@NewMicrochipSerialNumber	[char](15),
	@NewAggressive				[bit],
	@NewAggressiveDescription	[nvarchar](500),
	@NewChildFriendly			[bit],
	@NewNeuterStatus			[bit],
	@NewNotes					[nvarchar](500)
)
AS
	BEGIN
		UPDATE	[Animal]
		SET		[AnimalName] 			= @NewAnimalName,
				[AnimalGender] 			= @NewAnimalGender,
				[AnimalTypeId] 			= @NewAnimalTypeId,
				[AnimalBreedId] 		= @NewAnimalBreedId,
				[Personality] 			= @NewPersonality,
				[Description]			= @NewDescription,
				[AnimalStatusId] 		= @NewAnimalStatusID,
				[RecievedDate] 			= @NewReceivedDate,
				[MicrochipSerialNumber] = @NewMicrochipSerialNumber,
				[Aggressive] 			= @NewAggressive,
				[AggressiveDescription] = @NewAggressiveDescription,
				[NeuterStatus]          = @NewNeuterStatus,
				[Notes]          		= @NewNotes
		WHERE	[AnimalId] 				= @AnimalId
		  AND	[AnimalShelterId]		= @AnimalShelterId
		  AND	[AnimalName] 			= @OldAnimalName
		  AND	[AnimalGender] 			= @OldAnimalGender
		  AND	[AnimalTypeId] 			= @OldAnimalTypeId
		  AND	[AnimalBreedId] 		= @OldAnimalBreedId
		  AND	[Personality] 			= @OldPersonality
		  AND	[Description]			= @OldDescription
		  AND	[AnimalStatusId] 		= @OldAnimalStatusID
		  AND	[RecievedDate] 			= @OldReceivedDate
		  AND   [MicrochipSerialNumber] = @OldMicrochipSerialNumber
		  AND   [Aggressive] 			= @OldAggressive
		  AND	[AggressiveDescription] = @OldAggressiveDescription
		  AND   [NeuterStatus]          = @OldNeuterStatus		
		  AND   [Notes]          		= @OldNotes
		RETURN @@ROWCOUNT
	END
GO


/* SelectAnimalByAnimalId stored procedure */
/* Created by Andrew Schneider */
print '' print '*** creating sp_select_animal_by_animalId (Andrew S.)'
GO
CREATE PROCEDURE [dbo].[sp_select_animal_by_animalId]
(
	@AnimalId					[int],
	@AnimalShelterId			[int]
)
AS
	BEGIN
		SELECT	[Animal].[AnimalId], [AnimalName], [AnimalGender], [Animal].[AnimalTypeId], [AnimalBreedId],
				[Kennel].[KennelName], [Personality], [Description], [Animal].[AnimalStatusId],
				[AnimalStatus].[AnimalStatusDescription], [RecievedDate], [MicrochipSerialNumber],
				[Aggressive], [AggressiveDescription], [ChildFriendly], [NeuterStatus], [Notes], [AnimalShelterId]
		FROM 	[Animal]
		JOIN 	[AnimalStatus]
			ON 	[Animal].[AnimalStatusID] = [AnimalStatus].[AnimalStatusID]
		LEFT JOIN 	[AnimalKenneling]
			ON	[Animal].[AnimalId] = [AnimalKenneling].[AnimalId]
		LEFT JOIN	[Kennel]
			ON	[AnimalKenneling].[KennelId] = [Kennel].[KennelId]
		WHERE	@AnimalId = [Animal].[AnimalId]
		AND		@AnimalShelterId = [Animal].[AnimalShelterId]
	END
GO


/* InsertAnimal stored procedure */
/* Created by John */
print '' print '*** creating sp_insert_animal (John)'
	GO
	CREATE PROCEDURE [dbo].[sp_insert_animal]
	(
		@AnimalShelterId			[int],
		@AnimalName					[nvarchar](50),
		@AnimalGender				[nvarchar](50),
		@AnimalTypeId				[nvarchar](50),
		@AnimalBreedId				[nvarchar](50),
		@Personality				[nvarchar](500),
		@Description				[nvarchar](500),
		@AnimalStatusId				[nvarchar](50),
		@ReceivedDate				[date],
		@MicrochipSerialNumber		[char](15),
		@Aggressive					[bit],
		@AggressiveDescription		[nvarchar](500),
		@ChildFriendly				[bit],
		@NeuterStatus				[bit],
		@Notes						[nvarchar](500)	
	)

	AS
		BEGIN
			INSERT INTO [dbo].[Animal]
			([AnimalName],[AnimalGender],[AnimalTypeId],[AnimalBreedId],[Personality],[Description]
				,[AnimalStatusId],[RecievedDate],[MicrochipSerialNumber],[Aggressive]
				,[AggressiveDescription],[ChildFriendly],[NeuterStatus],[Notes], [AnimalShelterId])
			VALUES
			(@AnimalName,@AnimalGender,@AnimalTypeId,@AnimalBreedId,@Personality,@Description
			,@AnimalStatusId,@ReceivedDate,@MicrochipSerialNumber,@Aggressive
			,@AggressiveDescription,@ChildFriendly,@NeuterStatus,@Notes, @AnimalShelterId)
		END
	GO