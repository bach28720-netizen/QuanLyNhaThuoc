USE QuanLyPhongKhamMedpro;
GO

-- 1. Thêm 2 cột Loại thiết bị và Số lượng vào bảng Equipments có sẵn
IF COL_LENGTH('dbo.Equipments', 'EquipType') IS NULL
BEGIN
    ALTER TABLE dbo.Equipments ADD EquipType NVARCHAR(100) NULL;
END
GO

IF COL_LENGTH('dbo.Equipments', 'Quantity') IS NULL
BEGIN
    ALTER TABLE dbo.Equipments ADD Quantity INT NOT NULL CONSTRAINT DF_Equipments_Quantity DEFAULT(1);
END
GO

-- 2. Tạo bảng Hóa đơn & Chi tiết hóa đơn nối với bảng Medicines có sẵn
IF OBJECT_ID('dbo.HoaDon', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.HoaDon
    (
        MaHD VARCHAR(20) NOT NULL PRIMARY KEY,
        NgayLap DATETIME NOT NULL CONSTRAINT DF_HoaDon_NgayLap DEFAULT(GETDATE()),
        TenKH NVARCHAR(100) NULL,
        TongTien DECIMAL(18,2) NOT NULL DEFAULT(0)
    );
END
GO

IF OBJECT_ID('dbo.ChiTietHoaDon', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChiTietHoaDon
    (
        MaCTHD INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        MaHD VARCHAR(20) NOT NULL,
        MaThuoc VARCHAR(20) NOT NULL,
        SoLuongBan INT NOT NULL,
        ThanhTien DECIMAL(18,2) NOT NULL,
        CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY(MaHD)
            REFERENCES dbo.HoaDon(MaHD) ON DELETE CASCADE,
        CONSTRAINT FK_ChiTietHoaDon_Medicines FOREIGN KEY(MaThuoc)
            REFERENCES dbo.Medicines(MedID)
    );
END
GO