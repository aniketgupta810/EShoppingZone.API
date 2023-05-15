using ECommerceWeb.API.Data;
using ECommerceWeb.API.Repository;
using ECommerceWeb.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart_API.Repository;
using ShoppingCart_API.Services;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200",
                                              "https://localhost:7052",
                                              "https://localhost:65265",
                                              "http://localhost:3000").AllowCredentials().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceApplicationContext")));

builder.Services.AddTransient<IUser, UserRepo>();
builder.Services.AddTransient<UserDetailsServices, UserDetailsServices>();

//Products injection

builder.Services.AddTransient<IProduct, ProductRepo>();
builder.Services.AddTransient<ProductService, ProductService>();



// Add authentication
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7052",
        ClockSkew = TimeSpan.Zero,
        ValidAudiences = new List<string>
        {
            "https://localhost:7052",
            "https://localhost:4200"
        },
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PNM4t3NEYbOd1SGe"))
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
