namespace MauiShowcase.Pages.ThirdParty;

public partial class Chart : ContentView
{

	readonly ChartViewModel viewModel;
	public Chart()
	{
		InitializeComponent();
		viewModel = new();
		BindingContext = viewModel;
	}

    protected override void OnParentChanged()
    {
        base.OnParentChanged();
		viewModel.GroupCustomersByCountryCommand.Execute(null);
    }
}