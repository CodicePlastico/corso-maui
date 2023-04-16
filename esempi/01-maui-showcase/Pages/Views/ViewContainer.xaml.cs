namespace MauiShowcase.Pages.Views;

public partial class ViewContainer : ContentView
{

    public static readonly BindableProperty TitleProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(ViewContainer), "");

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty =
    BindableProperty.Create(nameof(Description), typeof(string), typeof(ViewContainer), "");

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public ViewContainer()
	{
		InitializeComponent();
	}
}