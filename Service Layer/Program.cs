using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccessLayer.Entities;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

builder.Services.AddControllers();
//main services 
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("DataAccessLayer")));
services.AddAutoMapper(typeof(Program));
//repository injection
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<ITemplateRepository, TemplateRepository>();
//service injection
services.AddTransient<ITemplateService, TemplateService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
