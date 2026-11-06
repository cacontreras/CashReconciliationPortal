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

CREATE TABLE [DepositAudits] (
    [DepositAuditId] int NOT NULL IDENTITY,
    [DespositId] int NOT NULL,
    [OldValues] nvarchar(max) NOT NULL,
    [NewValues] nvarchar(max) NOT NULL,
    [Action] nvarchar(max) NOT NULL,
    [TimeStamp] datetime2 NOT NULL,
    [UderId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DepositAudits] PRIMARY KEY ([DepositAuditId])
);
GO

CREATE TABLE [Deposits] (
    [DepositId] int NOT NULL IDENTITY,
    [DepositNumber] nvarchar(max) NOT NULL,
    [StoreNumber] nvarchar(max) NOT NULL,
    [ExpectedAmount] decimal(18,2) NOT NULL,
    [ActualAmount] decimal(18,2) NOT NULL,
    [Variance] decimal(18,2) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [DepositDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Deposits] PRIMARY KEY ([DepositId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261105085019_InitialCreate', N'8.0.33');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepositId', N'ActualAmount', N'DepositDate', N'DepositNumber', N'ExpectedAmount', N'Status', N'StoreNumber', N'Variance') AND [object_id] = OBJECT_ID(N'[Deposits]'))
    SET IDENTITY_INSERT [Deposits] ON;
INSERT INTO [Deposits] ([DepositId], [ActualAmount], [DepositDate], [DepositNumber], [ExpectedAmount], [Status], [StoreNumber], [Variance])
VALUES (1, 0.0, '2026-11-05T06:31:14.2718792Z', N'DEP-2026-0001', 1545.5, N'Pending', N'STR-002', 0.0),
(2, 0.0, '2026-11-04T06:31:14.2718801Z', N'DEP-2026-0002', 1591.0, N'Pending', N'STR-003', 0.0),
(3, 0.0, '2026-11-03T06:31:14.2718804Z', N'DEP-2026-0003', 1636.5, N'Pending', N'STR-004', 0.0),
(4, 0.0, '2026-11-02T06:31:14.2718808Z', N'DEP-2026-0004', 1682.0, N'Pending', N'STR-005', 0.0),
(5, 0.0, '2026-11-01T06:31:14.2718812Z', N'DEP-2026-0005', 1727.5, N'Pending', N'STR-001', 0.0),
(6, 0.0, '2026-10-31T06:31:14.2718815Z', N'DEP-2026-0006', 1773.0, N'Pending', N'STR-002', 0.0),
(7, 0.0, '2026-10-30T06:31:14.2718818Z', N'DEP-2026-0007', 1818.5, N'Pending', N'STR-003', 0.0),
(8, 0.0, '2026-10-29T06:31:14.2718821Z', N'DEP-2026-0008', 1864.0, N'Pending', N'STR-004', 0.0),
(9, 0.0, '2026-10-28T06:31:14.2718824Z', N'DEP-2026-0009', 1909.5, N'Pending', N'STR-005', 0.0),
(10, 0.0, '2026-10-27T06:31:14.2718828Z', N'DEP-2026-0010', 1955.0, N'Pending', N'STR-001', 0.0),
(11, 0.0, '2026-10-26T06:31:14.2718830Z', N'DEP-2026-0011', 2000.5, N'Pending', N'STR-002', 0.0),
(12, 0.0, '2026-10-25T06:31:14.2718833Z', N'DEP-2026-0012', 2046.0, N'Pending', N'STR-003', 0.0),
(13, 0.0, '2026-10-24T06:31:14.2718836Z', N'DEP-2026-0013', 2091.5, N'Pending', N'STR-004', 0.0),
(14, 0.0, '2026-10-23T06:31:14.2718838Z', N'DEP-2026-0014', 2137.0, N'Pending', N'STR-005', 0.0),
(15, 0.0, '2026-10-22T06:31:14.2718841Z', N'DEP-2026-0015', 2182.5, N'Pending', N'STR-001', 0.0),
(16, 0.0, '2026-10-21T06:31:14.2718844Z', N'DEP-2026-0016', 2228.0, N'Pending', N'STR-002', 0.0),
(17, 0.0, '2026-10-20T06:31:14.2718846Z', N'DEP-2026-0017', 2273.5, N'Pending', N'STR-003', 0.0),
(18, 0.0, '2026-10-19T06:31:14.2718849Z', N'DEP-2026-0018', 2319.0, N'Pending', N'STR-004', 0.0),
(19, 0.0, '2026-10-18T06:31:14.2718851Z', N'DEP-2026-0019', 2364.5, N'Pending', N'STR-005', 0.0),
(20, 0.0, '2026-10-17T06:31:14.2718854Z', N'DEP-2026-0020', 2410.0, N'Pending', N'STR-001', 0.0),
(21, 0.0, '2026-10-16T06:31:14.2718856Z', N'DEP-2026-0021', 2455.5, N'Pending', N'STR-002', 0.0),
(22, 0.0, '2026-10-15T06:31:14.2718859Z', N'DEP-2026-0022', 2501.0, N'Pending', N'STR-003', 0.0),
(23, 0.0, '2026-10-14T06:31:14.2718862Z', N'DEP-2026-0023', 2546.5, N'Pending', N'STR-004', 0.0),
(24, 0.0, '2026-10-13T06:31:14.2718864Z', N'DEP-2026-0024', 2592.0, N'Pending', N'STR-005', 0.0),
(25, 0.0, '2026-10-12T06:31:14.2718937Z', N'DEP-2026-0025', 2637.5, N'Pending', N'STR-001', 0.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepositId', N'ActualAmount', N'DepositDate', N'DepositNumber', N'ExpectedAmount', N'Status', N'StoreNumber', N'Variance') AND [object_id] = OBJECT_ID(N'[Deposits]'))
    SET IDENTITY_INSERT [Deposits] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261106063114_AddDummyData', N'8.0.33');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[DepositAudits].[UderId]', N'UserId', N'COLUMN';
GO

UPDATE [Deposits] SET [DepositDate] = '2026-11-05T17:00:49.3790988Z'
WHERE [DepositId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-11-04T17:00:49.3791021Z'
WHERE [DepositId] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-11-03T17:00:49.3791037Z'
WHERE [DepositId] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-11-02T17:00:49.3791242Z'
WHERE [DepositId] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-11-01T17:00:49.3791259Z'
WHERE [DepositId] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-31T17:00:49.3791273Z'
WHERE [DepositId] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-30T17:00:49.3791288Z'
WHERE [DepositId] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-29T17:00:49.3791302Z'
WHERE [DepositId] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-28T17:00:49.3791318Z'
WHERE [DepositId] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-27T17:00:49.3791332Z'
WHERE [DepositId] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-26T17:00:49.3791345Z'
WHERE [DepositId] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-25T17:00:49.3791361Z'
WHERE [DepositId] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-24T17:00:49.3791374Z'
WHERE [DepositId] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-23T17:00:49.3791388Z'
WHERE [DepositId] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-22T17:00:49.3791402Z'
WHERE [DepositId] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-21T17:00:49.3791414Z'
WHERE [DepositId] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-20T17:00:49.3791428Z'
WHERE [DepositId] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-19T17:00:49.3791444Z'
WHERE [DepositId] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-18T17:00:49.3791458Z'
WHERE [DepositId] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-17T17:00:49.3791472Z'
WHERE [DepositId] = 20;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-16T17:00:49.3791485Z'
WHERE [DepositId] = 21;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-15T17:00:49.3791498Z'
WHERE [DepositId] = 22;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-14T17:00:49.3791511Z'
WHERE [DepositId] = 23;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-13T17:00:49.3791526Z'
WHERE [DepositId] = 24;
SELECT @@ROWCOUNT;

GO

UPDATE [Deposits] SET [DepositDate] = '2026-10-12T17:00:49.3791539Z'
WHERE [DepositId] = 25;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261106170050_Rename_UderId_With_UserId', N'8.0.33');
GO

COMMIT;
GO

