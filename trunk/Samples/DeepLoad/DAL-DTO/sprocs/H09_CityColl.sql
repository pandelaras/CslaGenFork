/****** Object:  StoredProcedure [GetH09_CityColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH09_CityColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH09_CityColl]
GO

CREATE PROCEDURE [GetH09_CityColl]
    @Parent_Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H10_City from table */
        SELECT
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[Parent_Region_ID] = @Parent_Region_ID AND
            [5_Cities].[IsActive] = 'true'

    END
GO

