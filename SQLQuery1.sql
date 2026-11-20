USE QuanLyPhongKhamMedpro;
GO

-- 1. Tạo 2 bảng mở rộng cho phần khám bệnh của Phước
IF OBJECT_ID('dbo.Examinations', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Examinations
    (
        ExaminationID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ApptID INT NOT NULL,
        Symptoms NVARCHAR(1000) NULL,
        Diagnosis NVARCHAR(1000) NULL,
        Conclusion NVARCHAR(1000) NULL,
        ExaminationDate DATETIME NOT NULL CONSTRAINT DF_Examinations_ExaminationDate DEFAULT(GETDATE()),
        CONSTRAINT UQ_Examinations_ApptID UNIQUE(ApptID),
        CONSTRAINT FK_Examinations_Appointments FOREIGN KEY(ApptID)
            REFERENCES dbo.Appointments(ApptID)
    );
END
GO

IF OBJECT_ID('dbo.ExaminationServices', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ExaminationServices
    (
        ExaminationServiceID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ExaminationID INT NOT NULL,
        ServiceID VARCHAR(20) NOT NULL,
        Quantity INT NOT NULL CONSTRAINT DF_ExaminationServices_Quantity DEFAULT(1),
        UnitPrice DECIMAL(18,2) NOT NULL,
        CONSTRAINT FK_ExaminationServices_Examinations FOREIGN KEY(ExaminationID)
            REFERENCES dbo.Examinations(ExaminationID) ON DELETE CASCADE,
        CONSTRAINT FK_ExaminationServices_Services FOREIGN KEY(ServiceID)
            REFERENCES dbo.Services(ServiceID),
        CONSTRAINT CK_ExaminationServices_Quantity CHECK(Quantity > 0),
        CONSTRAINT CK_ExaminationServices_UnitPrice CHECK(UnitPrice >= 0)
    );
END
GO

UPDATE dbo.Appointments
SET Status = N'Chờ khám'
WHERE Status IS NULL OR LTRIM(RTRIM(Status)) = '';
GO

-- 2. Thêm vai trò & 1 tài khoản Bác sĩ mẫu (nếu chưa có) để Form Đặt lịch/Khám bệnh có dữ liệu chọn
IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleName = N'Bác sĩ')
BEGIN
    INSERT INTO dbo.Roles (RoleName) VALUES (N'Bác sĩ'), (N'Lễ tân'), (N'Dược sĩ');
END

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'bacsi1')
BEGIN
    DECLARE @DocRoleID INT = (SELECT TOP 1 RoleID FROM dbo.Roles WHERE RoleName = N'Bác sĩ');
    INSERT INTO dbo.Users (Username, PasswordHash, FullName, RoleID)
    VALUES ('bacsi1', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'BS. Nguyễn Văn A', @DocRoleID);
END
GO