CREATE PROCEDURE [dbo].[DeleteVideoGame]
	@ID int,
	@title nvarchar(255),
	@system nvarchar(255),
	@genre nvarchar(255),
	@releasedate nvarchar(255),
	@esrb nvarchar(255),
	@publisher nvarchar(255),
	@developer nvarchar(255)
AS
	DELETE FROM VideoGames WHERE VideoGames.ID = @id;
RETURN 0
