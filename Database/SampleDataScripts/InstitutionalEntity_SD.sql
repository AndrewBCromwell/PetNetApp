Use [PetNet_db_am]

print '' print '*** adding InstitutionalEntity records ***'
GO
INSERT INTO dbo.InstitutionalEntity
		(CompanyName, GivenName, FamilyName, Email, Phone, Address, AddressTwo, Zipcode, ContactType, ShelterId)
	VALUES
		('Noelridge Park', 'John', 'Doe', 'john@doe.com', '5551235551234', '4900 Council St NE', null, '52402', 'Host', 100000),
		('Noelridge Park', 'Jane', 'Doe', 'jane@doe.com', '5551235551234', '4900 Council St NE', null, '52402', 'Contact', 100000),
		('Noelridge Park', 'Juan', 'Doe', 'juan@doe.com', '5551235551234', '4900 Council St NE', null, '52402', 'Contact', 100000),
		('Bever Park', 'John', 'Doe', 'john@doe.com', '5551235551234', '2700 Bever Ave SE', null, '52402', 'Host', 100001),
		('Bever Park', 'Jane', 'Doe', 'jane@doe.com', '5551235551234', '2700 Bever Ave SE', null, '52402', 'Contact', 100001),
		('Bever Park', 'Juan', 'Doe', 'juan@doe.com', '5551235551234', '2700 Bever Ave SE', null, '52402', 'Sponsor', 100001)
GO