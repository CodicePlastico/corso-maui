using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShowcase.Pages.ThirdParty.Models;
using MauiShowcase.Pages.ThirdParty.Services;
using System.Collections.ObjectModel;

namespace MauiShowcase.Pages.ThirdParty
{
    public partial class TreeViewViewModel : ObservableObject
    {
        readonly SqliteDatabaseClient db = new();
        public TreeViewViewModel()
        {
            db = new SqliteDatabaseClient();
        }

        [ObservableProperty]
        ObservableCollection<Node> nodes = new();

        [ObservableProperty]
        bool isBusy = false;

        [RelayCommand]
        async Task GroupCustomersByLocation()
        {
            IsBusy = true;

            List<CustomerLocation> customerLocationList = await db.Query<CustomerLocation>("SELECT FirstName, LastName, City, Country FROM Customers");
            var customersByCounty = customerLocationList.GroupBy(c => c.Country).ToList();
            foreach (var country in customersByCounty)
            {
                var countryNode = new Node(country.Key);
                var customersByCity = country.GroupBy(c => c.City).ToList();
                foreach (var city in customersByCity)
                {
                    var cityNode = new Node(city.Key);
                    foreach (var customer in city)
                    {
                        cityNode.Children.Add(new Node($"{customer.FirstName} {customer.LastName}"));
                    }

                    countryNode.Children.Add(cityNode);
                }

                Nodes.Add(countryNode);
            }

            IsBusy = false;
        }

        public record Node(string Name)
        {
            public bool IsExpanded { get; set; } = false;
            public bool IsLeaf { get => Children.Count == 0; set { } }
            public IList<Node> Children { get; } = new ObservableCollection<Node>();
        }
    }
}
