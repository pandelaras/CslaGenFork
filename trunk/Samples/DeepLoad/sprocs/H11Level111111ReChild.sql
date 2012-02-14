/****** Object:  StoredProcedure [GetH11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH11Level111111ReChild]
GO

CREATE PROCEDURE [GetH11Level111111ReChild]
    @CQarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H11Level111111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = @CQarentID2 AND
            [Level_1_1_1_1_1_1_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH11Level111111ReChild]
GO

CREATE PROCEDURE [AddH11Level111111ReChild]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1_1_ReChild */
        INSERT INTO [Level_1_1_1_1_1_1_ReChild]
        (
            [CQarentID2],
            [Level_1_1_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_1_ID,
            @Level_1_1_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateH11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH11Level111111ReChild]
GO

CREATE PROCEDURE [UpdateH11Level111111ReChild]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID2] FROM [Level_1_1_1_1_1_1_ReChild]
            WHERE
                [CQarentID2] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11Level111111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1_1_ReChild */
        UPDATE [Level_1_1_1_1_1_1_ReChild]
        SET
            [Level_1_1_1_1_1_1_Child_Name] = @Level_1_1_1_1_1_1_Child_Name
        WHERE
            [CQarentID2] = @Level_1_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteH11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH11Level111111ReChild]
GO

CREATE PROCEDURE [DeleteH11Level111111ReChild]
    @Level_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID2] FROM [Level_1_1_1_1_1_1_ReChild]
            WHERE
                [CQarentID2] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11Level111111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H11Level111111ReChild object as not active */
        UPDATE [Level_1_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = @Level_1_1_1_1_1_ID

    END
GO
