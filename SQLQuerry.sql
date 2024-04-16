CREATE DATABASE OriCafe;
USE OriCafe;

-- -- Bảng Quán cà phê
 CREATE TABLE Quan_Ca_Phe (
     id int PRIMARY KEY IDENTITY(1,1),
     ten_quan nvarchar(255) NOT NULL,
    dia_chi nvarchar(255) NOT NULL,
     dien_thoai varchar(255) NOT NULL,
     email varchar(255),
     -- logo blob,
     trang_thai int NOT NULL
 );
 
-- -- Bảng Nhân viên
 CREATE TABLE Nhan_Vien (
     id int PRIMARY KEY IDENTITY(1,1),
     ten_nhan_vien nvarchar(255) NOT NULL,
     dia_chi nvarchar(255) NOT NULL,
     dien_thoai varchar(255) NOT NULL,
     email varchar(255),
     trang_thai int NOT NULL,
     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id)
 );

-- -- Bảng Khách hàng
 CREATE TABLE Khach_Hang (
     id int PRIMARY KEY IDENTITY(1,1),
     ten_khach_hang nvarchar(255) NOT NULL,
     dia_chi nvarchar(255) NOT NULL,
     dien_thoai varchar(255) NOT NULL,
     email varchar(255),
     diem_tich_luy int NOT NULL,
     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id)
 );

-- -- Bảng Loại sản phẩm
 CREATE TABLE Loai_San_Pham (
     id int PRIMARY KEY IDENTITY(1,1),
     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id),
     ten_loai_san_pham nvarchar(255) NOT NULL
 );

-- -- Bảng Sản phẩm
 CREATE TABLE San_Pham (
     id int PRIMARY KEY IDENTITY(1,1),
     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id),
     id_loai_san_pham int FOREIGN KEY REFERENCES Loai_San_Pham(id),
     ten_san_pham nvarchar(255) NOT NULL,
     gia_ban FLOAT NOT NULL,
     mo_ta text,
     -- hinh_anh blob
 );

-- -- Bảng Hóa đơn
 CREATE TABLE Hoa_Don (
     id int PRIMARY KEY IDENTITY(1,1),
     ngay_tao datetime NOT NULL,
     tong_tien int NOT NULL,
     trang_thai int NOT NULL,
     id_nhan_vien int FOREIGN KEY REFERENCES Nhan_Vien(id),
     id_khach_hang int FOREIGN KEY REFERENCES Khach_Hang(id),
     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id)
 );

 CREATE TRIGGER UpdateTotalAmount
ON Chi_Tiet_Hoa_Don
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted) OR EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE Hoa_Don
        SET tong_tien = (
            SELECT SUM(so_luong * gia_ban)
            FROM Chi_Tiet_Hoa_Don
            WHERE Chi_Tiet_Hoa_Don.id_hoa_don = Hoa_Don.id
        )
        WHERE id IN (
            SELECT id_hoa_don
            FROM inserted
            UNION
            SELECT id_hoa_don
            FROM deleted
        );
    END
END;
select * from Chi_Tiet_Hoa_Don
 UPDATE Hoa_Don
SET tong_tien = NULL;
-- -- Bảng Chi tiết hóa đơn
 CREATE TABLE Chi_Tiet_Hoa_Don (
     id int PRIMARY KEY IDENTITY(1,1),
     so_luong int NOT NULL,
     gia_ban FLOAT NOT NULL,
     id_hoa_don int FOREIGN KEY REFERENCES Hoa_Don(id),
     id_san_pham int FOREIGN KEY REFERENCES San_Pham(id)
 );

-- -- Bảng Tài khoản
 CREATE TABLE Tai_Khoan (
     id int PRIMARY KEY IDENTITY(1,1),
     ten_tai_khoan varchar(255) NOT NULL,
     mat_khau varchar(255) NOT NULL,
     vai_tro int NOT NULL,
     trang_thai int NOT NULL,
     id_quan int FOREIGN KEY REFERENCES Quan_Ca_Phe(id),
     id_nhan_vien int FOREIGN KEY REFERENCES Nhan_Vien(id)
 );

