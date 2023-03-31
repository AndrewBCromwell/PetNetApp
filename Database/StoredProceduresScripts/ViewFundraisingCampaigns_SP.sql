USE [PetNet_db_am]
GO

print '' print 'Creating sp_select_all_fundraising_campaigns_by_shelterId'
GO

CREATE PROCEDURE [dbo].[sp_select_all_fundraising_campaigns_by_shelterId]
(
	@ShelterId			int
)
AS
	BEGIN
		SELECT [FundraisingCampaignId], [UsersId], [ShelterId], [Title], [StartDate], [EndDate], [Description], [Complete],
				[Active], [AmountRaised], [NumOfAttendees], [NumAnimalsAdopted]
		FROM [FundraisingCampaign]
		WHERE @ShelterId = [ShelterId]
	END
GO