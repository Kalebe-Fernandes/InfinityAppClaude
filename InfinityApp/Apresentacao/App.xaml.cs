namespace InfinityApp.Apresentacao;

/// <summary>
/// Classe principal da aplicação MAUI.
/// </summary>
public partial class App : IApplication
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 400;
        const int newHeight = 800;

        window.Width = newWidth;
        window.Height = newHeight;
        window.MinimumWidth = newWidth;
        window.MinimumHeight = newHeight;
        window.MaximumWidth = newWidth;
        window.MaximumHeight = newHeight;

        return window;
    }
}
