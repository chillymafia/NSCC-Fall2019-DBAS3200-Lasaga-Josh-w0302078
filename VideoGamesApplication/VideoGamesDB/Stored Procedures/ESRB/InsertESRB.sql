CREATE PROCEDURE [dbo].[InsertESRB]
	@ESRBName nvarchar(50),
	@new_Identity int = NULL OUTPUT
AS
	INSERT INTO ESRB ([ESRBID]) VALUES (@ESRBName);

	SET @new_Identity = SCOPE_IDENTITY();

RETURN 0;
