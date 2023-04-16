using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using MauiShowcase.Pages.Form;

namespace MauiShowcase.Pages.Alerts;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
	}

    private async void OnShowDisplayAlert(object sender, EventArgs e)
    {
        await DisplayAlert("Hey", "Oggi è una bella giornata", "OK");
    }

    private async void OnShowDisplayPrompt(object sender, EventArgs e)
    {
        string nome = await DisplayPromptAsync("I tuoi dati", "Inserisci il tuo nome");
        await DisplayAlert("Grazie", $"Hai digitato {nome}", "OK");
    }

    private async void OnShowDisplayActionSheet(object sender, EventArgs e)
    {
        await DisplayActionSheet("Titolo", "Ok", "Annulla", "Azione1", "Azione2");
    }

    private async void OnShowSnackbar(object sender, EventArgs e)
    {
        await Snackbar.Make("Messaggio", () => { }, "OK").Show();
    }

    private async void OnShowToast(object sender, EventArgs e)
    {
        await Toast.Make("Messaggio", ToastDuration.Short).Show();
    }

    private void OnShowPopup(object sender, EventArgs e)
    {
        Privacy privacy = new Privacy
        {
            Size = new Size(350, 500),
            CanBeDismissedByTappingOutsideOfPopup = true
        };

        this.ShowPopup(privacy);
    }

    private void OnShowWindow(object sender, EventArgs e)
    {
        Window window = new()
        {
            Width = 600,
            Height = 400,
            Page = new Home()
        };

        Application.Current.OpenWindow(window);
    }
}

