using CatstagramDemoApp.Server;
using CatstagramDemoApp.Server.Data;
using CatstagramDemoApp.Server.Data.Models;
using CatstagramDemoApp.Server.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.
    AddDbContext<CatstagramDemoAppDbContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.
    AddDatabaseDeveloperPageExceptionFilter();
builder.Services
    .AddIdentity<User, IdentityRole>(options => {
        options.Password.RequiredLength = 3;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<CatstagramDemoAppDbContext>();

var applicationSettingsConfiguration = builder.Configuration.GetSection("ApplicationSettingsSection");
builder.Services.
    Configure<AppSettings>(applicationSettingsConfiguration);

var appSettings = applicationSettingsConfiguration.Get<AppSettings>();
var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret));

builder.Services
    .AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x => {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateAudience = false,
            ValidateIssuer = false // TODO: set to "true" may be
        };
    });

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} 
//else {
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.ApplyMigration();

app.Run();
