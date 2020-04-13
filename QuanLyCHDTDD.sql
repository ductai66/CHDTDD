Create database QuanLyCHDTDD

use QuanLyCHDTDD

CREATE TABLE tblLoaiHang(
      	sMaLH  NVARCHAR(10) primary key NOT NULL,
      	sTenLH NVARCHAR(30)
);

CREATE TABLE tblMatHang(
      	sMaMH nvarchar(10) primary key NOT NULL,
      	sTenMH NVARCHAR(30),
      	iSoLuong INT,
      	sThoigianbaohanh nvarchar(20),
      	fGiaHang FLOAT,
      	sMaLH NVARCHAR(10) NOT NULL
);

Alter table tblMatHang ADD 
	Constraint FK_MaLH FOREIGN KEY(sMaLH) REFERENCES tblLoaiHang(sMaLH),
	CONSTRAINT CK_TGBH CHECK(sThoigianbaohanh IN (N'12 tháng',N'18 tháng',N'24 tháng'))
	

CREATE TABLE tblNhanVien(
      	sMaNV nvarchar(10) primary key NOT NULL,
      	sTenNV NVARCHAR(30),
      	sGioitinh nvarchar(3),
      	sDiachi NVARCHAR(50),
      	dNgaysinh DATE,
      	fLcb FLOAT,
		sSdt nvarchar(12),
		sTrangthai nvarchar(30)
);

drop table tblNhanVien

drop table tblHoaDon

drop table tblChiTietHoaDon

Create table tblKhachHang(
	sMaKH nvarchar(10) primary key not null,
	sTenKH nvarchar(30) not null,
	sGioitinh nvarchar(3),
	sDiachi nvarchar(30),
	sSdt nvarchar(12)
);

Create table tblHoaDon(
	sMaHD nvarchar(10) primary key not null,
	sMaNV nvarchar(10) not null,
	sMaKH nvarchar(10) not null,
	dNgaydat date
);

Alter table tblHoaDon ADD 
	Constraint FK_MaNV FOREIGN KEY(sMaNV) References tblNhanVien(sMaNV),
	Constraint FK_MaKH FOREIGN KEY(sMaKH) References tblKhachHang(sMaKH)


Create table tblChiTietHoaDon(
	sMaHD nvarchar(10) not null,
	sMaMH nvarchar(10) not null,
	iSoluong int,
	fGiaban float
);


ALTER TABLE tblChiTietHoaDon
ADD CONSTRAINT PK_chitiethd PRIMARY KEY (sMaHD, sMaMH);

ALTER TABLE tblChiTietHoaDon
ADD CONSTRAINT FK_CTDH_SoHD FOREIGN KEY (sMaHD)
REFERENCES tblHoaDon(sMaHD);

Alter table tblChiTietHoaDon ADD 
	Constraint FK_MaMH FOREIGN KEY(sMaMH) REFERENCES tblMatHang(sMaMH),
	CONSTRAINT iSoLuong CHECK(iSoluong>0),
	CONSTRAINT fGiaban CHECK(fGiaban>0)

drop table tblNhanVien
drop table tblLogin
drop table tblHoaDon
drop table tblChiTietHoaDon


INSERT INTO tblLoaiHang(sMaLH,sTenLH)
VALUES
(N'LH1',N'SmartPhone'),
(N'LH2',N'Ốp lưng'),
(N'LH3',N'Tai nghe'),
(N'LH4',N'Gậy selfie'),
(N'LH5',N'Loa')

INSERT INTO tblMatHang(sMaMH,sTenMH,iSoluong,sThoigianbaohanh,fGiaHang,sMaLH)
VALUES
(N'MH01',N'SamSung Galaxy S9',10,N'12 tháng',20999000,N'LH1'),
(N'MH02',N'SamSung Galaxy S10',10,N'12 tháng',24999000,N'LH1'),
(N'MH03',N'Iphone XS Max',10,N'12 tháng',33999000,N'LH1'),
(N'MH04',N'Redmi Note 8',10,N'18 tháng',4490000,N'LH1'),
(N'MH05',N'Oppo F7',10,N'12 tháng',9490000,N'LH1'),

