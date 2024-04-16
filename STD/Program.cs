using STD.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using STD.Hubs;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using STD.Components.Models;
using STD.Data;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazorBootstrap();

builder.Services.AddControllers();

mySQLSqlHelper.conStr = builder.Configuration["ConnectionStrings:DefaultConnection"];

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();

builder.Services.AddSingleton<UserMasterDetailService>();


var app = builder.Build();


app.MapHub<ChatHub>("/ChatHub");

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2),
};

app.UseWebSockets(webSocketOptions);

app.UseHttpsRedirection();

app.MapFallbackToFile("index.html");

app.UseStaticFiles();
app.UseAntiforgery();


app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();