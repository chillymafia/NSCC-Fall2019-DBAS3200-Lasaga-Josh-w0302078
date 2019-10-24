CREATE PROCEDURE [dbo].[InsertSystem]
	@SystemName nvarchar(50),
	@SystemCompany nvarchar(50),
	@new_Identity int = NULL OUTPUT
AS
	INSERT INTO System([SystemID]) VALUES (@SystemName);
	INSERT INTO System([SystemID]) VALUES (@SystemCompany);

	SET @new_Identity = SCOPE_IDENTITY();

RETURN 0;

