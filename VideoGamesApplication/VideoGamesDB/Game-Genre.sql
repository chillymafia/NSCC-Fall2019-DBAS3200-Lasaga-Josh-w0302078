CREATE TABLE [dbo].[Game-Genre]
(
	[GameGenreID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GenreID] INT NOT NULL, 
    CONSTRAINT [FK_Game-Genre_ToGenre] FOREIGN KEY ([GenreID]) REFERENCES [Genre]([GenreID])
)
