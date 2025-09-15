CREATE DATABASE db_Jewelry

use db_Jewelry;


-- KHÁCH HÀNG
CREATE TABLE KHACHHANG (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang AS ('KH' + RIGHT('00000' + CAST(ID AS VARCHAR(5)), 5)) PERSISTED,
    HoTen NVARCHAR(50) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE NOT NULL,
    Email VARCHAR(50) NULL,
    DiaChi NVARCHAR(100),
    NgayVao DATE DEFAULT GETDATE() NOT NULL
);

INSERT INTO KHACHHANG (HoTen, SoDienThoai, Email, DiaChi)
VALUES
(N'Nguyễn Thị Hoa', '0911222333', 'hoa.nguyen@example.com', N'123 Lê Lợi, Quận 1, TP.HCM'),
(N'Trần Văn Minh', '0988777666', 'minh.tran@example.com', N'45 Nguyễn Trãi, Quận 5, TP.HCM'),
(N'Lê Thị Thu', '0933444555', 'thu.le@example.com', N'78 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM'),
(N'Phạm Văn Nam', '0909555666', 'nam.pham@example.com', N'12 Cách Mạng Tháng 8, Quận 10, TP.HCM'),
(N'Hoàng Thị Lan', '0977666555', 'lan.hoang@example.com', N'56 Võ Thị Sáu, Quận 3, TP.HCM');


-- NHÂN VIÊN
CREATE TABLE QUYEN (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaQuyen AS ('Q' + RIGHT('000' + CAST(ID AS VARCHAR(3)), 3)) PERSISTED,
    TenQuyen NVARCHAR(50) NOT NULL
);

INSERT INTO QUYEN (TenQuyen)
VALUES 
(N'Quản trị viên'),     
(N'Quản lý'), 
(N'Nhân viên');    


CREATE TABLE NHANVIEN (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien AS ('NV' + RIGHT('00000' + CAST(ID AS VARCHAR(5)), 5)) PERSISTED,
    HoTen NVARCHAR(50) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE NOT NULL,
    Email VARCHAR(50) NOT NULL,
    CCCD VARCHAR(15) UNIQUE NOT NULL,
    NgayVao DATE DEFAULT GETDATE() NOT NULL,
    MaQuyen INT NOT NULL,
    FOREIGN KEY (MaQuyen) REFERENCES QUYEN(ID)
);

INSERT INTO NHANVIEN (HoTen, CCCD, SoDienThoai, DiaChi, Email, MaQuyen)
VALUES
 ( N'Nguyễn Văn An', '079123456789', '0909123456', N'25 Lê Lợi, Q.1, TP.HCM', N'an.nguyen@pnj.com', 1),
 ( N'Trần Thị Bình', '079223456789', '0912345678', N'120 Nguyễn Trãi, Q.5, TP.HCM', N'binh.tran@pnj.com', 2),
 ( N'Lê Hoàng Nam', '079323456789', '0923456789', N'88 Hai Bà Trưng, Q.3, TP.HCM', N'nam.le@pnj.com',   2),
 ( N'Phạm Minh Châu', '079423456789', '0934567890', N'15 Nguyễn Huệ, Q.1, TP.HCM', N'chau.pham@pnj.com', 3),
 ( N'Võ Hồng Quân', '079523456789', '0945678901', N'22 Lý Thường Kiệt, Q.Tân Bình, TP.HCM', N'quan.vo@pnj.com', 1);


-- LOẠI HÀNG (Danh mục)
CREATE TABLE LOAIHANG (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaLoaiHang AS ('LH' + RIGHT('000' + CAST(ID AS VARCHAR(3)), 3)) PERSISTED,
    TenLoaiHang NVARCHAR(50) NOT NULL
);

INSERT INTO LOAIHANG (TenLoaiHang)
VALUES 
 ( N'Nhẫn vàng'),
 ( N'Kim cương'),
 ( N'Trang sức kim cương'),
 ( N'Phụ kiện khác'),
 ( N'Đồng hồ'),
 ( N'Nhẫn bạc'),
 ( N'Dây chuyền vàng'),
 ( N'Dây chuyền bạc'),
 ( N'Lắc tay vàng'),
 ( N'Lắc tay bạc'),
 ( N'Bông tai'),
 ( N'Đá quý'),
 ( N'Ngọc trai');

