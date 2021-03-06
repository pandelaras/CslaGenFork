/****** Object:  StoredProcedure [GetD07_RegionColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD07_RegionColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD07_RegionColl]
GO

CREATE PROCEDURE [GetD07_RegionColl]
    @Parent_Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D08_Region from table */
        SELECT
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[Parent_Country_ID] = @Parent_Country_ID

    END
GO

