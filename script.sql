IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [UserId] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Balance] real NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Accounts] (
    [AccountId] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Month] nvarchar(max) NOT NULL,
    [Year] int NOT NULL,
    [Salary] real NOT NULL,
    [Returns] real NOT NULL,
    [OtherEarnings] real NOT NULL,
    [FoodExpense] real NOT NULL,
    [ExpenseTransport] real NOT NULL,
    [HousingExpense] real NOT NULL,
    [HealthEducationExpenses] real NOT NULL,
    [Investments] real NOT NULL,
    [Taxes] real NOT NULL,
    [LeisureExpenses] real NOT NULL,
    [OtherExpenses] real NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([AccountId]),
    CONSTRAINT [FK_Accounts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Accounts_UserId] ON [Accounts] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240613000904_Initial Migration', N'8.0.4');
GO

COMMIT;
GO

