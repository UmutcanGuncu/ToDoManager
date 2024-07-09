using Microsoft.EntityFrameworkCore;
using ToDoManager.Application.Abstracts;
using ToDoManager.Domain.Entities;
using ToDoManager.Persistence.Concretes;
using ToDoManager.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
builder.Services.AddDbContext<ToDoManagerDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericService<>));
builder.Services.AddScoped<ILogRepository, LogService>();
builder.Services.AddScoped<IServerRepository, ServerService>();
builder.Services.AddScoped<ICheckpointRepository, CheckpointService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();