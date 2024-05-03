using Microsoft.EntityFrameworkCore;
using StudentPerformance.Repository.Common;
using StudentPerformance.Entity.Models;
using StudentPerformance.Business.Business;
using StudentPerformance.Business.Contract;
using StudentPerformance.Repository.Contract;
using StudentPerformance.Repository.Repository;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<DbContext, StudentAssgnContext>();
builder.Services.AddScoped<IStudentPerformanceBusiness, StudentPerformanceBusiness>();
builder.Services.AddScoped<IStudentPerformanceRepository, StudentPerformanceRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentAssgnContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("StudentAssgnConnectionString"));
});


//AUTOMAPPER
builder.Services.AddAutoMapper(c => {
    c.AddExpressionMapping();
}, typeof(AutoMapperProfiles).Assembly);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
