using hrm_api;
using hrm_api.Authorization;
using hrm_infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
string currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

if (currentEnvironment?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
{
    builder.Configuration.AddJsonFile($"appsettings.{currentEnvironment}.json", optional: false);
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(options =>
        {
            builder.Configuration.Bind("AzureAdB2C", options);

            options.TokenValidationParameters.NameClaimType = "name";
            options.TokenValidationParameters.ValidateIssuer = false;
        },
options => { builder.Configuration.Bind("AzureAdB2C", options); });

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();

builder.Services.ConfigureDependencyInjection(builder.Configuration);

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminRequire", policy => policy.Requirements.Add(new AdminRequirement(AuthorizationConstant.ADMIN)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseCors(option => option
    .WithOrigins(new[] { "http://localhost:3000" })
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<HRMDbContext>();
    context.Database.Migrate();
}

app.Run();
