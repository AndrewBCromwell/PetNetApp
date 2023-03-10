Use [PetNet_db_am]

print '' print '*** adding InstitutionalEntity records ***'
GO
INSERT INTO dbo.InstitutionalEntity
		(CompanyName, GivenName, FamilyName, Email, Phone, Address, AddressTwo, Zipcode, ContactType, ShelterId)
	VALUES
		('Noelridge Park', 'John', 'Doe', 'john@doe.com', '5551235551234', '4900 Council St NE', null, '84090', 'Host', 100000),
		('Noelridge Park', 'Jane', 'Doe', 'jane@doe.com', '5551235551234', '4900 Council St NE', null, '84090', 'Contact', 100000),
		('Noelridge Park', 'Juan', 'Doe', 'juan@doe.com', '5551235551234', '4900 Council St NE', null, '84090', 'Sponsor', 100000),
		('Bever Park', 'John', 'Doe', 'john@doe.com', '5551235551234', '2700 Bever Ave SE', null, '52402', 'Host', 100000),
		('Bever Park', 'Jane', 'Doe', 'jane@doe.com', '5551235551234', '2700 Bever Ave SE', null, '52402', 'Contact', 100000),
		('Bever Park', 'Juan', 'Doe', 'juan@doe.com', '5551235551234', '2700 Bever Ave SE', null, '52402', 'Sponsor', 100000),
		('Albertsons', 'Aiden', 'Martin', 'Aiden.Martin@Albersons.com', '5551235551234', '2700 Bever Ave SE', null, '55572', 'Host', 100000),
		('Albertsons', 'Aiden', 'Martin', 'Aiden.Martin@Albersons.com', '5551235551234', '2700 Bever Ave SE', null, '55572', 'Contact', 100000),
		('Albertsons', 'Aiden', 'Martin', 'Aiden.Martin@Albersons.com', '5551235551234', '2700 Bever Ave SE', null, '55572', 'Sponsor', 100000),
		('Coca Cola', 'Amelia', 'Rodriguez', 'Amelia.Rodriguez@cocacola.com', '5551235551234', '2700 Bever Ave SE', null, '41722', 'Host', 100000),
		('Coca Cola', 'Amelia', 'Rodriguez', 'Amelia.Rodriguez@cocacola.com', '5551235551234', '2700 Bever Ave SE', null, '41722', 'Contact', 100000),
		('Coca Cola', 'Amelia', 'Rodriguez', 'Amelia.Rodriguez@cocacola.com', '5551235551234', '2700 Bever Ave SE', null, '41722', 'Sponsor', 100000),
		('Cigna', 'Aria', 'Lopez', 'Aria.Lopez@cigna.com', '5551235551234', '2700 Bever Ave SE', null, '29621', 'Host', 100000),
		('Cigna', 'Aria', 'Lopez', 'Aria.Lopez@cigna.com', '5551235551234', '2700 Bever Ave SE', null, '29621', 'Contact', 100000),
		('Cigna', 'Aria', 'Lopez', 'Aria.Lopez@cigna.com', '5551235551234', '2700 Bever Ave SE', null, '29621', 'Sponsor', 100000),		
		('Cigna', 'Aria', 'Lopez', 'Aria.Lopez@cigna.com', '5551235551234', '2700 Bever Ave SE', null, '22937', 'Contact', 100000),
		(NULL, 'Aiden', 'Brooks', 'Aiden.Brooks@gmail.com', '5551235551234', '2700 Bever Ave SE', null, '22937', 'Contact', 100000),				
		(NULL, 'Amelia', 'Mitchell', 'Amelia.Mitchell@aol.com', '5551235551234', '2700 Bever Ave SE', null, '22937', 'Contact', 100000),
		('Noelridge Park', 'John', 'Doe', 'john@doe.com', '5551235551234', '4900 Council St NE', null, '17985', 'Host', 100001),
		('Noelridge Park', 'Jane', 'Doe', 'jane@doe.com', '5551235551234', '4900 Council St NE', null, '17985', 'Contact', 100001),
		('Noelridge Park', 'Juan', 'Doe', 'juan@doe.com', '5551235551234', '4900 Council St NE', null, '17985', 'Sponsor', 100001),
		('Bever Park', 'John', 'Doe', 'john@doe.com', '5551235551234', '2700 Bever Ave SE', null, '14042', 'Host', 100001),
		('Bever Park', 'Jane', 'Doe', 'jane@doe.com', '5551235551234', '2700 Bever Ave SE', null, '14042', 'Contact', 100001),
		('Bever Park', 'Juan', 'Doe', 'juan@doe.com', '5551235551234', '2700 Bever Ave SE', null, '14042', 'Sponsor', 100001)
GO