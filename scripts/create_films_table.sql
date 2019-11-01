use StarWars;

CREATE TABLE Films (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Title varchar(255),
	EpisodeID int,
	OpeningCrawl text,
    Director varchar(255),
	Producer varchar(255),
	ReleaseDate date
);