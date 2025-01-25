/*Správa autopůjčovny, Matěj Halmich, matejhalmich06@gmail.com*/
USE [halmich] /*Změnte na databázi kterou používáte*/
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 17.01.2025 16:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastRentalDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rental]    Script Date: 17.01.2025 16:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rental](
	[RentalId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[TotalPrice] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_CustomerRentals]    Script Date: 17.01.2025 16:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_CustomerRentals]
AS
SELECT 
    c.CustomerId,
    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerFullName,
    c.Email,
    r.RentalId,
    r.StartDate,
    r.EndDate,
    r.TotalPrice
FROM Customer c
INNER JOIN Rental r ON c.CustomerId = r.CustomerId;
GO
/****** Object:  Table [dbo].[ExtraService]    Script Date: 17.01.2025 16:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraService](
	[ExtraServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [varchar](50) NOT NULL,
	[PricePerDay] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ExtraServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rental_ExtraService]    Script Date: 17.01.2025 16:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rental_ExtraService](
	[RentalId] [int] NOT NULL,
	[ExtraServiceId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Rental_ExtraService] PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC,
	[ExtraServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_RentalServices]    Script Date: 17.01.2025 16:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_RentalServices]
AS
SELECT
    r.RentalId,
    r.StartDate,
    r.EndDate,
    es.ExtraServiceId,
    es.ServiceName,
    res.Quantity,
    es.PricePerDay
FROM Rental r
INNER JOIN Rental_ExtraService res ON r.RentalId = res.RentalId
INNER JOIN ExtraService es ON res.ExtraServiceId = es.ExtraServiceId;
GO
/****** Object:  Table [dbo].[Car]    Script Date: 17.01.2025 16:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [varchar](20) NOT NULL,
	[Brand] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[CarType] [int] NOT NULL,
	[DailyRate] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Car] ON 
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (1, N'ABC-1234', N'Škoda', N'Octavia', 1, 70)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (2, N'5B6-9876', N'Volkswagen', N'Passat', 1, 85.5)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (3, N'1A2-3456', N'BMW', N'X5', 2, 120)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (4, N'2C3-1111', N'Ford', N'Focus', 1, 60)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (5, N'EL3-8888', N'Tesla', N'Model 3', 3, 150)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (6, N'8M2-5678', N'Toyota', N'RAV4', 2, 95)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (10, N'1E4-2222', N'BMW', N'Z4', 2, 120)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (11, N'789-GHI', N'Audi', N'A6', 1, 95)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (12, N'234-JKL', N'Mercedes', N'C-Class', 1, 100)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (13, N'567-MNO', N'Kia', N'Sportage', 3, 60)
GO
INSERT [dbo].[Car] ([CarId], [LicensePlate], [Brand], [Model], [CarType], [DailyRate]) VALUES (14, N'890-PQR', N'Porsche', N'911', 2, 150)
GO
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (3, N'Jan', N'Novak', N'jan.novak@example.com', CAST(N'1980-05-10T00:00:00.000' AS DateTime), 1, CAST(N'2025-01-16T13:07:38.727' AS DateTime))
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (4, N'Lenka', N'Horkova', N'lenka.horkova@example.com', CAST(N'1992-11-03T00:00:00.000' AS DateTime), 1, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (5, N'Petr', N'Stary', N'petr.stary@example.com', CAST(N'1975-08-20T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (6, N'Martina', N'Kralova', N'martina.kralova@example.com', CAST(N'1989-01-15T00:00:00.000' AS DateTime), 1, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (7, N'Lukas', N'Kovar', N'lukas.kovar@example.com', CAST(N'1983-12-11T00:00:00.000' AS DateTime), 1, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (8, N'Alena', N'Smetanova', N'alena.smetanova@example.com', CAST(N'1979-04-09T00:00:00.000' AS DateTime), 1, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (9, N'Jakub', N'Horak', N'jakub.horak@example.com', CAST(N'1995-08-14T00:00:00.000' AS DateTime), 0, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (10, N'Jana', N'Vesela', N'jana.vesela@example.com', CAST(N'1986-10-31T00:00:00.000' AS DateTime), 1, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [LastRentalDate]) VALUES (11, N'Miroslav', N'Maly', N'miroslav.maly@example.com', CAST(N'1974-07-22T00:00:00.000' AS DateTime), 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Rental] ON 
GO
INSERT [dbo].[Rental] ([RentalId], [CustomerId], [CarId], [StartDate], [EndDate], [TotalPrice]) VALUES (13, 3, 1, CAST(N'2025-01-16T13:04:41.690' AS DateTime), CAST(N'2025-01-25T13:04:41.687' AS DateTime), 500)
GO
INSERT [dbo].[Rental] ([RentalId], [CustomerId], [CarId], [StartDate], [EndDate], [TotalPrice]) VALUES (14, 3, 1, CAST(N'2025-01-16T13:05:16.827' AS DateTime), CAST(N'2025-01-16T13:06:16.820' AS DateTime), 500)
GO
INSERT [dbo].[Rental] ([RentalId], [CustomerId], [CarId], [StartDate], [EndDate], [TotalPrice]) VALUES (15, 3, 1, CAST(N'2025-01-16T13:05:16.827' AS DateTime), CAST(N'2025-01-16T13:06:16.820' AS DateTime), 500)
GO
INSERT [dbo].[Rental] ([RentalId], [CustomerId], [CarId], [StartDate], [EndDate], [TotalPrice]) VALUES (16, 3, 1, CAST(N'2025-01-16T13:07:24.603' AS DateTime), CAST(N'2025-02-14T13:07:24.597' AS DateTime), 500)
GO
INSERT [dbo].[Rental] ([RentalId], [CustomerId], [CarId], [StartDate], [EndDate], [TotalPrice]) VALUES (21, 3, 1, CAST(N'2025-01-16T13:15:54.990' AS DateTime), CAST(N'2025-01-17T13:15:54.983' AS DateTime), 500)
GO
SET IDENTITY_INSERT [dbo].[Rental] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Car_LicensePlate]    Script Date: 17.01.2025 16:21:17 ******/
ALTER TABLE [dbo].[Car] ADD  CONSTRAINT [UQ_Car_LicensePlate] UNIQUE NONCLUSTERED 
(
	[LicensePlate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Customer_Email]    Script Date: 17.01.2025 16:21:17 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [UQ_Customer_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Rental_ExtraService] ADD  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Rental]  WITH CHECK ADD  CONSTRAINT [FK_Rental_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([CarId])
GO
ALTER TABLE [dbo].[Rental] CHECK CONSTRAINT [FK_Rental_Car]
GO
ALTER TABLE [dbo].[Rental]  WITH CHECK ADD  CONSTRAINT [FK_Rental_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Rental] CHECK CONSTRAINT [FK_Rental_Customer]
GO
ALTER TABLE [dbo].[Rental_ExtraService]  WITH CHECK ADD  CONSTRAINT [FK_RE_ExtraService] FOREIGN KEY([ExtraServiceId])
REFERENCES [dbo].[ExtraService] ([ExtraServiceId])
GO
ALTER TABLE [dbo].[Rental_ExtraService] CHECK CONSTRAINT [FK_RE_ExtraService]
GO
ALTER TABLE [dbo].[Rental_ExtraService]  WITH CHECK ADD  CONSTRAINT [FK_RE_Rental] FOREIGN KEY([RentalId])
REFERENCES [dbo].[Rental] ([RentalId])
GO
ALTER TABLE [dbo].[Rental_ExtraService] CHECK CONSTRAINT [FK_RE_Rental]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [CHK_Car_Brand_Not_Empty] CHECK  ((len(ltrim(rtrim([Brand])))>(0)))
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [CHK_Car_Brand_Not_Empty]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [CHK_Car_CarType_Valid] CHECK  (([CarType]=(3) OR [CarType]=(2) OR [CarType]=(1) OR [CarType]=(0)))
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [CHK_Car_CarType_Valid]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [CHK_Car_DailyRate_NonNegative] CHECK  (([DailyRate]>=(0)))
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [CHK_Car_DailyRate_NonNegative]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [CHK_Car_LicensePlate_Not_Empty] CHECK  ((len(ltrim(rtrim([LicensePlate])))>(0)))
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [CHK_Car_LicensePlate_Not_Empty]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [CHK_Car_Model_Not_Empty] CHECK  ((len(ltrim(rtrim([Model])))>(0)))
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [CHK_Car_Model_Not_Empty]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CHK_DateOfBirth_Over18] CHECK  ((datediff(year,[DateOfBirth],getdate())>=(18)))
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CHK_DateOfBirth_Over18]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CHK_Email_Valid] CHECK  (([Email] IS NOT NULL AND ltrim(rtrim([Email]))<>'' AND [Email] like '%@%'))
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CHK_Email_Valid]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CHK_FirstName_NotEmpty] CHECK  (([FirstName] IS NOT NULL AND ltrim(rtrim([FirstName]))<>''))
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CHK_FirstName_NotEmpty]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CHK_LastName_NotEmpty] CHECK  (([LastName] IS NOT NULL AND ltrim(rtrim([LastName]))<>''))
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CHK_LastName_NotEmpty]
GO
ALTER TABLE [dbo].[Rental]  WITH CHECK ADD  CONSTRAINT [CHK_EndDate_After_StartDate] CHECK  (([EndDate]>=[StartDate]))
GO
ALTER TABLE [dbo].[Rental] CHECK CONSTRAINT [CHK_EndDate_After_StartDate]
GO
ALTER TABLE [dbo].[Rental]  WITH CHECK ADD  CONSTRAINT [CHK_TotalPrice_Positive] CHECK  (([TotalPrice]>=(0)))
GO
ALTER TABLE [dbo].[Rental] CHECK CONSTRAINT [CHK_TotalPrice_Positive]
GO
