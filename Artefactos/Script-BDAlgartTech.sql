CREATE TABLE [dbo].[Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identification] [nvarchar](20) NULL,
	[Names] [nvarchar](150) NULL,
	[Surnames] [nvarchar](150) NULL,
	[Address] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[CellPhone] [nvarchar](20) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PlanSeparate]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanSeparate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_PlanSeparate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PlanSeparateBySale]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanSeparateBySale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanSeparateId] [int] NULL,
	[SaleId] [int] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_PlanSeparateBySale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Price] [decimal](18, 2) NULL,
	[SizeId] [int] NULL,
	[ColorId] [int] NULL,
	[SalesDepartmentId] [int] NULL,
	[Inventory] [decimal](5, 2) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Promotion]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Percentage] [int] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PromotionBySale]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromotionBySale](
	[Id] [int] NOT NULL,
	[PromotionId] [int] NULL,
	[SaleId] [int] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_PromotionBySale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sale]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[CustomerId] [int] NULL,
	[Total] [decimal](20, 2) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SaleDetail]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleId] [int] NULL,
	[ProductId] [int] NULL,
	[Amount] [decimal](20, 2) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_SaleDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SalesDepartment]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Department] [nvarchar](150) NULL,
	[Description] [nvarchar](150) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_SalesDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Size]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Size] [nvarchar](5) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[LastModifiedDate] [date] NULL,
	[LastModifiedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Color] ON 
