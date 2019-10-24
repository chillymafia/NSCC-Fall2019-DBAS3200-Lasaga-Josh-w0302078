CREATE PROCEDURE [dbo].[InsertDeveloper]
	@developerName nvarchar(50),
	@new_Identity int = NULL OUTPUT
AS
	INSERT INTO Developer ([DevID]) VALUES (@developerName);

	SET @new_Identity = SCOPE_IDENTITY();

RETURN 0;