(N'MH06',N'Ốp lưng S9',10,N'12 tháng',100000,N'LH2'),
(N'MH07',N'Ốp lưng S10',10,N'12 tháng',100000,N'LH2'),
(N'MH08',N'Ốp lưng XS Max',10,N'12 tháng',100000,N'LH2'),
(N'MH09',N'Ốp lưng Redmi Note 8',10,N'12 tháng',100000,N'LH2'),
(N'MH10',N'Ốp lưng F7',10,N'12 tháng',100000,N'LH2'),

(N'MH11',N'Tai Nghe S9',10,N'12 tháng',150000,N'LH3'),
(N'MH12',N'Tai Nghe S10',10,N'12 tháng',100000,N'LH3'),
(N'MH13',N'Tai Nghe XS Max',10,N'12 tháng',70000,N'LH3'),
(N'MH14',N'Tai Nghe Redmi Note 8',10,N'12 tháng',80000,N'LH3'),
(N'MH15',N'Tai Nghe F7',10,N'12 tháng',70000,N'LH3'),

(N'MH16',N'Gậy Selfe Mini Consalo CW1',10,N'12 tháng',50000,N'LH4'),
(N'MH17',N'Gậy Selfe Osmia OW2',10,N'12 tháng',70000,N'LH4'),
(N'MH18',N'Gậy Selfe Osmia OW4',10,N'12 tháng',70000,N'LH4'),
(N'MH19',N'Gậy Selfe OSmia OW5',10,N'12 tháng',70000,N'LH4'),
(N'MH20',N'Gậy Selfe Cosano HD-P7',10,N'12 tháng',70000,N'LH4'),

(N'MH21',N'Loa Bluetooth JBL Clip 3',10,N'12 tháng',1280000,N'LH5'),
(N'MH22',N'Loa Bluetooth JBL Pulse 4',10,N'12 tháng',5490000,N'LH5'),
(N'MH23',N'Loa Bluetooth Mozard E7',10,N'12 tháng',700000,N'LH5'),
(N'MH24',N'Loa Bluetooth Mozard H8030D',10,N'12 tháng',850000,N'LH5'),
(N'MH25',N'Loa Bluetooth JBL Filip 4',10,N'12 tháng',2690000,N'LH5')

INSERT INTO tblNhanVien(sMaNV,sTenNV,sGioitinh,sDiachi,dNgaysinh,fLcb,sSdt,sTrangthai)
VALUES
(N'NV01',N'Đỗ Thế Tài',N'Nam',N'Nam Định','2000/6/6',4500000,N'0369732412',N'Đang làm'),
(N'NV02',N'Nguyễn Hoàng Nam',N'Nam',N'Nam Định','2000/7/3',4300000,N'0354642456',N'Đang làm'),
(N'NV03',N'Cao Việt Đức',N'Nam',N'Nam Định','2000/10/9',4300000,N'097448544',N'Đang làm'),
(N'NV04',N'Trần Văn Đỉnh',N'Nam',N'Quảng Ninh','2000/6/6',4500000,N'037894525',N'Đang làm'),
(N'NV05',N'Trần Ngọc Thu',N'Nữ',N'Hà Nội','2000/11/9',4500000,N'0834568245',N'Đang làm'),
(N'NV06',N'Ngân Văn Đại',N'Nam',N'Hà Nội','2000/6/9',4400000,N'0369734521',N'Đang làm')


update tblNhanVien
set sTrangthai = N'Nghỉ'
where sMaNV = 'NV06'

INSERT INTO tblKhachHang(sMaKH,sTenKH,sGioitinh,sDiachi,sSdt)
VALUES
(N'KH01',N'Đào Thu Hà',N'Nữ',N'Thái Bình',N'0364728918'),
(N'KH02',N'Phạm Văn Hải',N'Nam',N'Hải Phòng',N'0374839484'),
(N'KH03',N'Đặng Đức Độ',N'Nam',N'Nam Định',N'0989543213'),
(N'KH04',N'Lưu Hà Anh',N'Nam',N'Hà Nội',N'0956789743'),
(N'KH05',N'Đặng Xuân Long',N'Nam',N'Hà Nội',N'0765423434')

INSERT INTO tblHoaDon(sMaHD,sMaNV,sMaKH,dNgaydat)
VALUES
(N'HD01',N'NV01',N'KH01','2019/12/6'),
(N'HD02',N'NV02',N'KH02','2020/1/3'),
(N'HD03',N'NV03',N'KH03','2019/12/8')


