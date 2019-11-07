CREATE PROCEDURE [dbo].[UpdatePublisher]
	@PubID int,
	@Name nvarchar(50)
AS
	UPDATE Publisher SET name=@name WHERE PubID=@pubid;
RETURN @@rowcount
