using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics;
using System.Text;

namespace MauiShowcase.Pages.Menu
{
    public partial class IndexViewModel : ObservableObject
    {
        [RelayCommand]
        void Exit()
        {
            // Exit the application
            #if WINDOWS10_0_17763_0_OR_GREATER
            Application.Current.Quit();
            #endif
        }

        [ObservableProperty]
        ImageSource picture;

        [ObservableProperty]
        double zoom = 1.0;

        [RelayCommand]
        async Task Open()
        {
            var result = await FilePicker.Default.PickAsync(PickOptions.Images);
            if (result != null)
            {
                Picture = ImageSource.FromFile(result.FullPath);
            }
        }

        [RelayCommand]
        async Task Save()
        {
            byte[] bytesToSave = Encoding.Default.GetBytes("Questo è un file salvato da MAUI!");
            using var stream = new MemoryStream(bytesToSave);

            // Il FileSaver chiederà conferma all'utente di salvare un file chiamato test.txt
            // L'utente potrà scegliere la directory di destinazione e cambiare nome
            var fileSaverResult = await FileSaver.Default.SaveAsync("test.txt", stream, CancellationToken.None);
            if (fileSaverResult.IsSuccessful)
            {
                await Toast.Make($"Il file è stato salvato nel percorso: {fileSaverResult.FilePath}").Show();
            }
        }

        [RelayCommand]
        async Task Navigate(string route)
        {
            await Shell.Current.GoToAsync(route);
        }

        [RelayCommand]
        async Task Help(string route)
        {
            await Application.Current.MainPage.DisplayAlert("Messaggio", "Informazioni sull'applicazione", "OK");
        }

        [RelayCommand]
        void ZoomIn()
        {
            Zoom *= 2;
        }

        [RelayCommand]
        void ZoomOut()
        {
            Zoom /= 2;
        }
    }
}
