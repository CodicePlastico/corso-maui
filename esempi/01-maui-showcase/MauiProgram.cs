using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ReorderableCollectionView.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;
using UraniumUI;
using ZXing.Net.Maui.Controls;

namespace MauiShowcase;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseSkiaSharp(true)
            .RegisterReorderableCollectionView()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("tabler-icons.ttf", "TablerIcons");
            })
            .Services
            .AddSingleton<Pages.Collections.Index>()
            .AddSingleton<Pages.Collections.IndexViewModel>()
            .AddSingleton<Pages.Collections.Detail>()
            .AddSingleton<Pages.Collections.DetailViewModel>()
            .AddSingleton(Connectivity.Current)
            .AddHttpClient<Pages.Collections.Services.PokemonClient>(client => client.BaseAddress = new Uri("https://pokeapi.co/api/v2/"))
			;

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
