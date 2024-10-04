using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace SlideCapture
{
    internal static class Program
    {
        private static ServiceProvider _serviceProvider;

        [STAThread]
        static void Main()
        {
            // Set up the dependency injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            // Use the service provider to create the main form
            var mainForm = _serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register the services and interfaces here
            services.AddSingleton<IScreenCapture, ScreenCapture>();
            services.AddSingleton<ISlideComparator, SlideComparator>();
            services.AddSingleton<IPDFGenerator, PDFGenerator>();

            // Register the form itself
            services.AddTransient<MainForm>();
        }
    }
}
