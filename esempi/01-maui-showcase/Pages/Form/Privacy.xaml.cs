using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;

namespace MauiShowcase.Pages.Form;

public partial class Privacy : Popup
{
	public Privacy()
	{
		InitializeComponent();
		BindingContext = this;
	}

	[RelayCommand]
	void Dismiss()
	{
		Close();
    }
}