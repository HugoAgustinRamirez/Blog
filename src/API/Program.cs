using Application.DTOs.Tweet;
using Application.DTOs.User;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Extensions;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MicrobloggingDb"));

builder.Services.AddScoped<ITweetService, TweetService>();
builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microblogging API", Version = "v1" });
});

builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microblogging API v1");
    });
}

app.MapPost("/tweets", async (
    [FromBody] CreateTweetRequest request,
    [FromHeader(Name = "X-User-Id")] int userId,
    ITweetService service) =>
{
    await service.CreateTweetAsync(request, userId);
    return Results.Created();
});

app.MapGet("/tweets/{id}", async (
    int id,
    ITweetService service) =>
{
    var tweet = await service.GetTweetByIdAsync(id);
    return tweet is not null ? Results.Ok(tweet) : Results.NotFound();
});

app.MapGet("/timeline/{userId}", async (
    int userId,
    ITweetService service,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10) =>
{
    var timeline = await service.GetTimelineAsync(userId, page, pageSize);
    return Results.Ok(timeline);
});

app.MapPost("/users", async (
    [FromBody] UserRequest user,
    IUserService service) =>
{
    await service.AddUserAsync(user);
    return Results.Created();
});

app.MapPost("/users/follow", async (
    [FromBody] FollowRequest request,
    [FromHeader(Name = "X-User-Id")] int followerId,
    IFollowService service) =>
{
    await service.FollowUserAsync(followerId, request.FollowedId);
    return Results.Ok();
});

app.MapDelete("/users/follow/{followedId}", async (
    int followedId,
    [FromHeader(Name = "X-User-Id")] int followerId,
    IFollowService service) =>
{
    await service.UnfollowUserAsync(followerId, followedId);
    return Results.NoContent();
});

app.MapGet("/users/{userId}/following", async (
    int userId,
   IFollowService service) =>
{
    var following = await service.GetFollowedUsersAsync(userId);
    return Results.Ok(following);
});

app.Run();