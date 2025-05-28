using Chat.Data;
using Chat.Forms;
using Chat.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

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

using var loginForm = new LoginForm();
if (loginForm.ShowDialog() == DialogResult.OK && loginForm.LoggedInUser != null)
{
    Application.Run(new MainForm(loginForm.LoggedInUser));
}
else
{
    Application.Exit();
}

