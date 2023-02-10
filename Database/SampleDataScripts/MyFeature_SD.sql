/***************************************************************
I.R. Stoodent
Created: 2023/02/22

Description:
File containing the event table
**************************************************************
<Updater Name>
Updated: yyyy/mm/dd

Description: 
****************************************************************/


USE [SomeDatabase_db]
GO


print '' print '*** sample records for Event table ***'
GO
INSERT INTO [dbo].[Event] (
	[EventName],
	[EventDescription],	
	[TotalBudget],
	[LocationID]
)
VALUES 
	('Scottish Highland Games', 'Event created for the Scottish Highland games in Cedar Rapids, IA',1000.00,100000),
	('Clean Up the Park','An event to organize a way to clean up the local park.',1000.00,100002),
	('Coachella in the Corridor','A music festival to raise money for local charities.',1000.00,100002),
	('Meeting of the C-Sharpians','Convention for C# coding enthusiasts.',1000.00,100003),
	('Ragbrai Stop Mason City','The event plans for Ragbrai in Mason City 2022.',1000.00,100005),
	('Jazzfest','Live jazz performances and food vendors downtown Iowa City.',1000.00,100004),
	('Bix7 2021','7 mile race in Davenport, Iowa ',1000.00,100000),
	('Spelling Bee for the Bees','A spelling bee contest to raise money for a bee sanctuary.',1000.00,100000),
	('Apple-Bobbing','Apple-Bobbing contest.',1000.00,100000),
	('Suprise Birthday Party for Alaina','Surprise party for Alaina. Will add date when I find out when her birthday is.',1000.00,100004),
	('Protest Injustice','Peaceful protest event at time and location unknown to keep the man off our tracks.',1,NULL)

GO

	