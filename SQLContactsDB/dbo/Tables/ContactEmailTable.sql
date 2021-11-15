CREATE TABLE [dbo].[ContactEmailTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContactId] INT NOT NULL, 
    [EmailAddressId] INT NOT NULL
)
