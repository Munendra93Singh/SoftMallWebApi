using AutoMapper;
using BusinessService.Implementation;
using BusinessService.Implemetation;
using BusinessService.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories.Implementation;
using Repositories.Implementation_StoreProcure;
using Respository;
using Respository.Implementation_StoreProcure;
using Respository.Interface;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SoftMallWebApi", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAutoMapper();


builder.Services.AddScoped(typeof(ISizeMasterRepos), typeof(SizeMasterRepos));
builder.Services.AddScoped(typeof(ISizeMasterService), typeof(SizeMasterService));

builder.Services.AddScoped(typeof(ITagMasterRepos), typeof(TagMasterRepos));
builder.Services.AddScoped(typeof(ITagMasterService), typeof(TagMasterService));

builder.Services.AddScoped(typeof(IUserTypeMasterRepos), typeof(UserTypeMasterRepos));
builder.Services.AddScoped(typeof(IUserTypeMasterService), typeof(UserTypeMasterService));


builder.Services.AddScoped(typeof(IColorMasterRepos), typeof(ColorMasterRepos));
builder.Services.AddScoped(typeof(IColorMasterService), typeof(ColorMasterService));


builder.Services.AddScoped(typeof(IUserMasterRepos), typeof(UserMasterRepos));
builder.Services.AddScoped(typeof(IUserMasterService), typeof(UserMasterService));

builder.Services.AddScoped(typeof(ICustomerMasterRepos), typeof(CustomerMasterRepos));
builder.Services.AddScoped(typeof(ICustomerMasterService), typeof(CustomerMasterService));

builder.Services.AddScoped(typeof(IBrandLogoMasterRepos), typeof(BrandLogoMasterRepos));
builder.Services.AddScoped(typeof(IBrandLogoMasterService), typeof(BrandLogoMasterService));

builder.Services.AddScoped(typeof(ICategoryMasterRepos), typeof(CategoryMasterRepos)); 
builder.Services.AddScoped(typeof(ICategoryMasterService), typeof(CategoryMasterService));


builder.Services.AddScoped(typeof(IProductMasterRepos), typeof(ProductMasterRepos));
builder.Services.AddScoped(typeof(IProductMasterService), typeof(ProductMasterService));






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicationDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));
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
