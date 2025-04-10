# BonAppetit - Website mua bán bánh
### Rookies-BuiThiNhatNguyet
## Giới thiệu
Một website bán bánh trực tuyến được xây dựng bằng ASP.NET Core MVC. Người dùng có thể duyệt các loại bánh, thêm vào giỏ hàng, đặt hàng, và quản lý đơn hàng. Admin có thể quản lý sản phẩm, đơn hàng và người dùng.
## Kiến trúc dự án
Dự án áp dụng mô hình Clean Architecture kết hợp với Repository Pattern và Unit of Work để tách biệt các lớp:
- `Domain`: Các Entity, Interface
- `Application`: DTOs, Service Interfaces, Business Logic
- `Infrastructure`: Triển khai EF Core, Repository
- `WebUI`: Giao diện người dùng MVC
## Cấu trúc thư mục
- /BakeryShop.WebUI        : ASP.NET Core MVC frontend
- /BakeryShop.Application  : DTOs, service interfaces
- /BakeryShop.Domain       : Entities, enums
- /BakeryShop.Infrastructure: EF Core, Repository implementation
## Đang phát triển
- [x] Tạo structure project
- [x] Xây dựng database
- [ ] Chức năng đăng ký / đăng nhập
- [ ] Xem sản phẩm, chọn sản phẩm
- [ ] Quản lý giỏ hàng
- [ ] Đặt hàng
- [ ] Giao diện responsive hoàn chỉnh