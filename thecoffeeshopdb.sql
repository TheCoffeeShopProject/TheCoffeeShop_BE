create database [TheCoffeeStoreDB]
go
USE [TheCoffeeStoreDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[RoleID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat](
	[CatID] [uniqueidentifier] NOT NULL,
	[CatName] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[CoffeeID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Cat] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatProduct]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatProduct](
	[CatProductID] [uniqueidentifier] NOT NULL,
	[CatProductName] [nvarchar](max) NOT NULL,
	[CatProductType] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[Status] [bit] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CatProduct] PRIMARY KEY CLUSTERED 
(
	[CatProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoffeeShop]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoffeeShop](
	[CoffeeID] [uniqueidentifier] NOT NULL,
	[CoffeeName] [nvarchar](max) NOT NULL,
	[OpenTime] [nvarchar](max) NOT NULL,
	[CloseTime] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CoffeeShop] PRIMARY KEY CLUSTERED 
(
	[CoffeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentID] [uniqueidentifier] NOT NULL,
	[CommentText] [nvarchar](max) NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[CoffeeID] [uniqueidentifier] NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerPackage]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPackage](
	[CPID] [uniqueidentifier] NOT NULL,
	[DateStart] [datetime2](7) NOT NULL,
	[DateEnd] [datetime2](7) NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
	[SubscriptionID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CustomerPackage] PRIMARY KEY CLUSTERED 
(
	[CPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drink]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drink](
	[DrinkID] [uniqueidentifier] NOT NULL,
	[DrinkName] [nvarchar](max) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Status] [bit] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Drink] PRIMARY KEY CLUSTERED 
(
	[DrinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [uniqueidentifier] NOT NULL,
	[Status] [bit] NOT NULL,
	[CoffeeID] [uniqueidentifier] NOT NULL,
	[DrinkID] [uniqueidentifier] NULL,
	[CatProductID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [uniqueidentifier] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[TotalItem] [int] NOT NULL,
	[TotalDiscount] [real] NOT NULL,
	[Status] [bit] NOT NULL,
	[CustomerID] [uniqueidentifier] NULL,
	[TableID] [uniqueidentifier] NOT NULL,
	[CPID] [uniqueidentifier] NULL,
	[StaffID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDeatailID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [real] NOT NULL,
	[MenuID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[SubscriptionID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDeatailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[DOB] [nvarchar](max) NOT NULL,
	[CoffeeID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[SubscriptionID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[DiscountPercent] [real] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 3/6/2024 11:45:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableID] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[CoffeeID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [StaffID]
GO
ALTER TABLE [dbo].[Subscription] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Price]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role_RoleID]
GO
ALTER TABLE [dbo].[Cat]  WITH CHECK ADD  CONSTRAINT [FK_Cat_CoffeeShop_CoffeeID] FOREIGN KEY([CoffeeID])
REFERENCES [dbo].[CoffeeShop] ([CoffeeID])
GO
ALTER TABLE [dbo].[Cat] CHECK CONSTRAINT [FK_Cat_CoffeeShop_CoffeeID]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_CoffeeShop_CoffeeID] FOREIGN KEY([CoffeeID])
REFERENCES [dbo].[CoffeeShop] ([CoffeeID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_CoffeeShop_CoffeeID]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Account_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Account_AccountID]
GO
ALTER TABLE [dbo].[CustomerPackage]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPackage_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CustomerPackage] CHECK CONSTRAINT [FK_CustomerPackage_Customer_CustomerID]
GO
ALTER TABLE [dbo].[CustomerPackage]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPackage_Subscription_SubscriptionID] FOREIGN KEY([SubscriptionID])
REFERENCES [dbo].[Subscription] ([SubscriptionID])
GO
ALTER TABLE [dbo].[CustomerPackage] CHECK CONSTRAINT [FK_CustomerPackage_Subscription_SubscriptionID]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_CatProduct_CatProductID] FOREIGN KEY([CatProductID])
REFERENCES [dbo].[CatProduct] ([CatProductID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_CatProduct_CatProductID]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_CoffeeShop_CoffeeID] FOREIGN KEY([CoffeeID])
REFERENCES [dbo].[CoffeeShop] ([CoffeeID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_CoffeeShop_CoffeeID]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Drink_DrinkID] FOREIGN KEY([DrinkID])
REFERENCES [dbo].[Drink] ([DrinkID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Drink_DrinkID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_CustomerPackage_CPID] FOREIGN KEY([CPID])
REFERENCES [dbo].[CustomerPackage] ([CPID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_CustomerPackage_CPID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Staff_StaffID] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Staff_StaffID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Table_TableID] FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([TableID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Table_TableID]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Menu_MenuID] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Menu_MenuID]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order_OrderID]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Subscription_SubscriptionID] FOREIGN KEY([SubscriptionID])
REFERENCES [dbo].[Subscription] ([SubscriptionID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Subscription_SubscriptionID]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Account_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Account_AccountID]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_CoffeeShop_CoffeeID] FOREIGN KEY([CoffeeID])
REFERENCES [dbo].[CoffeeShop] ([CoffeeID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_CoffeeShop_CoffeeID]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_CoffeeShop_CoffeeID] FOREIGN KEY([CoffeeID])
REFERENCES [dbo].[CoffeeShop] ([CoffeeID])
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_CoffeeShop_CoffeeID]
GO

INSERT INTO [dbo].[CoffeeShop] 
    ([CoffeeID], [CoffeeName], [OpenTime], [CloseTime], [Address], [PhoneNumber], [Description], [Status], [Image]) 
VALUES 
    ('ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', 'Coffee Cat Shop 1', '08:00:00', '20:00:00', N'250, Trần Hưng Đạo, P. Nguyễn Cư Trinh, Q. 1, Tp. Hồ Chí Minh', '0981245698', N'Ngoài những món nước độc, lạ The Cat Coffee còn thu hút bạn bởi không gian sang trọng, hiện đại và đặc biệt là thú cưng ở đây cực kỳ đáng yêu và thân thiện với mọi người.', 1, 'coffee1.jpg'),
    ('f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', 'Coffee Cat Shop 2', '09:00:00', '20:00:00', N'135 Hoàng Hoa Thám, Phường 13, Tân Bình, Thành phố Hồ Chí Minh', '0901663508', N'Tại quán, bạn sẽ có thể được ngắm nhìn những chú mèo Tây đắt đỏ trong không gian vô cùng sang trọng.', 1, 'coffee2.jpg'),
	('9c305019-b38f-431a-835f-7b29d4351bc7', 'Coffee Cat Shop 3', '08:00:00', '20:00:00', N'89 Đường số 3, Bình Hưng Hoà B, Bình Tân, Thành phố Hồ Chí Minh', '0987665431', N'Quán được thiết kế theo phong cách Bắc Âu với đàn mèo có giá trị lên đến hơn trăm triệu với đủ loại từ mèo Munchkin chân ngắn đến mèo báo Bengal, mèo Chinchilla, mèo Scottish tai cụp...', 1, 'coffee1.jpg'),
	('4ff4a000-9b2a-4409-92c5-f9cf01947609', 'Coffee Cat Shop 4', '08:00:00', '21:00:00', N'48 Đường Phan Liêm, Đa Kao, Quận 1, Thành phố Hồ Chí Minh', '0989776427', N'Quán gồm 2 tầng trong đó tầng 1 là nơi dành cho các bé mèo con, các bé mèo lớn hơn sẽ ở trên tầng 2. Không chỉ được chơi đùa với các bé mèo đáng yêu, đến đây bạn còn được thưởng thức rất nhiều đồ ăn ngon từ các loại đồ uống thanh mát.', 1, 'coffee1.jpg'),
	('e54cb065-8ef4-4041-8822-e2ecf294c281', 'Coffee Cat Shop 5', '08:00:00', '22:00:00', N'59 Châu Thị Hóa, Phường 4, Quận 8, Thành phố Hồ Chí Minh', '0934612486', N'Đồ uống tại Kẻ Cót chủ yếu là trà và cafe được pha theo phong cách truyền thống. Mèo ở đây bé nào cũng mũm mĩm, đáng yêu sẽ giúp bạn có những phút giây xả stress tuyệt vời nhất.', 1, 'coffee1.jpg')
    