-- -- Bảng Quyền hạn
 CREATE TABLE Quyen_Han (
     id int PRIMARY KEY IDENTITY(1,1),
     ten_quyen_han varchar(255) NOT NULL,
     mo_ta text
 );

-- -- Bảng Phân quyền
 CREATE TABLE Phan_Quyen (
     id int PRIMARY KEY IDENTITY(1,1),
     id_tai_khoan int FOREIGN KEY REFERENCES Tai_Khoan(id),
     id_quyen_han int FOREIGN KEY REFERENCES Quyen_Han(id)
 );

-- Thêm dữ liệu
INSERT INTO Quan_Ca_Phe (ten_quan, dia_chi, dien_thoai, email, trang_thai)
VALUES 
('Ha Cha', '274 Ngọc Lâm', '0123456789', '', 1);
INSERT INTO Quan_Ca_Phe (ten_quan, dia_chi, dien_thoai, email, trang_thai)
VALUES 
('The Coffee House', N'58 Triều Khúc', '0965239954', 'patuan1303@gmail.com', 1);

update  Quan_Ca_Phe
set email= N'patuan1303@gmail.com'
where id = 1

select * from Nhan_Vien

SELECT * FROM Quan_Ca_Phe

INSERT Nhan_Vien (ten_nhan_vien, dia_chi, dien_thoai, trang_thai, id_quan)
VALUES
('Ngọc', 'Hà Nội', '0123456789', 1, 1),
('Tuấn Anh', 'Hà Nội', '0123456789', 1, 1);
update  Nhan_Vien
set ten_nhan_vien= N'Lê Văn Huyên',dia_chi=N'Hà Nội'
where id = 4

 INSERT Nhan_Vien (ten_nhan_vien, dia_chi, dien_thoai, trang_thai, id_quan)
VALUES
(N'Lê Huyền Trang', N'Hà Nội', '0123456789', 1, 2),
(N'Lê Tuấn Anh',N'Hà Nội', '0123456789', 1, 2),
(N'Nguyễn Ngọc', N'Hà Nội', '0123456789', 1, 2),
(N'Hoàng Thị Phương Anh', N'Hà Nội', '0123456789', 1, 2),
(N'Đỗ Quốc Huy', N'Hà Nội', '0123456789', 1, 2),
(N'Đỗ Kim Anh', N'Hà Nội', '0123456789', 1, 2);

SELECT * FROM Nhan_Vien

INSERT Loai_San_Pham (id_quan, ten_loai_san_pham)
VALUES
(1, N'Đồ uống'),
(1, N'Bánh'),
(1, N'Khác');
SELECT * FROM San_Pham

INSERT San_Pham (id_quan, id_loai_san_pham, ten_san_pham, gia_ban)
VALUES
(1, 4, N'Cà phê đen', 15000),
(2, 1, N'Cà phê sữa', 15000),
(2, 1, N'Cappuccino', 15000),
(2, 1, N'Cà phê đá', 15000),
(2, 1, N'Mocha', 15000),
(2, 2, N'Bánh ngọt', 15000),
(2, 2, N'Bánh mì toast', 15000),
(2, 3, N'Hạt hướng dương', 15000),
(2, 3, N'Hạt điều', 15000),
(2, 4, N'Sandwich', 15000),
(2, 4, N'Sandwich', 15000);


---- !!! DANGER !!!
-- USE master
-- DROP DATABASE OriCafe


