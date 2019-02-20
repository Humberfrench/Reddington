SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Decrypt]
(
    @ValueToDecrypt varbinary(264)
)
RETURNS varchar(200)
AS
BEGIN
    DECLARE @Result varchar(200)

    SET @Result = CONVERT(VARCHAR(200),DecryptByKey(@ValueToDecrypt))

    -- Return the result of the function
    RETURN @Result
END

GO


