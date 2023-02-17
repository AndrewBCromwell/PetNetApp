/* Created by: Molly Meister */
USE [PetNet_db_am]

print '' print '*** inserting sample AnimalBreed data'
GO
insert into [dbo].[AnimalBreed]
(
	[AnimalBreedId]
)
values 
	("Labrador"),
	("Common"),
	("Rare")
GO

/* Created by: Molly Meister */
print '' print '*** inserting sample AnimalStatus data'
GO
insert into [dbo].[AnimalStatus]
(
	[AnimalStatusId], [AnimalStatusDescription]      
)
values 
	("Kenneled", null),
	("Ded", "rlly ded")
GO

/* Created by: Molly Meister */
print '' print '*** inserting Animal test data'
GO
insert into [dbo].[Animal]
(
	[AnimalName], [AnimalGender], [AnimalTypeId], [AnimalBreedId], [Personality], [Description],
	[AnimalStatusId], [RecievedDate], [MicrochipSerialNumber], [Aggressive], [AggressiveDescription], 
	[ChildFriendly], [NeuterStatus], [Notes], [AnimalShelterId]
)
values
	("Queso", "Unknown", "Snake", "Rare", "Sad", "flaky buttery crust, cheese inside", "Ded", DEFAULT, 
		"123456789123456", 0, NULL, 0, 0, NULL, 100000),
	("Spot", "Male", "Dog", "Labrador", "Happy", "best boi", "Kenneled", DEFAULT, 
		"111111111111111", 0, NULL, 0, 0, NULL, 100000),
	("Jamboree", "Unknown", "Snake", "Rare", "Sad", "flaky buttery crust, cheese inside", "Ded", DEFAULT, 
		"222222222222222", 0, NULL, 0, 0, NULL, 100000),
	("Chhalupa", "Male", "Dog", "Labrador", "Happy", "best boi", "Kenneled", DEFAULT, 
		"333333333333333", 0, NULL, 0, 0, NULL, 100000),
	("Mike", "Unknown", "Snake", "Rare", "Sad", "flaky buttery crust, cheese inside", "Ded", DEFAULT, 
		"444444444444444", 0, NULL, 0, 0, NULL, 100000),
	("Cat", "Male", "Dog", "Labrador", "Happy", "best boi", "Kenneled", DEFAULT, 
		"555555555555555", 0, NULL, 0, 0, NULL, 100000),
	("Taco", "Unknown", "Snake", "Rare", "Sad", "flaky buttery crust, cheese inside", "Ded", DEFAULT, 
		"666666666666666", 0, NULL, 0, 0, NULL, 100000),
	("KCRG TV9", "Male", "Dog", "Labrador", "Happy", "best boi", "Kenneled", DEFAULT, 
		"777777777777777", 0, NULL, 0, 0, NULL, 100000)
GO