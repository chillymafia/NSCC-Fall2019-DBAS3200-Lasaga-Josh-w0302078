CREATE PROCEDURE [dbo].[InsertPublisher]
	@PublisherName nvarchar(50),
	@new_Identity int = NULL OUTPUT
AS
	INSERT INTO Publisher([PubID]) VALUES (@PublisherName);

	SET @new_Identity = SCOPE_IDENTITY();

RETURN 0;
