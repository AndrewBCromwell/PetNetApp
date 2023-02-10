Use [PetNet_db_am]


 
print '' print '*** adding ExpenseCategory records ***'
GO
INSERT INTO [dbo].[ExpenseCategory]
		(
		[ExpenseCategoryName]
		)
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

print '' print '*** Inserting Job Records'
GO
INSERT INTO [dbo].[Job]
		(
		[JobDescription]
		)
	VALUES
		('Kennel Cleaning'),
		('Feeding animals'),
		('Checking on sick animals')
GO
	
	print '' print '*** Inserting Role Records'
GO
INSERT INTO [dbo].[Role]
		(
		[RoleId],
		[RoleDescription]
		)
	VALUES
		('Volunteer',''),
		('Admin',''),
		('Vet',''),
		('Manger',''),
		('Employee','')
GO

print '' print '*** Inserting Pronoun Records'
GO
INSERT INTO [dbo].[Pronoun]
		(
		[PronounId]
		)
	VALUES
		("He/Him"),
		("She/Her"),
		("They/Them"),
		("He/She"),
		("He/They"),
		("She/They"),
		("Any/All"),
		('Other')
GO

print '' print '*** inserting Images test records'
GO
INSERT INTO [dbo].[Images]
		(
		[ImageFileName]
		)
	VALUES
		('Dog.jpg'),
		('cat.jpg'),
		('bird.jpg'),
		('NotReal.jpeg'),
		('Fake.png')
GO

print '' print '*** Inserting ReportMessage Records'
GO
INSERT INTO [dbo].[ReportMessage]
		(
		[ReportMessageDescription]
		)
	VALUES
		('This is a message of reporting'),
		('bad words'),
		('inappropriate name'),
		('rude comment')
GO

print '' print '*** Inserting EventType Records'
GO
INSERT INTO [dbo].[EventType]
		(
		[EventTypeId],
		[EventTypeDescription]
		)
	VALUES
		('Gala','Pet Gala'),
		('Park','Day of adoptable pets in the park'),
		('Pet day','Adoptable pets day')
GO

print '' print '*** inserting ApplicationStatus test records'
GO
INSERT INTO [dbo].[ApplicationStatus]
		(
		[ApplicationStatusId]
		)
	VALUES
		('Approved'),
		('Denied'),
		('Pending')
GO

print '' print '*** adding HomeOwnership records ***'
GO
INSERT INTO [dbo].[HomeOwnership]
		(
		[HomeOwnershipId]
		)
	VALUES
		("Own"),
		("Rent")
GO

print '' print '*** Inserting HomeType Records'
GO
INSERT INTO [dbo].[HomeType]
		(
		[HomeTypeID]
		)
	VALUES
		('Single parent'),
		('With kids'),
		('With other pets')
GO

print '' print '*** Inserting BannedWords Records'
GO
INSERT INTO [dbo].[BannedWord]
		(
		[BannedWordId]
		)
	VALUES
		('Shit'),
		('Fuck'),
		('Cunt'),
		('Bitch'),
		('Cock'),
		('Dick')
GO

print '' print '*** Inserting DonationFrequency Records'
GO
INSERT INTO [dbo].[DonationFrequency]
		(
		[DonationFrequencyId]
		)
	VALUES
		('Every 30 days'),
		('Once a YEAR'),
		('One time')
GO


print '' print '*** inserting prescriptionType test records'
GO
INSERT INTO [dbo].[prescriptionType]
		(
		[PrescriptionTypeId]
		)
	VALUES
		('Medication'),
		('Food'),
		('Treatment')
GO

print '' print '*** Inserting sample Category (Inventory item tagging) records'
GO
INSERT INTO [dbo].[Category]
		(
		[CategoryID]
		)
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

print '' print '*** Inserting Item Records'
GO
INSERT INTO [dbo].[Item]
		(
		[ItemId]
		)
	VALUES
		
		 ('Cat Food')   ,
		 ('Dog Food')    ,
		 ('Rabbit Food') ,
		 ('Rodent Food') ,
		 ('Bird Feed')   ,
		 ('Toys')        ,
		 ('Medicine')    ,
		 ('Vaccinations')
GO

print '' print '*** Inserting AnimalType Records'
GO
INSERT INTO [dbo].[AnimalType]
		(
		[AnimalTypeId]
		)
	VALUES
		('Dog'),
		('Cat'),
		('Snake')	
GO

