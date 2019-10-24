CREATE PROCEDURE [dbo].[GetDeveloper]
	@developerid int
AS
	SELECT * FROM Developer WHERE DevID = @developerid;
RETURN 0
