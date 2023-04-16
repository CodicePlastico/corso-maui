namespace MauiShowcase.Pages.Collections;

[QueryProperty(nameof(PokemonId), "id")]
public partial class Detail : ContentPage
{
	private readonly DetailViewModel viewModel;
	public Detail(DetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}

    public string PokemonId { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.SelectCommand.Execute(PokemonId);
    }
}

