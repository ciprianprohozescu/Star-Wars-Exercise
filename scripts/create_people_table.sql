use StarWars;

CREATE TABLE Persons (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
	Height varchar(255),
	Mass varchar(255),
	HairColor varchar(255),
	SkinColor varchar(255),
	EyeColor varchar(255),
    BirthYear varchar(255),
	Gender varchar(255),
	Homeworld varchar(255)
);