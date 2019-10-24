CREATE PROCEDURE [dbo].[GetGenre]
	@genreid int
AS
	SELECT * FROM Genre WHERE GenreID = @genreid;
RETURN 0
