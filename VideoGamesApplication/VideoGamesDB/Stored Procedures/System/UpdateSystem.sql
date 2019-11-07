CREATE PROCEDURE [dbo].[UpdateSystem]
	@SystemID int,
	@Name nvarchar(50),
	@Company nvarchar(50)
AS
	UPDATE [System] SET Name=@Name WHERE SystemID=@systemID;
	UPDATE [System] SET Company=@Company WHERE SystemID=@systemID;
RETURN @@rowcount;
