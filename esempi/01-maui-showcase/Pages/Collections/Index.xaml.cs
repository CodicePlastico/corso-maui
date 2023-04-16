namespace MauiShowcase.Pages.Collections;

public partial class Index : ContentPage
{
	private readonly IndexViewModel viewModel;
	public Index(IndexViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.SearchCommand.Execute(viewModel.Query);
    }
}

