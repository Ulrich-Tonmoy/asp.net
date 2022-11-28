using EmployeeManagementSystem.Data.Context;
using EmployeeManagementSystem.Service.Services;
using EmployeeManagementSystem.Service.Services.Contracts;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using EmployeeManagementSystem.Common.Validators;
using EmployeeManagementSystem.Repository.Contracts;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.Repository.Repositories.Contracts;
using EmployeeManagementSystem.Repository.Repositories;
using EmployeeManagementSystem.Service.Sorting.Contracts;
using EmployeeManagementSystem.Service.Sorting;
using EmployeeManagementSystem.Service.Selection.Contracts;
using EmployeeManagementSystem.Service.Selection;

var builder = WebApplication.CreateBuilder(args);

// Connect to db
builder.Services.AddDbContext<EmployeeManagementSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagementDbConnection")));
builder.Services.AddScoped<DbContext, EmployeeManagementSystemContext>();

// Add services to the container.

// Repositories
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Helper
builder.Services.AddScoped<IDepartmentSort, DepartmentSort>();
builder.Services.AddScoped<IEmployeeSort, EmployeeSort>();
builder.Services.AddScoped<IJobSort, JobSort>();
builder.Services.AddScoped<IDepartmentDataShaper, DepartmentDataShaper>();
builder.Services.AddScoped<IEmployeeDataShaper, EmployeeDataShaper>();
builder.Services.AddScoped<IJobDataShaper, JobDataShaper>();

// Services
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IJobService, JobService>();

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<IValidationWrapper>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
