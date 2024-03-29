﻿CREATE TABLE [dbo].[VideoGames]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(255) NOT NULL, 
    [System] INT NOT NULL, 
    [ReleaseDate] DATE NOT NULL, 
    [ESRB] INT NOT NULL, 
    [Publisher] INT NOT NULL, 
    [Developer] INT NOT NULL, 
    CONSTRAINT [FK_VideoGames_ToSystem] FOREIGN KEY ([System]) REFERENCES [System]([SystemID]), 
    CONSTRAINT [FK_VideoGames_ToESRB] FOREIGN KEY ([ESRB]) REFERENCES [ESRB]([ESRBID]), 
    CONSTRAINT [FK_VideoGames_ToPublisher] FOREIGN KEY ([Publisher]) REFERENCES [Publisher]([PubID]), 
    CONSTRAINT [FK_VideoGames_ToDeveloper] FOREIGN KEY ([Developer]) REFERENCES [Developer]([DevID]) 
)
