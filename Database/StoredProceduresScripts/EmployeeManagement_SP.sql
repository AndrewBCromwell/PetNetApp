/***************************************************************
Hoang Chu
Created: 2023/01/10

Description:
File containing the stored procedures for Add_Event use case
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/

USE [PetNet_db_am]
GO

DROP PROCEDURE IF EXISTS dbo.sp_select_users_by_roleId;  
GO

print '' print '*** creating sp_select_all_employees (Hoang Chu)'
GO
CREATE PROCEDURE [dbo].[sp_select_all_employees]
AS
    BEGIN
        SELECT [Users].[UsersId], [GenderId], [PronounId], [ShelterId], [GivenName], [FamilyName],
                [Email], [Address], [AddressTwo], [Zipcode], [Phone], [CreationDate], 
                [Active], [Suspended]    
        FROM [Users]
        -- JOIN [UserRoles]
        --   ON [Users].[UsersId] = [UserRoles].[UsersId]
        -- WHERE [RoleId] = 'Employee'
    END
GO