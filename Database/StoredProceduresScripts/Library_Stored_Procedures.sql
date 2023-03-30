print '' print '*** Using PetNet_db_am'
USE [PetNet_db_am]
GO

/*
This stored procedure returns all the items in the Inventory Library, with there tags concatenated together.
Item tags are concatenated with the | (pipe) character, so can be isolated with a String.Split(|)
Logic adapted from https://stackoverflow.com/questions/194852/how-to-concatenate-text-from-multiple-rows-into-a-single-text-string-in-sql-serv/42778050#42778050
*/
print '' print '*** Creating sp_select_all_library_items (Brian Collum)'
GO
CREATE PROCEDURE	[dbo].[sp_select_all_library_items]
AS
	BEGIN
		SELECT	[ItemID], STRING_AGG([CategoryID], '|') WITHIN GROUP(ORDER BY [CategoryID] ASC) AS 'Tags'
		FROM	[dbo].[ItemCategory]
		GROUP BY [ItemID]
	END
GO