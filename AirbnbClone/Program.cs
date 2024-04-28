using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using AirbnbClone.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AirbnbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("base")));
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddScoped<IAuthenticateable, AuthenticationService>(options => new AuthenticationService(
    jwtSecret: builder.Configuration["JwtCredentials:jwtSecret"]!,
    issuer: builder.Configuration["JwtCredentials:issuer"]!,
    audience: builder.Configuration["JwtCredentials:issuer"]!
    ));
builder.Services.AddScoped<IHostable, HostService>();
builder.Services.AddScoped<IListable, ListingService>();
builder.Services.AddScoped<IReviewable, ReviewService>();
builder.Services.AddScoped<IManageableUser, UserService>();
builder.Services.AddScoped<IOrderable, OrderService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(dp =>
{
    dp.WithOrigins(builder.Configuration["AllowedOrigins"]!);
    dp.AllowAnyHeader();
    dp.AllowAnyMethod();
});
options.AddPolicy(name: "AnyOrigins",
    ap =>
{
    ap.AllowAnyOrigin();
    ap.AllowAnyHeader();
    ap.AllowAnyMethod();
});
});





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AnyOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
