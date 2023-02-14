/* check whether the database exists, if so, drop it */

IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'PetNet_db_am')
BEGIN
	DROP DATABASE PetNet_db_am
	print '' print '*** dropping database PetNet_db_am'
END
GO

print '' print '*** creating database PetNet_db_am'
GO
CREATE DATABASE PetNet_db_am
GO

print '' print '*** using PetNet_db_am'
GO
USE [PetNet_db_am]
GO

/* ExpenseCategory table */
/* Created by: Andrew S. */
print '' print '*** creating ExpenseCategory table'
GO
CREATE TABLE [dbo].[ExpenseCategory]
(
	[ExpenseCategoryID]		[int]	IDENTITY(100000,1)	NOT NULL,
	[ExpenseCategoryName]	[nvarchar](50)	UNIQUE		NOT NULL,
	CONSTRAINT [pk_ExpenseCategoryID] PRIMARY KEY ([ExpenseCategoryID])
)
GO

--print '' print '*** adding ExpenseCategory records ***'
GO
INSERT INTO dbo.ExpenseCategory
		([ExpenseCategoryName])
	VALUES
		('Animal food'),
		('Animal medicine'),
		('Supplies'),
		('Payroll'),
		('Insurance'),
		('Employee benefit program'),
		('Rent'),
		('Utilities'),
		('Marketing'),
		('Bank fees'),
		('Maintenance repairs'),
		('Legal expenses')
GO
		
/* Job Table */

/* Created by: John */
print '' print '*** creating table for Job (John)'
GO
CREATE TABLE [dbo].[Job] (
    [JobId]                [int]    IDENTITY(100000,1)         NOT NULL,
    [JobDescription]    [nvarchar](50)            
    CONSTRAINT [pk_JobId] PRIMARY KEY([JobId])
)
GO

/* Created by: Oleksiy Fedchuk */
print '' print '*** creating table for TableName Role'
GO
CREATE TABLE [dbo].[Role] (
	[RoleId]		[nvarchar](50) 	NOT NULL,
	[Description]	[nvarchar](250),
	CONSTRAINT [pk_RoleId] PRIMARY KEY([RoleId])
)
GO
--CREATED BY:: Mads Rhea
print '' print '*** creating table for Pronoun (Mads)'
GO
CREATE TABLE [dbo].[Pronoun] (
	[PronounId]		[nvarchar](50)		NOT NULL,
	
	CONSTRAINT [pk_PronounId] PRIMARY KEY([PronounId])
)
GO
/* Image table*/
/* Created by: Andrew Cromwell */
print '' print '** creating Images table'
GO
CREATE TABLE [dbo].[Images] (
	[ImageId] 		[int] IDENTITY(100000,1)	NOT NULL,
	[ImageFileName]		[nvarchar](50)			NOT NULL,
	CONSTRAINT [pk_ImageId] PRIMARY KEY([ImageId]),
	CONSTRAINT [ak_ImageFileName] UNIQUE([ImageFileName])
)
GO

--Created by: Mohmeed Tomsah
print '' print '*** creating ReportMessage table ***'
GO
CREATE TABLE [dbo].[ReportMessage](
	[ReportMessageId]			[int]IDENTITY(100000,1) NOT NULL,
	[ReportMessageDescription]	[nvarchar](250)			NOT NULL,
	CONSTRAINT [pk_ReportMessageId] PRIMARY KEY([ReportMessageId])
)
GO

/* Images test records */
--print '' print '*** inserting Images test records'
GO
INSERT INTO [dbo].[Images]
		([ImageFileName])
	VALUES
		('NotReal.jpeg'),
		('Fake.png')
GO
/* EventType Table */

/* Created by: John */
print '' print '*** creating table for EventType(John)'
GO
CREATE TABLE [dbo].[EventType] (
    [EventTypeId]                [nvarchar](50)            NOT NULL,
    [EventTypeDescription]    [nvarchar](50)                 NOT NULL
    CONSTRAINT [pk_EventTypeId] PRIMARY KEY([EventTypeId])
)

/* ApplicationStatus table*/
/* Created by: Andrew Cromwell */
print '' print '** creating ApplicationStatus table'
GO
CREATE TABLE [dbo].[ApplicationStatus] (
	[ApplicationStatusId] 	[nvarchar](50)			NOT NULL,
	CONSTRAINT [pk_ApplicationStatusId] PRIMARY KEY([ApplicationStatusId])
)
GO

/* ApplicationStatus test records */
--print '' print '*** inserting ApplicationStatus test records'
GO
INSERT INTO [dbo].[ApplicationStatus]
		([ApplicationStatusId])
	VALUES
		('Approved'),
		('Denied'),
		('Pending')
GO


/* HomeOwnership Created by: Asa Armstrong */
print '' print '*** create HomeOwnership table ***'
GO
CREATE TABLE [dbo].[HomeOwnership] (
	[HomeOwnershipId]		[nvarchar](50) 		NOT NULL,
	
	CONSTRAINT [pk_HomeOwnershipId] PRIMARY KEY ([HomeOwnershipId]),
)
GO

--print '' print '*** adding HomeOwnership records ***'
GO
INSERT INTO [dbo].[HomeOwnership]
		([HomeOwnershipId])
	VALUES
		("Own"),
		("Rent")
GO
/*Created By: Zaid Rachman*/
print '' print '*** Creating HomeType Table' 
GO
CREATE TABLE [dbo].[HomeType] (
	[HomeTypeID]	[nvarchar](50)	NOT NULL
	
	
	CONSTRAINT [pk_HomeTypeId] PRIMARY KEY([HomeTypeId])
)
GO
/* BANNED WORD TABLE */
-- Made 2023/01/27 by: Teft Francisco
print '' print '*** creating table for banned words'
GO
CREATE TABLE [dbo].[BannedWord] (
	[BannedWordId]		[nvarchar](50)			NOT NULL,
	CONSTRAINT [pk_BannedWordId] PRIMARY KEY([BannedWordId]),
)	
GO
/* DonationFrequency */
/* Chris D*/
print '' print '*** creating DonationFrequency'
GO
CREATE TABLE [dbo].[DonationFrequency] (
	[DonationFrequencyId]		[nvarchar](50)	NOT NULL,
	CONSTRAINT [pk_DonationFrequencyId] PRIMARY KEY([DonationFrequencyId])
)
GO

/* ContactType */
/* Created by:  Barry Mikulas */
print '' print '*** Creating ContactType'
GO
CREATE TABLE [dbo].[ContactType] (
	[ContactTypeId]		[nvarchar](17)	NOT NULL,

	CONSTRAINT [pk_ContactTypeId] PRIMARY KEY([ContactTypeId] ASC)
)
GO
--print '' print '*** Inserting ContactType Records'
GO
INSERT INTO [dbo].[ContactType]
		([ContactTypeId])
	VALUES
	('Host'),
	('Contact'),
	('Sponsor')	
GO

/* Prescription Type */
/* Created by: William Rients */
print '' print '*** creating table for prescriptionType'
GO
CREATE TABLE [dbo].[prescriptionType] (
	[PrescriptionTypeId]	[nvarchar](50) 	NOT NULL,
	CONSTRAINT [pk_PrescriptionTypeId] PRIMARY KEY([PrescriptionTypeId])
)
GO
/* Prescription Type test records */
--print '' print '*** inserting prescriptionType test records'
GO
INSERT INTO [dbo].[prescriptionType]
	([PrescriptionTypeId])
	VALUES
		('Medication'),
		('Food'),
		('Treatment')
GO

/* Category */
/* Created by Brian Collum */
print '' print '*** creating Category table'
GO
CREATE TABLE [dbo].[Category] (
	[CategoryID]	[nvarchar](50)			NOT NULL,
	CONSTRAINT	[pk_Category]	PRIMARY KEY([CategoryID])
)
GO
--print '' print '*** Inserting sample Category (Inventory item tagging) records'
GO
INSERT INTO [dbo].[Category]
		([CategoryID])
	VALUES
		/* Pet types*/
		  ('Cat')
		, ('Dog')
		, ('Rabbit')
		, ('Rodent')
		, ('Bird')
		, ('Reptile')
		, ('Turtle')
		, ('Lizard')
		/* Generic tags*/
		, ('Food')
		, ('Cleaning')
GO
/* Item table*/
/* Created by: Andrew Cromwell */
print '' print '** creating Item table'
GO
CREATE TABLE [dbo].[Item] (
	[ItemId] 	[nvarchar](50)			NOT NULL,
	CONSTRAINT [pk_ItemId] PRIMARY KEY([ItemId])
)
GO
/* AnimalType */
/* Created by: Matthew Meppelink */
print '' print '*** creating table for AnimalType'
GO
CREATE TABLE [dbo].[AnimalType] (
    [AnimalTypeId]      [nvarchar](50)      NOT NULL,
    CONSTRAINT  [pk_AnimalTypeId] PRIMARY KEY ([AnimalTypeId])   
)
/* Created by: Matthew Meppelink */
--print '' print '*** Inserting AnimalType Records'
GO
INSERT INTO [dbo].[AnimalType]
		([AnimalTypeId])
	VALUES
	('Dog'),
	('Cat'),
	('Snake')	
GO
/* AnimalStatus */
/* Created by: Matthew Meppelink */
print '' print '*** creating table for AnimalStatus'
GO
CREATE TABLE [dbo].[AnimalStatus] (
    [AnimalStatusId]                [nvarchar](50)      NOT NULL,
    [AnimalStatusDescription]       [nvarchar](50)      NULL,
    CONSTRAINT  [pk_AnimalStatusId] PRIMARY KEY ([AnimalStatusId])
)
/* Created by: Matthew Meppelink */
--print '' print '*** Inserting AnimalStatus Records'
GO
INSERT INTO [dbo].[AnimalStatus]
		([AnimalStatusId], [AnimalStatusDescription])
	VALUES
	('Sick', 'Animal is sick'),
	('Healthy', 'Animal is healthy')
GO
/* InventoryChangeReason */
/* Created by: Matthew Meppelink */
print '' print '*** creating table for InventoryChangeReason'
GO
CREATE TABLE [dbo].[InventoryChangeReason] (
    [InventoryChangeReasonId]       [nvarchar](50)      NOT NULL,
    [ReasonDescription]             [nvarchar](250)     NULL,
    CONSTRAINT  [pk_InventoryChangeReasonId] PRIMARY KEY ([InventoryChangeReasonId])
)
/* Created by: Matthew Meppelink */
--print '' print '*** Inserting InventoryChangeReason Records'
GO
INSERT INTO [dbo].[InventoryChangeReason]
		([InventoryChangeReasonId], [ReasonDescription])
	VALUES
	('Check-in', 'Item was checked in'),
	('Check-out', 'Item was checked out')
GO
/* Created by: Alex Oetken */
print '' print '*** creating table for AnimalBreed'
GO

CREATE TABLE [dbo].[AnimalBreed](
	[AnimalBreedId]	[NVARCHAR](50)	NOT NULL,
	CONSTRAINT [pk_AnimalBreedId]	PRIMARY KEY([AnimalBreedId])
)
GO 

--print '' print '*** creating AnimalBreed test records' 
GO 
INSERT INTO [dbo].[AnimalBreed]
		([AnimalBreedId])
VALUES 
('Lab'), 
('Persian'),
('Domestic Shorthair'),
('Parakeet'),
('German Shepard')
GO


/* Author:			Gwen Arman */
print '' print '*** creating Zipcode table'

