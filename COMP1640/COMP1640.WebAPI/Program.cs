using BusinessLogic;
using Common;
using COMP1640.WebAPI.Services.Files;
using COMP1640.WebAPI.Services.Token;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBLL();
builder.Services.AddDAL(builder.Configuration);
builder.Services.AddCommon();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
        .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

// Enable static files from wwwroot
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
