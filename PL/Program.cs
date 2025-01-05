using BL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace PL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var host = CreateHostBuilder().Build();
            var services = host.Services;

            ApplicationConfiguration.Initialize();
            LoginForm.Initialize();
            Application.Run(LoginForm.Instance);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddBusinessLogicServices("YourConnectionStringHere");

                    // Register your forms
                    services.AddTransient<LoginForm>();
                    services.AddTransient<StoreMainForm>();
                    services.AddTransient<ProductCreationForm>();
                    // Register other forms as needed
                });
        }
    }
}