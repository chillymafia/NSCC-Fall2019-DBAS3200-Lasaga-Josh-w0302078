CREATE PROCEDURE [dbo].[UpdatePublisher]
	@pubid int,
	@name nvarchar(50)
AS
	UPDATE Publisher SET name=@name WHERE PubID=@pubid;
RETURN @@rowcount
