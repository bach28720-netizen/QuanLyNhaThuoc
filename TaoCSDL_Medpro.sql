CREATE DATABASE QuanLyPhongKhamMedpro;
GO
USE QuanLyPhongKhamMedpro;
GO

-- 1. Bảng Phân Quyền (Phục vụ phần của Kiên)
CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL -- Admin, Bác sĩ, Lễ tân, Dược sĩ
);

-- 2. Bảng Người Dùng (Phục vụ phần của Kiên: frmQuanLyUser, frmNhanSu)
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash VARCHAR(256) NOT NULL, -- Lưu pass băm SHA-256
    FullName NVARCHAR(100) NOT NULL,
    RoleID INT FOREIGN KEY REFERENCES Roles(RoleID)
);

-- 3. Bảng Bệnh Nhân (Phục vụ phần của Phước: frmBenhNhan)
CREATE TABLE Patients (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Phone VARCHAR(15),
    Address NVARCHAR(255),
    DOB DATE
);

-- 4. Bảng Lịch Khám (Logic điểm cao cho Phước: đẩy từ Lễ tân sang Bác sĩ)
CREATE TABLE Appointments (
    ApptID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT FOREIGN KEY REFERENCES Patients(PatientID),
    DoctorID INT FOREIGN KEY REFERENCES Users(UserID),
    ApptDate DATETIME,
    Status NVARCHAR(50) -- Ví dụ: Chờ khám, Đang khám, Đã xong
);

-- 5. Bảng Dịch Vụ Khám (frmDichVu)
CREATE TABLE Services (
    ServiceID VARCHAR(20) PRIMARY KEY,
    ServiceName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2)
);

-- 6. Bảng Thuốc (Phục vụ Bách: frmThuoc và Transaction trừ tồn kho)
CREATE TABLE Medicines (
    MedID VARCHAR(20) PRIMARY KEY,
    MedName NVARCHAR(100) NOT NULL,
    Unit NVARCHAR(20),
    Price DECIMAL(18,2),
    StockQuantity INT -- Số lượng tồn kho 
);

-- 7. Bảng Hóa Đơn Tổng (Phục vụ Bách: frmHoaDon, frmBaoCao)
CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT FOREIGN KEY REFERENCES Patients(PatientID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID), -- Lễ tân hoặc Dược sĩ thu tiền
    CreatedDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(18,2)
);

-- 8. Bảng Thiết Bị (frmThietBi)
CREATE TABLE Equipments (
    EquipID VARCHAR(20) PRIMARY KEY,
    EquipName NVARCHAR(100) NOT NULL,
    Status NVARCHAR(50) 
);

-- Thêm sẵn 1 dòng Admin khởi tạo để Kiên làm frmLogin và băm pass
INSERT INTO Roles (RoleName) VALUES ('Admin');
INSERT INTO Users (Username, PasswordHash, FullName, RoleID) 
VALUES ('admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Quản trị viên', 1);
-- Mật khẩu hash ở trên mặc định là 123456 (đã băm SHA-256)