INSERT Khach_Hang (ten_khach_hang, dia_chi, dien_thoai, email, diem_tich_luy,id_quan)
VALUES
(N'Nguyễn Thị Vân Anh', 'Hà Nội', '0123456789', 'nguyenvananh290903@gmail.com', 20,1),
(N'Lê Mai Linh', 'Hà Nội', '0123456789', '19A10010062@students.hou.edu.vn', 34,1),
(N'Phạm Thị Anh Phiên', 'Hà Nội', '0123456789', 'Phien301002@gmail.com', 25,1),
(N'Đỗ Hải Nam', 'Hà Nội', '0123456789', 'daddyhome1811@gmail.com', 27,1),
(N'Lê Đức Mạnh', 'Hà Nội', '0123456789', 'manhdz1709@gmail.com', 54,1),
(N'Phạm Tuấn Phong', 'Hà Nội', '0123456789', 'mochimochipo1122@gmail.com', 32,1),
(N'Đoàn Thị Thu Thảo', 'Hà Nội', '0123456789', 'vietanhdj2k3@gmail.com', 2,1),
(N'Nguyễn Văn Tùng', 'Hà Nội', '0123456789', 'tungnguyentn12345@gmail.com', 19,1),
(N'Vũ Việt Anh', 'Hà Nội', '0123456789', 'vanh3117@gmail.com', 42,1);

SELECT * FROM Khach_Hang

update  Khach_Hang
set dia_chi=N'Hà Nội'


INSERT Loai_San_Pham (id_quan, ten_loai_san_pham)
VALUES
(2, N'Đồ uống'),
(2, N'Bánh'),
(2, N'Khác'),
(2, N'Đồ ăm nhẹ');


SELECT * FROM Loai_San_Pham
 CREATE TABLE Hoa_Don (
     id int PRIMARY KEY IDENTITY(1,1),
     ngay_tao datetime NOT NULL,
     tong_tien int NOT NULL,
     trang_thai int NOT NULL,
     id_nhan_vien int FOREIGN KEY REFERENCES Nhan_Vien(id),
     id_khach_hang int FOREIGN KEY REFERENCES Khach_Hang(id),
     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id)
 );


INSERT Hoa_Don (ngay_tao, tong_tien,trang_thai,id_nhan_vien,id_khach_hang,id_quan)
VALUES
('2024-04-08',5790000,1,1,1,1);

SELECT * FROM Chi_Tiet_Hoa_Don

delete 
from Chi_Tiet_Hoa_Don
where id=2

INSERT Chi_Tiet_Hoa_Don (so_luong, gia_ban,id_hoa_don,id_san_pham)
VALUES
(5,10000,1,15);


Create proc Proc_HoaDon
as
begin
select Hoa_Don.id,Hoa_Don.id_quan,Hoa_Don.id_khach_hang,Hoa_Don.id_nhan_vien,Quan_Ca_Phe.ten_quan,Khach_Hang.ten_khach_hang,Nhan_Vien.ten_nhan_vien,Hoa_Don.ngay_tao,Hoa_Don.tong_tien,Hoa_Don.trang_thai
from Hoa_Don,Nhan_Vien,Khach_Hang,Quan_Ca_Phe
where Hoa_Don.id_khach_hang = Khach_Hang.id and Hoa_Don.id_nhan_vien = Nhan_Vien.id and Hoa_Don.id_quan = Quan_Ca_Phe.id
end

exec Proc_HoaDon
drop proc Proc_HoaDon

CREATE PROCEDURE Proc_GetInvoiceDetail
    @id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
		Chi_Tiet_Hoa_Don.id_hoa_don,
        Chi_Tiet_Hoa_Don.id,
		ten_san_pham,
        so_luong,
        Chi_Tiet_Hoa_Don.gia_ban
    FROM 
        Chi_Tiet_Hoa_Don,San_Pham
    WHERE 
		Chi_Tiet_Hoa_Don.id_san_pham = San_Pham.id  and @id=Chi_Tiet_Hoa_Don.id_hoa_don;
END
drop proc Proc_GetInvoiceDetail
exec Proc_GetInvoiceDetail @id='1'

CREATE PROCEDURE DeleteProduct
    @Id INT
AS 
BEGIN
    DELETE FROM San_Pham
    WHERE San_Pham.id = @Id;
END

exec DeleteProduct @Id = 15
select * from San_Pham
