CREATE PROCEDURE [dbo].[UpdateVideoGame]
	@id int,
	@title nvarchar(255),
	@system nvarchar(255),
	@genre nvarchar(255),
	@releasedate nvarchar(255),
	@esrb nvarchar(255),
	@publisher nvarchar(255),
	@developer nvarchar(255)
AS
	UPDATE VideoGames SET Title=@title WHERE Title=@title;
	UPDATE VideoGames SET [System]=@system WHERE [System]=@system;
	UPDATE VideoGames SET Genre=@genre WHERE Genre=@genre;
	UPDATE VideoGames SET ReleaseDate=@releasedate WHERE ReleaseDate=@releasedate;
	UPDATE VideoGames SET ESRB=@esrb WHERE ESRB=@esrb;
	UPDATE VideoGames SET Publisher=@publisher WHERE Publisher=@publisher;
	UPDATE VideoGames SET Developer=@developer WHERE Developer=@developer;
RETURN @@rowcount
