namespace BindableProperties.Pages;

public partial class LabelContentView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
                                    propertyName: nameof(Text),
                                    returnType: typeof(string),
                                    declaringType: typeof(View),
                                    defaultValue: string.Empty);

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public LabelContentView()
	{
		InitializeComponent();
	}
}