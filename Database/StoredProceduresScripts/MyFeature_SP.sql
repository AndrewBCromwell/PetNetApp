USE [SomeDatabase_db]
GO

/***************************************************************
I.R. Stoodent
Created: 2023/01/22

Description:
File containing the stored procedures for Add_Event use case
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/

print '' print '*** creating sp_insert_event ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_event]
(
	@EventName			nvarchar(50),
	@EventDescription	nvarchar(1000),
	@TotalBudget		money
)
AS
	BEGIN
		INSERT INTO [dbo].[Event]
		(
			[EventName],			
			[EventDescription],
			[TotalBudget]
		)
		VALUES
		(
			@EventName, 
			@EventDescription,
			@TotalBudget
		)		
	END	
GO

