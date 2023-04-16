using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiShowcase.Pages.CustomView;

public partial class MeterView : ContentView
{
    public static readonly BindableProperty ValueProperty =
		BindableProperty.Create(nameof(Value), typeof(double), typeof(MeterView), 0d);

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly BindableProperty MaximumProperty =
        BindableProperty.Create(nameof(Maximum), typeof(double), typeof(MeterView), 10d);

    public double Maximum
    {
        get => (double)GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    public static readonly BindableProperty MinimumProperty =
        BindableProperty.Create(nameof(Minimum), typeof(double), typeof(MeterView), 0d);

    public double Minimum
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }


    public MeterView()
	{
		InitializeComponent();
        BindingContext = this;
	}
}