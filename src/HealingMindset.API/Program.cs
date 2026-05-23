using HealingMindset.Repositories.Context;
using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;
using HealingMindset.Repositories.Repositories;
using HealingMindset.Repositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<IVideoResourceService, MockVideoService>();
builder.Services.AddDbContext<VideoResourceDatabaseContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/videos", async (VideoResourceModel videoResource, IVideoResourceService videoService) => 
    await videoService.Create(videoResource));
app.MapGet("/api/videos", async (IVideoResourceService videoService) => 
    await videoService.GetAll());
app.MapGet("/api/videos/{videoResourceId:int}", async (int videoResourceId, IVideoResourceService videoService) => 
    await videoService.GetByID(videoResourceId));
app.MapPut("/api/videos", async (VideoResourceModel videoResource, IVideoResourceService videoService) => 
    await videoService.Update(videoResource));
app.MapDelete("/api/videos/{videoResourceId:int}", async (int videoResourceId, IVideoResourceService videoService) => 
    await videoService.Delete(videoResourceId));

app.Run();
