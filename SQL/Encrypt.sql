SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Encrypt]
(
    @ValueToEncrypt varchar(200)
)
RETURNS varbinary(264)
AS
BEGIN
    DECLARE @Result varbinary(264)

    SET @Result = EncryptByKey(Key_GUID('skRendAutenticacaoMultifatorial'), @ValueToEncrypt)

    RETURN @Result
END

GO


