create database ["QL_NhaThuoc"]
use ["QL_NhaThuoc"]

create table NhanVien
(
	maNV nvarchar(10) not null,
	ho_ten nvarchar(50),
	gioi_tinh nvarchar(10),
	tuoi int,
	dia_chi nvarchar(200),
	email nvarchar(50),
	soDT char(10),
	chuc_vu nvarchar(50),
	ten_DN nvarchar(20),
	matkhau nvarchar(20),
	constraint PK_NhanVien primary key (maNV)
)

create table KhachHang
(
	maKH nvarchar(10) not null,/*Mã khách hàng được quy định là số điện thoại */
	ho_ten nvarchar(50),
	gioi_tinh nvarchar(10),
	tuoi int,
	soDT char(10),
	diem int,
	constraint PK_KhachHang PRIMARY KEY (maKH)
)

create table NhomThuoc
(
	ma_nhom nvarchar(10)not null,
	ten_nhom nvarchar(50)
	constraint PK_NhomThuoc PRIMARY KEY (ma_nhom)
)

create table Thuoc
(
	ma_thuoc nvarchar(10) not null,
	ma_nhom nvarchar(10) not null,
	ten_thuoc nvarchar(50),
	cong_dung nvarchar(200),
	thanh_phan nvarchar(200),
	xuat_xu nvarchar (50),
	dvt nvarchar(10),
	gia_ban int,
	so_luong int,
	constraint PK_Thuoc PRIMARY KEY (ma_thuoc),
	constraint FK_Thuoc_NhomThuoc foreign key (ma_nhom) references NhomThuoc(ma_nhom)
)

create table HoaDonNhap
(
	maHD_Nhap nvarchar(10) not null,
	maNV nvarchar(10) not null,
	ngaynhap datetime,
	ten_nha_cung_cap nvarchar(50),
	tong_tien int,
	constraint PK_HoaDonNhap PRIMARY KEY (maHD_Nhap),
	constraint FK_HoaDonNhap_NhanVien FOREIGN KEY (maNV) REFERENCES NhanVien(maNV)
)


create table CTHoaDonNhap
(
	maHD_Nhap nvarchar(10) not null,
	ma_thuoc nvarchar(10) not null,
	gia_von int,
	SL_Nhap int,
	constraint PK_CTHoaDonNhap PRIMARY KEY (maHD_Nhap,ma_thuoc),
	constraint FK_CTHoaDonNhap_Thuoc FOREIGN KEY (ma_thuoc) REFERENCES Thuoc(ma_thuoc),
	constraint FK_CTHoaDonNhap_HoaDonNHap FOREIGN KEY (maHD_Nhap) REFERENCES HoaDonNHap(maHD_Nhap)
)

create table HoaDonXuat
(
	maHD_Xuat nvarchar(10) not null ,
	maNV nvarchar(10) not null,
	maKH nvarchar(10),
	ngay_xuat datetime,
	tong_tien int,
	constraint PK_HoaDonXuat PRIMARY KEY (maHD_Xuat),
	constraint FK_HoaDonXuat_NhanVien FOREIGN KEY (maNV) REFERENCES NhanVien(maNV),
	constraint FK_HoaDonXuat_KhachHang FOREIGN KEY (maKH) REFERENCES KhachHang(maKH)
) 

create table CTHoaDonXuat
(
	maHD_Xuat nvarchar(10) not null ,
	ma_thuoc nvarchar(10) not null,
	gia_ban int,
	SL_ban int,
	constraint PK_CTHoaDonXuat PRIMARY KEY (maHD_Xuat,ma_thuoc),
	constraint FK_CTHoaDonXuat_Thuoc FOREIGN KEY (ma_thuoc) REFERENCES Thuoc(ma_thuoc),
	constraint FK_CTHoaDonXuat_HoaDonXuat FOREIGN KEY (maHD_Xuat) REFERENCES HoaDonXuat(maHD_Xuat)
)

drop table CTHoaDonXuat
drop table HoaDonXuat
insert into NhanVien values('NV001',N'Nnguyễn Văn A',N'Nam',32,N'1 Trường Chinh',N'ABC@gmail.com','0123456789',N'Nhân Viên',N'abc',N'123')
insert into KhachHang values('0123456789',N'Nguyễn văn B',N'Nam',20,'0123456789',1)

<<<<<<< HEAD
select*from HoaDonXuat
select * from  CTHoaDonXuat
select * from Thuoc
select * from KhachHang
=======

select * from Thuoc
>>>>>>> c98fb80c62c3ddb36489d5a1b348819f75c45f9f
