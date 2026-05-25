var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

// Kiến trúc 3 layer (Tầng)

// Tầng API
    // Chịu trách nhiệm khai báo các Endpoint,
        // nhận request, trả response
    // Config hệ thống
    // Tầng API gọi tới Service
// Tầng Service
    // Chịu trách nhiệm xử lý nghiệp vụ
    // Tương tác với tầng Repository để lấy dữ liệu
    // Tầng Service gọi tới Repository
// Tầng Repository
    // Chịu trách nhiệm tương tác với database 
    // Cấu hình những thứ liên quan tới database

// A có 1 cái Req là đăng nhập vào hệ thống
    // Tầng API: Muốn đăng nhập vào hệ thống a
        // Chui vô đây nè: POST /api/auth/login
            // Nhận request body {email: "hai", password: "123"}
    // Tầng API lúc này gọi xuống tầng Service có cái hàm là
        // Xử lí login: LoginHandler(email, password)
        // Lúc này hàm login trong Service hãy chạy như sau
            // Kiểm tra email này có tồn tại trong database hay không
            // Người dùng này có bị ban hay ko
            // Nếu có lỗi thì trả về lỗi
            // Nếu không có lỗi thì trả về Token đăng nhập
    // Tầng Service lúc này gọi xuống tầng Repository có cái hàm là
        // GetUserByEmail(email)
        // Hàm này sẽ hạy câu lệnh SQL để
            // lấy thông tin người dùng ra khỏi database
            
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}