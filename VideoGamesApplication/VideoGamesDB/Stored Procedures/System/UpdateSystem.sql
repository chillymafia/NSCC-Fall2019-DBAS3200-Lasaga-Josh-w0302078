CREATE PROCEDURE [dbo].[UpdateSystem]
	@systemID int,
	@Name nvarchar(50),
	@Company nvarchar(50)
AS
	UPDATE [System] SET name=@Name WHERE SystemID=@systemID;
	UPDATE [System] SET Company=@Company WHERE SystemID=@systemID;
RETURN @@rowcount;
