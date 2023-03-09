using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResumeSvc.Infrastructure.Extensions;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository;
using StudentManagingSystem.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SmsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<SmsDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<ISmsDbContext, SmsDbContext>();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath ="/Login";
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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
