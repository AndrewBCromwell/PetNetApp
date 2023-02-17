/***************************************************************
William Rients
Created: 2023/02/16

Description:
File containing sample data for the View all tickets feature: 
****************************************************************/

USE [PetNet_db_am]
GO

print '' print '*** Creating Ticketstatus sample data'

GO
INSERT INTO [dbo].[Ticketstatus]
		(
		TicketStatusId
		)
	VALUES
		('Open'),
		('Closed')
GO


USE [PetNet_db_am]
GO

print '' print '*** Creating Ticket sample data'

GO
INSERT INTO [dbo].[Ticket]
		(
		[UsersId], 
		[TicketStatusId], 
		[TicketTitle],
		[TicketActive]
		)
	VALUES
		(100000, 'Open', 'Need to fix account', 1),
		(100001, 'Closed', 'Want to speak with admin', 1),
		(100002, 'Closed', 'Want to change username', 1)
GO