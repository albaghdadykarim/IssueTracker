using AuthGateway;
using EntityFramework.Data;
using EntityFramework.Data.Models.Domain;
using IssueTracker.AutoMapper;
using IssueTrackerRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

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

//////////JWT Configuration /////////////
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddScoped<ITokenService , TokenService>();
////////////////////////////////////////

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
