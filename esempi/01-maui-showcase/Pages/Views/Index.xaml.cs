using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MauiShowcase.Pages.Views;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
	}

    private void ToggleCheckbox(object sender, TappedEventArgs e)
    {
		MyCheckbox.IsChecked = !MyCheckbox.IsChecked;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Toast.Make("BOOM", ToastDuration.Short).Show();
    }
}

