﻿CREATE PROCEDURE [dbo].[DeleteESRB]
	@ESRBID int
AS
	DELETE FROM ESRB WHERE ESRB.ESRBID = @ESRBID;
RETURN @@rowcount