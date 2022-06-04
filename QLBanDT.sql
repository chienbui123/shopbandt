
use master

-----Tao CSDL QLBansach
create database QLbanDT
GO
use QLbanDT
CREATE TABLE KHACHHANG
(
MaKH INT IDENTITY(1,1),
HoTen nVarchar(50) NOT NULL,
Taikhoan Varchar(50) UNIQUE,
Matkhau Varchar(50) NOT NULL,
Email Varchar(100) UNIQUE,
DiachiKH nVarchar(200),
DienthoaiKH Varchar(50),
Ngaysinh DATETIME
CONSTRAINT PK_Khachhang PRIMARY KEY(MaKH)
)
Create Table HDH
(
MaHDH int Identity(1,1),
TenHDH nvarchar(50) NOT NULL,
CONSTRAINT PK_HDH PRIMARY KEY(MaHDH)
)
Create Table NHAXUATBAN
(
MaNXB int identity(1,1),
TenNXB nvarchar(50) NOT NULL,
Diachi NVARCHAR(200),
DienThoai VARCHAR(50),
CONSTRAINT PK_NhaXuatBan PRIMARY KEY(MaNXB)
)
CREATE TABLE DIENTHOAI
(
MaDT INT IDENTITY(1,1),
TenDT NVARCHAR(100) NOT NULL,
Giaban Decimal(18,0) CHECK (Giaban>=0),
Manhinh nvarchar(10),
Ram nvarchar(10),
Rom nvarchar(10),
cammera nvarchar(10),
Mota NVarchar(Max),
Anhbia VARCHAR(50),
Ngaycapnhat DATETIME,
Soluongton INT,
MaHDH INT,
MaNXB INT,
Constraint PK_Sach Primary Key(MaDT),
Constraint FK_HDH Foreign Key(MaHDH) References HDH(MaHDH),
Constraint FK_NhaXB Foreign Key(MaNXB)References
NHAXUATBAN(MANXB)
)
CREATE TABLE DONDATHANG
(
MaDonHang INT IDENTITY(1,1),
Dathanhtoan bit,
Tinhtranggiaohang bit,
Ngaydat Datetime,
Ngaygiao Datetime,
MaKH INT,
CONSTRAINT PK_DonDatHang PRIMARY KEY (MaDonHang),
CONSTRAINT FK_Khachhang FOREIGN KEY(MaKH) REFERENCES Khachhang(MaKH)
)
CREATE TABLE CHITIETDONTHANG
(
MaDonHang INT,
MaDT INT,
Soluong Int Check(Soluong>0),
Dongia Decimal(18,0) Check(Dongia>=0),
CONSTRAINT PK_CTDatHang PRIMARY KEY(MaDonHang,MaDT),
CONSTRAINT FK_Donhang FOREIGN KEY (Madonhang)
REFERENCES Dondathang(Madonhang),
CONSTRAINT FK_DT FOREIGN KEY (MaDT)
REFERENCES DIENTHOAI(MaDT)
)
CREATE TABLE Admin
(
MaTK INT IDENTITY(1,1) ,
HoTen nVarchar(50) NOT NULL,
Taikhoan Varchar(50) UNIQUE,
Matkhau Varchar(50) NOT NULL,CONSTRAINT PK_Admin PRIMARY KEY(MaTK))
insert into Admin values(N'Bùi Văn Chiến','Admin','Admin')

sELECT * from KHACHHANG
sELECT * from HDH
sELECT * from DIENTHOAI
sELECT * from DONDATHANG
sELECT * from CHITIETDONTHANG
sELECT * from NHAXUATBAN
select * from Admin



INSERT INTO HDH VALUES(N'Androi')
INSERT INTO HDH VALUES(N'IOS')


INSERT INTO NHAXUATBAN VALUES(N'SamSung',N'hàn quốc','09123123')
INSERT INTO NHAXUATBAN VALUES(N'Apple',N'Mỹ','0123123123')
INSERT INTO NHAXUATBAN VALUES(N'Oppo',N'Trung Quốc','04123123')

