CREATE PROCEDURE [dbo].[UpdateDeveloper]
	@DevID int,
	@Name nvarchar(50)
AS
	UPDATE Developer SET name=@Name WHERE DevID=@DevID;
RETURN @@rowcount