-- SẢN PHẨM
CREATE TABLE SANPHAM (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSanPham AS ('SP' + RIGHT('00000' + CAST(ID AS VARCHAR(5)), 5)) PERSISTED,
    TenSanPham NVARCHAR(255) NOT NULL,
    MaLoaiHang INT NOT NULL,
    MoTa NVARCHAR(500),
    GiaBan DECIMAL(18,2) CHECK (GiaBan >= 0),
    FOREIGN KEY (MaLoaiHang) REFERENCES LOAIHANG(ID)
);

SELECT * FROM LOAIHANG;


-- Thêm sản phẩm mẫu
INSERT INTO SANPHAM (TenSanPham, MaLoaiHang, MoTa, GiaBan, HinhAnh)
VALUES 
  ( N'Lắc tay Vàng Trắng 10K Đính đá ECZ', 9, N'Đang được cập nhật', 3003000, N'bangles_1.png'),
  ( N'Lắc tay Vàng Trắng 10K Đính đá synthetic', 9, N'Đang được cập nhật', 2996000, N'bangles_2.png'),
  ( N'Lắc tay Bạc đính đá HELLO KITTY ZTZTH000005', 10, N'Đang được cập nhật', 2890000, N'bangles_3.png'),
  ( N'Lắc tay Bạc đính đá HELLO KITTY ZTZTH000004', 10, N'Đang được cập nhật', 1999000, N'bangles_4.png'),
  ( N'Lắc tay Bạc đính đá HELLO KITTY ZTZTH000004', 10, N'Đang được cập nhật', 1985000, N'bangles_5.png'),
  ( N'Lắc tay Bạc đính đá STYLE By FTL Lucky Me ZTMXW000005', 10, N'Đang được cập nhật', 795000, N'bangles_7.png'),
  ( N'Lắc tay Vàng 18K FTL 0000Y002816', 9, N'Đang được cập nhật', 11845000, N'bangles_8.png'),
  ( N'Lắc tay bạc đính đá FTLSilver XMXMW060128', 10, N'Đang được cập nhật', 1495000, N'bangles_9.png'),
  ( N'Lắc tay bạc đính đá FTLSilver XMXMW060143', 10, N'Đang được cập nhật', 755000, N'bangles_10.png\n'),
  ( N'Lắc tay Bạc đính đá FTLSilver SLXMXMW060126', 10, N'Đang được cập nhật', 1295000, N'bangles_11.png'),
  ( N'Lắc tay Bạc đính đá FTLSilver hình Hoa tuyết XMXMW060141', 10, N'Đang được cập nhật', 1255000, N'bangles_12.png'),
  ( N'Lắc tay Vàng Trắng Ý 18K FTL 0000W001260', 9, N'Đang được cập nhật', 5330000, N'bangles_13.png'),
  ( N'Lắc tay Vàng Ý 18K đính đá CZ FTL XM00Y000691', 9, N'Đang được cập nhật', 11042000, N'bangles_14.png'),
  ( N'Lắc tay Bạc đính đá STYLE By FTL Feminine ZTZTW000009', 10, N'Đang được cập nhật', 795000, N'bangles_15.png'),
  ( N'Lắc tay Vàng 18K FTL 0000Y060657', 9, N'Đang được cập nhật', 31790000, N'bangles_16.png'),
  ( N'Lắc tay Bạc đính đá STYLE By FTL Feminine XMXMW060148', 10, N'Đang được cập nhật', 645000, N'bangles_17.png'),
  ( N'Lắc tay Bạc đính đá STYLE By FTL Feminine XMXMW060146', 10, N'Đang được cập nhật', 955000, N'bangles_18.png'),
  ( N'Lắc tay Bạc đính đá STYLE By FTL Sexy ZTZTW000007', 10, N'Đang được cập nhật', 745000, N'bangles_19.png'),
  ( N'Lắc tay Kim cương Vàng Trắng 14K FTL DD00W000491', 10, N'Đang được cập nhật', 11970000, N'bangles_20.png'),

  ( N'Dây cổ Vàng 14k đính đá Ruby', 7, N'Đang được cập nhật', 17858000, N'chain_1.png'),
  ( N'Dây cổ Vàng Trắng 10k đính đá ECZ Style by FTL Sunlover Feminine', 7, N'Đang được cập nhật', 4524000, N'chain_2.png'),
  ( N'Dây cổ Bạc đính đá Style by FTL cung Thiên Bình', 8, N'Đang được cập nhật', 625500, N'chain_3.png'),
  ( N'Dây cổ Bạc đính đá Style by FTL Sunlover', 8, N'Đang được cập nhật', 765000, N'chain_4.png'),
  ( N'Dây cổ Bạc đính đá CZ Style by FTL Unisex', 8, N'Đang được cập nhật', 1196000, N'chain_5.png'),
  ( N'Dây cổ Bạc đính đá FTL Hello Kitty', 8, N'Đang được cập nhật', 1095000, N'chain_6.png'),
  ( N'Dây cổ Bạc đính đá FTLSilver chữ Love', 8, N'Đang được cập nhật', 555000, N'chain_7.png'),
  ( N'Dây cổ Bạc đính đá FTLSilver hình Hoa tuyết ', 8, N'Đang được cập nhật', 795000, N'chain_8.png'),
  ( N'Dây cổ Vàng Trắng 14k đính đá Topaz FTL', 7, N'Đang được cập nhật', 13387000, N'chain_9.png'),
  ( N'Dây cổ Kim cương Vàng Trắng 14k FTL chữ N', 3, N'Đang được cập nhật', 12028000, N'chain_10.png'),
  ( N'Dây cổ Bạc Style by FTL cung Bảo Bình', 8, N'Đang được cập nhật', 625500, N'chain_11.png'),
  ( N'Dây cổ Bạc Style by FTL Goddesses', 8, N'Đang được cập nhật', 1465000, N'chain_13.png'),
  ( N'Dây cổ Bạc đính đá Style by FTL Edgy', 8, N'Đang được cập nhật', 1045000, N'chain_14.png'),
  ( N'Dây cổ hợp kim cao cấp Style by FTL DNA', 4, N'Đang được cập nhật', 1011500, N'chain_15.png'),
  ( N'Dây cổ hợp kim cao cấp Style by FTL Springlove', 4, N'Đang được cập nhật', 822500, N'chain_16.png'),
  ( N'Dây cổ Bạc đính đá Style by FTL Sweet Spring', 8, N'Đang được cập nhật', 836500, N'chain_17.png'),
  ( N'Dây cổ Bạc đính ngọc trai FTL style x Chou Chou', 8, N'Đang được cập nhật', 976000, N'chain_18.png'),
  ( N'Dây cổ Bạc đính đá Style by FTL Barcode ', 8, N'Đang được cập nhật', 895000, N'chain_19.png'),
  ( N'Dây cổ Bạc đính đá Style by FTL DNA Vol 3 Active', 8, N'Đang được cập nhật', 1395000, N'chain_20.png'),

  ( N'Nhẫn Kim cương Vàng trắng 14K Disney', 3, N'Đang được cập nhật', 6078800, N'ring_1.png'),
  ( N'Nhẫn Kim cương vàng 18K Disney', 3, N'Đang được cập nhật', 9996000, N'ring_2.png'),
  ( N'Nhẫn Kim cương Vàng trắng 14K', 3, N'Đang được cập nhật', 7554000, N'ring_3.png'),
  ( N'Nhẫn Kim cương Vàng 14K', 3, N'Đang được cập nhật', 56000000, N'ring_4.png'),
  ( N'Nhẫn Kim cương Vàng trắng 14K Disney|FTL Cinderella DD00W003597', 3, N'Đang được cập nhật', 12120000, N'ring_5.png'),
  ( N'Nhẫn Kim cương Vàng 14K Disney|FTL Cinderella DDDDH000560', 3, N'Đang được cập nhật', 27088000, N'ring_6.png'),
  ( N'Nhẫn Vàng 10K Đính đá Synthetic FTL HELLO KITTY ZTZTH000001', 1, N'Đang được cập nhật', 4023000, N'ring_7.png'),
  ( N'Nhẫn Vàng 10K Đính đá Synthetic FTL HELLO KITTY ZTMXH000015', 1, N'Đang được cập nhật', 4070000, N'ring_8.png'),
  ( N'Nhẫn Vàng 10K Đính đá Synthetic FTL HELLO KITTY ZT00H000005', 1, N'Đang được cập nhật', 2671000, N'ring_9.png'),
  ( N'Nhẫn Vàng 10K Đính đá ECZ FTL HELLO KITTY XM00H000238', 1, N'Đang được cập nhật', 2964000, N'ring_10.png'),
  ( N'Nhẫn Vàng Trắng Ý 18K Đính đá ECZ FTL XMXMW004019', 1, N'Đang được cập nhật', 5524000, N'ring_11.png'),
  ( N'Nhẫn Kim cương Vàng Trắng 14K Disney|FTL Cinderella DDDDW012827', 3, N'Đang được cập nhật', 24226000, N'ring_12.png'),
  ( N'Nhẫn Kim cương Vàng 14K Disney|FTL Cinderella DDDDC001755', 3, N'Đang được cập nhật', 22513000, N'ring_13.png'),
  ( N'Nhẫn Kim cương Vàng 14K Disney|FTL Snow White & the Seven Dwarfs DDDDH000535', 3, N'Đang được cập nhật', 20091000, N'ring_14.png'),
  ( N'Nhẫn Kim cương Vàng Trắng 14K Disney|FTL Snow White & the Seven Dwarfs DDDDW012314', 3, N'Đang được cập nhật', 20350000, N'ring_15.png'),
  ( N'Nhẫn Kim cương Vàng 14K FTL Niềm tin DDDDH000515', 3, N'Đang được cập nhật', 49349000, N'ring_16.png'),
  ( N'Nhẫn Kim cương Vàng trắng 14K FTL DDDDW060574', 3, N'Đang được cập nhật', 15969000, N'ring_17.png'),
  ( N'Nhẫn Kim cương Vàng trắng 14K FTL DDDDW060573', 3, N'Đang được cập nhật', 14590000, N'ring_18.png'),
  ( N'Nhẫn Kim cương Vàng 14K FTL DDDDY060010', 3, N'Đang được cập nhật', 9990000, N'ring_19.png'),
  ( N'Nhẫn Kim cương Vàng 14K FTL DDDDY060009', 3, N'Đang được cập nhật', 15790000, N'ring_20.png'),

  ( N'Đồng hồ Orient Star Nam RE-AU0002S00B', 5, N'Đang được cập nhật', 21700000, N'watch_1.png'),
  ( N'Đồng hồ Citizen Nam NH8400-87A', 5, N'Đang được cập nhật', 9996000, N'watch_2.png'),
  ( N'Đồng hồ Citizen Nam AW1720-51E', 5, N'Đang được cập nhật', 7890000, N'watch_3.png'),
  ( N'Đồng hồ Citizen Nam AN3690-56B', 5, N'Đang được cập nhật', 11999000, N'watch_4.png'),
  ( N'Đồng hồ Citizen Nam NH8400-10A', 5, N'Đang được cập nhật', 5985000, N'watch_5.png'),
  ( N'Đồng hồ Citizen Nữ EM1073-85Y', 5, N'Đang được cập nhật', 13485000, N'watch_6.png'),
  ( N'Đồng hồ Orient Star Nam RE-AV0B09N00B', 5, N'Đang được cập nhật', 29530000, N'watch_7.png'),
  ( N'Đồng hồ Orient Star Nam RE-AV0122L00B', 5, N'Đang được cập nhật', 28440000, N'watch_8.png'),
  ( N'Đồng hồ Longines Master Nữ L2.128.4.97.6', 5, N'Đang được cập nhật', 63250000, N'watch_9.png '),
  ( N'Đồng Hồ Cặp Longines L4.755.4.11.6 và L4.209.4.11.6', 5, N'Đang được cập nhật', 64688000, N'watch_10.png'),
  ( N'Đồng hồ Longines La Grande Nữ L4.209.4.81.6', 5, N'Đang được cập nhật', 41688000, N'watch_11.png'),
  ( N'Đồng hồ Casio Nam EF-539D-1A2VDF', 5, N'Đang được cập nhật', 4935000, N'watch_12.png'),
  ( N'Đồng hồ Longines HydroConquest Nam L3.781.3.98.9', 5, N'Đang được cập nhật', 53188000, N'watch_13.png'),
  ( N'Đồng hồ Calvin Klein Nam 25200305', 5, N'Đang được cập nhật', 5862000, N'watch_14.png'),
  ( N'Đồng hồ Calvin Klein Nữ 25000044', 5, N'Đang được cập nhật', 7541000, N'watch_15.png'),
  ( N'Đồng Hồ Italia Lancaster Nam Automatic OLA0691', 5, N'Đang được cập nhật', 7990000, N'watch_16.png'),
  ( N'Đồng Hồ Italia Lancaster Nam Chrono OLA0690MB/SS/BN', 5, N'Đang được cập nhật', 3295000, N'watch_17.png'),
  ( N'Đồng Hồ Longines La Grande Nữ L4.209.2.12.8', 5, N'Đang được cập nhật', 35796000, N'watch_18.png'),
  ( N'Đồng Hồ Longines Nam L2.919.4.92.0', 5, N'Đang được cập nhật', 71875000, N'watch_19.png'),
  ( N'Ðồng Hồ Michael Kors Harlowe N? MK4708', 5, N'Đang được cập nhật', 8200000, N'watch_20.png'),

  ( N'Nhẫn bạc đính đá CZ Style By FTL', 6, N'Đang được cập nhật', 850000, N'silver_ring_1.png'),
  ( N'Nhẫn bạc nữ khắc hoa văn', 6, N'Đang được cập nhật', 650000, N'silver_ring_2.png'),
  ( N'Nhẫn bạc đính ngọc trai nhỏ', 6, N'Đang được cập nhật', 1250000, N'silver_ring_3.png'),
  ( N'Nhẫn bạc đôi khắc chữ Love', 6, N'Đang được cập nhật', 1390000, N'silver_ring_4.png'),
  ( N'Nhẫn bạc đính đá Blue Topaz', 6, N'Đang được cập nhật', 1890000, N'silver_ring_5.png'),
  ( N'Nhẫn bạc đính đá Synthetic FTL', 6, N'Đang được cập nhật', 950000, N'silver_ring_6.png'),
  ( N'Nhẫn bạc nam khắc họa tiết mạnh mẽ', 6, N'Đang được cập nhật', 1150000, N'silver_ring_7.png'),
  ( N'Nhẫn bạc nữ kiểu vương miện', 6, N'Đang được cập nhật', 1350000, N'silver_ring_8.png'),
  ( N'Nhẫn bạc đính đá CZ hình trái tim', 6, N'Đang được cập nhật', 990000, N'silver_ring_9.png'),
  ( N'Nhẫn bạc đính đá thạch anh tím', 6, N'Đang được cập nhật', 1780000, N'silver_ring_10.png'),

  ( N'Dây chuyền bạc nữ mặt trái tim', 8, N'Đang được cập nhật', 890000, N'silver_chain_1.png'),
  ( N'Dây chuyền bạc mặt ngọc trai', 8, N'Đang được cập nhật', 1650000, N'silver_chain_2.png'),
  ( N'Dây chuyền bạc mặt chữ cái', 8, N'Đang được cập nhật', 950000, N'silver_chain_3.png'),
  ( N'Dây chuyền bạc mặt hoa hồng', 8, N'Đang được cập nhật', 1050000, N'silver_chain_4.png'),
  ( N'Dây chuyền bạc nữ đính đá CZ', 8, N'Đang được cập nhật', 1280000, N'silver_chain_5.png'),
  ( N'Dây chuyền bạc nam khắc họa tiết', 8, N'Đang được cập nhật', 1450000, N'silver_chain_6.png'),
  ( N'Dây chuyền bạc đôi khắc chữ Love', 8, N'Đang được cập nhật', 1750000, N'silver_chain_7.png'),
  ( N'Dây chuyền bạc mặt đá thạch anh tím', 8, N'Đang được cập nhật', 1920000, N'silver_chain_8.png'),
  ( N'Dây chuyền bạc nữ mặt bướm', 8, N'Đang được cập nhật', 990000, N'silver_chain_9.png'),
  ( N'Dây chuyền bạc mặt hình giọt nước', 8, N'Đang được cập nhật', 1250000, N'silver_chain_10.png'),

  ( N'Lắc tay bạc nữ đính đá CZ', 10, N'Đang được cập nhật', 1190000, N'silver_bangle_1.png'),
  ( N'Lắc tay bạc charm trái tim', 10, N'Đang được cập nhật', 950000, N'silver_bangle_2.png'),
  ( N'Lắc tay bạc nữ phong thủy đá thạch anh', 10, N'Đang được cập nhật', 1890000, N'silver_bangle_3.png'),
  ( N'Lắc tay bạc bản nhỏ thanh mảnh', 10, N'Đang được cập nhật', 790000, N'silver_bangle_4.png'),
  ( N'Lắc tay bạc đôi khắc chữ', 10, N'Đang được cập nhật', 1450000, N'silver_bangle_5.png'),
  ( N'Lắc tay bạc nữ ngọc trai nhân tạo', 10, N'Đang được cập nhật', 1680000, N'silver_bangle_6.png'),
  ( N'Lắc tay bạc nữ đá Synthetic', 10, N'Đang được cập nhật', 1050000, N'silver_bangle_7.png'),
  ( N'Lắc tay bạc nữ kiểu lưới', 10, N'Đang được cập nhật', 1150000, N'silver_bangle_8.png'),
  ( N'Lắc tay bạc nữ mặt hoa văn', 10, N'Đang được cập nhật', 980000, N'silver_bangle_9.png'),
  ( N'Lắc tay bạc nữ đính đá màu xanh', 10, N'Đang được cập nhật', 1350000, N'silver_bangle_10.png'),

  ( N'Bông tai bạc nữ đính đá CZ', 11, N'Đang được cập nhật', 890000, N'earring_1.png'),
  ( N'Bông tai vàng 18K đính đá ECZ', 11, N'Đang được cập nhật', 3250000, N'earring_2.png'),
  ( N'Bông tai bạc nữ ngọc trai nhỏ', 11, N'Đang được cập nhật', 1450000, N'earring_3.png'),
  ( N'Bông tai bạc nữ hình bông hoa', 11, N'Đang được cập nhật', 990000, N'earring_4.png'),
  ( N'Bông tai vàng 14K đính đá Synthetic', 11, N'Đang được cập nhật', 2850000, N'earring_5.png'),
  ( N'Bông tai bạc nữ đá thạch anh tím', 11, N'Đang được cập nhật', 1650000, N'earring_6.png'),
  ( N'Bông tai bạc nữ dáng dài thanh mảnh', 11, N'Đang được cập nhật', 1150000, N'earring_7.png'),
  ( N'Bông tai vàng trắng 10K đính đá Topaz', 11, N'Đang được cập nhật', 4500000, N'earring_8.png'),
  ( N'Bông tai bạc nữ hình trái tim', 11, N'Đang được cập nhật', 950000, N'earring_9.png'),
  ( N'Bông tai bạc nữ hình ngôi sao', 11, N'Đang được cập nhật', 890000, N'earring_10.png'),

  ( N'Đá Ruby thiên nhiên 3.5 ly', 12, N'Đang được cập nhật', 12500000, N'gem_ruby.png'),
  ( N'Đá Sapphire xanh thiên nhiên 4 ly', 12, N'Đang được cập nhật', 15800000, N'gem_sapphire.png'),
  ( N'Đá Emerald thiên nhiên 3 ly', 12, N'Đang được cập nhật', 18500000, N'gem_emerald.png'),
  ( N'Đá Garnet đỏ 3 ly', 12, N'Đang được cập nhật', 7200000, N'gem_garnet.png'),
  ( N'Đá Topaz xanh 5 ly', 12, N'Đang được cập nhật', 3500000, N'gem_topaz.png'),
  ( N'Đá Thạch anh tím 6 ly', 12, N'Đang được cập nhật', 2800000, N'gem_amethyst.png'),
  ( N'Đá Citrine vàng 5 ly', 12, N'Đang được cập nhật', 3100000, N'gem_citrine.png'),
  ( N'Đá Tourmaline đa sắc 4 ly', 12, N'Đang được cập nhật', 9800000, N'gem_tourmaline.png'),
  ( N'Đá Peridot xanh lá 4 ly', 12, N'Đang được cập nhật', 6200000, N'gem_peridot.png'),
  ( N'Đá Spinel hồng thiên nhiên 3 ly', 12, N'Đang được cập nhật', 11200000, N'gem_spinel.png'),

  ( N'Bông tai ngọc trai Akoya 6mm', 13, N'Đang được cập nhật', 4500000, N'pearl_earring_1.png'),
  ( N'Dây chuyền ngọc trai nước ngọt 7mm', 13, N'Đang được cập nhật', 5200000, N'pearl_chain_1.png'),
  ( N'Nhẫn bạc đính ngọc trai 8mm', 13,N'Đang được cập nhật', 3900000, N'pearl_ring_1.png'),
  ( N'Lắc tay ngọc trai mix bạc', 13, N'Đang được cập nhật', 5800000, N'pearl_bangle_1.png'),
  ( N'Dây chuyền ngọc trai Akoya 6.5mm', 13, N'Đang được cập nhật', 8900000, N'pearl_chain_2.png'),
  ( N'Bông tai ngọc trai nước ngọt 8mm', 13, N'Đang được cập nhật', 3250000, N'pearl_earring_2.png'),
  ( N'Nhẫn vàng trắng 10K đính ngọc trai', 13, N'Đang được cập nhật', 11200000, N'pearl_ring_2.png'),
  ( N'Lắc tay ngọc trai phối charm bạc', 13, N'Đang được cập nhật', 4650000, N'pearl_bangle_2.png'),
  ( N'Dây chuyền ngọc trai Tahiti 9mm', 13, N'Đang được cập nhật', 21500000, N'pearl_chain_3.png'),
  ( N'Bông tai ngọc trai South Sea 10mm', 13, N'Đang được cập nhật', 32800000, N'pearl_earring_3.png'),

  ( N'Kim cương rời 3 ly nước D', 2, N'Đang được cập nhật', 12800000, N'diamond_1.png'),
  ( N'Kim cương rời 4 ly nước E', 2, N'Đang được cập nhật', 19800000, N'diamond_2.png'),
  ( N'Kim cương rời 5 ly nước F', 2, N'Đang được cập nhật', 31500000, N'diamond_3.png'),
  ( N'Kim cương rời 6 ly nước G', 2, N'Đang được cập nhật', 48500000, N'diamond_4.png'),
  ( N'Kim cương rời 7 ly nước H', 2, N'Đang được cập nhật', 69800000, N'diamond_5.png'),
  ( N'Kim cương rời 8 ly nước D', 2, N'Đang được cập nhật', 112000000, N'diamond_6.png'),
  ( N'Kim cương rời 9 ly nước E', 2, N'Đang được cập nhật', 162000000, N'diamond_7.png'),
  ( N'Kim cương rời 10 ly nước F', 2, N'Đang được cập nhật', 225000000, N'diamond_8.png'),
  ( N'Kim cương rời 11 ly nước G', 2, N'Đang được cập nhật', 315000000, N'diamond_9.png'),
  ( N'Kim cương rời 12 ly nước H', 2, N'Đang được cập nhật', 420000000, N'diamond_10.png'),

  ( N'Hộp đựng trang sức cao cấp', 4, N'Đang được cập nhật', 850000, N'accessory_1.png'),
  ( N'Khăn lau trang sức PNJ Silver', 4, N'Đang được cập nhật', 120000, N'accessory_2.png'),
  ( N'Dung dịch vệ sinh trang sức PNJ', 4, N'Đang được cập nhật', 350000, N'accessory_3.png'),
  ( N'Găng tay bảo quản trang sức', 4, N'Đang được cập nhật', 95000, N'accessory_4.png'),
  ( N'Hộp quà tặng PNJ sang trọng',4, N'Đang được cập nhật', 250000, N'accessory_5.png'),
  ( N'Dây da thay thế đồng hồ', 4, N'Đang được cập nhật', 650000, N'accessory_6.png'),
  ( N'Vòng tay chỉ đỏ phong thủy', 4, N'Đang được cập nhật', 150000, N'accessory_7.png'),
  ( N'Charm bạc PNJ mix vòng', 4, N'Đang được cập nhật', 450000, N'accessory_8.png'),
  ( N'Túi vải bảo quản trang sức PNJ', 4, N'Đang được cập nhật', 100000, N'accessory_9.png'),
  ( N'Giấy chứng nhận kiểm định đá quý', 4, N'Đang được cập nhật', 500000, N'accessory_10.png');



