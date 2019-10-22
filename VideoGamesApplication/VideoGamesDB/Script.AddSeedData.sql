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