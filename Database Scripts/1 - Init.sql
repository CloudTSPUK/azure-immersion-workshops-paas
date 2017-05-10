CREATE TABLE dbo.Books
(
	[IdBook] int NOT NULL PRIMARY KEY IDENTITY,
	[Title] nvarchar(MAX) NOT NULL,
	[Author] nvarchar(255) NOT NULL,
	[Description] nvarchar(MAX) NULL,
	[Price] money NOT NULL
)

GO

CREATE TABLE dbo.Orders 
(
	[IdOrder] int NOT NULL PRIMARY KEY IDENTITY,
	[BookId] int NOT NULL FOREIGN KEY REFERENCES dbo.Books (IdBook),
	[OrderPlacedAtUtc] datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[Quantity] int NOT NULL DEFAULT 1,
	[TotalPrice] money NOT NULL,
	[FirstName] nvarchar(255) NOT NULL,
	[LastName] nvarchar(255) NOT NULL,
	[Email] nvarchar(255) NOT NULL,
	[TelephoneNumber] nvarchar(255) NOT NULL,
	[HouseNumber] nvarchar(5) NOT NULL,
	[PostCode] nvarchar(8) NOT NULL,
	[CreditCardNumber] nvarchar(4) NOT NULL
)

GO