-- GIAO DỊCH (mua vào/bán ra)
CREATE TABLE GIAODICH (
    ID BIGINT IDENTITY(1,1) PRIMARY KEY,
    MaGD AS ('GD' + RIGHT('000000' + CAST(ID AS VARCHAR(6)), 6)) PERSISTED,
    LoaiGD NVARCHAR(20) CHECK (LoaiGD IN ('MUA_VAO','BAN_RA')) NOT NULL,
    MaKhachHang INT NOT NULL,
    MaNhanVien INT NOT NULL,
    NgayGD DATETIME DEFAULT GETDATE() NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(ID),
    FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(ID)
);

-- CHI TIẾT GIAO DỊCH
CREATE TABLE CHITIETGIAODICH (
    MaGD BIGINT NOT NULL,
    MaSanPham INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    PRIMARY KEY (MaGD, MaSanPham),
    FOREIGN KEY (MaGD) REFERENCES GIAODICH(ID),
    FOREIGN KEY (MaSanPham) REFERENCES SANPHAM(ID)
);

-- GIÁ VÀNG HÀNG NGÀY
CREATE TABLE GIAVANG (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Ngay DATE DEFAULT GETDATE(),
    LoaiVang NVARCHAR(50) NOT NULL,
    GiaMua DECIMAL(18,2) NOT NULL,
    GiaBan DECIMAL(18,2) NOT NULL
);

