using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using MauiShowcase.Pages.ThirdParty.Models;
using MauiShowcase.Pages.ThirdParty.Services;
using System.Collections.ObjectModel;

namespace MauiShowcase.Pages.ThirdParty
{
    public partial class ChartViewModel : ObservableObject
    {
        readonly SqliteDatabaseClient db = new();
        public ChartViewModel()
        {
            db = new SqliteDatabaseClient();
        }

        [ObservableProperty]
        ISeries[] series;

        [ObservableProperty]
        bool isBusy = false;

        [RelayCommand]
        async Task GroupCustomersByCountry()
        {
            IsBusy = true;

            List<CustomerCountry> customerCountryList = await db.Query<CustomerCountry>("SELECT Country, COUNT(*) As Count FROM Customers GROUP BY Country");
            this.Series = customerCountryList
                .OrderByDescending(c => c.Count)
                .Select(c => new PieSeries<double> { Name = c.Country, Values = new double[] { c.Count } })
                .ToArray();

            IsBusy = false;
        }

        public record Node(string Name)
        {
            public IList<Node> Children { get; } = new ObservableCollection<Node>();
        }
    }
}
