INSERT INTO Users (Id, Name, Surname, Discriminator, Access) VALUES (1, 'Jonas', 'Schmidt', 'User', null);
INSERT INTO Users (Id, Name, Surname, Discriminator, Access) VALUES (2, 'Mia', 'Schulz', 'User', null);
INSERT INTO Users (Id, Name, Surname, Discriminator, Access) VALUES (3, 'Noah', 'Fischer', 'User', null);
INSERT INTO Users (Id, Name, Surname, Discriminator, Access) VALUES (4, 'Emma', 'Schulz', 'User', null);
INSERT INTO Users (Id, Name, Surname, Discriminator, Access) VALUES (5, 'Elias', 'Becker', 'User', null);

INSERT INTO Company (Id, Address, HqCompanyId, Name, ResponsibleUserId) VALUES (1, 'USA', null, 'Microsoft', 1);
INSERT INTO Company (Id, Address, HqCompanyId, Name, ResponsibleUserId) VALUES (2, 'USA', null, 'Google', 1);
INSERT INTO Company (Id, Address, HqCompanyId, Name, ResponsibleUserId) VALUES (3, 'Russia', null, 'Yandex', 2);
INSERT INTO Company (Id, Address, HqCompanyId, Name, ResponsibleUserId) VALUES (4, 'USA', null, 'EPAM', 3);

INSERT INTO Emails (Id, EmailAddress, Type, CompanyId, EmployeeId, UserId) VALUES (1, 'tryr@gmail.com', 1, null, null, 1);
INSERT INTO Emails (Id, EmailAddress, Type, CompanyId, EmployeeId, UserId) VALUES (2, 'google@gmail.com', 1, 2, null, null);
INSERT INTO Emails (Id, EmailAddress, Type, CompanyId, EmployeeId, UserId) VALUES (3, 'ms@bimg.com', 1, 1, null, null);

INSERT INTO Phones (Id, PhoneNumber, Type, CompanyId, EmployeeId, UserId) VALUES (2, '+79211234578', 1, null, null, 1);
INSERT INTO Phones (Id, PhoneNumber, Type, CompanyId, EmployeeId, UserId) VALUES (3, '+79311236785', 1, 1, null, null);
INSERT INTO Phones (Id, PhoneNumber, Type, CompanyId, EmployeeId, UserId) VALUES (4, '+79111237589', 1, 2, null, null);
INSERT INTO Phones (Id, PhoneNumber, Type, CompanyId, EmployeeId, UserId) VALUES (5, '+79001236281', 1, null, 1, null);
INSERT INTO Phones (Id, PhoneNumber, Type, CompanyId, EmployeeId, UserId) VALUES (6, '+79001231615', 1, null, 2, null);

INSERT INTO Employees (Id, CompanyId, Name, ResponsibleUserId, Surname) VALUES (1, 1, 'Brad', 1, 'Muller');
INSERT INTO Employees (Id, CompanyId, Name, ResponsibleUserId, Surname) VALUES (2, 1, 'Paul', 1, 'Hoffman');
INSERT INTO Employees (Id, CompanyId, Name, ResponsibleUserId, Surname) VALUES (3, 2, 'Sofia', 2, 'Becker');