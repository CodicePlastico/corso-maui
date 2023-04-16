namespace MauiShowcase;

public partial class AppShell : Shell
{
	public AppShell()
	{
        Routing.RegisterRoute("CollectionsDetail", typeof(Pages.Collections.Detail));
        InitializeComponent();
	}
}
