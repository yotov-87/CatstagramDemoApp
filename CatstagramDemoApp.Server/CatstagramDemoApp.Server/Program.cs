using CatstagramDemoApp.Server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appSettings = builder.Services.GetApplicationSettings(builder.Configuration);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddApplicationServices()
    .AddSwagger()
    .AddControllers();

builder.Services.
    AddDatabaseDeveloperPageExceptionFilter();

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

app.UseHttpsRedirection()
    .UseSwaggerUI()
    .UseRouting()
    .UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints => {
        endpoints.MapControllers();
    })
    .ApplyMigration();

app.Run();