INSERT INTO tblChiTietHoaDon(sMaHD,sMaMH,iSoluong,fGiaban)
VALUES
(N'HD01',N'MH01',1,20999000),
(N'HD01',N'MH02',1,24999000),
(N'HD02',N'MH01',1,20999000),
(N'HD02',N'MH02',2,24999000),
(N'HD03',N'MH01',2,20999000),
(N'HD03',N'MH02',1,24999000)


select * from tblCHiTietHoadon


update tblChitiethoadon
set iSoluong = 2, fGiaban = 24999000
where sMaHD = 'HD03'and sMaMH ='MH02'

--------------------------------tblNhanVien-------------------------------



create view vv_nhanvien
as
	select sMaNV as[Mã Nhân Viên], sTenNV as[Tên Nhân Viên], sGioitinh as[Giới tính],sDiachi as[Địa chỉ], dNgaysinh as[Ngày sinh],fLcb as[Lương cơ bản],sSdt as[Số điện thoại],sTrangthai as[Trạng thái]
	from tblNhanVien where sTrangthai =N'Đang làm'

	drop view vv_nhanvien 

	select * from tblNhanVien

	select * from vv_nhanvien where [Mã Nhân Viên] ='NV01'

create proc sp_them_nv(@manv nvarchar(10),@tennv nvarchar(30),@gioitinh nvarchar(3),@diachi nvarchar(30),@ngaysinh date,@luong float,@sdt nvarchar(12),@trangthai nvarchar(30))
as
	begin
		Insert into tblNhanVien
		values(@manv,@tennv,@gioitinh,@diachi,@ngaysinh,@luong,@sdt,@trangthai)
	end

CREATE PROC sp_update_nv(@manv nvarchar(10),@tennv nvarchar(30),@gioitinh nvarchar(3),@diachi nvarchar(30),@ngaysinh date,@luong float,@sdt nvarchar(12),@trangthai nvarchar(30))
AS
	BEGIN
		UPDate tblNhanVien
		set sTenNV = @tennv,sGioitinh=@gioitinh,sDiachi=@diachi,dNgaysinh = @ngaysinh,fLcb=@luong,sSdt=@sdt,sTrangthai=@trangthai
		Where sMaNV=@manv
	END

CREATE PROC sp_remove_nv(@manv nvarchar(10))
as
	begin
		delete from tblNhanVien
		where sMaNV=@manv
	end

Create proc sp_remove_status(@manv nvarchar(10))
as
	begin
		update tblNhanVien
		set sTrangthai = N'Nghỉ'
		where sMaNV = @manv
	end


---------------------------tblKhachHang------------------------

Create View vv_khachhang
as
	Select sMaKH as[Ma khach hang],sTenKH as[Ten khach hang],sGioitinh as[Gioi tinh],sDiachi as[Dia chi],sSdt as[So dien thoai]
	from tblKhachHang

	select * from vv_khachhang where [Ma khach hang] = N'KH07' or [Ten khach hang] LIKE N'%Đặng%'

Create Proc sp_them_kh(@makh nvarchar(10),@tenkh nvarchar(30),@gioitinh nvarchar(3),@diachi nvarchar(30),@sdt nvarchar(12))
as
	Begin
		INSERT INTO tblKhachHang
		Values (@makh,@tenkh,@gioitinh,@diachi,@sdt)
	End

Create Proc sp_update_kh(@makh nvarchar(10),@tenkh nvarchar(30),@gioitinh nvarchar(3),@diachi nvarchar(30),@sdt nvarchar(12))
as
	Begin
		Update tblKhachHang
		Set sTenKH=@tenkh,sGioitinh=@gioitinh,sDiachi=@diachi,sSdt=@sdt
		Where sMaKH=@makh
	End

Create Proc sp_remove_kh(@makh nvarchar(10))
as
	Begin
		Delete from tblKhachHang
		Where sMaKH=@makh
	End


-------------------------tblMatHang-------------------------

create view ds_mathang
as
	select sMaMH AS "Mã mặt hàng", sTenMH AS "Tên mặt hàng", iSoLuong as "Số lượng", 
	sThoigianbaohanh as "Thời gian BH", fGiaHang as "Giá hàng", sTenLH AS "Tên loại hàng"
	from tblMatHang, tblLoaiHang
	where tblLoaiHang.sMaLH = tblMatHang.sMaLH

