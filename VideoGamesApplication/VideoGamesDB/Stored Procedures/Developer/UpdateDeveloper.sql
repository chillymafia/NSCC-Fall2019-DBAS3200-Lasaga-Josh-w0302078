CREATE PROCEDURE [dbo].[UpdateDeveloper]
	@DevID int,
	@Name nvarchar(50)
AS
	UPDATE Developer SET Name=@Name WHERE DevID=@DevID;
RETURN @@rowcount
