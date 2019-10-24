CREATE PROCEDURE [dbo].[UpdateESRB]
	@esrbid int,
	@Rating nvarchar(50)
AS
	UPDATE ESRB SET Rating=@Rating WHERE ESRBID=@esrbid;
RETURN @@rowcount
