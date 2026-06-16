using FluentValidation;
using HealingMindset.Api.Features.VideoResources;
using HealingMindset.DataAccess.Context;
using HealingMindset.DataAccess.Interfaces;
using HealingMindset.DataAccess.Services;
using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HealingMindset.Api.Features.Users;
using HealingMindset.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<UserModel>()
    .AddEntityFrameworkStores<UserDatabaseContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IVideoResourceService, VideoResourceRepository>();
builder.Services.AddDbContext<VideoResourceDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<UserDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapVideoEndpoints();
app.MapUserEndpoints();

app.Run();
