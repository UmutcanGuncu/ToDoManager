﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoManager.Application.Abstracts;
using ToDoManager.Domain.Entities;
using ToDoManager.Persistence.Concretes;
using ToDoManager.Persistence.Context;
using ToDoManager.WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "ToDoManagerCookie";
    opt.LoginPath = "/Auth/Login";
    opt.LogoutPath = "/Auth/Logout";
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(5); //5 gün boyunca giriş yapmazsan login sayfasına yönlendşrşr
    opt.SlidingExpiration = true; // her giriş yaptığında cookie'nin süresi 5 gün olacak
});
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // 4 başarısız girişte 5 dakika boyunca giriş yapamayacak kullanıcı
    options.Lockout.MaxFailedAccessAttempts = 4; //Başarısız giriş sayısı
}).AddEntityFrameworkStores<ToDoManagerDbContext>();
builder.Services.AddDbContext<ToDoManagerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                      b => b.MigrationsAssembly("ToDoManager.WebAPI"))
);

builder.Services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericService<>));
builder.Services.AddScoped<ILogRepository, LogService>();
builder.Services.AddScoped<IServerRepository, ServerService>();
builder.Services.AddScoped<ICheckpointRepository, CheckpointService>();
builder.Services.AddScoped<ILogViewRepository, LogViewService>();
builder.Services.AddScoped<ITokenHandler, ToDoManager.Persistence.Concretes.TokenHandler>();
builder.Services.AddCors(opt =>
opt.AddPolicy("UIClients", builder =>
    builder.WithOrigins("https://localhost:7032", "http://localhost:5123").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // oluşturulacak token değerini kimlerin kulllanacağını belirtiriz www.umut.com
            ValidateIssuer = true, // oluşturulacak token değerini kimin dağıtacağı www.myapi.com
            ValidateLifetime = true, // oluşturulan token değerinin süresini kontrol eder
            ValidateIssuerSigningKey = true, // üretilecek token değerinin uygulamamıza ait olduğunu ifade eder security key değerinin doğrulanmasıdır

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
        };
    });
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

