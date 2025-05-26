using Chat.Data;
using Chat.Forms;
using Chat.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

//ApplicationConfiguration.Initialize();
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

// Iniciar el servidor web (SignalR + EF Core) en un hilo separado
Task.Run(() =>
{
    var host = new WebHostBuilder()
        .UseKestrel()
        .UseUrls("http://localhost:5000")
        .ConfigureServices(services =>
        {
            services.AddSignalR();
            services.AddDbContext<AppDbContext>();
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

    host.Run();
});

// Lanzar la UI WinForms
Application.Run(new MainForm());
