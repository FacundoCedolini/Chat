using Chat.Data;
using Chat.Forms;
using Chat.Hubs;
using Chat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

// Creamos el host primero para que esté disponible tanto en el servidor web como para el MainForm
var host = new WebHostBuilder()
    .UseKestrel()
    .UseUrls("http://localhost:5000")
    .ConfigureServices(services =>
    {
        services.AddSignalR();
        services.AddDbContext<AppDbContext>();
        services.AddScoped<UserService>();
    })
    .Configure(app =>
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<ChatHub>("/chatHub");
        });
    })
    .Build();

// Ejecutamos el host en segundo plano
Task.Run(() => host.Run());

// Iniciamos el MainForm con DI
using var scope = host.Services.CreateScope();
var userService = scope.ServiceProvider.GetRequiredService<UserService>();
Application.Run(new MainForm(userService));
