/***************************************************************
Hoang Chu
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

print '' print '*** Creating Table AnimalUpdates sample data'

GO
INSERT INTO [dbo].[AnimalUpdates]
		(
		[AnimalId],
		[AnimalRecordNotes]
		)
	VALUES
		(100000, "This is animal update test 1"),
		(100000, "This is animal update test 2"),
		(100000, "This is animal update test 3"),
		(100000, "This is animal update test 4")
GO