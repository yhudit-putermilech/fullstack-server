////using Api.Data;
////using System.Text.Json.Serialization;

////var builder = WebApplication.CreateBuilder(args);
////builder.Services.AddControllers();
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();
////builder.Services.AddControllers().AddJsonOptions(options =>
////{
////    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
////});

////var app = builder.Build();
////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();

////app.UseAuthorization();

////app.MapControllers();

////app.Run();
////------------------------------------------------------------------------------------------------
/////////----------------------------------------------��� ����
/////----------------------------------
////*
//using Api.Core;
//using Api.Core.Repositories;
//using Api.Core.Services;
//using Api.Data;
//using Api.Data.Repositories;
//using Api.Serveice;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using System.Text.Json.Serialization;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//// ���� �� �-using statements ������� ���� �����
//using Amazon.S3;
//using Amazon.Extensions.NETCore.Setup;

//var builder = WebApplication.CreateBuilder(args);
//// ����� ����� AWS S3
//builder.Services.AddAWSService<IAmazonS3>(new AWSOptions
//{
//    Region = Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"]),
//    Credentials = new Amazon.Runtime.BasicAWSCredentials(
//        builder.Configuration["AWS:AccessKey"],
//        builder.Configuration["AWS:SecretKey"])
//});

//// ����� ����� S3
//builder.Services.AddScoped<IS3Service, S3Service>();

//// ����� ����� ���� ������ ����� (���������)
//builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
//{
//    // ����� ���� ���� �-10MB
//    options.MultipartBodyLengthLimit = 10 * 1024 * 1024;
//});
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Description = "Bearer Authentication with JWT Token",
//        Type = SecuritySchemeType.Http
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//{
//Reference = new OpenApiReference
//{
//Id = "Bearer",
//Type = ReferenceType.SecurityScheme
//}
//            },
//            new List<string>()
//        }
//    });
//});
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["JWT:Issuer"],
//            ValidAudience = builder.Configuration["JWT:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//        };
//    });
//builder.Services.AddScoped<IAlbumService, AlbumService>();
//builder.Services.AddScoped<IImageService, MageService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAlbumFileService, AlbumFileService>();
//builder.Services.AddScoped<ILogService, LogService>();
//builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
//builder.Services.AddScoped<IAlbumFileRepository, AlbumFileRepository>();
//builder.Services.AddScoped<ILogRepository, LogRepository>();
//builder.Services.AddScoped<IUserrepository, UserRepository>();
//builder.Services.AddScoped<ImageRepository, MageRepository>();
//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();
//���� �� �� ���� �����
//using Api.Core;
//using Api.Core.Repositories;
//using Api.Core.Services;
//using Api.Data;
//using Api.Data.Repositories;
//using Api.Serveice;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using System.Text.Json.Serialization;
//using Amazon.S3;
//using Amazon.Extensions.NETCore.Setup;

//var builder = WebApplication.CreateBuilder(args);

//// 1. ������������ ������� �������
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//    });
//builder.Services.AddEndpointsApiExplorer();

//// 2. ������������ Swagger
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Description = "Bearer Authentication with JWT Token",
//        Type = SecuritySchemeType.Http
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Id = "Bearer",
//                    Type = ReferenceType.SecurityScheme
//                }
//            },
//            new List<string>()
//        }
//    });
//});

//// 3. ������������ ����� (Authentication)
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["JWT:Issuer"],
//        ValidAudience = builder.Configuration["JWT:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//    };
//});

//// 4. ������������ ��� ������
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//// 5. ������������ AWS S3
//builder.Services.AddAWSService<IAmazonS3>(new AWSOptions
//{
//    Region = Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"]),
//    Credentials = new Amazon.Runtime.BasicAWSCredentials(
//        builder.Configuration["AWS:AccessKey"],
//        builder.Configuration["AWS:SecretKey"])
//});

//// 6. ����� ����� ���� ������ �����
//builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
//{
//    // ����� ���� ���� �-10MB
//    options.MultipartBodyLengthLimit = 10 * 1024 * 1024;
//});

//// 7. ����� �������
//// ����� �� repositories
//builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
//builder.Services.AddScoped<IAlbumFileRepository, AlbumFileRepository>();
//builder.Services.AddScoped<ILogRepository, LogRepository>();
//builder.Services.AddScoped<IUserrepository, UserRepository>();
//builder.Services.AddScoped<ImageRepository, MageRepository>();
//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//// ����� �� services
//builder.Services.AddScoped<IAlbumService, AlbumService>();
//builder.Services.AddScoped<IImageService, MageService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAlbumFileService, AlbumFileService>();
//builder.Services.AddScoped<ILogService, LogService>();
//builder.Services.AddScoped<IS3Service, S3Service>();

//// 8. ����� AutoMapper
//builder.Services.AddAutoMapper(typeof(MappingProfile));

//// 9. ����� ���������
//var app = builder.Build();

//// 10. ������������ Middleware Pipeline
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();


//// ����� UseAuthentication ���� UseAuthorization
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
//����� �� �GPT 
using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using Api.Core;
using Api.Core.Repositories;
using Api.Core.Services;
using Api.Data;
using Api.Data.Repositories;
using Api.Serveice;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. ����� ������ MVC �� ����� �-JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// 2. ����� Swagger �� ����� �-JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "��� ���� JWT �� ������: Bearer {token}",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

// 3. ����� ����� �� JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

// 4. ����� ��� ������ �� MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 5. ����� AWS S3
builder.Services.AddAWSService<IAmazonS3>(new AWSOptions
{
    Region = Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"]),
    Credentials = new Amazon.Runtime.BasicAWSCredentials(
        builder.Configuration["AWS:AccessKey"],
        builder.Configuration["AWS:SecretKey"])
});

// 6. ����� ����� ���� ������ ����� (����, 10MB)
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10MB
});

// 7. ����� ������� (Repositories �-Services)
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumFileRepository, AlbumFileRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IUserrepository, UserRepository>();
builder.Services.AddScoped<ImageRepository, MageRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// ����� �� services
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IImageService, MageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAlbumFileService, AlbumFileService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IS3Service, S3Service>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173") // ���� ������ �� ����� ���
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
// 8. ����� AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 9. ����� ���������
var app = builder.Build();

// 10. ������������ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
