using AspNetCoreRateLimit;
using RateLimitingWebApi.Middleware.RateLimiting;
using RateLimitingWebApi.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
// Add services to the container.

builder.Services.AddMemoryCache();
//configs from appsettings
builder.Services.Configure<IpRateLimitOptions>(x=>config.GetSection("IpRateLimitingSettings").Bind(x));
builder.Services.Configure<IpRateLimitPolicies>(x=>config.GetSection("IpRateLimitingPolicies").Bind(x));

//storing rules
builder.Services.AddSingleton<IRateLimitConfiguration, CustomRateLimitConfiguration>();
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddScoped<IRateLimitingService, RateLimitingService>();
builder.Services.AddInMemoryRateLimiting();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();    //register to IpRateLimiting

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
