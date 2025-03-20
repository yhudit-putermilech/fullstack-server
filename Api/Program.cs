//using Api.Data;
//using System.Text.Json.Serialization;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});

//var app = builder.Build();
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
//------------------------------------------------------------------------------------------------

using Api.Core.Repositories;
using Api.Core.Services;
using Api.Data;
using Api.Data.Repositories;
using Api.Serveice;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IImageService, MageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAlbumFileService, AlbumFileService>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddScoped<IAlbumRepository,AlbumRepository>();
builder.Services.AddScoped<IAlbumFileRepository,AlbumFileRepository>();
builder.Services.AddScoped<ILogRepository,LogRepository>();
builder.Services.AddScoped<IUserrepository,UserRepository>();
builder.Services.AddScoped<ImageRepository,MageRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

////builder.Services.AddSingleton<DataContext>();
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db"));

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
