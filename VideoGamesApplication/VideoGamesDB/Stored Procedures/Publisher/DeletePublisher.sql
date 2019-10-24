CREATE PROCEDURE [dbo].[DeletePublisher]
	@PubID int
AS
	DELETE FROM Publisher WHERE Publisher.PubID = @PubID;
RETURN @@rowcount