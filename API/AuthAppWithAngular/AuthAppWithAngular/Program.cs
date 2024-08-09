using AuthAppWithAngular.Container;
using AuthAppWithAngular.Interface;
using AuthAppWithAngular.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AuthAppWithAngularContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AuthService with DI
builder.Services.AddScoped<IAuthInterface, AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//cors
builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder =>

    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
    );
});

// JWT 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
