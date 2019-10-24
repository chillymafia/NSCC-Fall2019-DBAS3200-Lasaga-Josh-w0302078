CREATE PROCEDURE [dbo].[InsertVideoGame]
	@id int,
	@title nvarchar(255),
	@system nvarchar(255),
	@genre nvarchar(255),
	@releasedate nvarchar(255),
	@esrb nvarchar(255),
	@publisher nvarchar(255),
	@developer nvarchar(255),
	@new_Identity int = NULL OUTPUT
AS
	INSERT INTO VideoGames (ID) VALUES (@title);
	INSERT INTO VideoGames (ID) VALUES (@system);
	INSERT INTO VideoGames (ID) VALUES (@genre);
	INSERT INTO VideoGames (ID) VALUES (@releasedate);
	INSERT INTO VideoGames (ID) VALUES (@esrb);
	INSERT INTO VideoGames (ID) VALUES (@publisher);
	INSERT INTO VideoGames (ID) VALUES (@developer);

	SET @new_Identity = SCOPE_IDENTITY();

RETURN 0
