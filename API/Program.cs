using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "Mingle API",
    Version = "v1",
    Description = "Mingle API is a Dating Software Application",
    Contact = new OpenApiContact
    {
      Name = "Omeje Ignatius",
      Email = "mrexcel153@gmail.com"
    }
  });
});

// Identity
builder.Services
.AddIdentityCore<AppUser>(options => options.User.RequireUniqueEmail = true)
.AddRoles<AppRole>()
.AddRoleManager<RoleManager<AppRole>>()
.AddSignInManager<SignInManager<AppUser>>()
.AddRoleValidator<RoleValidator<AppRole>>()
.AddEntityFrameworkStores<MingleDBContext>();

builder.Services.AddAuthentication();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MingleDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mingle API Doc V1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

// Using keywor disposes this service scope after use. 
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var userManager = services.GetRequiredService<UserManager<AppUser>>();
var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

await SeedData.SeedUsersAsync(userManager, roleManager);

await app.RunAsync();
