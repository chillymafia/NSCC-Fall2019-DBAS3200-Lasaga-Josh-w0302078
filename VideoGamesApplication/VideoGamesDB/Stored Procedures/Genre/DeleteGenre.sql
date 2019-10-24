CREATE PROCEDURE [dbo].[DeleteGenre]
	@GenreID int
AS
	DELETE FROM Genre WHERE Genre.GenreID = @GenreID;
RETURN @@rowcount
