using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;

namespace MauiShowcase.Pages.Barcode;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
	}

    private async void OnBarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		string barcodes = string.Join(", ", e.Results.Select(e => e.Value));
		await Toast.Make($"Barcode: {barcodes}").Show();
    }
}