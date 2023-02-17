USE [PetNet_db_am]

print '' print '*** creating AnimalKenneling sample data'
GO 
INSERT INTO [dbo].[AnimalKenneling]
    (
    [KennelId],
    [AnimalId]
    )
VALUES
(100001, 100001),
(100002, 100002)
GO