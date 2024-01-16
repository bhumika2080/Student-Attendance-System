using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Student_Attendance_SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Student_Attendance_SystemContext") ?? throw new InvalidOperationException("Connection string 'Student_Attendance_SystemContext' not found.")));

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie(options =>
//        {
//            options.LoginPath = "/Logins/LoginsView"; // Set the login path
//            options.AccessDeniedPath= "/Logins/LoginsView";
//        });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("LoggedInPolicy", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//    });
//});

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Logins}/{action=LoginsView}/{id?}");

app.Run();
