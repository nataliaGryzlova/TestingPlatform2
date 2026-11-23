using Microsoft.EntityFrameworkCore;
using TestingPlatform.Middlewares;
using Serilog;
using Serilog.Formatting.Json;
using TestingPlatform.Infrastructure.Data;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Infrastructure.Repositories;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        formatter: new JsonFormatter(),
        path: "logs/structured-.json")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps("TestingPlatform.Infrastructure");
    cfg.AddMaps(typeof(Program).Assembly);
});
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();