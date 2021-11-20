CREATE TABLE [dbo].[Register_Form] (
    [User_id]          INT  IDENTITY (1, 1)    NOT NULL ,
    [First_Name]       NVARCHAR (50) NULL,
    [Last_Name]        NVARCHAR (50) NULL,
    [User_Name]        NVARCHAR (50) NULL,
    [Password]         NVARCHAR (50) NULL,
    [Confirm_Password] NVARCHAR (50) NULL,
    [Gender]           NVARCHAR (50) NULL,
    [Address]          NVARCHAR (50) NULL,
    [Email_id]         NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([User_id] ASC)
);

