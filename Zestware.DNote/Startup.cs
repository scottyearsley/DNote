using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace Zestware.DNote;

public static class Startup
{
    public static void Configure(ResourceDictionary resources)
    {
        var services = new ServiceCollection();
        services.AddWpfBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.AddMudServices();
     
        // TODO: Add any service to DI
        
        resources.Add("services", services.BuildServiceProvider());
    }
}
