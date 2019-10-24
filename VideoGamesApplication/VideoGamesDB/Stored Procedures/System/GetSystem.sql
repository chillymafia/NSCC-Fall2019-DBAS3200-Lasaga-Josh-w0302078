CREATE PROCEDURE [dbo].[GetSystem]
	@systemid int
AS
	SELECT * FROM System WHERE SystemID = @systemid;
RETURN 0
