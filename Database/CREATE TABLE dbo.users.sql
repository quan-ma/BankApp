CREATE TABLE dbo.users
(
    Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
    username varchar(32) NOT NULL,
    [password] varchar(32) NOT NULL,
    firstName varchar(32),
    lastname varchar(32)
)

CREATE TABLE dbo.accounts
(
    userPKID int NOT NULL FOREIGN KEY REFERENCES dbo.users (Id),
    checkingNumber VARCHAR(16) NOT NULL,
    balance DECIMAL NOT NULL
)