INSERT INTO DIENTHOAI VALUES
(N'Samsung galaxy A53',30000000,N'2K 120hz',N'8 GB',N'128 GB',N'64 MP,12MP',
N'Thông tin sản phẩm
Samsung Galaxy A53 5G 128GB trình làng với một thiết kế hiện đại, hiệu năng ổn định cùng một màn hình hiển thị đẹp, hỗ trợ tần số quét cao giúp bạn có được những phút giây giải trí cực kỳ đã mắt, hay thỏa mãn đam mê nhiếp ảnh trong bạn nhờ trang bị nhiều camera cùng với các tính năng đầy mới mẻ.
Màu sắc hiển thị rực rỡ và mượt mà
Máy trang bị tấm nền Super AMOLED với kích thước màn hình lên đến 6.5 inch mang đến hình ảnh đầy màu sắc, độ tương phản cao, tối ưu năng lượng tiêu hao và không gian hiển thị đầy đủ, bao quát.',
'Hinh3.jpg',2019-12-11,140,1,1)
INSERT INTO DIENTHOAI VALUES
(N'Samsung galaxy S22',35000000,N'FullHD',N'6 GB',N'128 GB',N'64 MP,12MP',
N'Thông tin sản phẩm
Samsung Galaxy S22 ra mắt với diện mạo vô cùng tinh tế và trẻ trung, mang trong mình thiết kế phẳng theo xu hướng thịnh hành, màn hình 120 Hz mượt mà, cụm camera AI 50 MP và bộ xử lý đến từ Qualcomm.
Thiết kế thu hút mọi ánh nhìn 
Cảm giác đầu tiên Samsung Galaxy S22 mang lại cho mình khi sử dụng là máy cho cảm giác cầm nắm cực kỳ chắc chắn và đằm tay với thiết kế nhỏ gọn của mình.
Đây là một chiếc điện thoại vô cùng bền bỉ khi khung viền được cấu thành từ Armor Aluminum cứng cáp, hỗ trợ kháng bụi, nước chuẩn IP68 và đây cũng là một trong những sản phẩm được trang bị kính cường lực Corning Gorilla Glass Victus+ đầu tiên trên thị trường.',
'Hinh2.jpg',2019-12-13,120,1,1)
INSERT INTO DIENTHOAI VALUES
(N'Iphone 11',23000000,N'6.0"FullHD',N'6 GB',N'128 GB',N'12 MP,12MP',
N'Thông tin sản phẩm
Apple đã chính thức trình làng bộ 3 siêu phẩm iPhone 11, trong đó phiên bản iPhone 11 64GB có mức giá rẻ nhất nhưng vẫn được nâng cấp mạnh mẽ như iPhone Xr ra mắt trước đó.
Nâng cấp mạnh mẽ về camera
Nói về nâng cấp thì camera chính là điểm có nhiều cải tiến nhất trên thế hệ iPhone mới.',
'Hinh1.jpg',2019-12-16,160,2,2)
INSERT INTO DIENTHOAI VALUES
(N'Iphone 12',33000000,N'5.5"FullHD',N'4 GB',N'128 GB',N'12 MP,12MP',
N'Thông tin sản phẩm
Trong những tháng cuối năm 2020, Apple đã chính thức giới thiệu đến người dùng cũng như iFan thế hệ iPhone 12 series mới với hàng loạt tính năng bứt phá, thiết kế được lột xác hoàn toàn, hiệu năng đầy mạnh mẽ và một trong số đó chính là iPhone 12 64GB.',
'Hinh1.jpg',2019-12-04,200,2,2)
INSERT INTO DIENTHOAI VALUES
(N'Oppo Reno 4',14000000,N'5.5"FullHD',N'12 GB',N'128 GB',N'64 MP,12MP',
N'Thông tin sản phẩm
OPPO Reno4 - Chiếc điện thoại có thiết kế thời thượng, hiệu năng mạnh mẽ cùng bộ 4 camera siêu ấn tượng, tối ưu hóa cho chụp ảnh và quay phim siêu sắc nét, hứa hẹn sẽ là sản phẩm đáng để bạn nâng cấp của hãng OPPO.'
,'Hinh4.jpg',2019-12-09,240,1,3)
INSERT INTO DIENTHOAI VALUES
(N'Oppo Reno 5',16000000,N'6.5"2k',N'12 GB',N'256 GB',N'64 MP,12MP',
N'Thông tin sản phẩm
OPPO đã trình làng OPPO Reno5 5G phiên bản kết nối 5G internet siêu nhanh ra thị trường. Chiếc điện thoại với hàng loạt các tính năng nổi bật cùng vẻ ngoài thời thượng giúp tôn lên vẻ sang trọng cho người sở hữu.'
,'Hinh4.jpg',2019-12-06,180,1,3)





