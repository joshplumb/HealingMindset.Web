using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Repositories;
using HealingMindset.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using HealingMindset.Repositories.Shared;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IVideoResourceService, VideoResourceRepository>();
builder.AddDbContext<VideoResourceDatabaseContext>(options => options.)

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/videos", (IVideoResourceService videoService) => videoService.GetAll());

app.Run();