CREATE TABLE [dbo].[Zipcode] (
	[Zipcode]		[char](9)				NOT NULL,  
	[City]			[nvarchar](50)			NOT NULL,
	[State]			[nvarchar](50)			NOT NULL,
    [Latitude]		[decimal](8,5) 			NOT NULL,
    [Longitude]		[decimal](8,5)			NOT NULL,
	CONSTRAINT [pk_Zipcode]	PRIMARY KEY([Zipcode])
)
GO

print '' print '*** creating TicketStatus table'

/* Author:			Gwen Arman */
CREATE TABLE [dbo].[TicketStatus] (
	[TicketStatusId]		[nvarchar](50)				NOT NULL,  
	CONSTRAINT [pk_TicketStatusId]		PRIMARY KEY([TicketStatusId])
)
GO

print '' print '*** creating AppealStatus table'
/* Author:			Gwen Arman */
CREATE TABLE [dbo].[AppealStatus] (
	[AppealStatusId]		[nvarchar](50)				NOT NULL,  
    [AppealDescription] 	[nvarchar](500)				NOT NULL,
	CONSTRAINT [pk_AppealStatusId]		PRIMARY KEY([AppealStatusId])
)
GO
/* Created by: Alex Oetken */
print '' print '*** creating table for Gender'
GO

CREATE TABLE [dbo].[Gender](
	[GenderId]	[NVARCHAR](50)	NOT NULL,
	CONSTRAINT [pk_GenderId]	PRIMARY KEY([GenderId])
)
GO 

--print '' print '*** creating Gender test records' 
GO 
INSERT INTO [dbo].[Gender]
	([GenderId])
VALUES 
('Female'), 
('Male'),
('Unknown'),
('Other')
GO

--CREATED BY:: Mads Rhea
print '' print '*** creating table for Users (Mads)'
GO
CREATE TABLE [dbo].[Users] (
	[UsersId]		[int] IDENTITY(100000,1) 			NOT NULL,
	[GenderId]		[nvarchar](50) 						NOT NULL,
	[PronounId]		[nvarchar](50) 						NULL,
	[ShelterId]		[int] 								NULL,
	[GivenName]		[nvarchar](50) 						NULL,
	[FamilyName]	[nvarchar](50) 						NOT NULL,
	[Email]			[nvarchar](254) 					NOT NULL,
	[PasswordHash]	[nvarchar](100) 					NOT NULL DEFAULT '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Address]		[nvarchar](50) 						NULL,
	[AddressTwo]	[nvarchar](50) 						NULL,
	[Zipcode]		[char](9) 							NOT NULL,
	[Phone]			[nvarchar](13) 						NULL,
	[CreationDate]	[datetime] 							NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[Active]		[bit] 								NOT NULL DEFAULT 1,
	[Suspended]		[bit] 								NOT NULL DEFAULT 0,

	CONSTRAINT [pk_UsersId] PRIMARY KEY([UsersId]),
	CONSTRAINT [ak_UsersEmail] UNIQUE([Email]),
	CONSTRAINT [fk_UsersGender_GenderId] FOREIGN KEY ([GenderId])
        REFERENCES [Gender]([GenderId]),
	CONSTRAINT [fk_UsersPronoun_PronounId] FOREIGN KEY ([PronounId])
        REFERENCES [Pronoun]([PronounId]),
	CONSTRAINT [fk_UsersZipcode_Zipcode] FOREIGN KEY ([Zipcode])
        REFERENCES [Zipcode]([Zipcode])
)

GO



/* Shelter */
/* Created by:  Barry Mikulas */
print '' print '*** Creating Shelter'
GO
CREATE TABLE [dbo].[Shelter] (
	[ShelterId]					[int] IDENTITY(100000, 1) 	NOT NULL,
	[ShelterName]				[nvarchar](50)				NOT NULL,
	[Address]					[nvarchar](50)				NOT NULL,
	[AddressTwo]				[nvarchar](50)				NULL,
	[Zipcode]					[char](9) 					NOT NULL,
	[Phone]						[nvarchar](13)				NULL,
	[Email]						[nvarchar](254)				NULL,
	[Areasofneed]				[nvarchar](max)				NULL,
	[ShelterActive]				[bit]	DEFAULT 0			NOT NULL,
	CONSTRAINT [pk_ShelterInstitutional_ShelterId] PRIMARY KEY([ShelterId]),
	CONSTRAINT [fk_Shelter_Zipcode] FOREIGN KEY([Zipcode]) REFERENCES [dbo].[Zipcode]([Zipcode])
)
GO


/* Created by: Nathan */
print '' print '*** creating table for Animal'
GO
CREATE TABLE [dbo].[Animal] (
	[AnimalId]					[int]	IDENTITY(100000,1) 	NOT NULL,
	[AnimalName]				[nvarchar](50)				NOT NULL DEFAULT "unamed",
	[AnimalGender]				[nvarchar](50)				NOT NULL DEFAULT "none",
	[AnimalTypeId]				[nvarchar](50)				NOT NULL,
	[AnimalBreedId]				[nvarchar](50)				NOT NULL,
	[Personality]				[nvarchar](500)				NULL,
	[Description]				[nvarchar](500)				NULL,
	[AnimalStatusId]			[nvarchar](50)				NOT NULL,
	[RecievedDate]				[date]						NOT NULL DEFAULT GETDATE(),
	[MicrochipSerialNumber]		[char](15)					NULL,
	[Aggressive]				[bit]						NOT NULL DEFAULT 0,
	[AggressiveDescription]		[nvarchar](500)				NULL,
	[ChildFriendly]				[bit]						NOT NULL DEFAULT 0,
	[NeuterStatus]				[bit]						NOT NULL DEFAULT 0,
	[Notes]						[nvarchar](500)				NULL,
	
	CONSTRAINT [pk_AnimalId] PRIMARY KEY([AnimalId]),
	
	CONSTRAINT [fk_Animal_AnimalGender]FOREIGN KEY ([AnimalGender])
		REFERENCES [dbo].[Gender]([GenderID]) on UPDATE CASCADE,
	CONSTRAINT [fk_Animal_AnimalTypeId]FOREIGN KEY ([AnimalTypeId])
		REFERENCES [dbo].[AnimalType]([AnimalTypeId]) on UPDATE CASCADE,
	CONSTRAINT [fk_Animal_AnimalBreedId]FOREIGN KEY ([AnimalBreedId])
		REFERENCES [dbo].[AnimalBreed]([AnimalBreedId]) on UPDATE CASCADE,
	CONSTRAINT [fk_Animal_AnimalStatusId]FOREIGN KEY ([AnimalStatusId])
		REFERENCES [dbo].[AnimalStatus]([AnimalStatusId]) on UPDATE CASCADE,
	
	CONSTRAINT [ak_MicrochipSerialNumber] UNIQUE([MicrochipSerialNumber])
)
GO


--CREATED BY:: Mads Rhea

print '' print '*** creating table for Post (Mads)'
GO
CREATE TABLE [dbo].[Post] (
	[PostId]			[int]		IDENTITY(100000,1) 	NOT NULL,
	[UserId]			[int]							NOT NULL,
	[PostAuthor]		[int]							NOT NULL,
	[PostContent]		[nvarchar](250)					NOT NULL,
	[PostDate]			[datetime]						NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[PostVisibility]	[bit]							NOT NULL DEFAULT 1,
	
	CONSTRAINT [pk_PostId] PRIMARY KEY([PostId]),
	CONSTRAINT [fk_PostUsers_UserId] FOREIGN KEY ([UserId])
       REFERENCES [dbo].[Users]([UsersId])
)
GO


/* Created by: Hoang Chu*/
print '' print '*** creating table for Event'
GO
CREATE TABLE [dbo].[Event] (
	[EventId]				[int]			IDENTITY(100000,1) 	NOT NULL,
	[Zipcode]				[char](9) 							NOT NULL,
	[EventTypeId]			[nvarchar](50)						NOT NULL,
	[ShelterId]				[int]  								NOT NULL,
	[EventTitle]			[nvarchar](50)						NOT NULL,
	[EventDescription]		[nvarchar](200)						NOT NULL,
	[EventStart]			[datetime]							NOT NULL,
	[EventEnd]				[datetime]							NOT NULL,
	[EventAddress]			[nvarchar](50)						NOT NULL,
	[EventZipcode]			[char](9)							NOT NULL,
	[EventVisible]			[bit]			DEFAULT 1			NOT NULL,
	CONSTRAINT [pk_EventId] PRIMARY KEY([EventId]),
	CONSTRAINT [ak_EventId] UNIQUE([EventId]),
	CONSTRAINT [fk_EventTypeId] FOREIGN KEY([EventTypeId])
		REFERENCES [dbo].[EventType]([EventTypeId]),
	CONSTRAINT [fk_ShelterId] FOREIGN KEY([ShelterId])
		REFERENCES [dbo].[Shelter]([ShelterId]),
	CONSTRAINT [fk_ZipCode] FOREIGN KEY([ZipCode])
		REFERENCES [dbo].[ZipCode]([ZipCode])
)
GO


/* Created by: Hoang Chu*/
print '' print '*** creating table for EventUpDate'
GO
CREATE TABLE [dbo].[EventUpdate] (
	[EventUpdateId]				[int]			IDENTITY(100000,1) 	NOT NULL,
	[EventId]					[int]							 	NOT NULL,
	[EventUpdateTitle]			[nvarchar](50)						NOT NULL,
	[EventUpdateDescription]	[nvarchar](200)						NOT NULL,
	[EventUpdatePostTime]		[datetime]		DEFAULT GETDATE()	NOT NULL,
	[EventVisible]				[bit]			DEFAULT 1			NOT NULL,
	CONSTRAINT [pk_EventUpdateId] PRIMARY KEY([EventUpdateId]),
	CONSTRAINT [ak_EventUpdateId] UNIQUE([EventUpdateId]),
	CONSTRAINT [fk_EventId] FOREIGN KEY([EventId])
		REFERENCES [dbo].[Event]([EventId])
)
GO

/* Created by: Nathan */
print '' print '*** creating table for Intake'
GO
CREATE TABLE [dbo].[Intake] (
	[IntakeId]				[int]	IDENTITY(100000,1) 	NOT NULL,
	[IntakeTimeStamp]		[datetime]					NOT NULL DEFAULT GETDATE(),
	[DropOffSource]			[nvarchar](250)				NULL,
	[IntakeWorker]			[int]						NOT NULL,

	CONSTRAINT [pk_IntakeId] PRIMARY KEY([IntakeId]),
	CONSTRAINT [fk_Intake_IntakeWorker]FOREIGN KEY ([IntakeWorker])
		REFERENCES [dbo].[Users]([UsersId])
)
GO

/* Created by: John */
print '' print '*** creating table for TimeClock(John)'
GO
CREATE TABLE [dbo].[TimeClock] (
    [TimeClockId]        [int]   IDENTITY(100000,1)         NOT NULL,
    [UsersId]            [int]                             NOT NULL,
    [StartTime]           [datetime]                        NOT NULL,
    [EndTime]            [datetime]                        NOT NULL
    CONSTRAINT [pk_TimeClockId] PRIMARY KEY([TimeClockId])
    CONSTRAINT    [fk_TimeClock_UsersId] FOREIGN KEY ([UsersId])
        REFERENCES [dbo].[Users]([UsersId])
    
    
)
GO