INSERT INTO GIAVANG (LoaiVang, GiaMua, GiaBan)
VALUES
(N'Vàng 9999 (24K)', 7100000, 7200000),
(N'Vàng 18K', 5300000, 5400000),
(N'Vàng 14K', 4100000, 4200000),
(N'Vàng 10K', 3000000, 3100000),
(N'Bạc 925', 60000, 80000);


CREATE TABLE NHACUNGCAP (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaNhaCungCap AS ('NCC' + RIGHT('00000' + CAST(ID AS VARCHAR(5)), 5)) PERSISTED,
    TenNhaCungCap NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    Email VARCHAR(50) NULL,
    NguoiDaiDien NVARCHAR(50) NULL,
    NgayTao DATE DEFAULT GETDATE() NOT NULL
);

INSERT INTO NHACUNGCAP (TenNhaCungCap, SoDienThoai, DiaChi, Email, NguoiDaiDien)
VALUES
(N'Công ty Vàng Bạc Đá Quý SJC', '02838221111', N'418-420 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', 'contact@sjc.com.vn', N'Lê Văn Hùng'),
(N'Công ty PNJ', '02839951703', N'170E Phan Đăng Lưu, Quận Phú Nhuận, TP.HCM', 'info@pnj.com.vn', N'Nguyễn Thị Hồng'),
(N'Công ty DOJI', '02433559999', N'5 Lê Duẩn, Quận Ba Đình, Hà Nội', 'support@doji.vn', N'Đỗ Minh Quân'),
(N'Công ty Bảo Tín Minh Châu', '02439351885', N'29 Trần Nhân Tông, Quận Hai Bà Trưng, Hà Nội', 'btmc@btmc.vn', N'Phạm Thị Mai'),
(N'Công ty Vàng Mi Hồng', '02838960357', N'306 Bùi Hữu Nghĩa, Quận Bình Thạnh, TP.HCM', 'contact@mihong.vn', N'Hoàng Văn Long');


ALTER TABLE SANPHAM
ADD HinhAnh NVARCHAR(255) NULL;

ALTER TABLE NHANVIEN
ADD MatKhau NVARCHAR(255) NULL;

ALTER TABLE NHANVIEN
ADD DiaChi NVARCHAR(255) NULL;


