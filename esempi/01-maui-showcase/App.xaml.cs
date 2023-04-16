using Microsoft.Win32;

namespace MauiShowcase;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
		window.Title = MainPage.Title;
        window.SizeChanged += UpdateFlyoutBehaviorIfNeeded;

        return window;
    }

    private const double minPageWidth = 400;
    private void UpdateFlyoutBehaviorIfNeeded(object sender, EventArgs e)
    {
        double currentWidth = ((Window)sender).Width;
        if (currentWidth <= minPageWidth)
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }
        else if (currentWidth > minPageWidth + Shell.Current.FlyoutWidth)
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
        }
    }
}
