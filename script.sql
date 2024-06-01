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

CREATE TABLE [Accounts] (
    [UserId] uniqueidentifier NOT NULL,
    [Mouth] datetime2 NOT NULL,
    [Salary] real NULL,
    [Returns] real NULL,
    [OtherEarnings] real NULL,
    [FoodExpense] real NULL,
    [ExpenseTransport] real NULL,
    [HousingExpense] real NULL,
    [HealthEducationExpenses] real NULL,
    [Investments] real NULL,
    [Taxes] real NULL,
    [LeisureExpenses] real NULL,
    [OtherExpenses] real NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([UserId], [Mouth])
);
GO

CREATE TABLE [Users] (
    [UserId] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Balance] real NOT NULL,
    [Result] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240601183924_Initial migration', N'8.0.4');
GO

COMMIT;
GO

