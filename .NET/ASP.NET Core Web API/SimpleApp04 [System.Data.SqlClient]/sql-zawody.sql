-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-04-20 19:44:02.233

-- tables
-- Table: Championship

DROP TABLE IF EXISTS Championship_Team;
DROP TABLE IF EXISTS Player_Team;
DROP TABLE IF EXISTS Player;
DROP TABLE IF EXISTS Team;
DROP TABLE IF EXISTS Championship;
CREATE TABLE Championship (
    IdChampionship int  NOT NULL IDENTITY,
    OfficialName nvarchar(100)  NOT NULL,
    Year int  NOT NULL,
    CONSTRAINT Championship_pk PRIMARY KEY  (IdChampionship)
);

-- Table: Championship_Team
CREATE TABLE Championship_Team (
    IdChampionshipTeam int  NOT NULL IDENTITY,
    IdTeam int  NOT NULL,
    IdChampionship int  NOT NULL,
    Score float  NOT NULL,
    CONSTRAINT Championship_Team_pk PRIMARY KEY  (IdChampionshipTeam)
);

-- Table: Player
CREATE TABLE Player (
    IdPlayer int  NOT NULL IDENTITY,
    FirstName nvarchar(30)  NOT NULL,
    LastName nvarchar(50)  NOT NULL,
    DateOfBirth datetime  NOT NULL,
    CONSTRAINT Player_pk PRIMARY KEY  (IdPlayer)
);

-- Table: Player_Team
CREATE TABLE Player_Team (
    IdPlayerTeam int  NOT NULL IDENTITY,
    IdPlayer int  NOT NULL,
    IdTeam int  NOT NULL,
    NumOnShirt int  NOT NULL,
    Comment nvarchar(300)  NULL,
    CONSTRAINT Player_Team_pk PRIMARY KEY  (IdPlayerTeam)
);

-- Table: Team
CREATE TABLE Team (
    IdTeam int  NOT NULL IDENTITY,
    TeamName nvarchar(30)  NOT NULL,
    MaxAge int  NOT NULL,
    CONSTRAINT Team_pk PRIMARY KEY  (IdTeam)
);

-- foreign keys
-- Reference: Championship_Team_Championship (table: Championship_Team)
ALTER TABLE Championship_Team ADD CONSTRAINT Championship_Team_Championship
    FOREIGN KEY (IdChampionship)
    REFERENCES Championship (IdChampionship);

-- Reference: Championship_Team_Team (table: Championship_Team)
ALTER TABLE Championship_Team ADD CONSTRAINT Championship_Team_Team
    FOREIGN KEY (IdTeam)
    REFERENCES Team (IdTeam);

-- Reference: Player_Team_Player (table: Player_Team)
ALTER TABLE Player_Team ADD CONSTRAINT Player_Team_Player
    FOREIGN KEY (IdPlayer)
    REFERENCES Player (IdPlayer);

-- Reference: Player_Team_Team (table: Player_Team)
ALTER TABLE Player_Team ADD CONSTRAINT Player_Team_Team
    FOREIGN KEY (IdTeam)
    REFERENCES Team (IdTeam);

-- End of file.

INSERT INTO Player VALUES ('Jan','Kowalski',GETDATE()),('Norbert','Gierczak','01-05-1991'),('Pawel','Pawlowski','03-02-1970');

INSERT INTO Team VALUES ('Blue',21),('Red',30);
INSERT INTO Championship VALUES ('Rozgrywki o zlote kalesony',2012),('Zlota maczuga',2021);
INSERT INTO Championship_Team VALUES (1,1,10),(2,1,5),(2,2,20);
INSERT INTO Player_Team VALUES (1,1,10,null),(2,2,9,'Najlepszy')