select * from ds_mathang
create proc them_mathang
(@mamh nvarchar(10),@tenmh nvarchar(30),@sl int,@TGBH NVARCHAR(20),@giahang float,@malh nvarchar(10))
as
	begin
		insert into tblMatHang
		values(@mamh,@tenmh,@sl,@TGBH,@giahang,@malh)
	end


create proc sua_mathang
(@mamh nvarchar(10),@tenmh nvarchar(30),@sl int,@TGBH NVARCHAR(20),@giahang float,@malh nvarchar(10))
as
begin
	update tblMatHang 
	set sTenMH = @tenmh, iSoLuong = @sl, sThoigianbaohanh = @TGBH, fGiaHang = @giahang, sMaLH = @malh
	where sMaMH = @mamh
end

create proc xoa_mathang
(@mamh nvarchar(10))
as
	begin
	delete from tblMatHang
	where sMaMH = @mamh
end


-----------------------------------tblHoaDon-----------------------

create view ds_hoadon
as
	select sMaHD AS "Mã hóa đơn" , tblNhanVien.sMaNV AS "Mã nhân viên", tblKhachHang.sMaKH AS "Mã khách hàng", dNgaydat as "Ngày đặt hàng"
	from tblNhanVien, tblKhachHang, tblHoaDon
	where tblNhanVien.sMaNV = tblHoaDon.sMaNV and tblKhachHang.sMaKH = tblHoaDon.sMaKH

select * from ds_hoadon

--thống kê hóa đơn theo ngày lập

create proc thongkehd_ngay
(@ngaydat date,@ngay date)
	as
		begin
		select hd.sMaHD as[Mã hóa đơn],hd.sMaNV as [Mã nhân viên],hd.sMaKH as [Mã khách hàng],hd.dNgaydat as [Ngày đặt] from tblHoaDon as hd
		where dNgaydat between @ngaydat and @ngay
		--where dNgaydat = @ngaydat
		end

execute thongkehd_ngay '2019/8/3','2020/5/5' 

drop proc thongkehd_ngay


-----------view_sp_hoadon-----------

create view vv_thanhtoanHD
as
	select c.sMaHD as [Mã hóa đơn], c.sMaMH as [Mã mặt hàng], c.iSoluong as [Số lượng], c.fGiaban as [Giá bán],SUM(c.iSoluong * fGiaban) as [Tổng tiền]
	from tblChiTietHoaDon as c 
	group by c.sMaHD,c.sMaMH,c.iSoluong,c.fGiaban


	select * from vv_thanhtoanHD

create proc sp_chitietTTHD(@mahd nvarchar(10))
as
	select * from vv_thanhtoanHD
	where [Mã hóa đơn] = @mahd

exec sp_chitietTTHD 'HD01'

create view vv_baocaoHD
as
	select hd.sMaHD,nv.sTenNV,kh.sTenKH,mh.sTenMH,hd.dNgaydat,tt.[Số lượng],tt.[Giá bán],tt.[Tổng tiền]
	from tblHoaDon as hd,tblNhanVien as nv,tblKhachHang as kh,tblMatHang as mh,vv_thanhtoanHD as tt
	where hd.sMaNV = nv.sMaNV and hd.sMaKH = kh.sMaKH and tt.[Mã mặt hàng] = mh.sMaMH and hd.sMaHD = tt.[Mã hóa đơn]


	select * from vv_baocaoHD


CREATE PROC sp_hd
(@mahd nvarchar(10))
as
begin
select hd.sMaHD,nv.sTenNV,kh.sTenKH,mh.sTenMH,hd.dNgaydat,tt.[Số lượng],tt.[Giá bán],tt.[Tổng tiền]
	from tblHoaDon as hd,tblNhanVien as nv,tblKhachHang as kh,tblMatHang as mh,vv_thanhtoanHD as tt
	where hd.sMaNV = nv.sMaNV and hd.sMaKH = kh.sMaKH and tt.[Mã mặt hàng] = mh.sMaMH and hd.sMaHD = tt.[Mã hóa đơn]
	and hd.sMaHD = @mahd
end

EXECUTE sp_hd N'HD01'

-----------------proc_thêm hóa đơn -------------

create proc sp_them_hd
(@mahd nvarchar(10),
@manv nvarchar(10),
@makh nvarchar(10),
@ngaydat date
)
as
	begin
		insert into tblHoaDon
		values(@mahd,@manv,@makh,@ngaydat)
	end

	drop proc sp_them_hd

