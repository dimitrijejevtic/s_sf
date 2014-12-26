CREATE TABLE [dbo].[Autor] (
    [Id]         INT           NOT NULL,
    [ime_autora] NVARCHAR (50) NOT NULL,
    [knjige]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

