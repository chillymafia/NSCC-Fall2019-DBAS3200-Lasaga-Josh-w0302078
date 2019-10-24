CREATE PROCEDURE [dbo].[GetVideoGames]
	@id int,
	@title nvarchar(255),
	@system nvarchar(255),
	@genre nvarchar(255),
	@releasedate nvarchar(255),
	@esrb nvarchar(255),
	@publisher nvarchar(255),
	@developer nvarchar(255)
AS
	SELECT * FROM VideoGames WHERE ID=@id;
RETURN 0
