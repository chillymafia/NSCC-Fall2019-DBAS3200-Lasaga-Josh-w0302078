CREATE PROCEDURE [dbo].[InsertGenre]
	@GenreName nvarchar(50),
	@new_Identity int = NULL OUTPUT
AS
	INSERT INTO Genre ([GenreID]) VALUES (@GenreName);

	SET @new_Identity = SCOPE_IDENTITY();

RETURN 0;
