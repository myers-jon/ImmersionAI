using ImmersionAI.API.api.Helpers;
using ImmersionAI.API.api.Repositories;
using ImmersionAI.API.api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//// JWT
//builder.Services.AddSingleton<JwtTokenHelper>();

//builder.Services.AddAuthentication(options => {
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options => {
//    var cfg = builder.Configuration.GetSection("JwtSettings");
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = cfg["Issuer"],
//        ValidAudience = cfg["Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["SecretKey"]))
//    };
//});

//// Dapper + Postgres
//builder.Services.AddTransient<IDbConnection>(sp =>
//    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ollama client
builder.Services.AddHttpClient<IDeepSeekService, DeepSeekService>(c => {
    c.BaseAddress = new Uri("http://localhost:11434/api/generate");
    c.Timeout = TimeSpan.FromSeconds(30);
});

// Repositories & Services
//builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContextService, ContextService>();
builder.Services.AddScoped<PromptBuilder>();
//builder.Services.AddHostedService<ContextRefreshWorker>();

builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
