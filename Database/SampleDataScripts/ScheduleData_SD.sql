USE [PetNet_db_am]


print '' print '*** inserting Users sample data'
GO 
INSERT INTO [dbo].[Users]
	(		
	[GenderId],		
	[PronounId],		
	[ShelterId],		
	[GivenName],		
	[FamilyName],	
	[Email],		
	[Address],		
	[Zipcode],		
	[Phone]
    )
VALUES
('Male',null,100001,'Chris','Dreismeier','Chris@gmail.com','4150 Riverview rd', 50001, '3192948541'),
('Male',null,100001,'Asa','Armstrong','Asa@gmail.com','1234 Chestnut rd', 50001, '3191234321')
GO

print '' print '*** inserting test records job'
GO
INSERT INTO dbo.Job
		([JobDescription])
	VALUES
		('Test Job'),
		('Clean Kennel')
GO



print '' print '*** inserting Schedule sample data'
GO 
INSERT INTO [dbo].[Schedule]
	(		
	[UsersId],		
	[JobId],		
	[StartTime],		
	[EndTime]
    )
VALUES
(100000, 100000, '20230215 08:00:00 AM','20230215 06:00:00 PM' ),
(100000, 100000, '20230216 08:00:00 AM','20230216 06:00:00 PM' ),
(100000, 100000, '20230217 08:00:00 AM','20230217 06:00:00 PM' ),
(100000, 100000, '20230218 08:00:00 AM','20230218 06:00:00 PM' ),
(100001, 100000, '20230215 08:00:00 AM','20230215 06:00:00 PM' ),
(100001, 100000, '20230216 08:00:00 AM','20230216 06:00:00 PM' ),
(100001, 100000, '20230217 08:00:00 AM','20230217 06:00:00 PM' ),
(100001, 100000, '20230218 08:00:00 AM','20230218 06:00:00 PM' )
GO

print '' print '*** inserting UserRole sample data'
GO 
INSERT INTO [dbo].[UserRoles]
	(		
	[RoleId],		
	[UsersId]
    )
VALUES
('Volunteer',100002 ),
('Volunteer',100003 )
GO