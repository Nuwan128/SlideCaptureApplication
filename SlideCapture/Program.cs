using Microsoft.Extensions.DependencyInjection;

namespace SlideCapture;

internal static class Program
{
    private static ServiceProvider _serviceProvider;

    [STAThread]
    static void Main()
    {
        
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        ApplicationConfiguration.Initialize();

        var mainForm = _serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IScreenCapture, ScreenCapture>();
        services.AddSingleton<ISlideComparator, SlideComparator>();
        services.AddSingleton<IPDFGenerator, PDFGenerator>();

        services.AddTransient<MainForm>();
    }
}