create proc sp_update_hd(@mahd nvarchar(10),@manv nvarchar(10),@makh nvarchar(10),@ngaydat date)
as
	begin 
		update tblHoaDon
		Set sMaNV = @manv,sMaKH = @makh,dNgaydat = @ngaydat
		where sMaHD  = @mahd
	end

------------------------------------tblChiTietHoaDon---------------------------



create view ds_chitietHD as
	select sMaHD AS "Mã hóa đơn", sMaMH AS "Mã mặt hàng", iSoluong as "Số lượng", fGiaban as "Giá bán"
	from tblChiTietHoaDon

select * from ds_chitietHD

-- TÍNH TONG TIỀN CỦA TỪNG HÓA ĐƠN
CREATE PROC tongtien_hd
(@mahd nvarchar(10))
as
	begin
		select tblChiTietHoaDon.sMaHD AS "Mã hóa đơn" , Sum(iSoluong * fGiaban) as "Tổng tiền"
		from tblChiTietHoaDon
		where sMaHD = @mahd
		group by tblChiTietHoaDon.sMaHD
	end


EXECUTE tongtien_hd N'HD01'

Create proc sp_them_cthd(@mahd nvarchar(10),@mamh nvarchar(10),@soluong int,@giaban float)
as
	begin
		insert into tblChiTietHoaDon
		values(@mahd,@mamh,@soluong,@giaban)
	end


Create proc sp_update_cthd(@mahd nvarchar(10),@mamh nvarchar(10),@soluong int,@giaban float)
as
	begin
		update tblChiTietHoaDon
		set sMaHD = @mahd,sMaMH = @mamh,iSoluong = @soluong, fGiaban = @giaban
		where sMaHD = @mahd and sMaMH = @mamh
	end


	drop proc sp_update_cthd

	delete from tblHoadon where sMaHD = 'HD04'

	delete from tblchitiethoadon where sMaHD = 'HD04' and sMaMH ='MH04'



----------------------------------User---------------------

Create table tblLogin(
	Username nvarchar(50) Primary Key not null,
	Displayname nvarchar(50) not null,
	PassWord nvarchar(50) not null,
	sMaNV nvarchar(10) not null,
	Type nvarchar(10) not null
);
Alter table tblLogin ADD 
	Constraint FK_MaNV_Login FOREIGN KEY(sMaNV) REFERENCES tblNhanVien(sMaNV)

drop table tblLogin

Select * from tblLogin

Insert Into tblLogin
Values
	(N'dothetai8',N'Đỗ Thế Tài','2066','NV01','Admin'),
	(N'ngocthu1109',N'Trần Ngọc Thu','2066','NV02','User')

Insert Into tblLogin
Values
	(N'caovietduc',N'Cao Việt Đức','2066','NV03','User')


	select * from tblLogin where Username = N'dothetai8' and Password='2066'

Create Proc sp_login(@username nvarchar(50),@password nvarchar(50))
as
	Begin
		select * from tblLogin where Username=@username AND PassWord=@password
	End

	select * from tblKhachHang


Create proc sp_kh
as
	begin
		select * from tblKhachHang
	end


create view vv_info
as
	select tblNhanVien.sMaNV as[Mã NV],sTenNV as[Tên NV],sGioitinh as[Giới tính],sDiachi as[Địa chỉ]
	from tblNhanVien,tblLogin
	where tblNhanVien.sMaNV = tblLogin.sMaNV AND tblLogin.Username='dothetai8'

create view vv_login
as
	select * from tblLogin


create proc pr_info
(@username nvarchar(50))
as
begin
    select tblNhanVien.sMaNV as[Mã NV],sTenNV as[Tên NV],sGioitinh as[Giới tính],sDiachi as[Địa chỉ]
	from tblNhanVien,tblLogin
	where tblNhanVien.sMaNV = tblLogin.sMaNV AND tblLogin.Username= @username
end

execute pr_info 'ngocthu1109'


use QuanLyCuaHangDienThoai

select * from tblHangHoa where ((Mahang between 1 and 3) or (Mahang between 5 and 6))


select * from tblNhanVien

select * from tblNhanVien where sTenNV LIKE N'%Trần%'


select * from tblMatHang where fGiaHang > 100000
