﻿CREATE PROCEDURE [dbo].[OrganizationUser_DeleteById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON

    DELETE
    FROM
        [dbo].[OrganizationUser]
    WHERE
        [Id] = @Id
END