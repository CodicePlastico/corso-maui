namespace EsercizioStili;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnClicked(object sender, EventArgs e)
	{
		string buttonText = ((Button)sender).Text;
        await DisplayAlert("Messaggio", $"Hai cliccato {buttonText}", "OK");
	}
}

