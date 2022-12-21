using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common.Validators;
using UniversityCourseAndResultManagementSystem.Data;
using UniversityCourseAndResultManagementSystem.Repository.Repositories;
using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Repository;
using UniversityCourseAndResultManagementSystem.Service;
using UniversityCourseAndResultManagementSystem.Service.Contracts;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connect to db
builder.Services.AddDbContext<UniversityCourseAndResultManagementSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityCourseAndResultManagementSystemDbConnection")));
builder.Services.AddScoped<DbContext, UniversityCourseAndResultManagementSystemContext>();

// Repositories
builder.Services.AddScoped<IAssignedCourseRepository, AssignedCourseRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();
builder.Services.AddScoped<IEnrolledCourseRepository, EnrolledCourseRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<IAssignedCourseService, AssignedCourseService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDesignationService, DesignationService>();
builder.Services.AddScoped<IEnrolledCourseService, EnrolledCourseService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<IValidationWrapper>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
