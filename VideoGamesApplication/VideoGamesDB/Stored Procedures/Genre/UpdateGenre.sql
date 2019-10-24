CREATE PROCEDURE [dbo].[UpdateGenre]
	@genreid int,
	@Name nvarchar(50)
AS
	UPDATE Genre SET Name=@Name WHERE GenreID=@genreid;
RETURN @@rowcount