GO
INSERT [dbo].[Color] ([Id], [Color], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'Blanco', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Color] ([Id], [Color], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'Amarillo', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Color] ([Id], [Color], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (3, N'Azul', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Color] ([Id], [Color], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (4, N'Rojo', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Color] ([Id], [Color], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (5, N'Verde', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Color] ([Id], [Color], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (6, N'Negro', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Color] ([Id], [Color], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (7, N'Cafe', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [Identification], [Names], [Surnames], [Address], [Email], [CellPhone], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'8363085', N'Sixto José', N'Romero Martíenz', N'Calle 52 #38-40', N'sixto.jose@gmail.com', N'3022415223', CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Customer] ([Id], [Identification], [Names], [Surnames], [Address], [Email], [CellPhone], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'1040128645', N'Deni Luz', N'Pastrana Hoyos', N'Cra 14 #39-52', N'deniluz@gmail.com', N'3207455223', CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[PlanSeparate] ON 
GO
INSERT [dbo].[PlanSeparate] ([Id], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'Mega Prima', CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[PlanSeparate] ([Id], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'Sepáralo y es tuyo', CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[PlanSeparate] ([Id], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (3, N'Plan Separe Hogar', CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[PlanSeparate] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [SizeId], [ColorId], [SalesDepartmentId], [Inventory], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'Bicicicleta Roadmaster Hurricane 29 Shimano Revoshift 21vel', CAST(629900.00 AS Decimal(18, 2)), 1, 1, 1, CAST(26.00 AS Decimal(5, 2)), NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [SizeId], [ColorId], [SalesDepartmentId], [Inventory], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'Bicicleta Gw Hyena Rin 29 Grupo De 2 X 8 Hidráulico
', CAST(1229900.00 AS Decimal(18, 2)), 1, 3, 1, CAST(11.00 AS Decimal(5, 2)), NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [SizeId], [ColorId], [SalesDepartmentId], [Inventory], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (3, N'Bicicleta De Montaña Mountain Gear Eagle R27.5 18V Sin Suspensión Negro
', CAST(404900.00 AS Decimal(18, 2)), 5, 4, 1, CAST(58.00 AS Decimal(5, 2)), NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Promotion] ON 
GO
INSERT [dbo].[Promotion] ([Id], [Description], [Percentage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'Promoción sin Igual', 10, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Promotion] ([Id], [Description], [Percentage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'Ofertas del día', 5, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Promotion] ([Id], [Description], [Percentage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (3, N'Llevalo hoy', 15, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Promotion] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesDepartment] ON 
GO
INSERT [dbo].[SalesDepartment] ([Id], [Department], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'Departamento de Venta Medellin', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SalesDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[Size] ON 
GO
INSERT [dbo].[Size] ([Id], [Size], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'XS', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Size] ([Id], [Size], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'S', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Size] ([Id], [Size], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (3, N'M', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Size] ([Id], [Size], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (4, N'L', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
INSERT [dbo].[Size] ([Id], [Size], [Description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (5, N'XL', NULL, CAST(N'2022-12-29' AS Date), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Size] OFF
GO

ALTER TABLE [dbo].[PlanSeparateBySale]  WITH CHECK ADD  CONSTRAINT [FK_PlanSeparateBySale_PlanSeparate] FOREIGN KEY([PlanSeparateId])
REFERENCES [dbo].[PlanSeparate] ([Id])
GO
ALTER TABLE [dbo].[PlanSeparateBySale] CHECK CONSTRAINT [FK_PlanSeparateBySale_PlanSeparate]
GO
ALTER TABLE [dbo].[PlanSeparateBySale]  WITH CHECK ADD  CONSTRAINT [FK_PlanSeparateBySale_Sale] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([Id])
GO
ALTER TABLE [dbo].[PlanSeparateBySale] CHECK CONSTRAINT [FK_PlanSeparateBySale_Sale]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Color]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SalesDepartment] FOREIGN KEY([SalesDepartmentId])
REFERENCES [dbo].[SalesDepartment] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SalesDepartment]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Size]
GO
ALTER TABLE [dbo].[PromotionBySale]  WITH CHECK ADD  CONSTRAINT [FK_PromotionBySale_Promotion] FOREIGN KEY([PromotionId])
REFERENCES [dbo].[Promotion] ([Id])
GO
ALTER TABLE [dbo].[PromotionBySale] CHECK CONSTRAINT [FK_PromotionBySale_Promotion]
GO
ALTER TABLE [dbo].[PromotionBySale]  WITH CHECK ADD  CONSTRAINT [FK_PromotionBySale_Sale] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([Id])
GO
ALTER TABLE [dbo].[PromotionBySale] CHECK CONSTRAINT [FK_PromotionBySale_Sale]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK_Sale_Customer]
GO
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD  CONSTRAINT [FK_SaleDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SaleDetail] CHECK CONSTRAINT [FK_SaleDetail_Product]
GO
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD  CONSTRAINT [FK_SaleDetail_Sale] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([Id])
GO
ALTER TABLE [dbo].[SaleDetail] CHECK CONSTRAINT [FK_SaleDetail_Sale]
GO
/****** Object:  StoredProcedure [dbo].[uspGetCustomer]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetCustomer]
AS	
	SELECT Id
	,Identification
	,Names
	,Surnames
	,Address
	,Email
	,CellPhone
	FROM [dbo].[Customer]
GO

/****** Object:  StoredProcedure [dbo].[uspGetPlanSeparate]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetPlanSeparate]
AS
SELECT [Id]
      ,[Description]      
  FROM [BDAlgarTech].[dbo].[PlanSeparate]
GO

/****** Object:  StoredProcedure [dbo].[uspGetProducts]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProducts]
AS	
	SELECT p.Id
		,p.Name
		,p.Price
		,s.Size
		,c.Color
		,SalesDepartmentId
		,Inventory
	FROM [dbo].[Product] p 
	INNER JOIN [dbo].[Size] s ON p.SizeId = s.Id
	INNER JOIN [dbo].[Color] c ON p.ColorId = c.Id
GO

/****** Object:  StoredProcedure [dbo].[uspGetProductsBySaleDepartmentId]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProductsBySaleDepartmentId]
	@SalesDepartmentId int
AS	
	SELECT p.Id
		,p.Name
		,p.Price
		,s.Size
		,c.Color
		,p.SalesDepartmentId
		,Inventory
	FROM [dbo].[Product] p 
	INNER JOIN [dbo].[Size] s ON p.SizeId = s.Id
	INNER JOIN [dbo].[Color] c ON p.ColorId = c.Id
	WHERE p.SalesDepartmentId = @SalesDepartmentId
GO

/****** Object:  StoredProcedure [dbo].[uspGetSales]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetSales]
AS
	SELECT s.Id,
	s.CustomerId,
	c.Names + ' ' + c.Surnames AS FullName,
	s.Total,
	s.Description,
	isnull(ps.Id, 0) as PlanSeparateId,
	s.Date
	FROM [dbo].[Sale] s 	
	INNER JOIN [dbo].[Customer] c ON s.CustomerId = c.Id
	LEFT JOIN [dbo].[PlanSeparateBySale] ps ON s.Id = ps.SaleId
GO

/****** Object:  StoredProcedure [dbo].[uspGetSalesDepartment]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetSalesDepartment]
AS	
	SELECT Id
		,Department
		,Description
	FROM [dbo].[SalesDepartment]
GO

/****** Object:  StoredProcedure [dbo].[uspGetSalesDetail]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [dbo].[uspGetSalesDetail] 10
CREATE PROCEDURE [dbo].[uspGetSalesDetail]
	@SaleId INT
AS
	SELECT sd.Id, sd.SaleId, sd.ProductId, p.Name, sd.Amount, p.Price, (p.Price * sd.Amount) AS Total
	FROM [dbo].[SaleDetail] sd 
	INNER JOIN [dbo].[Product] p ON p.Id = sd.ProductId
	WHERE sd.SaleId = @SaleId
GO

/****** Object:  StoredProcedure [dbo].[uspSaleDelete]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSaleDelete]
	@Id int	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		
			DELETE FROM [dbo].[SaleDetail] WHERE SaleId = @Id
			DELETE FROM [dbo].[PlanSeparateBySale] WHERE SaleId = @Id
			DELETE FROM [dbo].[Sale] WHERE Id = @Id

			COMMIT TRANSACTION
			
			SELECT 'Success'

		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO

/****** Object:  StoredProcedure [dbo].[uspSaleInsert]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [dbo].[uspSaleInsert] 2, 1859800, '', '[{"ProductId":1,"Amount":629900.0},{"ProductId":2,"Amount":1229900.0}]'
CREATE PROCEDURE [dbo].[uspSaleInsert]		
	@CustomerId int,
	@Total decimal(18, 2),
	@Description nvarchar(250),
	@IsSeparatePlan bit,
	@PlanSeparateId int,
	@SaleDetail nvarchar(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		
			INSERT INTO [dbo].[Sale] (
				[Date]
				,CustomerId
				,Total
				,[Description]
				,CreatedDate
				,CreatedBy
			) VALUES (
				GETDATE()
				,@CustomerId
				,@Total
				,@Description
				,GETDATE()
				,'system'		
			)		
		
			 -- Obtener el último ID generado por la instrucción INSERT anterior
			DECLARE @SaleId int
			SELECT @SaleId = SCOPE_IDENTITY()
		
			INSERT INTO [dbo].[SaleDetail] (SaleId, ProductId, Amount, CreatedDate, CreatedBy)		
			SELECT 
				@SaleId,
				ProductId,
				Amount,
				getdate(),
				'system'		
			FROM OPENJSON(@SaleDetail) 
			WITH (
				ProductId int '$.ProductId',
				Amount decimal(18,3) '$.Amount'
			)

			DELETE FROM [dbo].[PlanSeparateBySale] WHERE [SaleId] = @SaleId
			IF (@IsSeparatePlan = 1)
			BEGIN							
				INSERT INTO [dbo].[PlanSeparateBySale]  (PlanSeparateId, SaleId, CreatedDate, CreatedBy) VALUES (@PlanSeparateId, @SaleId, getdate(), 'system')
			END

			COMMIT TRANSACTION
			SELECT 'Success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO

/****** Object:  StoredProcedure [dbo].[uspSaleInsert_BACKUP]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [dbo].[uspSaleInsert] 2, 1859800, '', '[{"ProductId":1,"Amount":629900.0},{"ProductId":2,"Amount":1229900.0}]'
CREATE PROCEDURE [dbo].[uspSaleInsert_BACKUP]		
	@CustomerId int,
	@Total decimal(18, 2),
	@Description nvarchar(250),
	@SaleDetail nvarchar(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		
		INSERT INTO [dbo].[Sale] (
			[Date]
			,CustomerId
			,Total
			,[Description]
			,CreatedDate
			,CreatedBy
		) VALUES (
			GETDATE()
			,@CustomerId
			,@Total
			,@Description
			,GETDATE()
			,'system'		
		)		
		
		 -- Obtener el último ID generado por la instrucción INSERT anterior
		DECLARE @SaleId int
		SELECT @SaleId = SCOPE_IDENTITY()
		
		INSERT INTO [dbo].[SaleDetail] (SaleId, ProductId, Amount, CreatedDate, CreatedBy)
		
		SELECT 
			@SaleId,
			ProductId,
			Amount,
			getdate(),
			'system'		
		FROM OPENJSON(@SaleDetail) 
		WITH (
			ProductId int '$.ProductId',
			Amount decimal(18,3) '$.Amount'
		)

			COMMIT TRANSACTION
			SELECT 'Success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END

GO

/****** Object:  StoredProcedure [dbo].[uspSaleUpdate]    Script Date: 02/01/2023 2:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [dbo].[uspSaleInsert] 2, 1859800, '', '[{"ProductId":1,"Amount":629900.0},{"ProductId":2,"Amount":1229900.0}]'
CREATE PROCEDURE [dbo].[uspSaleUpdate]		
	@Id int,
	@CustomerId int,
	@Total decimal(18, 2),
	@Description nvarchar(250),
	@IsSeparatePlan bit,
	@PlanSeparateId int,
	@SaleDetail nvarchar(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		
		UPDATE [dbo].[Sale] 
		SET Total = @Total, 
		Description = @Description,
		LastModifiedDate = GETDATE(),
		LastModifiedBy = 'system'
		WHERE Id = @Id
				
		-- Obtener el último ID generado por la instrucción INSERT anterior		
		DELETE FROM [dbo].[SaleDetail] WHERE SaleId = @Id
		INSERT INTO [dbo].[SaleDetail] (SaleId, ProductId, Amount, CreatedDate, CreatedBy)
		
		SELECT 
			@Id,
			ProductId,
			Amount,
			getdate(),
			'system'		
		FROM OPENJSON(@SaleDetail) 
		WITH (
			ProductId int '$.ProductId',
			Amount decimal(18,3) '$.Amount'
		)

		DELETE FROM [dbo].[PlanSeparateBySale] WHERE [SaleId] = @Id
		IF (@IsSeparatePlan = 1)
		BEGIN			
			INSERT INTO [dbo].[PlanSeparateBySale]  (PlanSeparateId, SaleId, CreatedDate, CreatedBy) VALUES (@PlanSeparateId, @Id, getdate(), 'system')
		END

			COMMIT TRANSACTION
			SELECT 'Success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
