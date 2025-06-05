// ✅ All usings must be here at the top
using Mission.Entities.Context;
using Mission.Repositories.Helpers;
using Mission.Repositories.Interface;
using Mission.Repositories.IRepositories;
using Mission.Repositories;
using Mission.Services.IServices;
using Mission.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ✅ Correct DbContext registration with MigrationsAssembly specified
builder.Services.AddDbContext<MissionDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("Mission.Entities")));

builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", policy =>
{
    policy.WithOrigins("http://localhost:4200")  // Angular dev server
          .AllowAnyMethod()
          .AllowAnyHeader();
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Dependency Injections
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// ✅ Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
