CREATE PROCEDURE [dbo].[UpdateGenre]
	@GenreID int,
	@GenreName nvarchar(50)
AS
	UPDATE Genre SET Name=@GenreName WHERE GenreID=@GenreID;
RETURN @@rowcount