GO
INSERT INTO [dbo].[Table]
([TableID],[Status],[Type],[CoffeeID])
VALUES
('3e9ffc0b-3784-484d-aacf-50a68e16dfca','Available','Small','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
('df1b3f75-82e2-45f8-a0f7-57c1f70f3234','Reserved','Medium','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
('fa81c3ee-af79-43c2-9647-b5ef610e0a58','Occupied','Small','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
('09e32031-9db7-41bf-bd99-c78bb8e6ff86','Available','Medium','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
('dd5b9b17-d08b-4531-8d65-eb1fd25e710d','Available','Medium','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
('d71129cd-b043-4ac4-9292-1d677b99b4fd','Reserved','Small','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
('18ef9f9c-51ab-4402-a7fe-3c5a7f1955b4','Reserved','Small','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
('05e9e994-8f7d-459d-8e7c-63bcfc8a3f90','Occupied','Small','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
('4f921199-4f53-47bf-9e59-0a42721e16e5','Occupied','Small','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
('f9fe07c5-77d3-4d71-8ccb-61bd56d480a3','Available','Medium','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
('0b7d91ed-e07b-4dc1-9a3e-27ea64ddabd2','Available','Medium','9c305019-b38f-431a-835f-7b29d4351bc7'),
('6a1aa86e-7e90-4523-83b8-84645e153a57','Reserved','Medium','9c305019-b38f-431a-835f-7b29d4351bc7'),
('15e9c887-fae0-49d8-ba0b-7ad6f32a460f','Reserved','Small','9c305019-b38f-431a-835f-7b29d4351bc7'),
('f02d716d-0792-4923-927f-c50aa0d2836e','Occupied','Small','9c305019-b38f-431a-835f-7b29d4351bc7'),
('3582a74e-f919-43d2-ac51-8a0cbbf82862','Occupied','Medium','9c305019-b38f-431a-835f-7b29d4351bc7'),
('b13a5af6-7b87-4195-88f8-97d22c23bb15','Available','Medium','4ff4a000-9b2a-4409-92c5-f9cf01947609'),
('25551008-d67e-4e65-83b3-52d0c25399f4','Available','Medium','4ff4a000-9b2a-4409-92c5-f9cf01947609'),
('03dc04a7-ddc6-43a1-a5a8-b4ccb3b9feca','Reserved','Small','4ff4a000-9b2a-4409-92c5-f9cf01947609'),
('906d82bd-9adb-475c-924d-312336e3e36b','Reserved','Small','4ff4a000-9b2a-4409-92c5-f9cf01947609'),
('68b8c110-25c7-4f0e-9f84-549dfae3de09','Occupied','Medium','4ff4a000-9b2a-4409-92c5-f9cf01947609'),
('ef7c8964-a0f6-4e56-8b84-cb5cbc7b18da','Occupied','Medium','e54cb065-8ef4-4041-8822-e2ecf294c281'),
('80b2144a-031a-455e-8058-5cf763a30f63','Available','Medium','e54cb065-8ef4-4041-8822-e2ecf294c281'),
('c210735d-de6c-4c08-88eb-ee5a8e074793','Available','Small','e54cb065-8ef4-4041-8822-e2ecf294c281'),
('bfa58196-098d-4cee-a359-f5fd23c1a00d','Reserved','Small','e54cb065-8ef4-4041-8822-e2ecf294c281'),
('c9568f9f-c52f-4707-868f-48fc6f8554c0','Reserved','Small','e54cb065-8ef4-4041-8822-e2ecf294c281')

GO
Insert into [dbo].[Role]
([RoleID],[RoleName])
values

('64dd1a12-3f2b-445e-951b-6da41bbb9b30', 'Staff'),
('94dab4fc-2c2a-4813-9691-d3bb42bb3760', 'Customer'),
('e9e125c5-defc-4035-a6b7-3f23c83453ba', 'Manager')
Go

INSERT INTO [dbo].[Cat] ([CatID], [CatName], [Age], [Description], [Type], [Status], [Image], [CoffeeID])
VALUES
    ('e1309f21-0bd5-4b78-9ac2-abef6c8dbddf', 'Martin', 3, N'Mèo Abyssinian nặng 3.5 – 5kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo Abyssinian', 1, 'Image1.jpg', 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
    ('4f37e2e0-36b4-4b0f-94bb-34f5d2f2647a', 'Lindley', 2, N'Mèo Bobtail nặng từ 6-8kg. Thuộc giống mèo trung bình tới lớn. Lông ngắn, phần đuôi xù, nhiều màu đan xen. Lông rụng vừa phải, cần chải định kỳ hàng tuần, thông minh và thân thiện, hòa đồng với mọi người và thích chơi trốn tìm.', N'Mèo Bobtail', 1, 'Image2.jpg', 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
    ('0c4a4cba-2a8e-4690-91f0-3670c6443af4', 'Mora', 4, N'Mèo lông xoăn nặng 3-5-5kg, lông ngắn trung bình, tai vểnh ra sau độc đáo. Ít rụng lông, thân thiện giàu tình cảm.', N'Mèo lông xoăn', 1, 'Image3.jpg', 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
    ('65a02855-9f89-4808-a5b1-175df32bec48', 'Lovelace', 5, N'Mèo lông ngắn nặng 5.5 – 7kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, độc lập, nhưng thích được quan tâm, không thích bị bế trong lòng, hòa thuận với chó và mèo khác, nhưng hiếu động với các loài chim.', N'Mèo lông ngắn', 1, 'Image4.jpg', 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
    ('7f224348-c3b1-4f51-bf90-464954c1e645', 'Gibson', 2, N'Mèo Wirehair nặng 5.5 – 7.5kg. bộ lông xoăn xù, râu cũng xoăn, ít rụng lông, vui vẻ thân thiện, quan tâm tới mọi người, quý trẻ em.', N'Mèo Wirehair', 1, 'Image5.jpg', 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc'),
    ('ffc1910c-d04a-4350-8b49-4cdf3865ddc5', 'Sosa', 3, N'Mèo Bali-Java nặng 6 – 8kg. Màu lông nhiều màu, ít rụng, nhẹ nhàng, tinh tế, nhưng hay tò mò.', N'Mèo Bali-Java', 1, 'Image6.jpg', 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
    ('e75f8185-f7c1-4969-96bc-8b95ed4a7d4f', 'Hunter', 2, N'Mèo Bengal nặng 5 – 10kg. Màu lông độc đáo gồm các đốm đen, nâu. Thậm chí một số con có ánh sáng lấp lánh ở đầu lông, thân thiện, vui vẻ, hay tò mò', N'Mèo Bengal', 1, 'Image7.jpg', 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
    ('7ee3fbcd-beff-4bc4-ac16-f96eec70067d', 'Cole', 4, N'Mèo Birman nặng 5 – 7.5kg. Màu lông sáng, đi tất trắng (các bạn thường gọi măng cụt) và mắt màu xanh, nhẹ nhàng, trầm lắng nhưng thân thiện.', N'Mèo Birman', 1, 'Image8.jpg', 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
    ('da531ace-24fd-4ff1-9529-2f0ce4c4d69f', 'Corbin', 3, N'Mèo Bombay nặng 4 – 5.5kg. Màu lông đen sâu, đầu tròn, tai dài dựng, thân hình tròn, chân dài, rất thông minh và thích tương tác với người nuôi.', N'Mèo Bombay', 1, 'Image9.jpg', 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
    ('b0f96d69-8e4d-4828-9d5b-aca6bacd893b', 'Cawley', 2, N'Mèo Anh lông ngắn nặng 6 – 9kg. Màu lông xanh đậm, thân tròn, ngực rộng, chân ngắn, mặt tròn, thích rúc vào nách người, nhưng không phải là loài mèo thích ôm.', N'Mèo Anh lông ngắn', 1, 'Image10.jpg', 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c'),
    ('0dca3824-1586-45fc-a366-1b5101bfdab9', 'Merrill', 1, N'Mèo Miến Điện nặng 4-6kg. Màu lông xám, nâu sâm, thân hình rắn chắc vạm vỡ. Lông ngắn, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo Miến Điện', 1, 'Image11.jpg', '9c305019-b38f-431a-835f-7b29d4351bc7'),
    ('820accd4-0312-4f8e-bbb0-267aa290ec19', 'Aponte', 4, N'Mèo Chartreux nặng 5-7.5 kg. Màu lông xanh, độ dài vừa phải. Trưởng thành chậm, từ 3-5 năm, thân thiện với mọi người trong gia đình. Được coi như nụ cười của nước pháp.', N'Mèo Chartreux', 1, 'Image12.jpg', '9c305019-b38f-431a-835f-7b29d4351bc7'),
    ('711573f3-028a-4b18-8d88-d5c419b3e6b4', 'Sasaki', 3, N'Mèo Cornish Rex nặng 3.5 – 4.5kg. Lông ngắn nhưng rất mềm và mượt. Rất hiếu động, thích leo trèo.', N'Mèo Cornish Rex', 1, 'Image13.jpg', '9c305019-b38f-431a-835f-7b29d4351bc7'),
    ('f02b0516-fb82-451a-bbd7-24c62c213c90', 'Jenkins', 2, N'Mèo Devon Rex nặng 4 – 5kg. Màu lông nhiều màu, đôi mắt to và đặc biệt tai dài quá khổ. râu ngắn. Cực kỳ thân thiện, thông mình và năng động.', N'Mèo Devon Rex', 1, 'Image14.jpg', '9c305019-b38f-431a-835f-7b29d4351bc7'),
    ('5420f77b-e87d-4ccd-89d6-b5015a547afe', 'Kyler', 1, N'Mèo Ai cập nặng 5 – 7 kg. Màu lông bạc, đồng và khói. Rất thích được ôm ấp. Thân thiện và vui vẻ.', N'Mèo Ai cập', 1, 'Image15.jpg', '9c305019-b38f-431a-835f-7b29d4351bc7'),
    ('691e50bf-a8be-4a89-8c76-f8b10fd5debf', 'Holly', 3, N'Mèo Exotic nặng 3.5 – 7kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, thích chơi đùa cùng chủ, thân thiện và thích nằm trong lòng người nuôi.', N'Mèo Exotic', 1, 'Image16.jpg', '4ff4a000-9b2a-4409-92c5-f9cf01947609'),
    ('548068c4-0b93-4674-a59b-867826151578', 'Towell', 2, N'Mèo nâu Havana nặng 4 – 5kg. Màu lông nâu đỏ sẫm, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo nâu Havana', 1, 'Image17.jpg', '4ff4a000-9b2a-4409-92c5-f9cf01947609'),
    ('b06b90e8-c4ac-4756-8fef-642a45ebabec', 'Rivet', 3, N'Mèo Himalayan nặng 4 – 7kg. Màu lông trắng, nâu vàng. Đuôi sẫm màu hơn, độc lập, thích yên bình và chơi một mình. Sợ người lạ, thích nằm trong lòng chủ.', N'Mèo Himalayan', 1, 'Image18.jpg', '4ff4a000-9b2a-4409-92c5-f9cf01947609'),
    ('c1e2eae8-e367-4388-af25-478b1510d5e9', 'Sutton', 5, N'Mèo Manx nặng 4.5 – 6.5kg. Màu lông đa sắc, thân tròn, mập mạp, ngực nở, mông tròn. Đặc biệt chân trước ngắn hơn chân sau. Lông cũng chia làm 2 loại ngắn và dài, thân thiện với mọi người và không sợ người lạ.', N'Mèo Manx', 1, 'Image19.jpg', '4ff4a000-9b2a-4409-92c5-f9cf01947609'),
    ('6eef53c5-4d60-4888-a2c7-127b9a3ade27', 'Patterson', 4, N'Mèo Munchkin nặng 2.5 – 5kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, rất thân thiện và bám chủ.', N'Mèo Munchkin', 1, 'Image20.jpg', '4ff4a000-9b2a-4409-92c5-f9cf01947609'),
    ('4e676aad-0a19-440e-b691-114a0cb04bf5', 'Harnish', 2, N'Mèo rừng Nauy nặng 3.5 – 5kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo rừng Nauy', 1, 'Image21.jpg', 'e54cb065-8ef4-4041-8822-e2ecf294c281'),
    ('cc9c8adc-d681-4c18-ae5e-9cf688a9f7ce', 'Given', 1, N'Mèo Ocicat nặng 3.5 – 5kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo Ocicat', 1, 'Image22.jpg', 'e54cb065-8ef4-4041-8822-e2ecf294c281'),
    ('1411cb07-e772-412e-bf4d-247dfd0bd58b', 'Scriber', 3, N'Mèo PeterBald nặng 3.5 – 5kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo PeterBald', 1, 'Image23.jpg', 'e54cb065-8ef4-4041-8822-e2ecf294c281'),
    ('b18a7735-62f3-4ca1-955e-bf96839a39e1', 'Hanley', 2, N'Mèo Pixiebob nặng 3.5 – 5kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo Pixiebob', 1, 'Image24.jpg', 'e54cb065-8ef4-4041-8822-e2ecf294c281'),
    ('282580a1-95c8-4325-b9de-8da54abf9b54', 'Allen', 4, N'Mèo Ragamuffin nặng 3.5 – 5kg. Màu lông đỏ hồng, xanh da trời, nâu vàng, tai dựng đứng, thân thiện với trẻ em, thú nuôi khác như chó, vẹt. Thích được người nuôi quan tâm.', N'Mèo Ragamuffin', 1, 'Image25.jpg', 'e54cb065-8ef4-4041-8822-e2ecf294c281')
	Go
INSERT INTO [dbo].[CatProduct](
	[CatProductID] , [CatProductName] , [CatProductType] , [Price] , [Status] , [Image] )
	
VALUES
('f0a54c6e-994b-4380-8851-efa124900e92',N'Pate gà',N'Thức ăn','30000',1,'Food1.jpg'),
('3eb4a0a5-02df-4d71-a451-6299937edb25',N'Pate cá',N'Thức ăn','30000',1,'Food2.jpg'),
('e6ce648e-6ac6-45ca-8b7b-8571bdbba138',N'Snack thưởng',N'Thức ăn','20000',1,'Food3.jpg'),
('253e41d6-b501-447d-a0eb-2ea829c0c139',N'Súp thưởng',N'Thức ăn','15000',1,'Food4.jpg'),
('430201bf-306c-4a4a-a065-15a172961e1a',N'Hạt dinh dưỡng nhỏ',N'Thức ăn','50000',1,'Food5.jpg'),
('bf4cb4b0-8146-4aad-b82c-c3ded73fbff9',N'Hạt dinh dưỡng lớn',N'Thức ăn','100000',1,'Food6.jpg'),
('96d10b2d-dcef-4a29-ae71-5904edc4d3ed',N'Xúc xích thưởng',N'Thức ăn','20000',1,'Food7.jpg'),
('48e97a18-e7fa-48f4-a70e-f5a8d8854c0f',N'Cỏ mèo',N'Đồ chơi','20000',1,'Toy1.jpg'),
('7d0f7183-c3b8-4741-bc9f-8d749283a5ac',N'Bàn cào móng ',N'Đồ chơi','50000',1,'Toy2.jpg'),
('2463d13e-b180-48f7-ab4e-05c84e4b9982',N'Cần câu mèo',N'Đồ chơi','30000',1,'Toy3.jpg'),
('87eeff72-4dba-46f6-8a4c-79ac60afc1ca',N'Cá nhồi bông',N'Đồ chơi','40000',1,'Toy4.jpg'),
('dc156463-1c39-4235-861f-407d272c1693',N'Chuột nhồi bông',N'Đồ chơi','30000',1,'Toy5.jpg'),
('98c51b18-da21-4f21-9335-9a733f67ff83',N'Đèn laze',N'Đồ chơi','40000',1,'Toy6.jpg'),
('d562ecae-f5b3-4ef8-ba74-dea1445b2a0b',N'Gậy lông vũ',N'Đồ chơi','70000',1,'Toy7.jpg'),
('c2df00fc-bd9c-4cce-8ee6-0e53c8e0926e',N'Chuột điều khiển từ xa',N'Đồ chơi','50000',1,'Toy8.jpg')

GO

INSERT INTO [dbo].[Drink] ([DrinkID], [DrinkName], [UnitPrice], [Status], [Image])
VALUES 
   ('bfc1dc18-efdc-42c0-ab76-7aecfb04ace0', N'Cà phê đen', '15000', 1, 'coffee1.jpg'),
   ('a25a3107-b1b9-4dec-9f80-0fbe5abe7184', N'Cà phê sữa', 25000, 1, 'coffee2.jpg'),
   ('ad00b943-2dc0-45ea-a3e1-b6a9d25e3910', N'Trà sữa truyền thống', 27000, 1, 'milktea1.jpg'),
   ('ac67e0b3-4a28-4f49-a36a-c3e4874ddf07', N'Trà sữa choco', 30000, 1, 'milktea2.jpg'),
   ('6547f918-2f7e-4977-b0ff-08c1c250009b', N'Olong sữa kem trứng nướng', 39000, 1, 'eggcream.jpg'),
   ('248b5b0b-3e36-41e3-af1e-4cafe9f1f279', N'Sữa tươi trân châu đường đen', 37000, 1, 'milk.jpg'),
   ('980cd6dc-6f89-498e-bf18-a472caa7385c', N'Trà lài vải', 37000, 1, 'fruittea.jpg'),
   ('33191348-8b56-4306-853f-a32adadb4b15', N'Hồng trà mật ông', 30000, 1, 'tea.jpg'),
   ('c4bd1439-a59f-4852-bad6-302ca47270a3', N'Sinh tố dâu', 40000, 1, 'smoothie1.jpg'),
   ('71b04e75-9a64-4c8b-a878-e8fefbd61107', N'Sinh tố bơ', 45000, 1, 'smoothie2.jpg'),
   ('aaaa7587-36b4-4cb2-8385-13e4bad3e47e', N'Đá xay matcha', 45000, 1, 'crushedice1.jpg'),
   ('31ffd135-9373-42c3-8366-37352fd1494c', N'Đá xay việt quốc', 45000, 1, 'crushedice2.jpg'),
   ('0dbcd8c3-993e-4ad6-bd85-7bf46896ee11', N'Nước ép thơm', 35000, 1, 'juice1.jpg'),
   ('3092cf02-21cf-4611-81df-ab13bf3cbe74', N'Nước ép bưởi', 40000, 1, 'juice2.jpg'),
   ('8ef69ebc-bc12-4644-afbb-c1f81041a913', N'Nước ép táo', 30000, 1, 'juice3.jpg')
   GO

   INSERT INTO [dbo].[Subscription] ([SubscriptionID], [Name], [Status], [DiscountPercent],[Price])
VALUES
    ('aed4a431-1db9-459b-a973-c54e4941b929', N'Hạng Bạc', 1, 0.05,20000),
    ('462332be-5bed-4bd6-85b2-a17530a25cfa', N'Hạng Vàng', 1, 0.1,30000),
    ('c6252b73-01a2-4996-9bfe-19fe9d78a618', N'Hạng Kim Cương', 1, 0.2,40000),
    ('cf235d7b-ac9e-4ebe-81f8-13694e2d485b', N'Hạng Ruby', 1, 0.3,50000)
	Go
	

	
	Insert Into [dbo].[Account]
	([AccountID],[Email],[Password],[Status],[RoleID])
	Values
	('7dda1a46-09a7-4cf3-8f8a-06c291955355','manager1@gmail.com','@1','1','e9e125c5-defc-4035-a6b7-3f23c83453ba'),
	('96f70fa3-223d-4d3a-af16-433004b27ff4','manager2@gmail.com','@1','1','e9e125c5-defc-4035-a6b7-3f23c83453ba'),
	('10c0c727-8603-4871-afd6-01b0ce1a7fd1','manager3@gmail.com','@1','1','e9e125c5-defc-4035-a6b7-3f23c83453ba'),
	('cb583ee3-79c0-4ab9-9602-4cdb3a9353f9','manager4@gmail.com','@1','1','e9e125c5-defc-4035-a6b7-3f23c83453ba'),
	('3b5aafe6-4e3a-4c63-9809-38519c895a27','manager5@gmail.com','@1','1','e9e125c5-defc-4035-a6b7-3f23c83453ba'),
	('f3d972b1-c6f4-493d-b4b1-3283dd5f36ee','staff1@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('7856a6f1-a23a-4a61-8dfb-e265c627b7d5','staff2@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('a2dcdc11-ddef-4e6c-9024-d04a3488e81a','staff3@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('2f61eca0-4b65-4a42-982d-de5a9a1a62b7','staff4@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('5d5b1d7d-b963-4521-b161-51eb0afefa1e','staff5@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('20b5b559-3a93-46a2-86b7-1d0bdee0aa00','staff6@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('113b54f3-4b4a-432d-a808-4488242f273b','staff7@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('daaf3121-194c-4802-a7b0-2e2b55fa616e','staff8@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('42cb6dca-485f-4102-9b34-c32194947c71','staff9@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('023b2278-e89d-4dda-a5fc-134f16ffd277','staff10@gmail.com','@1','1','64dd1a12-3f2b-445e-951b-6da41bbb9b30'),
	('dcd10bc6-50f6-46cc-a332-d5f3f5d26f3b','customer1@gmail.com','@1','1','94dab4fc-2c2a-4813-9691-d3bb42bb3760'),
	('6edda91c-f6c0-4681-9519-11c78bbcb930','customer2@gmail.com','@1','1','94dab4fc-2c2a-4813-9691-d3bb42bb3760'),
	('4d4ba1e9-d99a-451a-a00d-359d1c5f49a0','customer3@gmail.com','@1','1','94dab4fc-2c2a-4813-9691-d3bb42bb3760'),
	('cbae0414-7490-4a88-88db-1435704d7565','customer4@gmail.com','@1','1','94dab4fc-2c2a-4813-9691-d3bb42bb3760'),
	('6a8b42e4-a071-4f8c-bec6-1799af5597a0','customer5@gmail.com','@1','1','94dab4fc-2c2a-4813-9691-d3bb42bb3760')
	
	GO


	Insert Into [dbo].[Staff]
	([StaffID],[FullName],[PhoneNumber],[Address],[DOB],[CoffeeID],[AccountID])
	values
	('3d81e9ba-7b25-4e62-822f-5dd87825a5fe',N'Nguyễn Tiến Phát','0912443874',N'49 Đường số 2 phường Bình Hưng Hòa A Quận Bình Tân','19-01-1990','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc','7dda1a46-09a7-4cf3-8f8a-06c291955355')
	Go
	Insert Into [dbo].[Staff]
	([StaffID],[FullName],[PhoneNumber],[Address],[DOB],[CoffeeID],[AccountID])
	values
	('19c80e85-2aab-44cc-b248-bdf51977f87e',N'Hà Văn Nam','0816234913',N'34 Đường Số 17, P. Tân Kiểng, Quận 7','20-11-1995','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c','96f70fa3-223d-4d3a-af16-433004b27ff4'),
	('5d6e5e7a-4dae-4999-afbf-c3b8e599d172',N'Hồ Thiện Dũng','0912374859',N'500 Hoà Hảo, Quận 10','14-08-1989','9c305019-b38f-431a-835f-7b29d4351bc7','10c0c727-8603-4871-afd6-01b0ce1a7fd1')
	GO
	Insert Into [dbo].[Staff]
	([StaffID],[FullName],[PhoneNumber],[Address],[DOB],[CoffeeID],[AccountID])
	values
	('671fd03d-15af-436a-863d-951e2bcc75d7',N'Nguyễn Thiện Hưng','0812334871',N' 285/21 CMT8, Phường 12, Quận 10','11-12-1992','4ff4a000-9b2a-4409-92c5-f9cf01947609','cb583ee3-79c0-4ab9-9602-4cdb3a9353f9'),
	('90d0611b-e036-4dc9-b048-dcb96c2f1bbb',N'Mai Đào Tiên','0911243276',N' 666/55 Đường 3/2, Quận 10','15-03-1991','e54cb065-8ef4-4041-8822-e2ecf294c281','3b5aafe6-4e3a-4c63-9809-38519c895a27')
	GO
	Insert Into [dbo].[Staff]
	([StaffID],[FullName],[PhoneNumber],[Address],[DOB],[CoffeeID],[AccountID])
	values
	('38ec4538-365d-4c1b-8782-85da09f0ee68',N'Bùi Minh Đức','0912887364',N' 590 Sư Vạn Hạnh, Quận 10','14-08-1999','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc','f3d972b1-c6f4-493d-b4b1-3283dd5f36ee'),
	('2b5caf2e-2f7a-4908-a0f2-e9793defd110',N'Nguyễn Đức Bình','0933968931',N'  54 Đồng Nai, Phường 15, Quận 10','11-08-2000','ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc','7856a6f1-a23a-4a61-8dfb-e265c627b7d5')
	GO
	Insert Into [dbo].[Staff]
	([StaffID],[FullName],[PhoneNumber],[Address],[DOB],[CoffeeID],[AccountID])
	values
	('36b083df-3e37-4cf5-a002-3290f5303537',N'Trần Thái Bảo Ngọc','0918279858',N'413- 415 đường Nguyễn Trãi, Q5','15-06-2001','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c','a2dcdc11-ddef-4e6c-9024-d04a3488e81a'),
	('f8656bae-413a-4371-9221-62fed13498d1',N'Nguyễn Thanh Bình','0912873647',N'1-3 đường Phan Chu Trinh, Q1','21-03-2002','f9d87ddc-c7ea-4178-ba3b-d30efa6f426c','2f61eca0-4b65-4a42-982d-de5a9a1a62b7'),

	('97d2c8f1-244a-41df-b06c-d73d7bd852b3',N'Hà Đông Du','0923821982',N'433-435 Lý Thái Tổ, Q10','22-04-1987','9c305019-b38f-431a-835f-7b29d4351bc7','5d5b1d7d-b963-4521-b161-51eb0afefa1e'),
	('e4c753c0-9878-48f4-a6b1-e6151e68f350',N'Nguyễn Trà My','0812443275',N'14/5 Kỳ Đồng, P.9, Quận 3','21-02-1987','9c305019-b38f-431a-835f-7b29d4351bc7','20b5b559-3a93-46a2-86b7-1d0bdee0aa00'),

	('049f78ff-cedd-4add-94f0-b6cd038b666a',N'Bùi Mỹ Đan','0917239485',N'33 Hoàng Văn Thụ, Q. Phú Nhuận','17-11-2003','4ff4a000-9b2a-4409-92c5-f9cf01947609','113b54f3-4b4a-432d-a808-4488242f273b'),
	('4003ceb8-e72a-494e-a60e-2ba4c7d2cabb',N'Phạm Quỳnh Chi','081488290',N'150, Nguyễn Thị Nhỏ, Phường 15, Quận 11','11-11-1999','4ff4a000-9b2a-4409-92c5-f9cf01947609','daaf3121-194c-4802-a7b0-2e2b55fa616e'),

	('089bc1ac-5241-4fa7-b07a-79dda0dd5e33',N'Nguyễn Thiện Tú','0814682349',N' 339 Lê Văn Sỹ, Q. Tân Bình','23-03-2004','e54cb065-8ef4-4041-8822-e2ecf294c281','42cb6dca-485f-4102-9b34-c32194947c71'),
	('9e62408d-fec7-4f81-a9ac-865e10dd31e3',N'Cao Nguyễn Thùy Chi','0967912907',N' 503 đường Lê Văn Sỹ, P2, Q. Tân Bình','29-05-2004','e54cb065-8ef4-4041-8822-e2ecf294c281','023b2278-e89d-4dda-a5fc-134f16ffd277')
	GO

	Insert Into [dbo].[Customer]
	([CustomerID],[FullName],[PhoneNumber],[AccountID])
	values
	('0d22c24e-e48f-4894-bf50-a88d48342987',N'Cao Thiên Kỳ Duyên','0828773456','dcd10bc6-50f6-46cc-a332-d5f3f5d26f3b'),
	('3d5a3e0e-c724-4d7d-902a-cbb798bcbd8e',N'Nguyễn Đoàn Công Minh','0982117418','6edda91c-f6c0-4681-9519-11c78bbcb930'),
	('5da30602-172c-474f-b528-1066b05b4cb0',N'Lý Minh Tuấn ','0947669347','4d4ba1e9-d99a-451a-a00d-359d1c5f49a0'),
	('dcb2ea7e-126d-4abe-a0fc-2b7468892c72',N'Ông Cao Bình ','0798632917','cbae0414-7490-4a88-88db-1435704d7565'),
	('a0b6d033-72c1-4751-ac24-c82366a9fb5b',N'Nguyễn Thiên Ý ','0976234814','6a8b42e4-a071-4f8c-bec6-1799af5597a0')
	Go


INSERT INTO [dbo].[Menu] ([MenuID], [Status], [CoffeeID], [DrinkID], [CatProductID])
VALUES
    ('8fcc579c-bf5f-4a28-bc43-9645de29e263', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '6547f918-2f7e-4977-b0ff-08c1c250009b', null), --Shop 1, Olong sữa kem trứng nướng
    ('f8ee89bf-8aef-472e-b72f-42e6228d8eeb', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', 'a25a3107-b1b9-4dec-9f80-0fbe5abe7184', null), --Shop 1, Cà phê sữa
    ('abfd935c-40e8-4020-9cb7-f4942fce715d', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', 'aaaa7587-36b4-4cb2-8385-13e4bad3e47e', null), --Shop 1, Đá xay matcha
    ('6700028e-e85f-4a13-99be-03c76b1f8a21', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', 'c4bd1439-a59f-4852-bad6-302ca47270a3', null), --Shop 1, Sinh tố dâu
    ('007458e4-e54e-4517-b83e-8ce9026053a3', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '31ffd135-9373-42c3-8366-37352fd1494c', null), --Shop 1, Đá xay việt quốc
    ('72bb1e11-3ba9-435e-a8f6-285323f2f9fb', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '248b5b0b-3e36-41e3-af1e-4cafe9f1f279', null), --Shop 1, Sữa tươi trân châu đường đen
    ('f6382251-e79f-4d87-b766-0091d847e79b', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', 'bfc1dc18-efdc-42c0-ab76-7aecfb04ace0', null), --Shop 1, Cà phê đen
    ('a0d6cd18-ac91-45ef-8a9a-3f165bf8052b', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '0dbcd8c3-993e-4ad6-bd85-7bf46896ee11', null), --Shop 1, Nước ép thơm
    ('3f5bd30a-6f33-4643-88af-61309ccc23aa', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '33191348-8b56-4306-853f-a32adadb4b15', null), --Shop 1, Hồng trà mật ông
    ('0b1b3704-7509-41dd-a83c-e014eb235dd4', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '980cd6dc-6f89-498e-bf18-a472caa7385c', null), --Shop 1, Trà lài vải
    ('b994ee8e-c648-4203-a40d-eeb48aac99ca', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '3092cf02-21cf-4611-81df-ab13bf3cbe74', null), --Shop 1, Nước ép bưởi
    ('36abd32f-9c58-495d-ab2b-4c65e6ff9b21', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', 'ad00b943-2dc0-45ea-a3e1-b6a9d25e3910', null), --Shop 1, Trà sữa truyền thống
    ('14bbd1d7-061f-4238-81a6-85595339dbdf', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '8ef69ebc-bc12-4644-afbb-c1f81041a913', null), --Shop 1, Nước ép táo
    ('c1fc1afd-4519-4f99-96cc-f995d4b562a2', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', 'ac67e0b3-4a28-4f49-a36a-c3e4874ddf07', null), --Shop 1, Trà sữa choco
    ('11754feb-4ac0-49e9-bb81-7dd8d55ef7dd', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', '71b04e75-9a64-4c8b-a878-e8fefbd61107', null), --Shop 1, Sinh tố bơ
    ('a6fcaeed-5096-4b72-8c9c-1f8bb0da21b0', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '6547f918-2f7e-4977-b0ff-08c1c250009b', null), --Shop 2, Olong sữa kem trứng nướng
    ('fd2238b3-6b21-49b5-a555-77ecb94fc123', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', 'a25a3107-b1b9-4dec-9f80-0fbe5abe7184', null), --Shop 2, Cà phê sữa
    ('0654acd0-c2a8-4df3-b932-691eab6b966f', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', 'aaaa7587-36b4-4cb2-8385-13e4bad3e47e', null), --Shop 2, Đá xay matcha
    ('b5920fa6-db21-46f4-a829-4b248c9ff5f1', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', 'c4bd1439-a59f-4852-bad6-302ca47270a3', null), --Shop 2, Sinh tố dâu
    ('65dbecdc-400a-44be-8b81-8de3cb6bdc08', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '31ffd135-9373-42c3-8366-37352fd1494c', null), --Shop 2, Đá xay việt quốc
    ('2454f96e-7c87-474d-915a-90a898ade11c', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '248b5b0b-3e36-41e3-af1e-4cafe9f1f279', null), --Shop 2, Sữa tươi trân châu đường đen
    ('91219369-2152-4887-9754-80bf5821c85c', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', 'bfc1dc18-efdc-42c0-ab76-7aecfb04ace0', null), --Shop 2, Cà phê đen
    ('18fbb62d-b2fd-46bb-9e9c-1f08e8ddceb6', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '0dbcd8c3-993e-4ad6-bd85-7bf46896ee11', null), --Shop 2, Nước ép thơm
    ('3105990e-132d-4d47-91b9-662bfb127247', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '33191348-8b56-4306-853f-a32adadb4b15', null), --Shop 2, Hồng trà mật ông
    ('81e55293-32b5-4019-ad90-4c80c26cbbce', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '980cd6dc-6f89-498e-bf18-a472caa7385c', null), --Shop 2, Trà lài vải
    ('f4f05de7-e08a-456d-bfd9-557c67ec1790', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '3092cf02-21cf-4611-81df-ab13bf3cbe74', null), --Shop 2, Nước ép bưởi
    ('7a811e52-3e1c-49e1-b04e-f877f7c73cbf', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', 'ad00b943-2dc0-45ea-a3e1-b6a9d25e3910', null), --Shop 2, Trà sữa truyền thống
    ('49590f14-d577-4ca6-b2cd-8c3830407c0a', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '8ef69ebc-bc12-4644-afbb-c1f81041a913', null), --Shop 2, Nước ép táo
    ('1dda7009-1bd9-4faf-a55e-f470d89a8472', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', 'ac67e0b3-4a28-4f49-a36a-c3e4874ddf07', null), --Shop 2, Trà sữa choco
    ('08e1aa0e-6d6c-4504-9999-33d85665cde7', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', '71b04e75-9a64-4c8b-a878-e8fefbd61107', null), --Shop 2, Sinh tố bơ
    ('f2fdb98f-4bad-4fbf-9b1b-994a36cdcead', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '6547f918-2f7e-4977-b0ff-08c1c250009b', null), --Shop 3, Olong sữa kem trứng nướng
    ('b80a7e00-779f-4215-bcf7-3f198de522b4', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', 'a25a3107-b1b9-4dec-9f80-0fbe5abe7184', null), --Shop 3, Cà phê sữa
    ('82a151e5-f400-4ac2-a6c5-d06cf7d8740d', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', 'aaaa7587-36b4-4cb2-8385-13e4bad3e47e', null), --Shop 3, Đá xay matcha
    ('8cdb08e4-5f77-4c02-bda2-82425b7a9799', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', 'c4bd1439-a59f-4852-bad6-302ca47270a3', null), --Shop 3, Sinh tố dâu
    ('154b71b2-c7c6-4b75-9678-6f1e0a0081ce', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '31ffd135-9373-42c3-8366-37352fd1494c', null), --Shop 3, Đá xay việt quốc
    ('88482172-bee1-4159-b367-6961a554cc41', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '248b5b0b-3e36-41e3-af1e-4cafe9f1f279', null), --Shop 3, Sữa tươi trân châu đường đen
    ('82b17b63-c7b9-459f-bec3-52ce5a773a77', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', 'bfc1dc18-efdc-42c0-ab76-7aecfb04ace0', null), --Shop 3, Cà phê đen
    ('570fbd7d-1b32-4f09-bb4c-0ba7ecffc3b7', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '0dbcd8c3-993e-4ad6-bd85-7bf46896ee11', null), --Shop 3, Nước ép thơm
    ('bd7ed91f-350a-4608-87d9-4da315be8587', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '33191348-8b56-4306-853f-a32adadb4b15', null), --Shop 3, Hồng trà mật ông
    ('bc6a3950-c8c9-4674-8870-4b6f575ccab4', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '980cd6dc-6f89-498e-bf18-a472caa7385c', null), --Shop 3, Trà lài vải
    ('a203d30a-7159-4566-b471-b324a1ab514c', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '3092cf02-21cf-4611-81df-ab13bf3cbe74', null), --Shop 3, Nước ép bưởi
    ('8fb73a7c-9480-4038-a501-82b75a6fc9ca', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', 'ad00b943-2dc0-45ea-a3e1-b6a9d25e3910', null), --Shop 3, Trà sữa truyền thống
    ('5d9426a4-1bf8-4039-ba54-908c05224102', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '8ef69ebc-bc12-4644-afbb-c1f81041a913', null), --Shop 3, Nước ép táo
    ('37b15594-e101-4eed-9b0d-3bcc5ed2b153', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', 'ac67e0b3-4a28-4f49-a36a-c3e4874ddf07', null), --Shop 3, Trà sữa choco
    ('29db1a39-363e-4d9a-aea2-3019d73e2b89', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', '71b04e75-9a64-4c8b-a878-e8fefbd61107', null), --Shop 3, Sinh tố bơ
    ('335a6d1d-1a29-494d-9ebd-a9ec91d44b97', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '6547f918-2f7e-4977-b0ff-08c1c250009b', null), --Shop 4, Olong sữa kem trứng nướng
    ('0eb12be4-f7ae-4e07-83fa-b347a748cedf', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', 'a25a3107-b1b9-4dec-9f80-0fbe5abe7184', null), --Shop 4, Cà phê sữa
    ('9f9c766c-8d1c-4964-8dba-1a84558083d1', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', 'aaaa7587-36b4-4cb2-8385-13e4bad3e47e', null), --Shop 4, Đá xay matcha
    ('c71550f8-1ef2-400b-8a38-26987f9362ae', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', 'c4bd1439-a59f-4852-bad6-302ca47270a3', null), --Shop 4, Sinh tố dâu
    ('c613126e-d083-49f0-97b0-c89c264d3a19', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '31ffd135-9373-42c3-8366-37352fd1494c', null), --Shop 4, Đá xay việt quốc
    ('05c3d704-d40c-47c0-88ee-d7b196feb60b', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '248b5b0b-3e36-41e3-af1e-4cafe9f1f279', null), --Shop 4, Sữa tươi trân châu đường đen
    ('2e19482b-bc22-4896-ad56-da052518c0b2', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', 'bfc1dc18-efdc-42c0-ab76-7aecfb04ace0', null), --Shop 4, Cà phê đen
    ('3a82c8a1-b89c-41d2-a5ac-e1d4b91bde9c', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '0dbcd8c3-993e-4ad6-bd85-7bf46896ee11', null), --Shop 4, Nước ép thơm
    ('e5d50760-2a12-428c-ac1b-2fe732a64ca1', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '33191348-8b56-4306-853f-a32adadb4b15', null), --Shop 4, Hồng trà mật ông
    ('e551b4f4-2069-4754-b9bf-f77559f3fa5a', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '980cd6dc-6f89-498e-bf18-a472caa7385c', null), --Shop 4, Trà lài vải
    ('ea8ce596-8a10-4857-a119-ea54dbf18573', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '3092cf02-21cf-4611-81df-ab13bf3cbe74', null), --Shop 4, Nước ép bưởi
    ('63f21321-d854-4ecc-8e27-051ae336a98c', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', 'ad00b943-2dc0-45ea-a3e1-b6a9d25e3910', null), --Shop 4, Trà sữa truyền thống
    ('08dc47f4-a002-4d63-a6b5-34d40111acbf', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '8ef69ebc-bc12-4644-afbb-c1f81041a913', null), --Shop 4, Nước ép táo
    ('a5cb52e4-c343-4d31-9022-aec5f15f6d27', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', 'ac67e0b3-4a28-4f49-a36a-c3e4874ddf07', null), --Shop 4, Trà sữa choco
    ('46a6d731-1a60-4cf3-9222-c06d11f87ad9', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', '71b04e75-9a64-4c8b-a878-e8fefbd61107', null), --Shop 4, Sinh tố bơ
    ('47a2fa8d-834f-476a-b5ec-91646c8f47af', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '6547f918-2f7e-4977-b0ff-08c1c250009b', null), --Shop 5, Olong sữa kem trứng nướng
    ('79bf08f6-9b56-44be-b87b-ca079286c08b', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', 'a25a3107-b1b9-4dec-9f80-0fbe5abe7184', null), --Shop 5, Cà phê sữa
    ('510a1ff2-4422-4472-9076-763bb2339a65', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', 'aaaa7587-36b4-4cb2-8385-13e4bad3e47e', null), --Shop 5, Đá xay matcha
    ('b730ce3f-d943-451a-ad6f-c440b8808340', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', 'c4bd1439-a59f-4852-bad6-302ca47270a3', null), --Shop 5, Sinh tố dâu
    ('fe86cf0a-710e-476e-9291-75fa807b7398', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '31ffd135-9373-42c3-8366-37352fd1494c', null), --Shop 5, Đá xay việt quốc
    ('5e782293-2138-49d9-be7a-e8da7df9428a', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '248b5b0b-3e36-41e3-af1e-4cafe9f1f279', null), --Shop 5, Sữa tươi trân châu đường đen
    ('801e515c-704b-4d12-af0f-21fd9fe0677f', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', 'bfc1dc18-efdc-42c0-ab76-7aecfb04ace0', null), --Shop 5, Cà phê đen
    ('0db0eaf8-f624-4ada-9fa8-5345fc0d283d', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '0dbcd8c3-993e-4ad6-bd85-7bf46896ee11', null), --Shop 5, Nước ép thơm
    ('9d8f3119-596f-4760-91ae-c942dee38e41', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '33191348-8b56-4306-853f-a32adadb4b15', null), --Shop 5, Hồng trà mật ông
    ('34168244-cdd2-4d62-ad9c-032807eb0307', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '980cd6dc-6f89-498e-bf18-a472caa7385c', null), --Shop 5, Trà lài vải
    ('47621a56-327e-4590-bece-6d5912853fdd', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '3092cf02-21cf-4611-81df-ab13bf3cbe74', null), --Shop 5, Nước ép bưởi
    ('d617c8d8-ef1d-4591-a801-27e81aeeb3cd', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', 'ad00b943-2dc0-45ea-a3e1-b6a9d25e3910', null), --Shop 5, Trà sữa truyền thống
    ('f4196c30-b76c-4570-878e-22199a0e3afc', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '8ef69ebc-bc12-4644-afbb-c1f81041a913', null), --Shop 5, Nước ép táo
    ('7721c513-a6bd-4b3e-8770-26e56e208695', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', 'ac67e0b3-4a28-4f49-a36a-c3e4874ddf07', null), --Shop 5, Trà sữa choco
    ('f8d95bf1-302f-4eca-a812-039e94e6bdaf', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', '71b04e75-9a64-4c8b-a878-e8fefbd61107', null), --Shop 5, Sinh tố bơ
    ('584f4a07-219b-4c13-a399-cefd6aa83b6f', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '2463d13e-b180-48f7-ab4e-05c84e4b9982'), --Shop 1, Cần câu mèo
    ('280d2381-579b-4719-b43f-c0ee2d587931', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, 'c2df00fc-bd9c-4cce-8ee6-0e53c8e0926e'), --Shop 1, Chuột điều khiển từ xa
    ('562cb4dc-f4d1-4985-82bf-bacc679444d7', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '430201bf-306c-4a4a-a065-15a172961e1a'), --Shop 1, Hạt dinh dưỡng nhỏ
    ('03369a51-39ec-4ae9-be3b-755998c19740', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '253e41d6-b501-447d-a0eb-2ea829c0c139'), --Shop 1, Súp thưởng
    ('a3e99400-b4a1-4be8-8997-efc6940cde58', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, 'dc156463-1c39-4235-861f-407d272c1693'), --Shop 1, Chuột nhồi bông
    ('d68b3e0c-6d39-4976-8db5-550e05c3798c', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '96d10b2d-dcef-4a29-ae71-5904edc4d3ed'), --Shop 1, Xúc xích thưởng
    ('2afb64f0-abf9-4ae8-92ad-1d6c45940c69', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '3eb4a0a5-02df-4d71-a451-6299937edb25'), --Shop 1, Pate cá
    ('1cb75f97-f3ea-4522-a166-e773a704906f', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '87eeff72-4dba-46f6-8a4c-79ac60afc1ca'), --Shop 1, Cá nhồi bông
    ('dba748a8-8fc4-427c-8e57-bcde79cd67cc', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, 'e6ce648e-6ac6-45ca-8b7b-8571bdbba138'), --Shop 1, Snack thưởng
    ('7566a876-d8df-42af-9a4d-afe171cb2b21', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '7d0f7183-c3b8-4741-bc9f-8d749283a5ac'), --Shop 1, Bàn cào móng
    ('c7e0f35f-efe3-4643-b2f1-b2da5db98d02', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '98c51b18-da21-4f21-9335-9a733f67ff83'), --Shop 1, Đèn laze
    ('c475da37-266c-4a1b-87d9-daaead8f519e', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, 'bf4cb4b0-8146-4aad-b82c-c3ded73fbff9'), --Shop 1, Hạt dinh dưỡng lớn
    ('4a175add-683d-47db-82bc-cd5d2165f4a4', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, 'd562ecae-f5b3-4ef8-ba74-dea1445b2a0b'), --Shop 1, Gậy lông vũ
    ('ea16e015-d42f-4f57-b6e4-93e7d38d6f00', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, 'f0a54c6e-994b-4380-8851-efa124900e92'), --Shop 1, Pate gà
    ('e0e1150f-44ba-4568-81f5-824d572e0d05', 1, 'ea50c8f8-ac2b-425d-8cda-b67bfb65cbcc', null, '48e97a18-e7fa-48f4-a70e-f5a8d8854c0f'), --Shop 1, Cỏ mèo
    ('b68f3dd9-da2e-40ef-8edb-6c39d38e9e39', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '2463d13e-b180-48f7-ab4e-05c84e4b9982'), --Shop 2, Cần câu mèo
    ('10dccb73-bb84-4050-bca2-6a1f6e9ce3fb', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, 'c2df00fc-bd9c-4cce-8ee6-0e53c8e0926e'), --Shop 2, Chuột điều khiển từ xa
    ('60c712b5-a06a-49f8-b0e5-e69838c1a51c', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '430201bf-306c-4a4a-a065-15a172961e1a'), --Shop 2, Hạt dinh dưỡng nhỏ
    ('90939076-b65a-442f-a162-185f54e77a22', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '253e41d6-b501-447d-a0eb-2ea829c0c139'), --Shop 2, Súp thưởng
    ('a1b4906d-2df9-4080-bd20-c84bbd5d8502', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, 'dc156463-1c39-4235-861f-407d272c1693'), --Shop 2, Chuột nhồi bông
    ('f4cd7985-f8a8-42e5-95c4-2dee70264f08', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '96d10b2d-dcef-4a29-ae71-5904edc4d3ed'), --Shop 2, Xúc xích thưởng
    ('f19d3655-50e5-4ff5-8ee8-5bd320bc3024', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '3eb4a0a5-02df-4d71-a451-6299937edb25'), --Shop 2, Pate cá
    ('27d68c6e-7252-4404-a90e-c5396bb0ab55', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '87eeff72-4dba-46f6-8a4c-79ac60afc1ca'), --Shop 2, Cá nhồi bông
    ('8568f03a-0591-4b3b-a431-97205d843c85', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, 'e6ce648e-6ac6-45ca-8b7b-8571bdbba138'), --Shop 2, Snack thưởng
    ('2c9621da-8bf0-4b05-bda1-c433f8b768a8', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '7d0f7183-c3b8-4741-bc9f-8d749283a5ac'), --Shop 2, Bàn cào móng
    ('63b0167d-4059-4d62-a2a9-76e5d9ae79a0', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '98c51b18-da21-4f21-9335-9a733f67ff83'), --Shop 2, Đèn laze
    ('b8fd921a-b38d-482c-a680-85fbb82d98dc', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, 'bf4cb4b0-8146-4aad-b82c-c3ded73fbff9'), --Shop 2, Hạt dinh dưỡng lớn
    ('7915fa63-30df-41d9-bffd-4217471bb251', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, 'd562ecae-f5b3-4ef8-ba74-dea1445b2a0b'), --Shop 2, Gậy lông vũ
    ('a05b47f3-e94a-408a-9c53-525d95831620', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, 'f0a54c6e-994b-4380-8851-efa124900e92'), --Shop 2, Pate gà
    ('bff22ba7-4650-440f-841f-3672aaca0ab5', 1, 'f9d87ddc-c7ea-4178-ba3b-d30efa6f426c', null, '48e97a18-e7fa-48f4-a70e-f5a8d8854c0f'), --Shop 2, Cỏ mèo
    ('d81b9914-3ca7-4118-a1dc-00504a925cbc', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '2463d13e-b180-48f7-ab4e-05c84e4b9982'), --Shop 3, Cần câu mèo
    ('608f5101-68e7-4a44-bd38-ea4f76d7ee6a', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, 'c2df00fc-bd9c-4cce-8ee6-0e53c8e0926e'), --Shop 3, Chuột điều khiển từ xa
    ('d69163d1-d645-4545-9ce3-a9dd6657f02b', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '430201bf-306c-4a4a-a065-15a172961e1a'), --Shop 3, Hạt dinh dưỡng nhỏ
    ('b472b7fa-a410-4982-b8e3-628f169fb8d8', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '253e41d6-b501-447d-a0eb-2ea829c0c139'), --Shop 3, Súp thưởng
    ('ae9b579c-d0c2-48dd-90d0-df2e0b0ac436', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, 'dc156463-1c39-4235-861f-407d272c1693'), --Shop 3, Chuột nhồi bông
    ('7cf38e51-2fef-4479-8afc-84f69e68e369', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '96d10b2d-dcef-4a29-ae71-5904edc4d3ed'), --Shop 3, Xúc xích thưởng
    ('94401601-20f6-40cf-94e8-505df05d4c9f', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '3eb4a0a5-02df-4d71-a451-6299937edb25'), --Shop 3, Pate cá
    ('f73d53f9-9c8e-4421-ad06-8551f42f2536', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '87eeff72-4dba-46f6-8a4c-79ac60afc1ca'), --Shop 3, Cá nhồi bông
    ('0c1f6e88-53cb-4dde-9404-40a3630a332c', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, 'e6ce648e-6ac6-45ca-8b7b-8571bdbba138'), --Shop 3, Snack thưởng
    ('6de8f324-bf59-4170-bf3d-94c067d9a1f4', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '7d0f7183-c3b8-4741-bc9f-8d749283a5ac'), --Shop 3, Bàn cào móng
    ('06ca74ad-decd-4cb1-a03c-74229b288fd4', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '98c51b18-da21-4f21-9335-9a733f67ff83'), --Shop 3, Đèn laze
    ('37920a41-f184-4b45-a2bb-30735618b157', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, 'bf4cb4b0-8146-4aad-b82c-c3ded73fbff9'), --Shop 3, Hạt dinh dưỡng lớn
    ('09508ad8-4f53-4f17-ab0e-7278aedeeabc', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, 'd562ecae-f5b3-4ef8-ba74-dea1445b2a0b'), --Shop 3, Gậy lông vũ
    ('dec3e1ff-58c8-4049-b882-44370ff68364', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, 'f0a54c6e-994b-4380-8851-efa124900e92'), --Shop 3, Pate gà
    ('d4ce0e00-7715-441e-b214-36739fcd2c93', 1, '9c305019-b38f-431a-835f-7b29d4351bc7', null, '48e97a18-e7fa-48f4-a70e-f5a8d8854c0f'), --Shop 3, Cỏ mèo
    ('b95cea8d-d241-4f49-9646-bcf65b483007', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '2463d13e-b180-48f7-ab4e-05c84e4b9982'), --Shop 4, Cần câu mèo
    ('d5d15fba-04f7-495b-8061-c32acf5265bb', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, 'c2df00fc-bd9c-4cce-8ee6-0e53c8e0926e'), --Shop 4, Chuột điều khiển từ xa
    ('27f89e2a-a32e-4f0c-a3d1-33c4b59edfad', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '430201bf-306c-4a4a-a065-15a172961e1a'), --Shop 4, Hạt dinh dưỡng nhỏ
    ('f1548f24-434a-4ca4-be40-38ec36056499', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '253e41d6-b501-447d-a0eb-2ea829c0c139'), --Shop 4, Súp thưởng
    ('c9f64632-143b-4828-97fe-8fb5d3e445f1', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, 'dc156463-1c39-4235-861f-407d272c1693'), --Shop 4, Chuột nhồi bông
    ('330fbbf9-91f4-4dbc-b542-bca245cd901f', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '96d10b2d-dcef-4a29-ae71-5904edc4d3ed'), --Shop 4, Xúc xích thưởng
    ('7b7c2ae7-f4e3-4a6b-9ae2-fd1f60b3779a', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '3eb4a0a5-02df-4d71-a451-6299937edb25'), --Shop 4, Pate cá
    ('03cf8950-6758-4d16-a79f-f29be0215678', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '87eeff72-4dba-46f6-8a4c-79ac60afc1ca'), --Shop 4, Cá nhồi bông
    ('929032c9-eda8-4769-a813-c35e3e4270e4', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, 'e6ce648e-6ac6-45ca-8b7b-8571bdbba138'), --Shop 4, Snack thưởng
    ('1c1034fa-aa66-46d1-90bc-4e195ee183d3', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '7d0f7183-c3b8-4741-bc9f-8d749283a5ac'), --Shop 4, Bàn cào móng
    ('8e0c4c22-98f3-4e60-b331-01e2e148a150', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '98c51b18-da21-4f21-9335-9a733f67ff83'), --Shop 4, Đèn laze
    ('5c167160-df3a-4394-8768-1fc12b538c78', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, 'bf4cb4b0-8146-4aad-b82c-c3ded73fbff9'), --Shop 4, Hạt dinh dưỡng lớn
    ('0944a9cd-0e6f-451a-a5cb-4d300483f381', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, 'd562ecae-f5b3-4ef8-ba74-dea1445b2a0b'), --Shop 4, Gậy lông vũ
    ('5a2d02e7-73e5-49ae-9716-6c08b65b5e1c', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, 'f0a54c6e-994b-4380-8851-efa124900e92'), --Shop 4, Pate gà
    ('b82977af-504b-4f59-9fee-7f99a8b34ab9', 1, '4ff4a000-9b2a-4409-92c5-f9cf01947609', null, '48e97a18-e7fa-48f4-a70e-f5a8d8854c0f'), --Shop 4, Cỏ mèo
    ('1583480a-89e8-4496-8614-83e60174059c', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '2463d13e-b180-48f7-ab4e-05c84e4b9982'), --Shop 5, Cần câu mèo
    ('9eea64ef-c014-4d58-99a7-3e081a50bd11', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, 'c2df00fc-bd9c-4cce-8ee6-0e53c8e0926e'), --Shop 5, Chuột điều khiển từ xa
    ('b4040bb4-cb33-47a1-9fe4-686dbd08d2c5', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '430201bf-306c-4a4a-a065-15a172961e1a'), --Shop 5, Hạt dinh dưỡng nhỏ
    ('8afeb765-4019-45d3-b2f7-b6ed3174d662', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '253e41d6-b501-447d-a0eb-2ea829c0c139'), --Shop 5, Súp thưởng
    ('59687569-a27e-47b5-86b2-98be91ee4a49', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, 'dc156463-1c39-4235-861f-407d272c1693'), --Shop 5, Chuột nhồi bông
    ('04c4dda1-c82b-446e-b07c-79dbe5f93685', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '96d10b2d-dcef-4a29-ae71-5904edc4d3ed'), --Shop 5, Xúc xích thưởng
    ('ec21c87e-a478-4d74-b59b-4c763fed65ef', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '3eb4a0a5-02df-4d71-a451-6299937edb25'), --Shop 5, Pate cá
    ('fd86003b-a1bb-4a15-b438-3b2c14131a24', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '87eeff72-4dba-46f6-8a4c-79ac60afc1ca'), --Shop 5, Cá nhồi bông
    ('0dc27ef9-f4a3-485d-b2c7-286694b7c39a', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, 'e6ce648e-6ac6-45ca-8b7b-8571bdbba138'), --Shop 5, Snack thưởng
    ('f0901ef3-58d7-4a11-a9a8-ae6e4635857f', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '7d0f7183-c3b8-4741-bc9f-8d749283a5ac'), --Shop 5, Bàn cào móng
    ('e78ecc07-f8e3-4e26-b3f4-503ecda4962c', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '98c51b18-da21-4f21-9335-9a733f67ff83'), --Shop 5, Đèn laze
    ('8fcde56a-d154-4ef2-80ed-bdcf306d0ec2', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, 'bf4cb4b0-8146-4aad-b82c-c3ded73fbff9'), --Shop 5, Hạt dinh dưỡng lớn
    ('cfcb6389-f825-49ed-8e28-562a10b330ec', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, 'd562ecae-f5b3-4ef8-ba74-dea1445b2a0b'), --Shop 5, Gậy lông vũ
    ('367ec173-9652-4339-bd58-efd79da13e9f', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, 'f0a54c6e-994b-4380-8851-efa124900e92'), --Shop 5, Pate gà
    ('66abed9d-6dcc-48da-8eba-5395d42b7488', 1, 'e54cb065-8ef4-4041-8822-e2ecf294c281', null, '48e97a18-e7fa-48f4-a70e-f5a8d8854c0f') --Shop 5, Cỏ mèo
	GO




