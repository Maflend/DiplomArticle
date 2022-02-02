using AuthenticationBlazor.Server.Services.AuthService;
using AuthenticationBlazor.Server.Services.DataBase;
using AuthenticationBlazor.Server.Services.JWTService;
using AuthenticationBlazor.Server.Services.ProductService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IData, Data>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();



app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
