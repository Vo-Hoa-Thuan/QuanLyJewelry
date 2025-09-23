USE [master]
GO
/****** Object:  Database [db_Jewelry]    Script Date: 23/09/2025 11:46:06 SA ******/
CREATE DATABASE [db_Jewelry]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_Jewelry', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.VOHOATHUAN1\MSSQL\DATA\db_Jewelry.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_Jewelry_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.VOHOATHUAN1\MSSQL\DATA\db_Jewelry_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_Jewelry] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_Jewelry].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_Jewelry] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_Jewelry] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_Jewelry] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_Jewelry] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_Jewelry] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_Jewelry] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_Jewelry] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_Jewelry] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_Jewelry] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_Jewelry] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_Jewelry] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_Jewelry] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_Jewelry] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_Jewelry] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_Jewelry] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_Jewelry] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_Jewelry] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_Jewelry] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_Jewelry] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_Jewelry] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_Jewelry] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_Jewelry] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_Jewelry] SET RECOVERY FULL 
GO
ALTER DATABASE [db_Jewelry] SET  MULTI_USER 
GO
ALTER DATABASE [db_Jewelry] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_Jewelry] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_Jewelry] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_Jewelry] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_Jewelry] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_Jewelry] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_Jewelry', N'ON'
GO
ALTER DATABASE [db_Jewelry] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_Jewelry] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_Jewelry]
GO
/****** Object:  Table [dbo].[CHITIETGIAODICH]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETGIAODICH](
	[MaGD] [bigint] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGD] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIAODICH]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAODICH](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaGD]  AS ('GD'+right('000000'+CONVERT([varchar](6),[ID]),(6))) PERSISTED,
	[LoaiGD] [nvarchar](20) NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[NgayGD] [datetime] NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIAVANG]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAVANG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ngay] [date] NULL,
	[LoaiVang] [nvarchar](50) NOT NULL,
	[GiaMua] [decimal](18, 2) NOT NULL,
	[GiaBan] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang]  AS ('KH'+right('00000'+CONVERT([varchar](5),[ID]),(5))) PERSISTED,
	[HoTen] [nvarchar](50) NOT NULL,
	[SoDienThoai] [varchar](15) NOT NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[NgayVao] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIHANG]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIHANG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiHang]  AS ('LH'+right('000'+CONVERT([varchar](3),[ID]),(3))) PERSISTED,
	[TenLoaiHang] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNhaCungCap]  AS ('NCC'+right('00000'+CONVERT([varchar](5),[ID]),(5))) PERSISTED,
	[TenNhaCungCap] [nvarchar](100) NOT NULL,
	[SoDienThoai] [varchar](15) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[Email] [varchar](50) NULL,
	[NguoiDaiDien] [nvarchar](50) NULL,
	[NgayTao] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien]  AS ('NV'+right('00000'+CONVERT([varchar](5),[ID]),(5))) PERSISTED,
	[HoTen] [nvarchar](50) NOT NULL,
	[SoDienThoai] [varchar](15) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CCCD] [varchar](15) NOT NULL,
	[NgayVao] [date] NOT NULL,
	[MaQuyen] [int] NOT NULL,
	[MatKhau] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaQuyen]  AS ('Q'+right('000'+CONVERT([varchar](3),[ID]),(3))) PERSISTED,
	[TenQuyen] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 23/09/2025 11:46:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham]  AS ('SP'+right('00000'+CONVERT([varchar](5),[ID]),(5))) PERSISTED,
	[TenSanPham] [nvarchar](255) NOT NULL,
	[MaLoaiHang] [int] NOT NULL,
	[MoTa] [nvarchar](500) NULL,
	[GiaBan] [decimal](18, 2) NULL,
	[HinhAnh] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (1, 156, 2, CAST(11970000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (2, 151, 2, CAST(795000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (3, 157, 2, CAST(17858000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (4, 174, 2, CAST(895000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (5, 158, 2, CAST(4524000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (5, 177, 7, CAST(9996000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (6, 221, 2, CAST(950000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (7, 209, 2, CAST(5862000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (7, 220, 5, CAST(1890000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (7, 240, 2, CAST(1450000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (8, 155, 22, CAST(745000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (8, 276, 2, CAST(12800000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (8, 285, 5, CAST(420000000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (9, 189, 2, CAST(20091000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (9, 285, 22, CAST(420000000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (10, 189, 2, CAST(20091000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (11, 285, 2, CAST(420000000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (12, 186, 2, CAST(5524000.00 AS Decimal(18, 2)))
INSERT [dbo].[CHITIETGIAODICH] ([MaGD], [MaSanPham], [SoLuong], [DonGia]) VALUES (13, 160, 2, CAST(765000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[GIAODICH] ON 

INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (1, N'BAN_RA', 3, 2, CAST(N'2025-09-14T01:23:43.403' AS DateTime), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (2, N'MUA_VAO', 1, 2, CAST(N'2025-09-14T01:29:21.637' AS DateTime), CAST(1590000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (3, N'BAN_RA', 1, 2, CAST(N'2025-09-14T01:40:23.437' AS DateTime), CAST(35716000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (4, N'MUA_VAO', 1, 2, CAST(N'2025-09-14T01:44:11.993' AS DateTime), CAST(1790000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (5, N'BAN_RA', 5, 2, CAST(N'2025-09-14T01:52:22.100' AS DateTime), CAST(79020000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (6, N'MUA_VAO', 3, 2, CAST(N'2025-09-14T15:43:44.127' AS DateTime), CAST(1900000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (7, N'MUA_VAO', 1, 2, CAST(N'2025-09-15T08:29:45.200' AS DateTime), CAST(24074000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (8, N'MUA_VAO', 6, 2, CAST(N'2025-09-23T01:35:46.560' AS DateTime), CAST(2141990000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (9, N'BAN_RA', 6, 2, CAST(N'2025-09-23T01:40:00.173' AS DateTime), CAST(9280182000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (10, N'BAN_RA', 3, 2, CAST(N'2025-09-23T01:45:52.010' AS DateTime), CAST(40182000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (11, N'BAN_RA', 3, 2, CAST(N'2025-09-23T10:18:03.930' AS DateTime), CAST(840000000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (12, N'BAN_RA', 5, 2, CAST(N'2025-09-23T10:22:39.770' AS DateTime), CAST(11048000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAODICH] ([ID], [LoaiGD], [MaKhachHang], [MaNhanVien], [NgayGD], [TongTien]) VALUES (13, N'BAN_RA', 2, 6, CAST(N'2025-09-23T11:16:55.447' AS DateTime), CAST(1530000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[GIAODICH] OFF
GO
SET IDENTITY_INSERT [dbo].[GIAVANG] ON 

INSERT [dbo].[GIAVANG] ([ID], [Ngay], [LoaiVang], [GiaMua], [GiaBan]) VALUES (1, CAST(N'2025-09-03' AS Date), N'Vàng 9999 (24K)', CAST(7100000.00 AS Decimal(18, 2)), CAST(7200000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAVANG] ([ID], [Ngay], [LoaiVang], [GiaMua], [GiaBan]) VALUES (2, CAST(N'2025-09-03' AS Date), N'Vàng 18K', CAST(5300000.00 AS Decimal(18, 2)), CAST(5400000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAVANG] ([ID], [Ngay], [LoaiVang], [GiaMua], [GiaBan]) VALUES (3, CAST(N'2025-09-03' AS Date), N'Vàng 14K', CAST(4100000.00 AS Decimal(18, 2)), CAST(4200000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAVANG] ([ID], [Ngay], [LoaiVang], [GiaMua], [GiaBan]) VALUES (4, CAST(N'2025-09-03' AS Date), N'Vàng 10K', CAST(3000000.00 AS Decimal(18, 2)), CAST(3100000.00 AS Decimal(18, 2)))
INSERT [dbo].[GIAVANG] ([ID], [Ngay], [LoaiVang], [GiaMua], [GiaBan]) VALUES (5, CAST(N'2025-09-03' AS Date), N'Bạc 925', CAST(60000.00 AS Decimal(18, 2)), CAST(80000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[GIAVANG] OFF
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([ID], [HoTen], [SoDienThoai], [Email], [DiaChi], [NgayVao]) VALUES (1, N'Nguyễn Thị Hoa', N'0911222333', N'hoa.nguyen@example.com', N'123 Lê Lợi, Quận 1, TP.HCM', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[KHACHHANG] ([ID], [HoTen], [SoDienThoai], [Email], [DiaChi], [NgayVao]) VALUES (2, N'Trần Văn Minh', N'0988777666', N'minh.tran@example.com', N'45 Nguyễn Trãi, Quận 5, TP.HCM', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[KHACHHANG] ([ID], [HoTen], [SoDienThoai], [Email], [DiaChi], [NgayVao]) VALUES (3, N'Nguyễn Bùi Huỳnh Nhi', N'0933444555', N'thu.le@example.com', N'78 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[KHACHHANG] ([ID], [HoTen], [SoDienThoai], [Email], [DiaChi], [NgayVao]) VALUES (4, N'Phạm Văn Nam', N'0909555666', N'nam.pham@example.com', N'12 Cách Mạng Tháng 8, Quận 10, TP.HCM', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[KHACHHANG] ([ID], [HoTen], [SoDienThoai], [Email], [DiaChi], [NgayVao]) VALUES (5, N'Hoàng Thị Lan', N'0977666555', N'lan.hoang@example.com', N'56 Võ Thị Sáu, Quận 3, TP.HCM', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[KHACHHANG] ([ID], [HoTen], [SoDienThoai], [Email], [DiaChi], [NgayVao]) VALUES (6, N'Võ Hòa Thuận', N'0867962672', N'vohoathuan2828@gmail.com', N'Thành Phố Hồ Chí Minh', CAST(N'2025-09-14' AS Date))
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAIHANG] ON 

INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (1, N'Nhẫn vàng')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (2, N'Kim cương')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (3, N'Trang sức kim cương')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (4, N'Phụ kiện khác')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (5, N'Đồng hồ')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (6, N'Nhẫn bạc')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (7, N'Dây chuyền vàng')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (8, N'Dây chuyền bạc')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (9, N'Lắc tay vàng')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (10, N'Lắc tay bạc')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (11, N'Bông tai')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (12, N'Đá quý')
INSERT [dbo].[LOAIHANG] ([ID], [TenLoaiHang]) VALUES (13, N'Ngọc trai')
SET IDENTITY_INSERT [dbo].[LOAIHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] ON 

INSERT [dbo].[NHACUNGCAP] ([ID], [TenNhaCungCap], [SoDienThoai], [DiaChi], [Email], [NguoiDaiDien], [NgayTao]) VALUES (1, N'Công ty Vàng Bạc Đá Quý SJC', N'02838221111', N'418-420 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', N'contact@sjc.com.vn', N'Võ Hòa Thuận', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[NHACUNGCAP] ([ID], [TenNhaCungCap], [SoDienThoai], [DiaChi], [Email], [NguoiDaiDien], [NgayTao]) VALUES (2, N'Công ty PNJ', N'02839951703', N'170E Phan Đăng Lưu, Quận Phú Nhuận, TP.HCM', N'info@pnj.com.vn', N'Nguyễn Thị Hồng', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[NHACUNGCAP] ([ID], [TenNhaCungCap], [SoDienThoai], [DiaChi], [Email], [NguoiDaiDien], [NgayTao]) VALUES (3, N'Công ty DOJI', N'02433559999', N'5 Lê Duẩn, Quận Ba Đình, Hà Nội', N'support@doji.vn', N'Đỗ Minh Quân', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[NHACUNGCAP] ([ID], [TenNhaCungCap], [SoDienThoai], [DiaChi], [Email], [NguoiDaiDien], [NgayTao]) VALUES (4, N'Công ty Bảo Tín Minh Châu', N'02439351885', N'29 Trần Nhân Tông, Quận Hai Bà Trưng, Hà Nội', N'btmc@btmc.vn', N'Phạm Thị Mai', CAST(N'2025-09-03' AS Date))
INSERT [dbo].[NHACUNGCAP] ([ID], [TenNhaCungCap], [SoDienThoai], [DiaChi], [Email], [NguoiDaiDien], [NgayTao]) VALUES (7, N'Công ty Vàng Mi Hồng', N'02838960357', N'306 Bùi Hữu Nghĩa, Quận Bình Thạnh, TP.HCM', N'contact@mihong.vn', N'Hoàng Văn Long', CAST(N'2025-09-06' AS Date))
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] OFF
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([ID], [HoTen], [SoDienThoai], [Email], [CCCD], [NgayVao], [MaQuyen], [MatKhau], [DiaChi]) VALUES (2, N'Võ Hòa Thuận', N'0909123456', N'an.nguyen@pnj.com', N'079123456789', CAST(N'2025-09-03' AS Date), 1, N'a0PMvLkcF3pV+P5doA7taIcsEtFRYwzXyQyzLrYbbjA=', N'25 Lê Lợi, Q.1, TP.HCM')
INSERT [dbo].[NHANVIEN] ([ID], [HoTen], [SoDienThoai], [Email], [CCCD], [NgayVao], [MaQuyen], [MatKhau], [DiaChi]) VALUES (3, N'Trần Thị Bình', N'0912345678', N'binh.tran@pnj.com', N'079223456789', CAST(N'2025-09-03' AS Date), 2, N'a0PMvLkcF3pV+P5doA7taIcsEtFRYwzXyQyzLrYbbjA=', N'120 Nguyễn Trãi, Q.5, TP.HCM')
INSERT [dbo].[NHANVIEN] ([ID], [HoTen], [SoDienThoai], [Email], [CCCD], [NgayVao], [MaQuyen], [MatKhau], [DiaChi]) VALUES (4, N'Lê Hoàng Nam', N'0923456789', N'nam.le@pnj.com', N'079323456789', CAST(N'2025-09-03' AS Date), 2, N'0923456789', N'88 Hai Bà Trưng, Q.3, TP.HCM')
INSERT [dbo].[NHANVIEN] ([ID], [HoTen], [SoDienThoai], [Email], [CCCD], [NgayVao], [MaQuyen], [MatKhau], [DiaChi]) VALUES (5, N'Phạm Minh Châu', N'0934567890', N'chau.pham@pnj.com', N'079423456789', CAST(N'2025-09-03' AS Date), 3, N'0934567890', N'15 Nguyễn Huệ, Q.1, TP.HCM')
INSERT [dbo].[NHANVIEN] ([ID], [HoTen], [SoDienThoai], [Email], [CCCD], [NgayVao], [MaQuyen], [MatKhau], [DiaChi]) VALUES (6, N'Võ Hồng Quân', N'0945678901', N'quan.vo@pnj.com', N'079523456789', CAST(N'2025-09-03' AS Date), 1, N'0945678901', N'22 Lý Thường Kiệt, Q.Tân Bình, TP.HCM')
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
GO
SET IDENTITY_INSERT [dbo].[QUYEN] ON 

INSERT [dbo].[QUYEN] ([ID], [TenQuyen]) VALUES (1, N'Quản trị viên')
INSERT [dbo].[QUYEN] ([ID], [TenQuyen]) VALUES (2, N'Quản lý')
INSERT [dbo].[QUYEN] ([ID], [TenQuyen]) VALUES (3, N'Nhân viên')
INSERT [dbo].[QUYEN] ([ID], [TenQuyen]) VALUES (4, N'Khách hàng')
SET IDENTITY_INSERT [dbo].[QUYEN] OFF
GO
SET IDENTITY_INSERT [dbo].[SANPHAM] ON 

INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (138, N'Lắc tay Vàng Trắng 10K Đính đá ECZ', 9, N'Đang được cập nhật', CAST(3000000.00 AS Decimal(18, 2)), N'D:\Sourcecode\Quanlydocongnghe\SaleApp\bin\Debug\net6.0-windows\Hinhanh\bangles_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (139, N'Lắc tay Vàng Trắng 10K Đính đá synthetic', 9, N'Đang được cập nhật', CAST(2300000.00 AS Decimal(18, 2)), N'D:\Sourcecode\QuanLyJewelry\QuanLyJewelry\bin\Debug\net6.0-windows\Hinhanh\bangles_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (140, N'Lắc tay Bạc đính đá HELLO KITTY ZTZTH000005', 10, N'Đang được cập nhật', CAST(2000000.00 AS Decimal(18, 2)), N'D:\Sourcecode\Quanlydocongnghe\SaleApp\bin\Debug\net6.0-windows\Hinhanh\bangles_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (141, N'Lắc tay Bạc đính đá HELLO KITTY ZTZTH000004', 10, N'Đang được cập nhật', CAST(1999000.00 AS Decimal(18, 2)), N'bangles_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (142, N'Lắc tay Bạc đính đá HELLO KITTY ZTZTH000004', 10, N'Đang được cập nhật', CAST(1985000.00 AS Decimal(18, 2)), N'bangles_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (143, N'Lắc tay Bạc đính đá STYLE By FTL Lucky Me ZTMXW000005', 10, N'Đang được cập nhật', CAST(795000.00 AS Decimal(18, 2)), N'bangles_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (144, N'Lắc tay Vàng 18K FTL 0000Y002816', 9, N'Đang được cập nhật', CAST(11845000.00 AS Decimal(18, 2)), N'bangles_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (145, N'Lắc tay bạc đính đá FTLSilver XMXMW060128', 10, N'Đang được cập nhật', CAST(1495000.00 AS Decimal(18, 2)), N'bangles_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (146, N'Lắc tay bạc đính đá FTLSilver XMXMW060143', 10, N'Đang được cập nhật', CAST(755000.00 AS Decimal(18, 2)), N'bangles_10.png\n')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (147, N'Lắc tay Bạc đính đá FTLSilver SLXMXMW060126', 10, N'Đang được cập nhật', CAST(1295000.00 AS Decimal(18, 2)), N'bangles_11.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (148, N'Lắc tay Bạc đính đá FTLSilver hình Hoa tuyết XMXMW060141', 10, N'Đang được cập nhật', CAST(1255000.00 AS Decimal(18, 2)), N'bangles_12.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (149, N'Lắc tay Vàng Trắng Ý 18K FTL 0000W001260', 9, N'Đang được cập nhật', CAST(5330000.00 AS Decimal(18, 2)), N'bangles_13.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (150, N'Lắc tay Vàng Ý 18K đính đá CZ FTL XM00Y000691', 9, N'Đang được cập nhật', CAST(11042000.00 AS Decimal(18, 2)), N'bangles_14.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (151, N'Lắc tay Bạc đính đá STYLE By FTL Feminine ZTZTW000009', 10, N'Đang được cập nhật', CAST(795000.00 AS Decimal(18, 2)), N'bangles_15.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (152, N'Lắc tay Vàng 18K FTL 0000Y060657', 9, N'Đang được cập nhật', CAST(31790000.00 AS Decimal(18, 2)), N'bangles_16.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (153, N'Lắc tay Bạc đính đá STYLE By FTL Feminine XMXMW060148', 10, N'Đang được cập nhật', CAST(645000.00 AS Decimal(18, 2)), N'bangles_17.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (154, N'Lắc tay Bạc đính đá STYLE By FTL Feminine XMXMW060146', 10, N'Đang được cập nhật', CAST(955000.00 AS Decimal(18, 2)), N'bangles_18.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (155, N'Lắc tay Bạc đính đá STYLE By FTL Sexy ZTZTW000007', 10, N'Đang được cập nhật', CAST(745000.00 AS Decimal(18, 2)), N'bangles_19.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (156, N'Lắc tay Kim cương Vàng Trắng 14K FTL DD00W000491', 10, N'Đang được cập nhật', CAST(11970000.00 AS Decimal(18, 2)), N'bangles_20.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (157, N'Dây cổ Vàng 14k đính đá Ruby', 7, N'Đang được cập nhật', CAST(17858000.00 AS Decimal(18, 2)), N'chain_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (158, N'Dây cổ Vàng Trắng 10k đính đá ECZ Style by FTL Sunlover Feminine', 7, N'Đang được cập nhật', CAST(4524000.00 AS Decimal(18, 2)), N'chain_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (159, N'Dây cổ Bạc đính đá Style by FTL cung Thiên Bình', 8, N'Đang được cập nhật', CAST(625500.00 AS Decimal(18, 2)), N'chain_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (160, N'Dây cổ Bạc đính đá Style by FTL Sunlover', 8, N'Đang được cập nhật', CAST(765000.00 AS Decimal(18, 2)), N'chain_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (161, N'Dây cổ Bạc đính đá CZ Style by FTL Unisex', 8, N'Đang được cập nhật', CAST(1196000.00 AS Decimal(18, 2)), N'chain_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (162, N'Dây cổ Bạc đính đá FTL Hello Kitty', 8, N'Đang được cập nhật', CAST(1095000.00 AS Decimal(18, 2)), N'chain_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (163, N'Dây cổ Bạc đính đá FTLSilver chữ Love', 8, N'Đang được cập nhật', CAST(555000.00 AS Decimal(18, 2)), N'chain_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (164, N'Dây cổ Bạc đính đá FTLSilver hình Hoa tuyết ', 8, N'Đang được cập nhật', CAST(795000.00 AS Decimal(18, 2)), N'chain_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (165, N'Dây cổ Vàng Trắng 14k đính đá Topaz FTL', 7, N'Đang được cập nhật', CAST(13387000.00 AS Decimal(18, 2)), N'chain_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (166, N'Dây cổ Kim cương Vàng Trắng 14k FTL chữ N', 3, N'Đang được cập nhật', CAST(12028000.00 AS Decimal(18, 2)), N'chain_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (167, N'Dây cổ Bạc Style by FTL cung Bảo Bình', 8, N'Đang được cập nhật', CAST(625500.00 AS Decimal(18, 2)), N'chain_11.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (168, N'Dây cổ Bạc Style by FTL Goddesses', 8, N'Đang được cập nhật', CAST(1465000.00 AS Decimal(18, 2)), N'chain_13.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (169, N'Dây cổ Bạc đính đá Style by FTL Edgy', 8, N'Đang được cập nhật', CAST(1045000.00 AS Decimal(18, 2)), N'chain_14.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (170, N'Dây cổ hợp kim cao cấp Style by FTL DNA', 4, N'Đang được cập nhật', CAST(1011500.00 AS Decimal(18, 2)), N'chain_15.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (171, N'Dây cổ hợp kim cao cấp Style by FTL Springlove', 4, N'Đang được cập nhật', CAST(822500.00 AS Decimal(18, 2)), N'chain_16.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (172, N'Dây cổ Bạc đính đá Style by FTL Sweet Spring', 8, N'Đang được cập nhật', CAST(836500.00 AS Decimal(18, 2)), N'chain_17.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (173, N'Dây cổ Bạc đính ngọc trai FTL style x Chou Chou', 8, N'Đang được cập nhật', CAST(976000.00 AS Decimal(18, 2)), N'chain_18.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (174, N'Dây cổ Bạc đính đá Style by FTL Barcode ', 8, N'Đang được cập nhật', CAST(895000.00 AS Decimal(18, 2)), N'chain_19.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (175, N'Dây cổ Bạc đính đá Style by FTL DNA Vol 3 Active', 8, N'Đang được cập nhật', CAST(1395000.00 AS Decimal(18, 2)), N'chain_20.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (176, N'Nhẫn Kim cương Vàng trắng 14K Disney', 3, N'Đang được cập nhật', CAST(6078800.00 AS Decimal(18, 2)), N'ring_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (177, N'Nhẫn Kim cương vàng 18K Disney', 3, N'Đang được cập nhật', CAST(9996000.00 AS Decimal(18, 2)), N'ring_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (178, N'Nhẫn Kim cương Vàng trắng 14K', 3, N'Đang được cập nhật', CAST(7554000.00 AS Decimal(18, 2)), N'ring_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (179, N'Nhẫn Kim cương Vàng 14K', 3, N'Đang được cập nhật', CAST(56000000.00 AS Decimal(18, 2)), N'ring_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (180, N'Nhẫn Kim cương Vàng trắng 14K Disney|FTL Cinderella DD00W003597', 3, N'Đang được cập nhật', CAST(12120000.00 AS Decimal(18, 2)), N'ring_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (181, N'Nhẫn Kim cương Vàng 14K Disney|FTL Cinderella DDDDH000560', 3, N'Đang được cập nhật', CAST(27088000.00 AS Decimal(18, 2)), N'ring_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (182, N'Nhẫn Vàng 10K Đính đá Synthetic FTL HELLO KITTY ZTZTH000001', 1, N'Đang được cập nhật', CAST(4023000.00 AS Decimal(18, 2)), N'ring_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (183, N'Nhẫn Vàng 10K Đính đá Synthetic FTL HELLO KITTY ZTMXH000015', 1, N'Đang được cập nhật', CAST(4070000.00 AS Decimal(18, 2)), N'ring_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (184, N'Nhẫn Vàng 10K Đính đá Synthetic FTL HELLO KITTY ZT00H000005', 1, N'Đang được cập nhật', CAST(2671000.00 AS Decimal(18, 2)), N'ring_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (185, N'Nhẫn Vàng 10K Đính đá ECZ FTL HELLO KITTY XM00H000238', 1, N'Đang được cập nhật', CAST(2964000.00 AS Decimal(18, 2)), N'ring_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (186, N'Nhẫn Vàng Trắng Ý 18K Đính đá ECZ FTL XMXMW004019', 1, N'Đang được cập nhật', CAST(5524000.00 AS Decimal(18, 2)), N'ring_11.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (187, N'Nhẫn Kim cương Vàng Trắng 14K Disney|FTL Cinderella DDDDW012827', 3, N'Đang được cập nhật', CAST(24226000.00 AS Decimal(18, 2)), N'ring_12.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (188, N'Nhẫn Kim cương Vàng 14K Disney|FTL Cinderella DDDDC001755', 3, N'Đang được cập nhật', CAST(22513000.00 AS Decimal(18, 2)), N'ring_13.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (189, N'Nhẫn Kim cương Vàng 14K Disney|FTL Snow White & the Seven Dwarfs DDDDH000535', 3, N'Đang được cập nhật', CAST(20091000.00 AS Decimal(18, 2)), N'ring_14.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (190, N'Nhẫn Kim cương Vàng Trắng 14K Disney|FTL Snow White & the Seven Dwarfs DDDDW012314', 3, N'Đang được cập nhật', CAST(20350000.00 AS Decimal(18, 2)), N'ring_15.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (191, N'Nhẫn Kim cương Vàng 14K FTL Niềm tin DDDDH000515', 3, N'Đang được cập nhật', CAST(49349000.00 AS Decimal(18, 2)), N'ring_16.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (192, N'Nhẫn Kim cương Vàng trắng 14K FTL DDDDW060574', 3, N'Đang được cập nhật', CAST(15969000.00 AS Decimal(18, 2)), N'ring_17.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (193, N'Nhẫn Kim cương Vàng trắng 14K FTL DDDDW060573', 3, N'Đang được cập nhật', CAST(14590000.00 AS Decimal(18, 2)), N'ring_18.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (194, N'Nhẫn Kim cương Vàng 14K FTL DDDDY060010', 3, N'Đang được cập nhật', CAST(9990000.00 AS Decimal(18, 2)), N'ring_19.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (195, N'Nhẫn Kim cương Vàng 14K FTL DDDDY060009', 3, N'Đang được cập nhật', CAST(15790000.00 AS Decimal(18, 2)), N'ring_20.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (196, N'Đồng hồ Orient Star Nam RE-AU0002S00B', 5, N'Đang được cập nhật', CAST(21700000.00 AS Decimal(18, 2)), N'watch_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (197, N'Đồng hồ Citizen Nam NH8400-87A', 5, N'Đang được cập nhật', CAST(9996000.00 AS Decimal(18, 2)), N'watch_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (198, N'Đồng hồ Citizen Nam AW1720-51E', 5, N'Đang được cập nhật', CAST(7890000.00 AS Decimal(18, 2)), N'watch_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (199, N'Đồng hồ Citizen Nam AN3690-56B', 5, N'Đang được cập nhật', CAST(11999000.00 AS Decimal(18, 2)), N'watch_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (200, N'Đồng hồ Citizen Nam NH8400-10A', 5, N'Đang được cập nhật', CAST(5985000.00 AS Decimal(18, 2)), N'watch_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (201, N'Đồng hồ Citizen Nữ EM1073-85Y', 5, N'Đang được cập nhật', CAST(13485000.00 AS Decimal(18, 2)), N'watch_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (202, N'Đồng hồ Orient Star Nam RE-AV0B09N00B', 5, N'Đang được cập nhật', CAST(29530000.00 AS Decimal(18, 2)), N'watch_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (203, N'Đồng hồ Orient Star Nam RE-AV0122L00B', 5, N'Đang được cập nhật', CAST(28440000.00 AS Decimal(18, 2)), N'watch_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (204, N'Đồng hồ Longines Master Nữ L2.128.4.97.6', 5, N'Đang được cập nhật', CAST(63250000.00 AS Decimal(18, 2)), N'watch_9.png ')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (205, N'Đồng Hồ Cặp Longines L4.755.4.11.6 và L4.209.4.11.6', 5, N'Đang được cập nhật', CAST(64688000.00 AS Decimal(18, 2)), N'watch_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (206, N'Đồng hồ Longines La Grande Nữ L4.209.4.81.6', 5, N'Đang được cập nhật', CAST(41688000.00 AS Decimal(18, 2)), N'watch_11.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (207, N'Đồng hồ Casio Nam EF-539D-1A2VDF', 5, N'Đang được cập nhật', CAST(4935000.00 AS Decimal(18, 2)), N'watch_12.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (208, N'Đồng hồ Longines HydroConquest Nam L3.781.3.98.9', 5, N'Đang được cập nhật', CAST(53188000.00 AS Decimal(18, 2)), N'watch_13.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (209, N'Đồng hồ Calvin Klein Nam 25200305', 5, N'Đang được cập nhật', CAST(5862000.00 AS Decimal(18, 2)), N'watch_14.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (210, N'Đồng hồ Calvin Klein Nữ 25000044', 5, N'Đang được cập nhật', CAST(7541000.00 AS Decimal(18, 2)), N'watch_15.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (211, N'Đồng Hồ Italia Lancaster Nam Automatic OLA0691', 5, N'Đang được cập nhật', CAST(7990000.00 AS Decimal(18, 2)), N'watch_16.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (212, N'Đồng Hồ Italia Lancaster Nam Chrono OLA0690MB/SS/BN', 5, N'Đang được cập nhật', CAST(3295000.00 AS Decimal(18, 2)), N'watch_17.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (213, N'Đồng Hồ Longines La Grande Nữ L4.209.2.12.8', 5, N'Đang được cập nhật', CAST(35796000.00 AS Decimal(18, 2)), N'watch_18.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (214, N'Đồng Hồ Longines Nam L2.919.4.92.0', 5, N'Đang được cập nhật', CAST(71875000.00 AS Decimal(18, 2)), N'watch_19.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (215, N'Ðồng Hồ Michael Kors Harlowe N? MK4708', 5, N'Đang được cập nhật', CAST(8200000.00 AS Decimal(18, 2)), N'watch_20.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (216, N'Nhẫn bạc đính đá CZ Style By FTL', 6, N'Đang được cập nhật', CAST(850000.00 AS Decimal(18, 2)), N'silver_ring_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (217, N'Nhẫn bạc nữ khắc hoa văn', 6, N'Đang được cập nhật', CAST(650000.00 AS Decimal(18, 2)), N'silver_ring_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (218, N'Nhẫn bạc đính ngọc trai nhỏ', 6, N'Đang được cập nhật', CAST(1250000.00 AS Decimal(18, 2)), N'silver_ring_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (219, N'Nhẫn bạc đôi khắc chữ Love', 6, N'Đang được cập nhật', CAST(1390000.00 AS Decimal(18, 2)), N'silver_ring_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (220, N'Nhẫn bạc đính đá Blue Topaz', 6, N'Đang được cập nhật', CAST(1890000.00 AS Decimal(18, 2)), N'silver_ring_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (221, N'Nhẫn bạc đính đá Synthetic FTL', 6, N'Đang được cập nhật', CAST(950000.00 AS Decimal(18, 2)), N'silver_ring_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (222, N'Nhẫn bạc nam khắc họa tiết mạnh mẽ', 6, N'Đang được cập nhật', CAST(1150000.00 AS Decimal(18, 2)), N'silver_ring_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (223, N'Nhẫn bạc nữ kiểu vương miện', 6, N'Đang được cập nhật', CAST(1350000.00 AS Decimal(18, 2)), N'silver_ring_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (224, N'Nhẫn bạc đính đá CZ hình trái tim', 6, N'Đang được cập nhật', CAST(990000.00 AS Decimal(18, 2)), N'silver_ring_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (225, N'Nhẫn bạc đính đá thạch anh tím', 6, N'Đang được cập nhật', CAST(1780000.00 AS Decimal(18, 2)), N'silver_ring_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (226, N'Dây chuyền bạc nữ mặt trái tim', 8, N'Đang được cập nhật', CAST(890000.00 AS Decimal(18, 2)), N'silver_chain_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (227, N'Dây chuyền bạc mặt ngọc trai', 8, N'Đang được cập nhật', CAST(1650000.00 AS Decimal(18, 2)), N'silver_chain_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (228, N'Dây chuyền bạc mặt chữ cái', 8, N'Đang được cập nhật', CAST(950000.00 AS Decimal(18, 2)), N'silver_chain_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (229, N'Dây chuyền bạc mặt hoa hồng', 8, N'Đang được cập nhật', CAST(1050000.00 AS Decimal(18, 2)), N'silver_chain_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (230, N'Dây chuyền bạc nữ đính đá CZ', 8, N'Đang được cập nhật', CAST(1280000.00 AS Decimal(18, 2)), N'silver_chain_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (231, N'Dây chuyền bạc nam khắc họa tiết', 8, N'Đang được cập nhật', CAST(1450000.00 AS Decimal(18, 2)), N'silver_chain_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (232, N'Dây chuyền bạc đôi khắc chữ Love', 8, N'Đang được cập nhật', CAST(1750000.00 AS Decimal(18, 2)), N'silver_chain_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (233, N'Dây chuyền bạc mặt đá thạch anh tím', 8, N'Đang được cập nhật', CAST(1920000.00 AS Decimal(18, 2)), N'silver_chain_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (234, N'Dây chuyền bạc nữ mặt bướm', 8, N'Đang được cập nhật', CAST(990000.00 AS Decimal(18, 2)), N'silver_chain_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (235, N'Dây chuyền bạc mặt hình giọt nước', 8, N'Đang được cập nhật', CAST(1250000.00 AS Decimal(18, 2)), N'silver_chain_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (236, N'Lắc tay bạc nữ đính đá CZ', 10, N'Đang được cập nhật', CAST(1190000.00 AS Decimal(18, 2)), N'silver_bangle_1.png')
GO
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (237, N'Lắc tay bạc charm trái tim', 10, N'Đang được cập nhật', CAST(950000.00 AS Decimal(18, 2)), N'silver_bangle_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (238, N'Lắc tay bạc nữ phong thủy đá thạch anh', 10, N'Đang được cập nhật', CAST(1890000.00 AS Decimal(18, 2)), N'silver_bangle_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (239, N'Lắc tay bạc bản nhỏ thanh mảnh', 10, N'Đang được cập nhật', CAST(790000.00 AS Decimal(18, 2)), N'silver_bangle_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (240, N'Lắc tay bạc đôi khắc chữ', 10, N'Đang được cập nhật', CAST(1450000.00 AS Decimal(18, 2)), N'silver_bangle_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (241, N'Lắc tay bạc nữ ngọc trai nhân tạo', 10, N'Đang được cập nhật', CAST(1680000.00 AS Decimal(18, 2)), N'silver_bangle_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (242, N'Lắc tay bạc nữ đá Synthetic', 10, N'Đang được cập nhật', CAST(1050000.00 AS Decimal(18, 2)), N'silver_bangle_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (243, N'Lắc tay bạc nữ kiểu lưới', 10, N'Đang được cập nhật', CAST(1150000.00 AS Decimal(18, 2)), N'silver_bangle_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (244, N'Lắc tay bạc nữ mặt hoa văn', 10, N'Đang được cập nhật', CAST(980000.00 AS Decimal(18, 2)), N'silver_bangle_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (245, N'Lắc tay bạc nữ đính đá màu xanh', 10, N'Đang được cập nhật', CAST(1350000.00 AS Decimal(18, 2)), N'silver_bangle_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (246, N'Bông tai bạc nữ đính đá CZ', 11, N'Đang được cập nhật', CAST(890000.00 AS Decimal(18, 2)), N'earring_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (247, N'Bông tai vàng 18K đính đá ECZ', 11, N'Đang được cập nhật', CAST(3250000.00 AS Decimal(18, 2)), N'earring_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (248, N'Bông tai bạc nữ ngọc trai nhỏ', 11, N'Đang được cập nhật', CAST(1450000.00 AS Decimal(18, 2)), N'earring_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (249, N'Bông tai bạc nữ hình bông hoa', 11, N'Đang được cập nhật', CAST(990000.00 AS Decimal(18, 2)), N'earring_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (250, N'Bông tai vàng 14K đính đá Synthetic', 11, N'Đang được cập nhật', CAST(2850000.00 AS Decimal(18, 2)), N'earring_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (251, N'Bông tai bạc nữ đá thạch anh tím', 11, N'Đang được cập nhật', CAST(1650000.00 AS Decimal(18, 2)), N'earring_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (252, N'Bông tai bạc nữ dáng dài thanh mảnh', 11, N'Đang được cập nhật', CAST(1150000.00 AS Decimal(18, 2)), N'earring_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (253, N'Bông tai vàng trắng 10K đính đá Topaz', 11, N'Đang được cập nhật', CAST(4500000.00 AS Decimal(18, 2)), N'earring_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (254, N'Bông tai bạc nữ hình trái tim', 11, N'Đang được cập nhật', CAST(950000.00 AS Decimal(18, 2)), N'earring_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (255, N'Bông tai bạc nữ hình ngôi sao', 11, N'Đang được cập nhật', CAST(890000.00 AS Decimal(18, 2)), N'earring_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (256, N'Đá Ruby thiên nhiên 3.5 ly', 12, N'Đang được cập nhật', CAST(12500000.00 AS Decimal(18, 2)), N'gem_ruby.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (257, N'Đá Sapphire xanh thiên nhiên 4 ly', 12, N'Đang được cập nhật', CAST(15800000.00 AS Decimal(18, 2)), N'gem_sapphire.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (258, N'Đá Emerald thiên nhiên 3 ly', 12, N'Đang được cập nhật', CAST(18500000.00 AS Decimal(18, 2)), N'gem_emerald.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (259, N'Đá Garnet đỏ 3 ly', 12, N'Đang được cập nhật', CAST(7200000.00 AS Decimal(18, 2)), N'gem_garnet.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (260, N'Đá Topaz xanh 5 ly', 12, N'Đang được cập nhật', CAST(3500000.00 AS Decimal(18, 2)), N'gem_topaz.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (261, N'Đá Thạch anh tím 6 ly', 12, N'Đang được cập nhật', CAST(2800000.00 AS Decimal(18, 2)), N'gem_amethyst.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (262, N'Đá Citrine vàng 5 ly', 12, N'Đang được cập nhật', CAST(3100000.00 AS Decimal(18, 2)), N'gem_citrine.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (263, N'Đá Tourmaline đa sắc 4 ly', 12, N'Đang được cập nhật', CAST(9800000.00 AS Decimal(18, 2)), N'gem_tourmaline.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (264, N'Đá Peridot xanh lá 4 ly', 12, N'Đang được cập nhật', CAST(6200000.00 AS Decimal(18, 2)), N'gem_peridot.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (265, N'Đá Spinel hồng thiên nhiên 3 ly', 12, N'Đang được cập nhật', CAST(11200000.00 AS Decimal(18, 2)), N'gem_spinel.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (266, N'Bông tai ngọc trai Akoya 6mm', 13, N'Đang được cập nhật', CAST(4500000.00 AS Decimal(18, 2)), N'pearl_earring_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (267, N'Dây chuyền ngọc trai nước ngọt 7mm', 13, N'Đang được cập nhật', CAST(5200000.00 AS Decimal(18, 2)), N'pearl_chain_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (268, N'Nhẫn bạc đính ngọc trai 8mm', 13, N'Đang được cập nhật', CAST(3900000.00 AS Decimal(18, 2)), N'pearl_ring_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (269, N'Lắc tay ngọc trai mix bạc', 13, N'Đang được cập nhật', CAST(5800000.00 AS Decimal(18, 2)), N'pearl_bangle_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (270, N'Dây chuyền ngọc trai Akoya 6.5mm', 13, N'Đang được cập nhật', CAST(8900000.00 AS Decimal(18, 2)), N'pearl_chain_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (272, N'Nhẫn vàng trắng 10K đính ngọc trai', 13, N'Đang được cập nhật', CAST(11200000.00 AS Decimal(18, 2)), N'pearl_ring_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (273, N'Lắc tay ngọc trai phối charm bạc', 13, N'Đang được cập nhật', CAST(4650000.00 AS Decimal(18, 2)), N'pearl_bangle_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (274, N'Dây chuyền ngọc trai Tahiti 9mm', 13, N'Đang được cập nhật', CAST(21500000.00 AS Decimal(18, 2)), N'pearl_chain_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (275, N'Bông tai ngọc trai South Sea 10mm', 13, N'Đang được cập nhật', CAST(32800000.00 AS Decimal(18, 2)), N'pearl_earring_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (276, N'Kim cương rời 3 ly nước D', 2, N'Đang được cập nhật', CAST(12800000.00 AS Decimal(18, 2)), N'diamond_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (277, N'Kim cương rời 4 ly nước E', 2, N'Đang được cập nhật', CAST(19800000.00 AS Decimal(18, 2)), N'diamond_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (278, N'Kim cương rời 5 ly nước F', 2, N'Đang được cập nhật', CAST(31500000.00 AS Decimal(18, 2)), N'diamond_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (279, N'Kim cương rời 6 ly nước G', 2, N'Đang được cập nhật', CAST(48500000.00 AS Decimal(18, 2)), N'diamond_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (280, N'Kim cương rời 7 ly nước H', 2, N'Đang được cập nhật', CAST(69800000.00 AS Decimal(18, 2)), N'diamond_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (281, N'Kim cương rời 8 ly nước D', 2, N'Đang được cập nhật', CAST(112000000.00 AS Decimal(18, 2)), N'diamond_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (282, N'Kim cương rời 9 ly nước E', 2, N'Đang được cập nhật', CAST(162000000.00 AS Decimal(18, 2)), N'diamond_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (283, N'Kim cương rời 10 ly nước F', 2, N'Đang được cập nhật', CAST(225000000.00 AS Decimal(18, 2)), N'diamond_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (284, N'Kim cương rời 11 ly nước G', 2, N'Đang được cập nhật', CAST(315000000.00 AS Decimal(18, 2)), N'diamond_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (285, N'Kim cương rời 12 ly nước H', 2, N'Đang được cập nhật', CAST(420000000.00 AS Decimal(18, 2)), N'diamond_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (286, N'Hộp đựng trang sức cao cấp', 4, N'Đang được cập nhật', CAST(850000.00 AS Decimal(18, 2)), N'accessory_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (287, N'Khăn lau trang sức PNJ Silver', 4, N'Đang được cập nhật', CAST(120000.00 AS Decimal(18, 2)), N'accessory_2.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (288, N'Dung dịch vệ sinh trang sức PNJ', 4, N'Đang được cập nhật', CAST(350000.00 AS Decimal(18, 2)), N'accessory_3.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (289, N'Găng tay bảo quản trang sức', 4, N'Đang được cập nhật', CAST(95000.00 AS Decimal(18, 2)), N'accessory_4.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (290, N'Hộp quà tặng PNJ sang trọng', 4, N'Đang được cập nhật', CAST(250000.00 AS Decimal(18, 2)), N'accessory_5.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (291, N'Dây da thay thế đồng hồ', 4, N'Đang được cập nhật', CAST(650000.00 AS Decimal(18, 2)), N'accessory_6.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (292, N'Vòng tay chỉ đỏ phong thủy', 4, N'Đang được cập nhật', CAST(150000.00 AS Decimal(18, 2)), N'accessory_7.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (293, N'Charm bạc PNJ mix vòng', 4, N'Đang được cập nhật', CAST(450000.00 AS Decimal(18, 2)), N'accessory_8.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (294, N'Túi vải bảo quản trang sức PNJ', 4, N'Đang được cập nhật', CAST(100000.00 AS Decimal(18, 2)), N'accessory_9.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (295, N'Giấy chứng nhận kiểm định đá quý', 4, N'Đang được cập nhật', CAST(500000.00 AS Decimal(18, 2)), N'accessory_10.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (296, N'Lắc tay Vàng Trắng 10K Đính đá ECZ QUá Là đẹp', 5, N'Đang được cập nhật', CAST(3000000.00 AS Decimal(18, 2)), N'D:\Sourcecode\Quanlydocongnghe\SaleApp\bin\Debug\net6.0-windows\Hinhanh\bangles_1.png')
INSERT [dbo].[SANPHAM] ([ID], [TenSanPham], [MaLoaiHang], [MoTa], [GiaBan], [HinhAnh]) VALUES (297, N'Lắc tay Vàng Trắng 10K Đính đá ECZ QUá Là đẹp', 5, N'Đang được cập nhật', CAST(3000000.00 AS Decimal(18, 2)), N'D:\Sourcecode\Quanlydocongnghe\SaleApp\bin\Debug\net6.0-windows\Hinhanh\bangles_1.png')
SET IDENTITY_INSERT [dbo].[SANPHAM] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KHACHHAN__0389B7BDBF04C49D]    Script Date: 23/09/2025 11:46:06 SA ******/
ALTER TABLE [dbo].[KHACHHANG] ADD UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NHANVIEN__0389B7BD42B0C67B]    Script Date: 23/09/2025 11:46:06 SA ******/
ALTER TABLE [dbo].[NHANVIEN] ADD UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NHANVIEN__A955A0AAA2455E79]    Script Date: 23/09/2025 11:46:06 SA ******/
ALTER TABLE [dbo].[NHANVIEN] ADD UNIQUE NONCLUSTERED 
(
	[CCCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GIAODICH] ADD  DEFAULT (getdate()) FOR [NgayGD]
GO
ALTER TABLE [dbo].[GIAVANG] ADD  DEFAULT (getdate()) FOR [Ngay]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT (getdate()) FOR [NgayVao]
GO
ALTER TABLE [dbo].[NHACUNGCAP] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT (getdate()) FOR [NgayVao]
GO
ALTER TABLE [dbo].[CHITIETGIAODICH]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SANPHAM] ([ID])
GO
ALTER TABLE [dbo].[CHITIETGIAODICH]  WITH CHECK ADD FOREIGN KEY([MaGD])
REFERENCES [dbo].[GIAODICH] ([ID])
GO
ALTER TABLE [dbo].[GIAODICH]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACHHANG] ([ID])
GO
ALTER TABLE [dbo].[GIAODICH]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([ID])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[QUYEN] ([ID])
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD FOREIGN KEY([MaLoaiHang])
REFERENCES [dbo].[LOAIHANG] ([ID])
GO
ALTER TABLE [dbo].[CHITIETGIAODICH]  WITH CHECK ADD CHECK  (([DonGia]>=(0)))
GO
ALTER TABLE [dbo].[CHITIETGIAODICH]  WITH CHECK ADD CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[GIAODICH]  WITH CHECK ADD CHECK  (([LoaiGD]='BAN_RA' OR [LoaiGD]='MUA_VAO'))
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD CHECK  (([GiaBan]>=(0)))
GO
USE [master]
GO
ALTER DATABASE [db_Jewelry] SET  READ_WRITE 
GO