/* Created by: Matthew Meppelink */
print '' print '*** creating table for ResourceAddRequest'
GO
CREATE TABLE [dbo].[ResourceAddRequest] (
    [ResourceAddRequestId]  [int] IDENTITY(100000, 1)       NOT NULL,
    [UsersId]               [int]                           NOT NULL,
    [Title]                 [nvarchar](100)                 NOT NULL,
    [Note]                  [nvarchar](2500)                NOT NULL,
    [Active]                [bit]                           NOT NULL,
    [Date]                  [datetime]  DEFAULT GETDATE()   NOT NULL,
    CONSTRAINT  [pk_ResourceAddRequestId] PRIMARY KEY ([ResourceAddRequestId]),
    CONSTRAINT  [fk_UsersId] FOREIGN KEY ([UsersId])
        REFERENCES [dbo].[Users]([UsersId])
)
GO

print '' print '*** creating Suspension table'
GO
/* Author:			Gwen Arman */
CREATE TABLE [dbo].[Suspension] (
	[SuspensionId]			[int]	IDENTITY(100000,1)	NOT NULL, 
	[UsersId]               [int]                           NOT NULL,
    [SuspendedUser]			[int]						NOT NULL,
    [SuspendingUser]		[int]						NOT NULL,
    [DateStart] 			[datetime]	DEFAULT GETDATE()	NOT NULL,
    [DaysSuspended] 		[int]						NOT NULL,
    [SuspendReason]			[nvarchar] (500)			NOT NULL,
    CONSTRAINT	[fk_Suspension_SuspendedUser] FOREIGN KEY ([UsersId])
		REFERENCES [dbo].[Users]([UsersId]),
     CONSTRAINT	[fk_Suspension_SuspendingUser] FOREIGN KEY ([UsersId])
		REFERENCES [dbo].[Users]([UsersId]) ON UPDATE CASCADE,   
	CONSTRAINT [pk_SuspensionId] PRIMARY KEY([SuspensionId])
)
GO

--CREATED BY:: Mads Rhea
print '' print '*** creating table for Reply (Mads)'
GO
CREATE TABLE [dbo].[Reply] (
	[ReplyId]			[int] IDENTITY(100000,1)	NOT NULL,
	[UsersId]           [int]                       NOT NULL,
	[PostId]			[int]						NOT NULL,
	[ReplyAuthor]		[int]						NOT NULL,
	[ReplyContent]		[nvarchar](250)				NOT NULL,
	[ReplyDate]			[datetime]					NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[ReplyVisibility]	[bit]						NOT NULL DEFAULT 1,

	CONSTRAINT [pk_ReplyId]	PRIMARY KEY ([ReplyId]),
	CONSTRAINT [fk_ReplyPost_PostId] FOREIGN KEY ([PostId])
        REFERENCES [Post]([PostId]),
	CONSTRAINT [fk_ReplyUsers_UsersId] FOREIGN KEY ([UsersId])
        REFERENCES [Users]([UsersId])
)
GO


/* Favorite  */
/* Created by: Ethan Kline */
print '' print '** creating table for Favorite'
GO
CREATE TABLE [dbo].[Favorite] (
    [PostId]    [int]     NOT NULL,
    [UsersId]   [int]     NOT NULL,

    CONSTRAINT [pk_Fav_UsersId] PRIMARY KEY([UsersId],[PostId]),
    CONSTRAINT [fk_Favorite_PostId] FOREIGN KEY ([PostId])
        REFERENCES [dbo].[Post] ([PostId]),
    CONSTRAINT [fk_Favorite_UsersId] FOREIGN KEY ([UsersId])
        REFERENCES [dbo].[Users] ([UsersId]),

)
GO


/* Created by: Nathan */
print '' print '*** creating table for BookmarkAnimal'
GO
CREATE TABLE [dbo].[BookmarkAnimal] (
	[UsersId]					[int]				NOT NULL,
	[AnimalId]					[int]				NOT NULL,
	
	CONSTRAINT [fk_BookmarkAnimal_UsersId]FOREIGN KEY ([UsersId])
		REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [fk_BookmarkAnimal_AnimalId]FOREIGN KEY ([AnimalId])
		REFERENCES [dbo].[Animal]([AnimalId]),
		
	CONSTRAINT [pk_BookmarkAnimal] PRIMARY KEY([UsersId], [AnimalId])
)
GO


/* Created by: Hoang Chu*/
print '' print '*** creating table for Ticket'
GO
CREATE TABLE [dbo].[Ticket] (
	[TicketId]					[int]			IDENTITY(100000,1) 	NOT NULL,
	[UsersId]					[int]							 	NOT NULL,
	[TicketStatusId]			[nvarchar](50)						NOT NULL, 
	[TicketTitle]				[nvarchar](500)						NOT NULL,
	[TicketDate]				[datetime]		DEFAULT GETDATE()	NOT NULL,
	[TicketActive]				[bit]			DEFAULT 1			NOT NULL,
	CONSTRAINT [pk_TicketId] PRIMARY KEY([TicketId]),
	CONSTRAINT [ak_TicketId] UNIQUE([TicketId]),
	CONSTRAINT [fk_ticket_UsersId] FOREIGN KEY([UsersId])
		REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [fk_TicketStatusId] FOREIGN KEY([TicketStatusId])
		REFERENCES [dbo].[TicketStatus]([TicketStatusId])
		ON UPDATE CASCADE
)
GO


--CREATED BY:: Mads Rhea
print '' print '*** creating table for HoursOfOperation (Mads)'
GO
CREATE TABLE [dbo].[HoursOfOperation] (
	[HoursOfOperationId]	[int] IDENTITY(100000,1)	NOT NULL,
	[ShelterId]				[int]						NOT NULL,
	[DayOfWeek]				[tinyint]					NOT NULL,
	[OpenTime]				[time]						NOT NULL,
	[CloseTime]				[time]						NOT NULL,

	CONSTRAINT [pk_HoursOfOperationId]	PRIMARY KEY ([HoursOfOperationId]),
	CONSTRAINT [ak_ShelterDayOfWeek] UNIQUE([ShelterId], [DayOfWeek]),
	CONSTRAINT [fk_HoursOfOperationShelter_ShelterId] FOREIGN KEY ([ShelterId])
        REFERENCES [Shelter]([ShelterId])

)
GO

print '' print '*** creating SuspensionAppeal table'
/* Author:			Gwen Arman */
CREATE TABLE [dbo].[SuspensionAppeal] (
	[SuspensionAppealId]	[int]	IDENTITY(100000,1)	NOT NULL, 
    [SuspensionId]			[int]						NOT NULL,
    [AppealStatusId]		[nvarchar](50)				NOT NULL,
    [AssignedAppealUser] 	[int]						NULL,
    CONSTRAINT	[fk_SuspensionAppeal_SuspendId] FOREIGN KEY ([SuspensionId])
		REFERENCES [dbo].[Suspension]([SuspensionId]),
     CONSTRAINT	[fk_SuspensionAppeal_AppealStatusId] FOREIGN KEY ([AppealStatusId])
		REFERENCES [dbo].[AppealStatus]([AppealStatusId]) ON UPDATE CASCADE,   
	CONSTRAINT [pk_SuspensionAppealId]		PRIMARY KEY([SuspensionAppealId])
)
GO

