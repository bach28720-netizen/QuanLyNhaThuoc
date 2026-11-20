HƯỚNG DẪN CHẠY PROJECT "QUẢN LÝ PHÒNG KHÁM MEDPRO" TRONG VISUAL STUDIO
========================================================================

1. TẠO CƠ SỞ DỮ LIỆU
   - Mở SQL Server Management Studio (hoặc công cụ tương đương), kết nối tới
     SQL Server instance của bạn.
   - Mở và chạy (Execute) file: Database\TaoCSDL_Medpro.sql
     File này sẽ tạo database "QuanLyPhongKhamMedpro" cùng toàn bộ bảng,
     và thêm sẵn 1 tài khoản Admin:
         Tài khoản : admin
         Mật khẩu  : 123456

2. KIỂM TRA CHUỖI KẾT NỐI (connection string)
   - Mở file: "QuanLyPhongKhamMedpro\App.config"
   - Theo mặc định, chuỗi kết nối trỏ tới "data source=." (SQL Server mặc định
     trên máy local, đăng nhập Windows - Integrated Security).
   - Nếu bạn dùng SQL Server Express, đổi "data source=." thành
     "data source=.\SQLEXPRESS" (hoặc tên instance SQL Server của bạn).

3. MỞ PROJECT TRONG VISUAL STUDIO
   - Mở file "QuanLyPhongKhamMedpro.sln" bằng Visual Studio (2019/2022, có cài
     workload ".NET desktop development").
   - Lưu ý: tên file/thư mục trong bộ này đã đổi sang không dấu (ASCII) để
     tránh lỗi hiển thị sai (mojibake) khi giải nén trên Windows. Code bên
     trong (namespace, giao diện tiếng Việt...) không bị ảnh hưởng gì.
   - Lần build/mở đầu tiên, Visual Studio sẽ tự động khôi phục (NuGet Package
     Restore) gói "EntityFramework" phiên bản 6.5.2 đã khai báo trong
     packages.config - cần có kết nối Internet cho bước này.
   - Nếu VS hỏi "Restore NuGet packages?" thì bấm "Restore".
   - Nhấn F5 (hoặc Ctrl+F5) để build và chạy.

4. GHI CHÚ VỀ ENTITY FRAMEWORK
   - Project gốc được thiết kế theo Entity Framework "Database First" (file
     model .edmx), nhưng file .edmx này không có trong bộ mã nguồn được bàn
     giao nên không thể khôi phục lại chính xác.
   - Vì vậy, ModelMedpro.Context.cs trong bộ file này đã được viết lại theo
     Entity Framework "Code First", ánh xạ (mapping) trực tiếp tới các bảng
     đã có sẵn trong CSDL (không tạo lại / không thay đổi schema CSDL).
   - Nếu muốn khôi phục lại đúng kiểu Database First bằng EF Designer, bạn có
     thể: Add New Item > ADO.NET Entity Data Model > EF Designer from
     database > chọn đúng 8 bảng hiện có, rồi xoá ModelMedpro.Context.cs bản
     Code First này đi để tránh trùng lặp.

5. CẤU TRÚC CHỨC NĂNG MỚI (phần Kiên - Phân quyền)
   - frmDoiMatKhau   : Đổi mật khẩu (mọi vai trò)
   - frmQuanLyUser   : Quản lý tài khoản đăng nhập (chỉ Admin)
   - frmQuanLyQuyen  : Quản lý vai trò / phân quyền (chỉ Admin)
   - frmNhanSu       : Danh sách nhân sự (chỉ Admin)
   - PasswordHelper.cs : hàm băm mật khẩu SHA-256 dùng chung cho toàn bộ app
   - Menu chính (frmMain) đã được ẩn/hiện tự động theo vai trò đăng nhập:
     Admin / Lễ tân / Bác sĩ / Dược sĩ (xem hàm PhanQuyen() trong frmMain.cs)
