using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Windows;

namespace MyJourney.Desktop;

public partial class MainWindow : Window
{
    private bool _ready;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var webRoot = Path.Combine(AppContext.BaseDirectory, "wwwroot");
        var startPage = Path.Combine(webRoot, "index.html");
        if (!File.Exists(startPage))
        {
            MessageBox.Show($"The website files were not found here:\n{webRoot}\n\nRebuild the solution so the site is copied beside the app.",
                "My Journey files missing", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        try
        {
            var userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyJourney", "WebView2");
            Directory.CreateDirectory(userData);
            var environment = await CoreWebView2Environment.CreateAsync(userDataFolder: userData);
            await JourneyView.EnsureCoreWebView2Async(environment);
            JourneyView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "myjourney.local", webRoot, CoreWebView2HostResourceAccessKind.Allow);
            JourneyView.CoreWebView2.Navigate("https://myjourney.local/index.html");
            _ready = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("My Journey needs the Microsoft Edge WebView2 Runtime. Install it, then reopen the app.\n\n" + ex.Message,
                "WebView2 could not start", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void Home_Click(object sender, RoutedEventArgs e)
    {
        if (_ready) JourneyView.CoreWebView2.Navigate("https://myjourney.local/index.html");
    }

    private void Refresh_Click(object sender, RoutedEventArgs e)
    {
        if (_ready) JourneyView.CoreWebView2.Reload();
    }
}