/* This table joins the Shelter and Inventory tables */
/* Created by Brian Collum */
print '' print '*** creating ShelterInventoryItem join table'
GO
CREATE TABLE [dbo].[ShelterInventoryItem] (
	/* Primary Keys */
	[ShelterId]					[int]			NOT NULL,
	[ItemId]					[nvarchar](50)	NOT NULL,
	/* Inventory Item Details */
	[Quantity]					[int]			NOT NULL DEFAULT 0,
	[UseStatistic]				[decimal](4,2)	NULL,
	[LastUpdated]				[date]			NOT NULL DEFAULT GETDATE(),
	[LowInventoryThreshold]		[int]			NULL,
	[HighInventoryThreshold]	[int]			NULL,
	/* Status flags */
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



/* Created by: Oleksiy Fedchuk  */
print '' print '*** creating table for TableName FosterRequest'
GO
CREATE TABLE [dbo].[FosterRequest] (
	[FosterRequestId]			[int]				NOT NULL,
	[FosterRequestShelterId]	[int]				NOT NULL,
	[FosterRequestUsersId]		[int]				NOT NULL,
	[FosterRequestMessage]		[nvarchar](500)		NOT NULL,
	CONSTRAINT [fk_Shelter_FosterRequestShelterId] FOREIGN KEY ([FosterRequestShelterId])
		REFERENCES [dbo].[Shelter] ([ShelterId]),
	CONSTRAINT [fk_Users_FosterRequestUsersId] FOREIGN KEY ([FosterRequestUsersId])
		REFERENCES [dbo].[Users] ([UsersId]),
	CONSTRAINT [pk_FosterRequest] PRIMARY KEY ([FosterRequestId])
)
GO

/* Request(Shelter) Created by: Asa Armstrong */
print '' print '*** create Request table ***'
GO
CREATE TABLE [dbo].[Request] (
	[RequestId]				[int] IDENTITY(100000, 1)	NOT NULL,
	[ReceivingShelterId]	[int]						NOT NULL,
	[RequestedByUserId]		[int]						NOT NULL,
	[RequestDate]			[date]						NOT NULL DEFAULT GETDATE(),
	[Acknowledged]			[bit]						NULL,
	
	CONSTRAINT [pk_RequestId] PRIMARY KEY ([RequestId]),
	CONSTRAINT [fk_ReceivingShelterId]	FOREIGN KEY ([ReceivingShelterId]) REFERENCES [dbo].[Shelter]([ShelterId]),
	CONSTRAINT [fk_RequestedByUserId]	FOREIGN KEY ([RequestedByUserId]) REFERENCES [dbo].[Users]([UsersId])
)
GO

/* Created by: Stephen Jaurigue */
print '' print '*** creating table for UserRoles (Stephen Jaurigue)'
GO
CREATE TABLE [dbo].[UserRoles] (
	[RoleId]		[nvarchar](50)	NOT NULL,
	[UsersId]		[int]				NOT NULL
	CONSTRAINT [fk_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role]([RoleId]) ON UPDATE CASCADE,
	CONSTRAINT [fk_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Users]([UsersId]),
	CONSTRAINT [ak_RoleId_and_UsersId] UNIQUE([RoleId],[UsersId]),
	CONSTRAINT [pk_RoleId_and_UsersId] PRIMARY KEY([RoleId],[UsersId]),
)
GO

--print '' print '*** adding indexes to UsersRoles table (Stephen Jaurigue'
GO
CREATE INDEX ix_UserRoles_RoleId 
	ON [dbo].[UserRoles] ([RoleId])
GO
CREATE INDEX ix_UserRoles_UsersId 
	ON [dbo].[UserRoles] ([UsersId])
GO
/* Created by: Chris Dreismeier */
print '' print '*** creating ScheduledDonation'
GO
CREATE TABLE [dbo].[ScheduledDonation] (
	[ScheduledDonationId]	[int]		IDENTITY(100000,1) 			NOT NULL,
	[DonationFrequencyId]	[nvarchar](50)							NOT NULL,
	[UsersId]				[int]									NOT NULL,
	[ShelterId]				[int]									NOT NULL,
	[Amount]				[DECIMAL](7,2)							NULL,
	[Message]				[nvarchar](225)							NULL,
	[Date]					[datetime]		DEFAULT getdate()		NULL,
	[Anonymous]				[bit] 			DEFAULT 0				NOT NULL,
	[Target]				[nvarchar](225)							NULL,
	[PaymentMethod]			[nvarchar](50)							NOT NULL,
	[Frequency]				[nvarchar](50)	DEFAULT 'one-time'		NOT NULL,
	[StartDate]				[datetime]								NOT NULL,
	[NextDonationDate]		[datetime]								NOT NULL,
	[Active]				[bit]			DEFAULT 1				NOT NULL,
	
	CONSTRAINT [pk_ScheduledDonationId] PRIMARY KEY([ScheduledDonationId]),
	CONSTRAINT [fk_ScheduledDonation_UserId]		FOREIGN KEY ([UsersID])
		REFERENCES [dbo].[Users] ([UsersID]),
		
	CONSTRAINT [fk_ScheduledDonation_ShelterId]		FOREIGN KEY ([ShelterId])
		REFERENCES [dbo].[Shelter] ([ShelterId]),
		
	CONSTRAINT [fk_ScheduledDonation_Frequency]		FOREIGN KEY ([DonationFrequencyId])
		REFERENCES [dbo].[DonationFrequency] ([DonationFrequencyId]) ON UPDATE CASCADE
)
GO

/* FundraisingCampaign table */
/* Created by: Andrew S. */
print '' print '*** creating FundraisingCampaign table'
GO
CREATE TABLE [dbo].[FundraisingCampaign]
(
	[FundraisingCampaignId]	[int]	IDENTITY(100000,1)	NOT NULL,
	[UsersId]				[int]						NOT NULL,
	[ShelterId]				[int]						NOT NULL,
	[Title]					[nvarchar](100)				NOT NULL,
	[StartDate]				[datetime]					NULL,
	[EndDate]				[datetime]					NULL,
	[Description]			[nvarchar](255)				NULL,
	[Complete]				[bit]	DEFAULT 0			NOT NULL,
	[Updated]				[int]						NULL,
	CONSTRAINT [pk_FundraisingCampaignId] PRIMARY KEY ([FundraisingCampaignId]),
	CONSTRAINT [fk_FundraisingCampaign_UsersId] FOREIGN KEY ([UsersId])
		REFERENCES [Users]([UsersId]),
	CONSTRAINT [fk_FundraisingCampaign_ShelterId] FOREIGN KEY ([ShelterId])
		REFERENCES [Shelter]([ShelterId])
)
GO


--print '' print '*** creating FundraisingCampaign indices'
CREATE INDEX ix_FundraisingCampaignUsersId
	ON [FundraisingCampaign]([UsersId])	
GO
CREATE INDEX ix_FundraisingCampaignStartDate
	ON [FundraisingCampaign]([StartDate])	
GO
CREATE INDEX ix_FundraisingCampaignEndDate
	ON [FundraisingCampaign]([EndDate])
GO
CREATE INDEX ix_FundraisingCampaignComplete
	ON [FundraisingCampaign]([Complete])
GO

/* FundraisingEvent table */
/* Created by: Andrew S. */
print '' print '*** creating FundraisingEvent table'
GO
CREATE TABLE [dbo].[FundraisingEvent]
(
	[FundraisingEventId]	[int]	IDENTITY(100000,1)	NOT NULL,
	[UsersId]				[int]						NOT NULL,
	[ImageId]				[int]						NULL,
	[CampaignId]			[int]						NULL,
	[ShelterId]				[int]						NOT NULL,
	[Title]					[nvarchar](100)				NOT NULL,
	[EventDate]				[datetime]					NULL,
	[StartTime]				[datetime]					NULL,
	[EndTime]				[datetime]					NULL,
	[Hidden]				[bit]			DEFAULT 0	NOT NULL,
	[Complete]				[bit]			DEFAULT 0	NOT NULL,
	[Description]			[nvarchar](max)				NULL,
	[AdditionalInfo]		[nvarchar](max)				NULL,
	[Cost]					[decimal](7,2)	DEFAULT 0	NULL,
	[NumOfAttendees]		[int]			DEFAULT 0	NULL,
	[NumAnimalsAdopted]		[int]			DEFAULT 0	NULL,
	[UpdateNotes]			[nvarchar](max)				NULL,
	CONSTRAINT [pk_FundraisingEventId] PRIMARY KEY ([FundraisingEventId]),
	CONSTRAINT [fk_FundraisingEvent_UsersId] FOREIGN KEY ([UsersId])
		REFERENCES [Users]([UsersId]),
	CONSTRAINT [fk_FundraisingEvent_ImageId] FOREIGN KEY ([ImageId])
		REFERENCES [Images]([ImageId]),
	CONSTRAINT [fk_FundraisingEvent_CampaignId] FOREIGN KEY ([CampaignId])
		REFERENCES [FundraisingCampaign]([FundraisingCampaignId]),
	CONSTRAINT [fk_FundraisingEvent_ShelterId] FOREIGN KEY ([ShelterId])
		REFERENCES [Shelter]([ShelterId])
)
GO


--print '' print '*** creating FundraisingEvent indices'
CREATE INDEX ix_FundraisingEventUsersId
	ON [FundraisingEvent]([UsersId])	
GO
CREATE INDEX ix_FundraisingEventEventDate
	ON [FundraisingEvent]([EventDate])	
GO
CREATE INDEX ix_FundraisingEventStartTime
	ON [FundraisingEvent]([StartTime])
GO



--Created by: Mohmeed Tomsah
print '' print '*** creating Donation table ***'
GO
CREATE TABLE [dbo].[Donation](
	[DonationId]	            [int] IDENTITY(1000000,1) NOT NULL,
	[UsersId]	                [int]	                      NULL,
	[ShelterId]	                [int]	                  NOT NULL,
	[Amount]	                [DECIMAL](30,3)	              NULL,
	[Message]	                [nvarchar](255)	              NULL,
	[Date]	                    [DATE] 	DEFAULT GETDATE()     NULL,
	[GivenName]	                [nvarchar](50)	              NULL,
	[FamilyName]	            [nvarchar](50)	              NULL,
	[HasInKindDonation]	        [bit]          NOT NULL  DEFAULT 0,
	[Anonymous]	                [bit]	       NOT NULL  DEFAULT 0,
	[Target]	                [nvarchar](255)	              NULL,
	[PaymentMethod]	            [nvarchar](50)	              NULL,
	[ScheduledDonationId]	    [int]	                      NULL,
	[FundraisingEventId]	    [int]	                      NULL,

	CONSTRAINT [pk_DonationId] PRIMARY KEY([DonationId] ASC),
	
	CONSTRAINT [fk_Donation_UsersId] FOREIGN KEY([UsersId])
	REFERENCES [dbo].[Users]([UsersId]),
	
	CONSTRAINT [fk_Donation_ShelterId] FOREIGN KEY([ShelterId])
	REFERENCES [dbo].[Shelter]([ShelterId]),
	
	CONSTRAINT [fk_Donation_ScheduledDonationId] FOREIGN KEY([ScheduledDonationId])
	REFERENCES [dbo].[ScheduledDonation]([ScheduledDonationId]),
	
	CONSTRAINT [fk_Donation_FundraisingEventId] FOREIGN KEY([FundraisingEventId])
	REFERENCES [dbo].[FundraisingEvent]([FundraisingEventId])
)
GO


/* InKind */

/* Created by: Chris Dreismeier */
print '' print '*** creating InKind'
GO
CREATE TABLE [dbo].[InKind] (
	[InKindId]					[int]		IDENTITY(100000,1) 			NOT NULL,
	[DonationId]				[int]									NOT NULL,
	[Description]				[NVARCHAR](225)							NOT NULL,
	[Quantity]					[int]									Not NULL,
	[Target]					[nvarchar](225)							NULL,
	[Received]					[bit]		DEFAULT 0					Not NULL,
	
	CONSTRAINT [pk_InKindId] PRIMARY KEY([InKindId]),
	CONSTRAINT [fk_InKind_DonationId]		FOREIGN KEY ([DonationId])
		REFERENCES [dbo].[Donation] ([DonationId])
)
GO

/* DonationAppointment */

/* Created by: Chris Dreismeier */
print '' print '*** creating DonationAppointment'
GO
CREATE TABLE [dbo].[DonationAppointment] (
	[DonationAppointmentId]			[int]		IDENTITY(100000,1) 			NOT NULL,
	[DonationId]					[int]									NULL,
	[DateScheduled]					[datetime]								NOT NULL,
	[Note]							[nvarchar](225)							NULL,
	[IsConfirmed]					[bit]									NULL,
	[IsFulfilled]					[bit]									NULL,
	[DateCreated]					[datetime]		DEFAULT getdate()		NOT NULL,
	[Active]						[bit]			DEFAULT 1				NOT NULL,
	
	CONSTRAINT [pk_DonationAppointmentId] PRIMARY KEY([DonationAppointmentId]),
	CONSTRAINT [fk_DonationAppointment_DonationId]		FOREIGN KEY ([DonationId])
		REFERENCES [dbo].[Donation] ([DonationId])
)
GO

/* Created by: Hoang Chu*/
print '' print '*** creating table for AnimalAttendingEvent'
GO
CREATE TABLE [dbo].[AnimalAttendingEvent] (
	[AnimalAttendingEventId]	[int]			IDENTITY(100000,1) 	NOT NULL,
	[AnimalId]					[int]							 	NOT NULL,
	[EventId]					[int]								NOT NULL,
	[AnimalAttendingId]			[int]							 	NOT NULL,
	[EventAttendingId]			[int]							 	NOT NULL,
	[TimeAdded]					[datetime]		DEFAULT GETDATE()	NOT NULL,
	[Attending]					[bit]			DEFAULT 1			NOT NULL,
	CONSTRAINT [pk_AnimalAttendingEventId] PRIMARY KEY([AnimalAttendingEventId]),
	CONSTRAINT [ak_AnimalAttendingEventId] UNIQUE([AnimalAttendingEventId]),
	CONSTRAINT [fk_AnimalId] FOREIGN KEY([AnimalId])
		REFERENCES [dbo].[Animal]([AnimalId]),
	CONSTRAINT [fk_AnimalAttendingEvent_EventId] FOREIGN KEY([EventId])
		REFERENCES [dbo].[Event]([EventId])
)
GO


/* This table joins the Item and Category tables */
/* Created by Brian Collum */
print '' print '*** creating ItemCategory join table'
GO
CREATE TABLE [dbo].[ItemCategory] (
	[ItemID]		[nvarchar](50)		NOT NULL,
	[CategoryID]	[nvarchar](50)		NOT NULL,	
	CONSTRAINT	[fk_ItemCategory_ItemID] FOREIGN KEY ([ItemID])
		REFERENCES [dbo].[Item]([ItemID]) ON UPDATE CASCADE,
	CONSTRAINT	[fk_ItemCategory_CategoryID] FOREIGN KEY ([CategoryID])
		REFERENCES [dbo].[Category]([CategoryID]) ON UPDATE CASCADE,
	CONSTRAINT	[pk_ItemCategory_ItemID_CategoryID] PRIMARY KEY ([ItemID], [CategoryID])
)
GO

/* EventSubscription */
/* Created by:  Barry Mikulas */
print '' print '*** Creating EventSubscription (Barry Mikulas)'
GO
CREATE TABLE [dbo].[EventSubscription] (
	[EventSubscriptionId]		[int] IDENTITY(100000, 1) 	NOT NULL,
	[SubscriberId]				[int]						NOT NULL,
	[EventId]					[int]						NOT NULL,
	[DateSubscribed]			[datetime]DEFAULT GETDATE()	NULL,
	[Subscribed]				[bit] DEFAULT 1				NOT NULL,
	CONSTRAINT [pk_EventSubscription_EventSubscriptionId] PRIMARY KEY([EventSubscriptionId]),
	CONSTRAINT [fk_EventSubscription_SubscriberId] FOREIGN KEY([SubscriberId]) REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [fk_EventSubscription_EventId] FOREIGN KEY([EventId]) REFERENCES [dbo].[Event]([EventId])
)
GO
--print '' print '*** adding indexes to EventSubscription table (Barry Mikulas)'
GO
CREATE INDEX ix_EventSubscription_SubscriberId 
	ON [dbo].[EventSubscription] ([SubscriberId])
GO
CREATE INDEX ix_EventSubscription_EventId 
	ON [dbo].[EventSubscription] ([EventId])
GO


/*Created By: Zaid Rachman*/
print '' print '*** Creating Applicant Table' 
GO
CREATE TABLE [dbo].[Applicant] (
	[ApplicantId]			[int] IDENTITY(100000,1)	NOT NULL,
	[UsersId]				[int]						NULL,
	[ApplicantGivenName]	[nvarchar](50)				NOT NULL,
	[ApplicantFamilyName]	[nvarchar](50)				NOT NULL,
	[ApplicantAddress]		[nvarchar](50)				NOT NULL,
	[ApplicantAddress2]		[nvarchar](50)				NOT NULL,
	[ApplicantZipCode]		[char](9)					NOT NULL,
	[ApplicantPhoneNumber]	[nvarchar](13)				NOT NULL,
	[ApplicantEmail]		[nvarchar](254)				NOT NULL,
	[HomeTypeId]			[nvarchar](50)				NOT NULL,
	[HomeOwnershipId]		[nvarchar](50)				NOT NULL,
	[NumberOfChildren]		[int]						NOT NULL,
	[NumberOfPets]			[int]						NOT NULL,
	[CurrentlyAcceptingAnimals]	[bit]					NOT NULL DEFAULT NULL,
	
	CONSTRAINT [fk_Applicant_UsersID] FOREIGN KEY([UsersId])
		REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [fk_Applicant_Zipcode] FOREIGN KEY([ApplicantZipCode])
		REFERENCES [dbo].[Zipcode]([Zipcode]),	
	CONSTRAINT [fk_Applicant_HomeTypeId] FOREIGN KEY([HomeTypeId])
		REFERENCES [dbo].[HomeType]([HomeTypeID]),
	CONSTRAINT [fk_Applicant_HomeOwnershipId] FOREIGN KEY([HomeOwnershipId])
		REFERENCES [dbo].[HomeOwnership]([HomeOwnershipId]),
	CONSTRAINT [pk_ApplicantId] PRIMARY KEY([ApplicantId])
)
GO


/* Created by: Oleksiy Fedchuk  */
print '' print '*** creating table for TableName FosterApplication'
GO
CREATE TABLE [dbo].[FosterApplication] (
	[FosterApplicationId]			[int]	IDENTITY(100000,1)	NOT NULL,
	[ApplicantId]					[int]						NOT NULL,
	[ApplicationStatusId]			[nvarchar](50)				NOT NULL,
	[FosterApplicationDate]			[datetime]					NOT NULL DEFAULT GETDATE(),
	[FosterApplicationStartDate]	[datetime]					NOT NULL,
	[FosterApplicationMaxAnimals]	[int]						NOT NULL,
	CONSTRAINT [fk_Applicant_ApplicantId] FOREIGN KEY ([ApplicantId])
		REFERENCES [dbo].[Applicant] ([ApplicantId]),
	CONSTRAINT [fk_ApplicationStatus_ApplicationStatusId] FOREIGN KEY ([ApplicationStatusId])
		REFERENCES [dbo].[ApplicationStatus] ([ApplicationStatusId]),
	CONSTRAINT [pk_FosterApplicationId]	PRIMARY KEY	([FosterApplicationId])
)
GO

/* FosterApplicationAnimalType table */
/* Created by: Andrew Cromwell */
/* this table was not tested because of the forign keys */
print '' print '** creating FosterApplicationAnimalType table'
GO
CREATE TABLE [dbo].[FosterApplicationAnimalType] (
	[AnimalTypeId] 	 			[nvarchar](50)      NOT NULL,
	[FosterApplicationId]		[int]				NOT NULL,
	CONSTRAINT [fk_FosterApplicationAnimalType_AnimalTypeId] FOREIGN KEY ([AnimalTypeId])
		REFERENCES [dbo].[AnimalType]([AnimalTypeId]),
	CONSTRAINT [fk_FosterApplicationAnimalType_FosterApplicationId] FOREIGN KEY ([FosterApplicationId])
		REFERENCES [dbo].[FosterApplication]([FosterApplicationId]),
	CONSTRAINT [pk_FosterApplicationAnimalType] PRIMARY KEY ([AnimalTypeId], [FosterApplicationId])
)
GO



/* Created by: Oleksiy Fedchuk */
print '' print '*** creating table for TableName FosterRequestResponse'
GO
CREATE TABLE [dbo].[FosterRequestResponse] (
	[FosterResponseId]			[int] 				NOT NULL,
	[ApplicantId]				[int]				NOT NULL,
	[FosterRequestId]			[int]				NOT NULL,
	[FosterResponseAccepted]	[nvarchar](500),
	CONSTRAINT [fk_FosterRequest_FosterRequestId] FOREIGN KEY ([FosterRequestId])
		REFERENCES [dbo].[FosterRequest] ([FosterRequestId]),
	CONSTRAINT [fk_FosterRequestResponce_ApplicantId] FOREIGN KEY ([ApplicantId])
		REFERENCES [dbo].[Applicant] ([ApplicantId]),
	CONSTRAINT [pk_FosterRequestResponse] PRIMARY KEY ([FosterResponseId])
)
GO

/* Created by: Oleksiy Fedchuk */
print '' print '*** creating table for TableName FosterRequestApplicant'
GO
CREATE TABLE [dbo].[FosterRequestApplicant] (
	[FosterRequestId]	[int] 	NOT NULL,
	[ApplicantId]		[int]	NOT NULL,
	CONSTRAINT [fk_FosterRequestApplicant_FosterRequestId] FOREIGN KEY ([FosterRequestId])
		REFERENCES [dbo].[FosterRequest] ([FosterRequestID]),
	CONSTRAINT [fk_FosterRequestApplicant_ApplicantId] FOREIGN KEY ([ApplicantId])
		REFERENCES [dbo].[Applicant] ([ApplicantId]),
	CONSTRAINT [pk_FosterRequestApplicant] PRIMARY KEY ([FosterRequestId], [ApplicantId])
)
GO

/* Medical Record */
/* Created by: William Rients */
print '' print '*** creating table for MedicalRecord'
GO
CREATE TABLE [dbo].[MedicalRecord] (
	[MedicalRecordId]	[int]	IDENTITY(100000, 1) 	NOT NULL,
	[AnimalId]			[int]							NOT NULL,
	[Date]				[datetime]						NOT NULL 	DEFAULT GETDATE(),
	[MedicalNotes]		[nvarchar](250)					NOT NULL,
	[MedProcedure]		[bit]							NOT NULL	DEFAULT 0,
	[Test]				[bit]							NOT NULL	DEFAULT 0,
	[Vaccination]		[bit]							NOT NULL	DEFAULT 0,
	[Prescription]		[bit]							NOT NULL	DEFAULT 0,
	[Images]			[bit]							NOT NULL	DEFAULT 0,
	[QuarantineStatus]	[bit]							NOT NULL	DEFAULT 0,
	[Diagnosis]			[nvarchar](250)					NOT NULL,
	CONSTRAINT [fk_MedicalRecord_AnimalId]	FOREIGN KEY ([AnimalId])
		REFERENCES [dbo].[Animal] ([AnimalId]),
	CONSTRAINT [pk_MedicalRecordId] PRIMARY KEY ([MedicalRecordId])
)
GO

CREATE INDEX ix_MedicalRecord_AnimalId
	ON [dbo].[MedicalRecord] ([AnimalId])
	
GO

/*  Created by: Molly Meister*/
print '' print '*** creating table for MedProcedure'
GO
CREATE TABLE [dbo].[MedProcedure] (
    [MedProcedureId]            [int]           IDENTITY(100000, 1)     NOT NULL,
    [MedicalRecordId]           [int]           NOT NULL,
    [UsersId]                   [int]           NOT NULL,
    [MedProcedureName]          [nvarchar](50)  NOT NULL,
    [MedicationsAdministered]   [nvarchar](100) NULL,
    [MedProcedureNotes]         [nvarchar](500) NULL,
    [MedProcedureDate]          [date]          DEFAULT GETDATE()       NOT NULL,
    [MedProcedureTime]          [time]          NOT NULL,
    CONSTRAINT [pk_MedProcedureId] PRIMARY KEY([MedProcedureId]),
    CONSTRAINT [fk_MedProcedure_MedicalRecordId] FOREIGN KEY([MedicalRecordId])
            REFERENCES [dbo].[MedicalRecord]([MedicalRecordId]),
    CONSTRAINT [fk_MedProcedure_UsersId] FOREIGN KEY([UsersId])
            REFERENCES [dbo].[Users]([UsersId])
)
GO
--print '' print '*** creating MedProcedure_UsersID Index'
CREATE INDEX ix_MedProcedure_UsersId
    ON [dbo].[MedProcedure]([UsersId])
GO

/*  Created by: Molly Meister*/
print '' print '*** creating table for Test'
GO
CREATE TABLE [dbo].[Test] (
    [TestId]                    [int]           IDENTITY(100000, 1)     NOT NULL,
    [MedicalRecordId]           [int]           NOT NULL,
    [UsersId]                   [int]           NOT NULL,
    [TestName]                  [nvarchar](50)  NOT NULL,
    [TestAcceptableRange]       [nvarchar](50)  NULL,
    [TestResult]                [nvarchar](50)  NOT NULL,
    [TestNotes]                 [nvarchar](500) NULL,
    [TestDate]                  [datetime]      DEFAULT GETDATE()       NOT NULL,
    CONSTRAINT [pk_TestId] PRIMARY KEY([TestId]),
    CONSTRAINT [fk_Test_MedicalRecordId] FOREIGN KEY([MedicalRecordId])
            REFERENCES [dbo].[MedicalRecord]([MedicalRecordId]),
    CONSTRAINT [fk_Test_UsersId] FOREIGN KEY([UsersId])
            REFERENCES [dbo].[Users]([UsersId])
    
)
GO
--print '' print '*** creating Test_UsersId Index'
CREATE INDEX ix_Test_UsersId
    ON [dbo].[Test]([UsersId])
GO


/* Vaccination */
/* Created by: William Rients */
print '' print '*** creating table for Vaccination'
GO
CREATE TABLE [dbo].[Vaccination] (
	[VaccineId]				[int]	IDENTITY(100000, 1) 	NOT NULL,
	[MedicalRecordId]		[int]							NOT NULL,
	[UsersId]				[int]							NOT NULL,
	[VaccineName]			[nvarchar](50)					NOT NULL,
	[VaccineAdminsterDate]	[datetime]						NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [fk_Vaccination_MedicalRecordId]	FOREIGN KEY ([MedicalRecordId])
		REFERENCES [dbo].[MedicalRecord] ([MedicalRecordId]),
	CONSTRAINT [fk_Vaccination_UsersId]	FOREIGN KEY ([UsersId])
		REFERENCES [dbo].[Users] ([UsersId]),	
	CONSTRAINT [pk_VaccineId] PRIMARY KEY ([VaccineId])
)
GO

CREATE INDEX ix_Vaccination_UsersId_VaccineName
	ON [dbo].[Vaccination] ([UsersId], [VaccineName])
	
GO

/* Prescription */
/* Created by: William Rients */

print '' print '*** creating table for Prescription'
GO
CREATE TABLE [dbo].[Prescription] (
	[PrescriptionId]			[int]	IDENTITY(100000, 1) 	NOT NULL,						
	[MedicalRecordId]			[int]							NOT NULL,
	[UsersId]					[int]							NOT NULL,
	[PrescriptionTypeId]		[nvarchar](50)					NOT NULL,
	[PrescriptionName]			[nvarchar](50)					NOT NULL,
	[PrescriptionDosage]		[nvarchar](50)					NOT NULL,
	[PrescriptionFrequency]		[nvarchar](50)					NOT NULL,
	[PrescriptionDuration]		[int]							NOT NUll,
	[PrescriptionNotes]			[nvarchar](500)					NULL,
	[DatePrescribed]			[datetime]						NOT NULL DEFAULT GETDATE(),
	[EndDate]					[datetime]						NOT NULL,
	CONSTRAINT [fk_Prescription_MedicalRecordId]	FOREIGN KEY ([MedicalRecordId])
		REFERENCES [dbo].[MedicalRecord] ([MedicalRecordId]),
	CONSTRAINT [fk_Prescription_UsersId]	FOREIGN KEY ([UsersId])
		REFERENCES [dbo].[Users] ([UsersId]),	
	CONSTRAINT [fk_Prescription_PrescriptionTypeId]	FOREIGN KEY ([PrescriptionTypeId])
		REFERENCES [dbo].[PrescriptionType] ([PrescriptionTypeId]) ON UPDATE CASCADE,
	CONSTRAINT [pk_PrescriptionId] PRIMARY KEY ([PrescriptionId])
)

	
GO

/* Created by: Nathan */
print '' print '*** creating table for Kennel'
GO
CREATE TABLE [dbo].[Kennel] (
	[KennelId]					[int]				IDENTITY(100000,1) 	NOT NULL,
	[ShelterId]					[int]				NOT NULL,
	[KennelName]				[nvarchar](50)		NOT NULL,
	[AnimalTypeId]				[nvarchar](50)		NOT NULL,
	[KennelSpace]				[int]				NOT NULL DEFAULT 1,
	[KennelActive]				[bit]				NOT NULL DEFAULT 1,
	
	CONSTRAINT [pk_KennelId] PRIMARY KEY([KennelId]),
	
	CONSTRAINT [fk_Kennel_ShelterId]FOREIGN KEY ([ShelterId])
		REFERENCES [dbo].[Shelter]([ShelterId]),
	CONSTRAINT [fk_Kennel_AnimalTypeId]FOREIGN KEY ([AnimalTypeId])
		REFERENCES [dbo].[AnimalType]([AnimalTypeId])
)

--print '' print '*** creating indexs for Kennel'
GO
CREATE INDEX ix_Kennel_KennelActive
	ON [dbo].[Kennel]([KennelActive])

GO
/* Created by: Nathan */
print '' print '*** creating table for AnimalKenneling'
GO
CREATE TABLE [dbo].[AnimalKenneling] (
	[KennelId]					[int]				NOT NULL,
	[AnimalId]					[int]				NOT NULL,
	
	CONSTRAINT [fk_AnimalKenneling_KennelId]FOREIGN KEY ([KennelId])
		REFERENCES [dbo].[Kennel]([KennelId]),
	CONSTRAINT [fk_AnimalKenneling_AnimalId]FOREIGN KEY ([AnimalId])
		REFERENCES [dbo].[Animal]([AnimalId]),
		
	CONSTRAINT [pk_AnimalKenneling] PRIMARY KEY([KennelId], [AnimalId])
)

/*Created By: Zaid Rachman*/
print '' print '*** Creating Inspection Table' 
GO
CREATE TABLE [dbo].[Inspection] (
	[InspectionId]					[int] IDENTITY(100000,1)	NOT NULL,
	[ApplicantId]					[int] 						NOT NULL,
	[InspectionInspectorId] 		[int]						NOT NULL,
	[InspectionComments] 			[nvarchar](500)				NULL,
	[InspectionDateScheduled] 		[datetime]					NOT NULL,
	[InspectionDateCompleted] 		[datetime]					NULL,
	[InspectionAnimalCountApproved] [int]						NOT NULL,
	[InspectionPassed]				[bit]						NOT NULL DEFAULT 0,
	
	
	CONSTRAINT [fk_Inspection_ApplicantId] FOREIGN KEY ([ApplicantId])
		REFERENCES [dbo].[Applicant]([ApplicantId]),
	CONSTRAINT [fk_Inspection_InspectionInspectorId] FOREIGN KEY ([InspectionInspectorId])
		REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [pk_InspectionId] PRIMARY KEY([InspectionId])
)
GO


/* Animal Medical Image */
/* Created by: William Rients */
print '' print '*** creating table for AnimalMedicalImage'
GO
CREATE TABLE [dbo].[AnimalMedicalImage] (
	[ImageId]				[int]		NOT NULL,						
	[MedicalRecordId]		[int]		NOT NULL,
	CONSTRAINT [fk_AnimalMedicalImage_ImageId]	FOREIGN KEY ([ImageId])
		REFERENCES [dbo].[Images] ([ImageId]),
	CONSTRAINT [fk_AnimalMedicalImage_MedicalRecordId]	FOREIGN KEY ([MedicalRecordId])
		REFERENCES [dbo].[MedicalRecord] ([MedicalRecordId]),
	CONSTRAINT [pk_AnimalMedicalImage] PRIMARY KEY ([ImageId], [MedicalRecordId])
)
GO



--Created by: Mohmeed Tomsah
print '' print '*** creating RequestRescourceLine table ***'
GO
CREATE TABLE [dbo].[RequestRescourceLine](
	[RequestId]	                     [int]                    NOT NULL,
	[ItemId]	                     [nvarchar](50)	          NOT NULL,
	[QuantityRequested]	             [int]	                  NOT NULL,
	[Notes]	                         [nvarchar](1000)	      NOT NULL,
	
	CONSTRAINT [pk_RequestRescourceLine_RequestId] PRIMARY KEY([RequestId] ASC),
		CONSTRAINT [fk_ItemId] FOREIGN KEY([ItemId])
		REFERENCES [dbo].[Item]([ItemId])
)
GO

	

/* CampaignUpdate table */
/* Created by: Andrew S. */
print '' print '*** creating CampaignUpdate table'
GO
CREATE TABLE [dbo].[CampaignUpdate]
(
	[CampaignUpdateID]	[int]	IDENTITY(100000,1)		  NOT NULL,
	[CampaignId]		[int]							  NOT NULL,
	[UpdateTitle]		[nvarchar](50)					  NOT NULL,
	[UpdateDescription]	[nvarchar](500)					  NOT NULL,
	[UpdatePostTime]	[nvarchar](50)	DEFAULT getdate() NOT NULL,
	CONSTRAINT [pk_CampaignUpdateID] PRIMARY KEY ([CampaignUpdateID]),
	CONSTRAINT [fk_CampaignUpdate_CampaignId] FOREIGN KEY ([CampaignId])
		REFERENCES [FundraisingCampaign]([FundraisingCampaignId])
)
GO


--print '' print '*** creating CampaignUpdate index'
CREATE INDEX ix_CampaignUpdateCampaignId
	ON [CampaignUpdate]([CampaignId])	
GO


/* PostReport table */
/* Created by: Andrew S. */
print '' print '*** creating PostReport table'
GO
CREATE TABLE [dbo].[PostReport]
(
	[PostId]			[int]							NOT NULL,
	[PostReporter]		[int]							NOT NULL,
	[ReportMessageId]	[int]							NOT NULL,
	[PostReportDate]	[datetime]	DEFAULT	getdate()	NOT NULL,
	[PostReportActive]	[bit]		DEFAULT 1			NOT NULL,
	CONSTRAINT [pk_PostReport] PRIMARY KEY ([PostId]),
	CONSTRAINT [fk_PostReport_PostReporter] FOREIGN KEY ([PostReporter])
		REFERENCES [Users]([UsersId]),
	CONSTRAINT [fk_PostReport_ReportMessageId] FOREIGN KEY ([ReportMessageId]) 
		REFERENCES [ReportMessage]([ReportMessageId]) ON UPDATE CASCADE
)
GO
/* Reply Report */
/* Created by: William Rients */
print '' print '*** creating table for ReplyReports'
GO
CREATE TABLE [dbo].[ReplyReport] (
	[ReplyId]				[int]		NOT NUll,
	[ReplyReporter]			[int]		NOT NULL,
	[ReportMessageId]		[int]		NOT NULL,
	[ReplyReportDate]		[datetime]	DEFAULT GETDATE() NOT NULL ,
	[ReplyReportActive]		[bit]		NOT NULL,
	CONSTRAINT [fk_ReplyReport_ReplyId]	FOREIGN KEY ([ReplyId])
		REFERENCES [dbo].[Reply] ([ReplyId]),
	CONSTRAINT [fk_ReplyReport_ReplyReporter] FOREIGN KEY ([ReplyReporter])
		REFERENCES [Users]([UsersId]),
	CONSTRAINT [fk_ReplyReport_ReportMessageId]	FOREIGN KEY ([ReportMessageId])
		REFERENCES [dbo].[ReportMessage] ([ReportMessageId]) ON UPDATE CASCADE,
	CONSTRAINT [ReplyId] PRIMARY KEY ([ReplyId], [ReplyReporter])
)
GO


/* Pledge Created by: Asa Armstrong */
print '' print '*** create Pledge table ***'
GO
CREATE TABLE [dbo].[Pledge] (
	[PledgeId]					[int] IDENTITY(100000, 1)	NOT NULL,
	[DonationId]				[int]						NULL,
	[UsersId]					[int]						NULL,
	[FundraisingEventId]		[int]						NOT NULL,
	[Date]						[datetime]					NOT NULL DEFAULT GETDATE(),
	[Amount]					[decimal](7,2)				NOT NULL,
	[Message]					[nvarchar](255)				NULL,
	[Target]					[nvarchar](255)				NULL,
	[Requirement]				[nvarchar](255)				NULL,
	[RequirementMet]			[bit]						NULL,
	[GivenName]					[nvarchar](50)				NOT NULL,
	[FamilyName]				[nvarchar](50)				NOT NULL,
	[Phone]						[nvarchar](13)				NULL,
	[Email]						[nvarchar](254)				NULL,
	[IsContactPreferencePhone]	[bit]						NOT NULL DEFAULT 1,
	[ReminderSent]				[bit]						NOT NULL DEFAULT 0,
	[ReminderDate]				[datetime]					NULL,
	
	CONSTRAINT [pk_PledgeId] PRIMARY KEY ([PledgeId]),
	CONSTRAINT [fk_PledgeDonationId] FOREIGN KEY ([DonationId])
			REFERENCES [dbo].[Donation]([DonationId]),
	CONSTRAINT [fk_PledgeUsersId] FOREIGN KEY ([UsersId]) 
			REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [fk_PledgeFundraisingEventId] FOREIGN KEY ([FundraisingEventId]) 
			REFERENCES [dbo].[FundraisingEvent]([FundraisingEventId])
)
GO

CREATE INDEX [ix_PledgeFundraisingEventId]
	ON [dbo].[Pledge]([FundraisingEventId])
GO



/* AdoptionApplication */
/* Created by: Ethan Kline */
print '' print '** creating table for AdoptionApplication'
GO
CREATE TABLE [dbo].[AdoptionApplication] (
    [AdoptionApplicationId]    	[int]  IDENTITY(100000,1)     NOT NULL,
    [ApplicantId]    			[int]     NOT NULL,
    [AnimalId]    				[int]     NOT NULL,
    [ApplicationStatusId]    	[nvarchar](50)     NOT NULL,
    [AdoptionApplicationDate]   [datetime]     NOT NULL

    CONSTRAINT [pk_AdoptionApplication] PRIMARY KEY([AdoptionApplicationId]),
    CONSTRAINT [fk_AdoptionApplication_ApplicantId] FOREIGN KEY ([ApplicantId])
        REFERENCES [dbo].[Applicant] ([ApplicantId]),
    CONSTRAINT [fk_AdoptionApplication_ApplicationStatusId] FOREIGN KEY ([ApplicationStatusId])
        REFERENCES [dbo].[ApplicationStatus] ([ApplicationStatusId]),
    CONSTRAINT [fk_AdoptionApplication_AnimalId] FOREIGN KEY ([AnimalId])
        REFERENCES [dbo].[Animal] ([AnimalId])
)
GO


print '' print '*** Creating InstitutionalEntity (Barry Mikulas)'
GO
CREATE TABLE [dbo].[InstitutionalEntity] (
	[InstitutionalEntityId]		[int] IDENTITY(100000, 1) 	NOT NULL,
	[CompanyName]				[nvarchar](100)				NULL,
	[GivenName]					[nvarchar](50)				NOT NULL,
	[FamilyName]				[nvarchar](50)				NOT NULL,
	[Email]						[nvarchar](254)				NOT NULL,
	[Phone]						[nvarchar](13)				NOT NULL,
	[Address]					[nvarchar](50)				NOT NULL,
	[AddressTwo]				[nvarchar](50)				NULL,
	[Zipcode]					[char](9)					NOT NULL,
	[ContactType]				[nvarchar](17)				NOT NULL,
	
	CONSTRAINT [pk_InstitutionalEntityId] PRIMARY KEY([InstitutionalEntityId]),
	CONSTRAINT [fk_InstitutionalEntity_Zipcode] FOREIGN KEY([Zipcode]) 
			REFERENCES [dbo].[Zipcode]([Zipcode]),
	CONSTRAINT [fk_InstitutionalEntity_ContactType] FOREIGN KEY([ContactType]) 
			REFERENCES [dbo].[ContactType]([ContactTypeId]) ON UPDATE CASCADE
)
GO

/* FundraisingCampaignEntity */
/* Created by:  Barry Mikulas */
print '' print '*** Creating FundraisingCampaignEntity (Barry Mikulas)'
GO
CREATE TABLE [dbo].[FundraisingCampaignEntity] (
	[Fundraiser]		[int] NOT NULL,
	[Institution]		[int] NOT NULL,
	CONSTRAINT [pk_FundraisingCampaignEntity] PRIMARY KEY([Fundraiser], [Institution]),
	CONSTRAINT [fk_FundraisingCampaignEntity_Fundraiser] FOREIGN KEY([Fundraiser]) 
			REFERENCES [dbo].[FundraisingCampaign]([FundraisingCampaignId]),
	CONSTRAINT [fk_FundraisingCampaignEntity_Institution] FOREIGN KEY([Institution]) 
			REFERENCES [dbo].[InstitutionalEntity]([InstitutionalEntityId])
)
GO

--print '' print '*** adding indexes to FundraisingCampaignEntity table (Barry Mikulas)'
GO
CREATE INDEX ix_FundraisingCampaignEntity_Fundraiser 
	ON [dbo].[FundraisingCampaignEntity] ([Fundraiser])
GO
CREATE INDEX ix_FundraisingCampaignEntity_Institution 
	ON [dbo].[FundraisingCampaignEntity] ([Institution])
GO

/* FundraisingEventEntity */
/* Created by:  Barry Mikulas */
print '' print '*** Creating FundraisingEventEntity (Barry Mikulas)'
GO
CREATE TABLE [dbo].[FundraisingEventEntity] (
	[EventId]		[int] NOT NULL,
	[ContactId]		[int] NOT NULL,
	CONSTRAINT [pk_FundraisingEventEntity] PRIMARY KEY([EventId], [ContactId]),
	CONSTRAINT [fk_FundraisingEventEntity_EventId] FOREIGN KEY([EventId]) 
			REFERENCES [dbo].[FundraisingEvent]([FundraisingEventId]),
	CONSTRAINT [fk_FundraisingEventEntity_ContactId] FOREIGN KEY([ContactId]) 
			REFERENCES [dbo].[InstitutionalEntity]([InstitutionalEntityId])
)
GO

--print '' print '*** adding indexes to FundraisingEventEntity table (Barry Mikulas)'
GO
CREATE INDEX ix_FundraisingEventEntity_EventId 
	ON [dbo].[FundraisingEventEntity] ([EventId])
GO


-- Made 2023/01/27 by: Teft Francisco
print '' print '*** creating table for inspection image'
GO
CREATE TABLE [dbo].[InspectionImage]
(
	[InspectionId] 				[int] 			NOT NULL,
    [ImageId]		 			[int] 			NOT NULL,
    CONSTRAINT [pk_InspectionImage] PRIMARY KEY ([InspectionId], [ImageId]),
    CONSTRAINT [fk_InspectionImage_InspectionId] FOREIGN KEY ([InspectionId])
		REFERENCES [dbo].[Inspection] ([InspectionId]),
    CONSTRAINT [fk_InspectionImage_ImageId] FOREIGN KEY ([ImageId])
		REFERENCES [dbo].[Images] ([ImageId])
)
GO

-- Made 2023/01/27 by: Teft Francisco
print '' print '*** creating table for adoption placement'
GO
CREATE TABLE [dbo].[AdoptionPlacement]
(
	[AdoptionPlacementId]	[int]	IDENTITY(100000,1)	NOT NULL,
	[AnimalId] 				[int] 						NOT NULL,
    [ApplicantId] 			[int] 						NOT NULL,
	[AdoptionDate]			[date]						NOT NULL,
    CONSTRAINT [pk_AdoptionPlacement] PRIMARY KEY ([AdoptionPlacementId]),
    CONSTRAINT [fk_AdoptionPlacement_AnimalId] FOREIGN KEY ([AnimalId])
		REFERENCES [dbo].[Animal] ([AnimalId]),
    CONSTRAINT [fk_AdoptionPlacement_ApplicantId] FOREIGN KEY ([ApplicantId])
		REFERENCES [dbo].[Applicant] ([ApplicantId])
)
GO


/* ShelterItemTransaction table */
/* Created by: Andrew Cromwell */
/* this table was not tested because of the forign keys */
print '' print '*** creating ShelterItemTransaction table'
GO
CREATE TABLE [dbo].[ShelterItemTransaction] (
	[ShelterItemTransactionId]	[int] IDENTITY(100000,1)	NOT NULL,
	[ShelterId]					[int]				NOT NULL,
	[ItemId]					[nvarchar](50)		NOT NULL,
	[ChangedByUsersId]			[int]				NOT NULL,
	[InventoryChangeReasonId]	[nvarchar](50)		NOT NULL,
	[QuantityIncrement]			[int]				NOT NULL,
	[DateChanged]				[datetime]  		DEFAULT	getdate(),
	CONSTRAINT [pk_ShelterItemTransactionId] PRIMARY KEY ([ShelterItemTransactionId]),
	CONSTRAINT [fk_ShelterItemTransaction_ShelterId] FOREIGN KEY ([ShelterId])
		REFERENCES [dbo].[Shelter]([ShelterId]),
	CONSTRAINT [fk_ShelterItemTransaction_ItemId] FOREIGN KEY ([ItemId])
		REFERENCES [dbo].[Item]([ItemId]),
	CONSTRAINT [fk_ShelterItemTransaction_ChangedByUsersId] FOREIGN KEY ([ChangedByUsersId])
		REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [fk_ShelterItemTransaction_InventoryChangeReasonId] FOREIGN KEY ([InventoryChangeReasonId])
		REFERENCES [dbo].[InventoryChangeReason]([InventoryChangeReasonId])
)
GO
/* INTAKE LINE TABLE */
-- Made 2023/01/27 by: Teft Francisco
print '' print '*** creating table for intake line'
GO
CREATE TABLE [dbo].[IntakeLine]
(
	[IntakeId] 					[int] 			NOT NULL,
    [AnimalId]		 			[int] 			NOT NULL,
    CONSTRAINT [pk_IntakeLine] PRIMARY KEY ([IntakeId], [AnimalId]),
    CONSTRAINT [fk_IntakeLine_IntakeId] FOREIGN KEY ([IntakeId])
		REFERENCES [dbo].[Intake] ([IntakeId]),
    CONSTRAINT [fk_IntakeLine_AnimalId] FOREIGN KEY ([AnimalId])
		REFERENCES [dbo].[Animal] ([AnimalId])
)
GO

print '' print '*** creating table for FundraiserAnimal (Stephen Jaurigue)'
GO
CREATE TABLE [dbo].[FundraiserAnimal] (
	[FundraisingEventId]	[int]	NOT NULL,
	[AnimalId]				[int]	NOT NULL,
	CONSTRAINT [pk_FundraisingEventId_and_AnimalId] PRIMARY KEY([FundraisingEventId],[AnimalId]),
	CONSTRAINT [fk_FundraisingEvent_FundraisingEventId] FOREIGN KEY([FundraisingEventId]) REFERENCES[FundraisingEvent]([FundraisingEventId]),
	CONSTRAINT [fk_Animal_AnimalId] FOREIGN KEY([AnimalId]) REFERENCES[Animal]([AnimalId])
)
GO

/* AnimalUpdates */
/* Created by: Matthew Meppelink */
print '' print '*** creating table for AnimalUpdates'
GO
CREATE TABLE [dbo].[AnimalUpdates] (
    [AnimalRecordId]        [int]                                   NOT NULL,
    [AnimalId]              [int]                                   NOT NULL,
    [AnimalRecordNotes]     [nvarchar](500)                         NOT NULL,
    [AnimalRecordDate]      [datetime]	DEFAULT GETDATE()           NOT NULL,
    CONSTRAINT  [pk_AnimalRecordId] PRIMARY KEY ([AnimalRecordId]),
    CONSTRAINT  [fk_AnimalUpdates_AnimalId] FOREIGN KEY ([AnimalID])
        REFERENCES [dbo].[Animal]([AnimalId]) ON UPDATE CASCADE
)
GO

/* Created by: Alex Oetken */
print '' print '*** creating table FosterPlacement'
GO

CREATE TABLE [dbo].[FosterPlacement](
	[FosterPlacementId]		[int] IDENTITY(100000,1) NOT NULL,
	[AnimalId]				[int]	NOT NULL,
	[ApplicantId]			[int]	NOT NULL,
	[FosterStartDate]		[date]	NOT NULL,
	[FosterEndDate]			[date]	NOT NULL, 
	[FosterAnimalReturned]	[bit]	NOT NULL DEFAULT 0, 
	
	CONSTRAINT [fk_FosterPlacement_AnimalId] 	FOREIGN KEY ([AnimalId])
			REFERENCES [dbo].[Animal]([AnimalId]),
	CONSTRAINT [fk_FosterPlacement_ApplicantId] 	FOREIGN KEY ([ApplicantId])
			REFERENCES [dbo].[Applicant]([ApplicantId]),
	CONSTRAINT [pk_FosterPlacementId]	PRIMARY KEY([FosterPlacementId])
	
)
GO 

/* Created by: Alex Oetken */
print '' print '*** creating table for FosterPlacementRecord'
GO

CREATE TABLE [dbo].[FosterPlacementRecord] (
	[FosterPlacementRecordId]		[int] IDENTITY(100000,1) NOT NULL,
	[FosterPlacementId]				[int] 					NOT NULL,
	[FosterPlacementRecordNotes]	[nvarchar](500)			NOT NULL,
	[FosterPlacementRecordDate]		[datetime] DEFAULT GETDATE() 		NOT NULL,
	
	CONSTRAINT [fk_FosterPlacement.FosterPlacementId] FOREIGN KEY ([FosterPlacementId])
		REFERENCES [dbo].[FosterPlacement]([FosterPlacementId]),
	CONSTRAINT [pk_FosterPlacementRecordId]	PRIMARY KEY([FosterPlacementRecordId])
)
GO 

/*Created By: Zaid Rachman*/
print '' print '*** Creating AdoptionApplicationResponse Table' 
GO
CREATE TABLE [dbo].[AdoptionApplicationResponse] (
	[AdoptionApplicationResponseId]	[int]				NOT NULL,
	[AdoptionApplicationId]			[int]				NOT NULL,
	[UsersId]						[int]				NOT NULL,
	[Approved]						[bit]				NOT NULL,
	[AdoptionApplicationResponseDate] [datetime] 		NOT NULL,
	[AdoptionApplicationResponseNotes] [nvarchar](500)	NULL
	
	CONSTRAINT [fk_AdoptionApplicationResponse_AdoptionApplicationId] FOREIGN KEY ([AdoptionApplicationId])
		REFERENCES [dbo].[AdoptionApplication]([AdoptionApplicationId]),
	CONSTRAINT [fk_AdoptionApplicationResponse_Users] FOREIGN KEY  ([UsersId])
		REFERENCES [dbo].[Users]([UsersId]),
	CONSTRAINT [pk_AdoptionApplicationResponse] PRIMARY KEY([AdoptionApplicationResponseId])
)
GO

/* Created by: Stephen Jaurigue */
print '' print '*** creating table for FundraiserVolunteerUser (Stephen Jaurigue)'
GO
CREATE TABLE [dbo].[FundraiserVolunteerUser] (
	[FundraisingEventId]		[int]	NOT NULL,
	[UsersId]			[int]	NOT NULL,
	CONSTRAINT [pk_FundraisingId_and_UsersId] PRIMARY KEY([FundraisingEventId],[UsersId]),
	CONSTRAINT [fk_Fundraising_FundraisingId] FOREIGN KEY([FundraisingEventId]) 
			REFERENCES [FundraisingEvent]([FundraisingEventId]),
	CONSTRAINT [fk_FundraiserVolunteerUser_UsersId] FOREIGN KEY([UsersId]) 
			REFERENCES [dbo].[Users]([UsersId])
)
GO
/* Created by: Stephen Jaurigue */
print '' print '*** creating table for ShelterExpense (Stephen Jaurigue)'
GO
CREATE TABLE [dbo].[ShelterExpense] (
	[ShelterExpenseId]		[int]	IDENTITY(100000,1) 	NOT NULL,
	[ShelterId]				[int]						NOT NULL,
	[CategoryID]			[nvarchar](50)				NOT NULL,
	[Year]					[smallint]					NOT NULL,
	[Amount]				[decimal](7,2)				NOT NULL,
	CONSTRAINT [pk_ShelterExpenseId] PRIMARY KEY([ShelterExpenseId]),
	CONSTRAINT [fk_Shelter_ShelterId] FOREIGN KEY ([ShelterId])
			REFERENCES [dbo].[Shelter]([ShelterId]),
	CONSTRAINT [fk_Category_CategoryId] FOREIGN KEY ([CategoryId])
			REFERENCES[dbo].[Category] ([CategoryId]),
	CONSTRAINT [ak_ShelterId_and_CategoryId_and_Year] UNIQUE([ShelterId],[CategoryId],[Year])
)
GO

/* Created by: John */
print '' print '*** creating table for Schedule(John)'
GO
CREATE TABLE [dbo].[Schedule] (
    [ScheduleId]        [int]    IDENTITY(100000,1)         NOT NULL,
    [UsersId]            [int]                             NOT NULL,
    [JobId]                [int],
    [StartTime]            [datetime]                        NOT NULL,
    [EndTime]            [datetime]                        NOT NULL
    CONSTRAINT [pk_ScheduleId] PRIMARY KEY([ScheduleId])
    CONSTRAINT    [fk_Schedule_UsersId] FOREIGN KEY ([UsersId])
        REFERENCES [dbo].[Users]([UsersId]),
    CONSTRAINT     [fk_Schedule_JobId] FOREIGN KEY ([JobId])
        REFERENCES [dbo].[Job]([JobId])
    
)
GO


/*  Created by: Molly Meister*/
print '' print '*** creating table for Death'
GO
CREATE TABLE [dbo].[Death] (
	[DeathId]              [int]	        IDENTITY(100000,1)       NOT NULL,
    [UsersId]              [int]            NOT NULL,
    [AnimalId]             [int] UNIQUE           NOT NULL,
    [DeathDate]            [datetime]       DEFAULT GETDATE()       NOT NULL,
    [DeathCause]           [nvarchar](100)  NOT NULL,
    [DeathDisposal]        [nvarchar](100)  NOT NULL,
    [DeathDisposalDate]    [datetime]       NOT NULL,
    [DeathNotes]           [nvarchar](500)  NULL,
	CONSTRAINT [pk_DeathId] PRIMARY KEY([DeathId]),
	CONSTRAINT [fk_Death_UsersId] FOREIGN KEY([UsersId])
            REFERENCES [dbo].[Users]([UsersId]),
    CONSTRAINT [fk_Death_AnimalId] FOREIGN KEY([AnimalId])
            REFERENCES [dbo].[Animal]([AnimalId])
)
GO




/*  
	Project:		PetNet
	Database Name:	PetNet_db_am
	Author:			Gwen Arman
    Description: 	Sprint 1, sample data
*/

print '' print '*** Using PetNet_db_am'
USE [PetNet_db_am]
GO 

/* Source: https://simplemaps.com/data/us-zips */
print '' print '*** creating Zipcode sample data'
GO 
INSERT INTO [dbo].[Zipcode]
	(
    [Zipcode],
    [City],
    [State],
    [Latitude],
    [Longitude]
    )
VALUES
(50001,'Ackworth','Iowa', 41.3669, 93.4727),
(50002,'Adair','Iowa', 41.5004, 94.6434)
GO

print '' print '*** creating Shelter sample data'
GO 
INSERT INTO [dbo].[Shelter]
	(
    [ShelterName],
    [Address],
    [Zipcode],
    [Phone],
    [Email],
    [Areasofneed],
    [ShelterActive]
    )
VALUES
("S1", "111 Shelter Drive", 50001, "123-123-1111", "shelter1@shelter.com", "Animal Food", 1),
("S2", "112 Shelter Drive", 50002, "123-123-1112", "shelter2@shelter.com", "Animal Medicine", 1),
("S3", "113 Shelter Drive", 50001, "123-123-1113", "shelter3@shelter.com", "Kitty Litter", 1)
GO


/* Insert Into AnimalStatus table stored procedure */
/* Created by Andrew Schneider */
print '' print '*** adding AnimalStatus records (Andrew S.)***'
GO
INSERT INTO dbo.AnimalStatus
	([AnimalStatusId], [AnimalStatusDescription])
	VALUES
		('Available', 'Test animal status description')
GO


/* Insert Into Animal table stored procedure */
/* Created by Andrew Schneider */
print '' print '*** adding Animal records (Andrew S.)***'
GO
INSERT INTO dbo.Animal
(	
	[AnimalName], [AnimalGender], [AnimalTypeId], [AnimalBreedId], [Personality], [Description], [AnimalStatusId],		
	[RecievedDate], [MicrochipSerialNumber], [Aggressive], [AggressiveDescription], [ChildFriendly], [NeuterStatus], [Notes]					
)
		
	VALUES
		('Fido', 'Male', 'Dog', 'Lab', 'Friendly', 'Great dog rescued', 'Available', '2023-01-01',
		'15A73', 0, 'Not aggressive', 1, 1, 'No notes')
GO



print '' print '*** creating Kennel sample data'
GO 
INSERT INTO [dbo].[Kennel]
	(
    [ShelterId],
    [KennelName],
    [AnimalTypeId],
    [KennelSpace],
    [KennelActive]
    )
VALUES
(100000, "Kennel 1", "Dog", 1, 1),
(100001, "Kennel 2", "Dog", 1, 1),
(100002, "Kennel 3", "Dog", 1, 1),
(100000, "Kennel 4", "Dog", 1, 1),
(100000, "Kennel 5", "Dog", 1, 1),
(100000, "Kennel 6", "Dog", 1, 1),
(100000, "Kennel 7", "Dog", 1, 1),
(100000, "Kennel 8", "Dog", 1, 1),
(100000, "Kennel 9", "Dog", 1, 1),
(100000, "Kennel 10", "Dog", 1, 1)
GO

print '' print '*** creating AnimalKenneling sample data'
GO 
INSERT INTO [dbo].[AnimalKenneling]
	(
	[KennelId],
	[AnimalId]
    )
VALUES
(100000, 100000)
GO




/* SelectAnimalByAnimalId stored procedure */
/* Created by Andrew Schneider */
print '' print '*** creating sp_select_animal_by_animalId (Andrew S.)'
GO
CREATE PROCEDURE [dbo].[sp_select_animal_by_animalId]
(
	@AnimalId			[int]
)
AS
	BEGIN
		SELECT	[Animal].[AnimalId], [AnimalName], [AnimalGender], [Animal].[AnimalTypeId], [AnimalBreedId],
				[Kennel].[KennelName], [Personality], [Description], [Animal].[AnimalStatusId],
				[AnimalStatus].[AnimalStatusDescription], [RecievedDate], [MicrochipSerialNumber],
				[Aggressive], [AggressiveDescription], [ChildFriendly], [NeuterStatus], [Notes]
		FROM 	[Animal]
		JOIN 	[AnimalStatus]
			ON 	[Animal].[AnimalStatusID] = [AnimalStatus].[AnimalStatusID]
		JOIN 	[AnimalKenneling]
			ON	[Animal].[AnimalId] = [AnimalKenneling].[AnimalId]
		JOIN	[Kennel]
			ON	[AnimalKenneling].[KennelId] = [Kennel].[KennelId]
		WHERE	@AnimalId = [Animal].[AnimalId]
	END
GO