USE [DBPharmacy]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/03/2025 02:09:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patientsQueues]    Script Date: 26/03/2025 02:09:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patientsQueues](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[number] [int] NOT NULL,
	[pharmacyId] [bigint] NOT NULL,
 CONSTRAINT [PK_patientsQueues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pharmacies]    Script Date: 26/03/2025 02:09:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pharmacies](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[manager] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[stationCount] [int] NOT NULL,
	[addCounter] [int] NOT NULL,
	[removeCounter] [int] NOT NULL,
	[specialsAddCounter] [int] NOT NULL,
	[specialsRemoveCounter] [int] NOT NULL,
	[pharmacyPassword] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_pharmacies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pharmacists]    Script Date: 26/03/2025 02:09:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pharmacists](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[pharmacyId] [bigint] NOT NULL,
 CONSTRAINT [PK_pharmacists] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specialsQueues]    Script Date: 26/03/2025 02:09:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specialsQueues](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[number] [int] NOT NULL,
	[pharmacyId] [bigint] NOT NULL,
 CONSTRAINT [PK_specialsQueues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stations]    Script Date: 26/03/2025 02:09:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stations](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[pharmacyId] [bigint] NOT NULL,
	[isActive] [bit] NOT NULL,
	[pharmacistId] [bigint] NULL,
 CONSTRAINT [PK_stations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250304190155_addQueues-changes', N'6.0.36')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250306125951_06-03', N'6.0.36')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250309172550_add-password-to-pharmacist', N'6.0.36')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250310204547_changeStation', N'6.0.36')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250310230014_deleteConnect', N'6.0.36')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250311103242_add-migration 11-03', N'6.0.36')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250325073510_23-03-2025', N'6.0.36')
GO
SET IDENTITY_INSERT [dbo].[patientsQueues] ON 

INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (1, 101, 1)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (2, 102, 1)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (9, 101, 9)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (10, 102, 9)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (11, 103, 9)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (12, 104, 9)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (13, 105, 9)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (14, 106, 9)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (15, 107, 9)
INSERT [dbo].[patientsQueues] ([id], [number], [pharmacyId]) VALUES (16, 108, 9)
SET IDENTITY_INSERT [dbo].[patientsQueues] OFF
GO
SET IDENTITY_INSERT [dbo].[pharmacies] ON 

INSERT [dbo].[pharmacies] ([id], [manager], [password], [stationCount], [addCounter], [removeCounter], [specialsAddCounter], [specialsRemoveCounter], [pharmacyPassword]) VALUES (1, N'gad', N'Gad111!!', 5, 102, 100, 103, 100, N'Gad222@@')
INSERT [dbo].[pharmacies] ([id], [manager], [password], [stationCount], [addCounter], [removeCounter], [specialsAddCounter], [specialsRemoveCounter], [pharmacyPassword]) VALUES (9, N'nadav', N'Nadav11!!', 5, 108, 100, 107, 100, N'Nadav22@@')
SET IDENTITY_INSERT [dbo].[pharmacies] OFF
GO
SET IDENTITY_INSERT [dbo].[pharmacists] ON 

INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (1, N'dani', N'Gad222@@', 1)
INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (2, N'yoni', N'Gad222@@', 1)
INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (3, N'yosi', N'Gad222@@', 1)
INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (4, N'shimi', N'Gad222@@', 1)
INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (5, N'sasi', N'Gad222@@', 1)
INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (10, N'levi', N'Nadav22@@', 9)
INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (11, N'yonatai', N'Nadav22@@', 9)
INSERT [dbo].[pharmacists] ([id], [name], [password], [pharmacyId]) VALUES (12, N'kobi', N'Nadav22@@', 9)
SET IDENTITY_INSERT [dbo].[pharmacists] OFF
GO
SET IDENTITY_INSERT [dbo].[specialsQueues] ON 

INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (3, 103, 1)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (11, 101, 9)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (12, 102, 9)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (13, 103, 9)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (14, 104, 9)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (15, 104, 9)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (16, 105, 9)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (17, 106, 9)
INSERT [dbo].[specialsQueues] ([id], [number], [pharmacyId]) VALUES (18, 107, 9)
SET IDENTITY_INSERT [dbo].[specialsQueues] OFF
GO
SET IDENTITY_INSERT [dbo].[stations] ON 

INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (1, 1, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (2, 1, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (3, 1, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (4, 1, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (5, 1, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (44, 9, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (45, 9, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (46, 9, 1, 12)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (47, 9, 0, NULL)
INSERT [dbo].[stations] ([id], [pharmacyId], [isActive], [pharmacistId]) VALUES (48, 9, 0, NULL)
SET IDENTITY_INSERT [dbo].[stations] OFF
GO
ALTER TABLE [dbo].[pharmacies] ADD  DEFAULT (N'') FOR [pharmacyPassword]
GO
ALTER TABLE [dbo].[patientsQueues]  WITH CHECK ADD  CONSTRAINT [FK_patientsQueues_pharmacies_pharmacyId] FOREIGN KEY([pharmacyId])
REFERENCES [dbo].[pharmacies] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[patientsQueues] CHECK CONSTRAINT [FK_patientsQueues_pharmacies_pharmacyId]
GO
ALTER TABLE [dbo].[pharmacists]  WITH CHECK ADD  CONSTRAINT [FK_pharmacists_pharmacies_pharmacyId] FOREIGN KEY([pharmacyId])
REFERENCES [dbo].[pharmacies] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[pharmacists] CHECK CONSTRAINT [FK_pharmacists_pharmacies_pharmacyId]
GO
ALTER TABLE [dbo].[specialsQueues]  WITH CHECK ADD  CONSTRAINT [FK_specialsQueues_pharmacies_pharmacyId] FOREIGN KEY([pharmacyId])
REFERENCES [dbo].[pharmacies] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[specialsQueues] CHECK CONSTRAINT [FK_specialsQueues_pharmacies_pharmacyId]
GO
ALTER TABLE [dbo].[stations]  WITH CHECK ADD  CONSTRAINT [FK_stations_pharmacies_pharmacyId] FOREIGN KEY([pharmacyId])
REFERENCES [dbo].[pharmacies] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[stations] CHECK CONSTRAINT [FK_stations_pharmacies_pharmacyId]
GO
