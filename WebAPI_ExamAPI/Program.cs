using WebAPI_ExamAPI;
using WebAPI_ExamAPI.DBFactory;
using WebAPI_ExamAPI.Reponsitories;
using WebAPI_ExamAPI.Responsitories;
using WebAPI_ExamAPI.Service;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls(
    "https://localhost:5001"
);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<ExamService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
