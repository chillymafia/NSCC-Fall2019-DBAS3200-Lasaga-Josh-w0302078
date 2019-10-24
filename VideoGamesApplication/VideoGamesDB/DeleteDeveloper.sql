CREATE PROCEDURE [dbo].[DeleteDeveloper]
	@DevID int
AS
	DELETE FROM Developer WHERE Developer.DevID = @DevID;
RETURN @@rowcount