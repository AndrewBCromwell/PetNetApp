/***************************************************************
Mads Rhea
Created: 2023/03/29

Description:
File contains 
    - a stored procedure to [sp_select_all_roles]

**************************************************************
Updated by:
Updated: 202-/--/--

Description: ---
****************************************************************/

USE [PetNet_db_am]
GO

print '' print '*** creating [SP_SELECT_ALL_ROLES]'
GO
CREATE PROCEDURE [dbo].[sp_select_all_roles]
AS
	BEGIN
		SELECT 	[RoleID]
		FROM	[Role]
	END
GO