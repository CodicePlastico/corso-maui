namespace MauiShowcase.Pages.ThirdParty;

public partial class TreeView : ContentView
{

    readonly TreeViewViewModel viewModel;
	public TreeView()
	{
		InitializeComponent();
        viewModel = new TreeViewViewModel();
        this.BindingContext = viewModel;
	}

    protected override void OnParentChanged()
    {
        base.OnParentChanged();
        viewModel.GroupCustomersByLocationCommand.Execute(null);
    }
}