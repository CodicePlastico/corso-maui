namespace MauiShowcase.Pages.ThirdParty;

public partial class DataGrid : ContentView
{

	readonly DataGridViewModel viewModel;
	public DataGrid()
	{
		InitializeComponent();
		viewModel = new();
		BindingContext = viewModel;
	}

    protected override void OnParentChanged()
    {
        base.OnParentChanged();
		viewModel.FillCustomersCollectionCommand.Execute(viewModel.Page);
    }
}