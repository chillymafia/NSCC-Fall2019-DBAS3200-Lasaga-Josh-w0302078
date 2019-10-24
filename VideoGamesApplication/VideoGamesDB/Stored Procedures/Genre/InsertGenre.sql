CREATE PROCEDURE [dbo].[InsertGenre]
	@GenreName nvarchar(50),
	@GenreRating nvarchar(4),
	@new_Identity int = NULL OUTPUT
AS
	INSERT INTO GenreGenre([GenreID]) VALUES (@GenreName);
	INSERT INTO GenreRating([GenreID]) VALUES (@GenreRating);

	SET @new_Identity = SCOPE_IDENTITY();

RETURN 0;
