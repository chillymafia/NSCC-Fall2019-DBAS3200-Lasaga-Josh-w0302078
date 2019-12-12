/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT 1 FROM VideoGames)
BEGIN
	INSERT INTO VideoGames (Title, System.Name, ReleaseDate, ESRB.Rating, Publisher.Name, Developer.Name) VALUES('Devil May Cry','PS2','08/23/2001','M','Capcom','Capcom');
	INSERT INTO VideoGames (Title, System.Name, ReleaseDate, ESRB.Rating, Publisher.Name, Developer.Name) VALUES('GTA: San Andreas','PS2','10/26/2004','M','Rockstar','Rockstar');
	INSERT INTO VideoGames (Title, System.Name, ReleaseDate, ESRB.Rating, Publisher.Name, Developer.Name) VALUES('Persona 5','PS4','09/15/2016','M','Atlus','Atlus');
	INSERT INTO VideoGames (Title, System.Name, ReleaseDate, ESRB.Rating, Publisher.Name, Developer.Name) VALUES('Pokemon Moon','3DS','11/18/2016','E','Gamefreak','Nintendo');
	INSERT INTO VideoGames (Title, System.Name, ReleaseDate, ESRB.Rating, Publisher.Name, Developer.Name) VALUES('Mario KArt 8 Deluxe','Switch','04/27/2017','E','Nintendo','Nintendo');
END
--populate ESRB ratings--
IF NOT EXISTS (SELECT 1 From ESRB)
BEGIN
	INSERT INTO ESRB ([Rating]) VALUES ('EC');
	INSERT INTO ESRB ([Rating]) VALUES ('E');
	INSERT INTO ESRB ([Rating]) VALUES ('E10+');
	INSERT INTO ESRB ([Rating]) VALUES ('T');
	INSERT INTO ESRB ([Rating]) VALUES ('M');
	INSERT INTO ESRB ([Rating]) VALUES ('AO');
END

--Populate Genres--
IF NOT EXISTS (SELECT 1 From Genre)
BEGIN
	INSERT INTO Genre ([Name]) VALUES ('MMO');
	INSERT INTO Genre ([Name]) VALUES ('Simulation');
	INSERT INTO Genre ([Name]) VALUES ('Adventure');
	INSERT INTO Genre ([Name]) VALUES ('First-Person-Shooter');
	INSERT INTO Genre ([Name]) VALUES ('Third-Person-Shooter');
	INSERT INTO Genre ([Name]) VALUES ('Puzzle');
	INSERT INTO Genre ([Name]) VALUES ('Action');
	INSERT INTO Genre ([Name]) VALUES ('Stealth');
	INSERT INTO Genre ([Name]) VALUES ('Sports');
	INSERT INTO Genre ([Name]) VALUES ('RPG');
	INSERT INTO Genre ([Name]) VALUES ('Educational');
	INSERT INTO Genre ([Name]) VALUES ('Platformer');
	INSERT INTO Genre ([Name]) VALUES ('Fighting');
	INSERT INTO Genre ([Name]) VALUES ('Rhythm');
	INSERT INTO Genre ([Name]) VALUES ('Strategy');
	INSERT INTO Genre ([Name]) VALUES ('Survival');
	INSERT INTO Genre ([Name]) VALUES ('Horror');
	INSERT INTO Genre ([Name]) VALUES ('Racing');
	INSERT INTO Genre ([Name]) VALUES ('Beat-em-ups');
END

--Populate System--
IF NOT EXISTS (SELECT 1 From System)
BEGIN
INSERT INTO System(Name, Company) VALUES ('GameBoy','Nintendo');
INSERT INTO System(Name, Company) VALUES ('GameBoy-Color','Nintendo');
INSERT INTO System(Name, Company) VALUES ('GameBoy-Advanced','Nintendo');
INSERT INTO System(Name, Company) VALUES ('DS','Nintendo');
INSERT INTO System(Name, Company) VALUES ('3DS','Nintendo');
INSERT INTO System(Name, Company) VALUES ('Switch','Nintendo');
INSERT INTO System(Name, Company) VALUES ('PS1','Sony');
INSERT INTO System(Name, Company) VALUES ('PS2','Sony');
INSERT INTO System(Name, Company) VALUES ('PS3','Sony');
INSERT INTO System(Name, Company) VALUES ('PS4','Sony');
INSERT INTO System(Name, Company) VALUES ('Wii','Nintendo');
INSERT INTO System(Name, Company) VALUES ('Wii-U','Nintendo');
INSERT INTO System(Name, Company) VALUES ('GameCube','Nintendo');
INSERT INTO System(Name, Company) VALUES ('Xbox One','Microsoft');
INSERT INTO System(Name, Company) VALUES ('Xbox','Microsoft');
INSERT INTO System(Name, Company) VALUES ('Xbox 360','Microsoft');
INSERT INTO System(Name, Company) VALUES ('PC','Unknown');
END

--Populate Developers--
IF NOT EXISTS (SELECT 1 From Developer)
BEGIN
INSERT INTO Developer([Name]) VALUES ('NaughtyDog');
INSERT INTO Developer([Name]) VALUES ('Atlus');
INSERT INTO Developer([Name]) VALUES ('Capcom');
INSERT INTO Developer([Name]) VALUES ('Valve');
INSERT INTO Developer([Name]) VALUES ('Rockstar');
INSERT INTO Developer([Name]) VALUES ('Electronic Arts');
INSERT INTO Developer([Name]) Values ('Gamefreak');
END

--Populate Publishers--
IF NOT EXISTS (SELECT 1 From Publisher)
BEGIN
INSERT INTO Publisher([Name]) VAlUES ('Sony');
INSERT INTO Publisher([Name]) VAlUES ('Activision');
INSERT INTO Publisher([Name]) VAlUES ('Bandai Namco');
INSERT INTO Publisher([Name]) VAlUES ('Square Enix');
INSERT INTO Developer([Name]) VALUES ('Electronic Arts');
INSERT INTO Developer([Name]) VALUES ('Valve');
INSERT INTO Developer([Name]) VALUES ('Rockstar');
Insert into Developer([Name]) Values ('Nintendo');
END