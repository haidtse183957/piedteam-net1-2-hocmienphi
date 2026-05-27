namespace piedteam_net1_2_hocmienphi.repository;

public class Class1
{
}

// CODE FIRST | DATABASE FIRST
// ORM

// Thông thường để mà trên code có thể làm việc được với Database.
    // Thì mình cần phải ánh xạ (mapping) từ các table lên code để
    // dễ dàng thao tác với dữ liệu
    
// Database First:
// Mình làm việc với 1 Database đã có sẵn, (Create Database bằng SQL)
// Vô tạo Database nè, setup các field, các mối quan hệ, ràng buộc trong DB
// Sau đó ở trên code sử dụng các Driver hoặc thư viện ORM để
    // kết nối xuống Database
// Ở trên code sẽ tạo các class tương ứng với các table trong Database
// Thằng này sử dụng khi nào: Khi mình Database đã có sẵn và đang được sử dụng
    // trong nhiều năm. Được Join vào dự án MAintain
    
// Code First:
// Mình sẽ không setup Database thử công bằng các câu lệnh Query
    // Create Database, Create Contraint
// Mình sẽ Design Database bằng các class trên Code, trên Code setup ntn
    // thì Database sẽ được tạo ra như thế đó
    // Mình setup trên code các field, các relationship
    // Sau đó mình ánh xạ các đoạn code đó để tạo ra các table trong Database
// Vậy thì làm thế nào để ánh xạ được từ code xuống các table trong Database
    // Câu trả lời: ORM - Object Relational Mapping - Entity Framework
    // Nó sẽ đọc các class trên code, dọc các attribute, đọc các cấu hình
        // sau đó tạo ra các câu lệnh SQL để tạo các bảng.
    // Nó cũng là thằng kết hợp với LINQ
        // Khi sử dụng các hàm Where..., Translate sang SQL
        // .WHERE() => Select * from table where ...
// Thằng này được sử dụng khi:
    // Mình mới bắt đầu dự án, chưa có Database nào cả
    // Thiết kế bằng Code thì nó sẽ dễ dàng Maintain (Dễ nhìn,
        // dễ sửa đổi) hơn so với các câu lệnh SQL

// Nếu mà không biết về LINQ + EF thì coi như mất 95% sức mạnh    