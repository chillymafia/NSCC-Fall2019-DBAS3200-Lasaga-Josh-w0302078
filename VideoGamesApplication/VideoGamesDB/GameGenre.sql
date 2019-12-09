CREATE TABLE [dbo].[GameGenre]
(
	[GameGenreID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GenreID] INT NOT NULL, 
    [GameID] INT NOT NULL, 
    CONSTRAINT [FK_Game-Genre_ToGenre] FOREIGN KEY ([GenreID]) REFERENCES [Genre]([GenreID]),
	CONSTRAINT [FK_Game-Genre_ToGame] FOREIGN KEY ([GameID]) REFERENCES [VideoGames]([id])
)
