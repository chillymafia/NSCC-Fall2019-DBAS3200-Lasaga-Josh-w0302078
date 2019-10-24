CREATE PROCEDURE [dbo].[DeleteSystem]
	@SystemID int
AS
	DELETE FROM [System] WHERE [System].SystemID = @SystemID;
RETURN @@rowcount
