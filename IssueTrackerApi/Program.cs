using EntityFramework.Data;
using EntityFramework.Data.Models.Domain;
using IssueTracker.AutoMapper;
using IssueTrackerRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .PartManager.ApplicationParts.Add(new AssemblyPart(Assembly.Load("IssueTracker.Controllers")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EntityFramework.Data.IssueTrackerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IssueTrackerConnectionString"),
        b => b.MigrationsAssembly("EntityFramework.Data")
    )); 
builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AuthConnection"),
        b => b.MigrationsAssembly("EntityFramework.Data")
    ));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IProjectsRepo , ProjectRepo>();
builder.Services.AddAutoMapper(typeof(ProjectProfile).Assembly);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