print '' print '*** Inserting AnimalStatus Records'
GO
INSERT INTO [dbo].[AnimalStatus]
		(
		[AnimalStatusId],
		[AnimalStatusDescription]
		)
	VALUES
		('Sick', 'Animal is sick'),
		('Healthy', 'Animal is healthy')
GO


print '' print '*** Inserting InventoryChangeReason Records'
GO
INSERT INTO [dbo].[InventoryChangeReason]
		(
		[InventoryChangeReasonId], 
		[ReasonDescription]
		)
	VALUES
		('Check-in', 'Item was checked in'),
		('Check-out', 'Item was checked out')
GO

print '' print '*** creating AnimalBreed test records' 
GO 
INSERT INTO [dbo].[AnimalBreed]
		(
		[AnimalBreedId]
		)
	VALUES 
		('Lab'), 
		('Persian'),
		('Domestic Shorthair'),
		('Parakeet'),
		('German Shepard')
GO


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

print '' print '*** creating TicketStatus sample data'
GO
INSERT INTO [dbo].[TicketStatus]
		(
		[TicketStatusId]
		)
	VALUES 
		('Approved'), 
		('Denied'),
		('Pending')
GO


print '' print '*** creating AppealStatus sample data'
GO
INSERT INTO [dbo].[AppealStatus]
		(
		[AppealStatusId],
		[AppealDescription]
		)
	VALUES 
		('Approved','This is approved'), 
		('Denied','This is denied'),
		('Pending','This is pending')
GO

print '' print '*** creating Gender test records' 
GO 
INSERT INTO [dbo].[Gender]
		(
		[GenderId]
		)
	VALUES 
		('Female'), 
		('Male'),
		('Unknown'),
		('Other')
GO

print '' print '*** Inserting ContactType Records'
GO
INSERT INTO [dbo].[ContactType]
		(
		[ContactTypeId]
		)
	VALUES
		('Host'),
		('Contact'),
		('Sponsor')	
GO


print '' print '*** creating test data for Users (Mads)'
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
		[AddressTwo], 
		[Zipcode], 
		[Phone]
		)
    VALUES
		("Unknown", "He/She", "999999", "Mads", "Rhea", "madsrhea@company.com", "811 Kirkwood Parkway", "Apt 207", '50001', "3195943138"),
		("Male", "He/Him", "888888", "Stephen", "Jaurigue", "stephenjaurigue@company.com", "123 Kirkwood Parkway", "Apt 210", "50001", "3195555555"),
		("Female", "She/Her", "777777", "Molly", "Meister", "mollymeister@company.com", "456 Kirkwood Parkway", "Apt 256", "50001", "3196666666"),
		('Male', 'He/Him', '666666', 'Tyler', 'Hand', 'tylerhand@company.com', '789 Kirkwood Parkway', 'Apt 240', '50002', '3197777777')
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
		("Shelter 1", "111 Shelter Drive", 50001, "123-123-1111", "shelter1@shelter.com", "Animal Food", 1),
		("Shelter 2", "112 Shelter Drive", 50002, "123-123-1112", "shelter2@shelter.com", "Animal Medicine", 1),
		("Shelter 3", "113 Shelter Drive", 50001, "123-123-1113", "shelter3@shelter.com", "Kitty Litter", 1)
GO


print '' print '*** creating Animal sample data'
GO 
INSERT INTO [dbo].[Animal]
		(
		[AnimalName],
		[AnimalGender],
		[AnimalTypeId],
		[AnimalBreedId],
		[AnimalStatusId],
		[RecievedDate],
		[MicrochipSerialNumber],
		[Notes]
		)
	VALUES
		("Franny", "Female", "Dog", "Lab", "Healthy", "2022-12-15", "Microchip111111", "Very Cute"), 
		("Spots", "Female", "Dog", "Lab", "Healthy", "2022-12-01", "Microchip111112", "Lots of spots"), 
		("Ruffer", "Female", "Dog", "Lab", "Healthy", "2022-12-03", "Microchip111113", "Barks a lot"),
		("Buddy", "Female", "Dog", "Lab", "Healthy", "2022-12-03", "Microchip111114", "A cat in disguise")
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
		(100000, 100000),
		(100001, 100001),
		(100008, 100002),
		(100009, 100003)
GO
print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[Post]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[Event]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[EventUpdate]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[Intake]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[TimeClock]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[ResourceAddRequest]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[Suspension]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[Reply]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[Favorite]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

print '' print '*** Creating Table name sample data'

GO
INSERT INTO [dbo].[]
		(
		[],
		[]
		)
	VALUES
		(),
		(),
		(),
		()
GO

