/*
CREATE TABLE [dbo].[ShelterInventoryItem] (
	
	[ShelterId]					[int]			NOT NULL,
	[ItemId]					[nvarchar](50)	NOT NULL,
	
	[Quantity]					[int]			NOT NULL DEFAULT 0,
	[UseStatistic]				[decimal](4,2)	NULL,
	[LastUpdated]				[date]			NOT NULL DEFAULT GETDATE(),
	[LowInventoryThreshold]		[int]			NULL,
	[HighInventoryThreshold]	[int]			NULL,
	
	[InTransit]					[bit]			NOT NULL DEFAULT 0,
	[Urgent]					[bit]			NOT NULL DEFAULT 0,
	[Processing]				[bit]			NOT NULL DEFAULT 0,
	[DoNotOrder]				[bit]			NOT NULL DEFAULT 0,
	[CustomFlag]				[nvarchar](250)	NULL,
	
	CONSTRAINT	[fk_ShelterInventoryItem_ShelterId] FOREIGN KEY ([ShelterId])
		REFERENCES [dbo].[Shelter]([ShelterId]),
	CONSTRAINT	[fk_ShelterInventoryItem_ItemId] FOREIGN KEY ([ItemId])
		REFERENCES [dbo].[Item]([ItemId]) ON UPDATE CASCADE,
	CONSTRAINT	[pk_ShelterInventoryItem_ShelterId_ItemId] PRIMARY KEY ([ItemId], [ShelterId])
)
GO
*/

USE [PetNet_db_am]

DROP PROCEDURE IF EXISTS dbo.sp_update_shelterInventoryItem;  
GO
print '' print '*** Creating sp_update_shelterInventoryItem'
GO
CREATE PROCEDURE [dbo].[sp_update_shelterInventoryItem]
(
	@ShelterId					[int],
	@ItemId						[nvarchar](50),
	@Quantity					[int],
	@UseStatistic				[decimal](4,2),
	@LastUpdated				[date],
	@LowInventoryThreshold		[int],
	@HighInventoryThreshold		[int],
	@InTransit					[bit],
	@Urgent						[bit],
	@Processing					[bit],
	@DoNotOrder					[bit],
	@CustomFlag					[nvarchar](250)
	
	
)
AS
	BEGIN
			UPDATE 	[ShelterInventoryItem]
			   SET 	[Quantity] = 				@Quantity,
					[UseStatistic] =			@UseStatistic,
					[LastUpdated] = 			@LastUpdated,
					[LowInventoryThreshold] = 	@LowInventoryThreshold,
					[HighInventoryThreshold] = 	@HighInventoryThreshold,
					[InTransit] = 				@InTransit,
					[Urgent] = 					@Urgent,
					[Processing] = 				@Processing,
					[DoNotOrder] = 				@DoNotOrder,
					[CustomFlag] = 				@CustomFlag
					
			WHERE	[ShelterId] = 				@ShelterId
			  AND	[ItemId] = 					@ItemId
			  
			  
			  
			  
			  SELECT 	[ShelterInventoryItem].[ShelterId],
				[ShelterInventoryItem].[ItemId],
				[Quantity],
				[UseStatistic],
				[LastUpdated],
				[LowInventoryThreshold],
				[HighInventoryThreshold],
				[InTransit],
				[Urgent],
				[Processing],
				[DoNotOrder],
				[CustomFlag],
				[ShelterName]
				
				
				
		FROM [dbo].[ShelterInventoryItem]
		JOIN [Shelter]
			ON [Shelter].[ShelterId] = [ShelterInventoryItem].[ShelterId]
		WHERE [ShelterInventoryItem].[ShelterId] = @ShelterId
		AND	  [ShelterInventoryItem].[ItemId] = @ItemId
			  
			 
		
	END
GO
