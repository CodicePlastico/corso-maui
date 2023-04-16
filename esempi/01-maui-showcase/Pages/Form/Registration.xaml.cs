using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using MauiShowcase.Pages.Form.Extensions;
using System.Diagnostics;

namespace MauiShowcase.Pages.Form;

public partial class Registration : ContentView
{
	public Registration()
	{
		InitializeComponent();
        BindingContext = this;
	}

    [RelayCommand]
    void OpenPrivacy()
    {
        Privacy privacy = new Privacy
        {
            Size = new Size(350, 500)
        };

        this.GetPage().ShowPopup(privacy);
    }

    private async void SubmitForm(object sender, EventArgs e)
    {
        Submit.IsEnabled = false;
        Debug.WriteLine($@"User entered this data: 
        Email: {Email.Text}
        Password: {Password.Text}
        Consenso: {Consent.IsChecked}
        Data di nascita: {DateOfBirth.Date:dd/MM/yyyy}
        Soggetto: {Subject.SelectedItem}
        Codice fiscale: {FiscalCode.Text}
        ");

        await Task.Delay(2000);
        Submit.IsEnabled = true;
    }
}