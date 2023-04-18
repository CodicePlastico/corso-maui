namespace EsercizioImpaginazione.Content_Views;

public partial class RejectVisi : ContentView
{
	public RejectVisi()
	{
		InitializeComponent();
	}


    public static readonly BindableProperty TextProperty = BindableProperty.Create(
                                    propertyName: nameof(Text),
                                    returnType: typeof(string),
                                    declaringType: typeof(View),
                                    defaultValue: "");

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }


    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                                    propertyName: nameof(Value),
                                    returnType: typeof(int),
                                    declaringType: typeof(View),
                                    defaultValue: 0);

    public int Value
    {
        get { return (int)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }


}