--CREATE DATABASE OriCafe;
USE OriCafe;

-- -- Bảng Quán cà phê
-- CREATE TABLE Quan_Ca_Phe (
--     id int PRIMARY KEY IDENTITY(1,1),
--     ten_quan nvarchar(255) NOT NULL,
--     dia_chi nvarchar(255) NOT NULL,
--     dien_thoai varchar(255) NOT NULL,
--     email varchar(255),
--     -- logo blob,
--     trang_thai int NOT NULL
-- );

-- -- Bảng Nhân viên
-- CREATE TABLE Nhan_Vien (
--     id int PRIMARY KEY IDENTITY(1,1),
--     ten_nhan_vien nvarchar(255) NOT NULL,
--     dia_chi nvarchar(255) NOT NULL,
--     dien_thoai varchar(255) NOT NULL,
--     email varchar(255),
--     trang_thai int NOT NULL,
--     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id)
-- );

-- -- Bảng Khách hàng
-- CREATE TABLE Khach_Hang (
--     id int PRIMARY KEY IDENTITY(1,1),
--     ten_khach_hang nvarchar(255) NOT NULL,
--     dia_chi nvarchar(255) NOT NULL,
--     dien_thoai varchar(255) NOT NULL,
--     email varchar(255),
--     diem_tich_luy int NOT NULL,
--     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id)
-- );

-- -- Bảng Loại sản phẩm
-- CREATE TABLE Loai_San_Pham (
--     id int PRIMARY KEY IDENTITY(1,1),
--     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id),
--     ten_loai_san_pham nvarchar(255) NOT NULL
-- );

-- -- Bảng Sản phẩm
-- CREATE TABLE San_Pham (
--     id int PRIMARY KEY IDENTITY(1,1),
--     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id),
--     id_loai_san_pham int FOREIGN KEY REFERENCES Loai_San_Pham(id),
--     ten_san_pham nvarchar(255) NOT NULL,
--     gia_ban FLOAT NOT NULL,
--     mo_ta text,
--     -- hinh_anh blob
-- );

-- -- Bảng Hóa đơn
-- CREATE TABLE Hoa_Don (
--     id int PRIMARY KEY IDENTITY(1,1),
--     ngay_tao datetime NOT NULL,
--     tong_tien int NOT NULL,
--     trang_thai int NOT NULL,
--     id_nhan_vien int FOREIGN KEY REFERENCES Nhan_Vien(id),
--     id_khach_hang int FOREIGN KEY REFERENCES Khach_Hang(id),
--     id_quan INT FOREIGN KEY REFERENCES Quan_Ca_Phe(id)
-- );

-- -- Bảng Chi tiết hóa đơn
-- CREATE TABLE Chi_Tiet_Hoa_Don (
--     id int PRIMARY KEY IDENTITY(1,1),
--     so_luong int NOT NULL,
--     gia_ban FLOAT NOT NULL,
--     id_hoa_don int FOREIGN KEY REFERENCES Hoa_Don(id),
--     id_san_pham int FOREIGN KEY REFERENCES San_Pham(id)
-- );

-- -- Bảng Tài khoản
-- CREATE TABLE Tai_Khoan (
--     id int PRIMARY KEY IDENTITY(1,1),
--     ten_tai_khoan varchar(255) NOT NULL,
--     mat_khau varchar(255) NOT NULL,
--     vai_tro int NOT NULL,
--     trang_thai int NOT NULL,
--     id_quan int FOREIGN KEY REFERENCES Quan_Ca_Phe(id),
--     id_nhan_vien int FOREIGN KEY REFERENCES Nhan_Vien(id)
-- );

-- -- Bảng Quyền hạn
-- CREATE TABLE Quyen_Han (
--     id int PRIMARY KEY IDENTITY(1,1),
--     ten_quyen_han varchar(255) NOT NULL,
--     mo_ta text
-- );

-- -- Bảng Phân quyền
-- CREATE TABLE Phan_Quyen (
--     id int PRIMARY KEY IDENTITY(1,1),
--     id_tai_khoan int FOREIGN KEY REFERENCES Tai_Khoan(id),
--     id_quyen_han int FOREIGN KEY REFERENCES Quyen_Han(id)
-- );

-- Thêm dữ liệu
INSERT INTO Quan_Ca_Phe (ten_quan, dia_chi, dien_thoai, email, trang_thai)
VALUES 
('Ha Cha', '274 Ngọc Lâm', '0123456789', '', 1);

SELECT * FROM Quan_Ca_Phe

INSERT Nhan_Vien (ten_nhan_vien, dia_chi, dien_thoai, trang_thai, id_quan)
VALUES
('Ngọc', 'Hà Nội', '0123456789', 1, 1),
('Tuấn Anh', 'Hà Nội', '0123456789', 1, 1);

SELECT * FROM Nhan_Vien

INSERT Loai_San_Pham (id_quan, ten_loai_san_pham)
VALUES
(1, N'Đồ uống'),
(1, N'Bánh'),
(1, N'Khác');
SELECT * FROM Loai_San_Pham

INSERT San_Pham (id_quan, id_loai_san_pham, ten_san_pham, gia_ban)
VALUES
(1, 3, N'Cà phê đen', 15000),
(1, 3, N'Cà phê sữa', 20000),
(1, 3, N'Bạc sỉu', 22000),
(1, 4, N'Bánh quy', 3000),
(1, 5, N'Hạt hướng dương', 10000);


---- !!! DANGER !!!
-- USE master
-- DROP DATABASE OriCafe


