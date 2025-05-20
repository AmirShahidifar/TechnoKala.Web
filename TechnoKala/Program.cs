using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TechnoKala.CoreLayer.Servises.Blogs;
using TechnoKala.CoreLayer.Servises.Blogs_Categories;
using TechnoKala.CoreLayer.Servises.Faqs;
using TechnoKala.CoreLayer.Servises.Teams;
using TechnoKala.CoreLayer.Servises.Users;
using TechnoKala.DaytaLayer.Contex;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBlogs_CategoryService, BlogsCtegoryService>();
builder.Services.AddScoped<IBlogsService, BlogsService>();
builder.Services.AddScoped<IFaqService, FaqService>();
builder.Services.AddScoped<ITeamService, TeamService>();


builder.Services.AddDbContext<AppDbContex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/Auth/Login";
    option.LogoutPath = "/Auth/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(1);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

        );

    app.MapRazorPages();
});


app.Run();
