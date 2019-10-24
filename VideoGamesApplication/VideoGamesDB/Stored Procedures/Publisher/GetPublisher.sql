CREATE PROCEDURE [dbo].[GetPublisher]
	@pubid int
AS
	SELECT * FROM Publisher WHERE PubID = @pubid;
RETURN 0
