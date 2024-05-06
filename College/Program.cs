using BusinessLayer;
using DataLayer;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Utilities.Enums.File;
using Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<StudentBll>();
//builder.Services.AddDbContext<CollegeContext>((option) =>
//{
//    string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
//    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//    var buildedConfiguration = builder.Build();

//    var connectionString = buildedConfiguration.GetSection("ConnectionStrings").GetSection("college").Value;
//    FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] connectionString = {connectionString}" });
//    option.UseSqlServer(connectionString);
//});

builder.Services.AddDbContext<CollegeContext>();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
