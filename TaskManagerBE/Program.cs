using TaskManagerBE.MapperBase;
using TaskManagerBE.Models;
using TaskManagerBE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
#region Services
builder.Services.AddScoped<IUserService, UserService>();
#endregion

#region Mappers
builder.Services.AddScoped<IReadMapper<User, UserReadDTO>, UserReadMapper>();
builder.Services.AddScoped<ICreateMapper<User, UserCreateDTO>, UserCreateMapper>();
builder.Services.AddScoped<IUpdateMapper<User, UserUpdateDTO>, UserUpdateMapper>();
#endregion

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
