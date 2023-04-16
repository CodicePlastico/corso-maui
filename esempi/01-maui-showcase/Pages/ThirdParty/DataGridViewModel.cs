using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShowcase.Pages.ThirdParty.Models;
using MauiShowcase.Pages.ThirdParty.Services;
using System.Collections.ObjectModel;

namespace MauiShowcase.Pages.ThirdParty
{
    public partial class DataGridViewModel : ObservableObject
    {
        int pageSize = 7;

        readonly SqliteDatabaseClient db = new();

        [ObservableProperty]
        ObservableCollection<Customer> customers = new();

        [ObservableProperty]
        int page = 1;

        [ObservableProperty]
        bool isBusy = false;

        [RelayCommand]
        async Task FillCustomersCollection(int page)
        {
            Customers.Clear();

            List<Customer> customersList = await db.Query<Customer>($"SELECT CustomerId, FirstName, LastName, Company, Address, City, Country FROM Customers LIMIT {(page - 1) * pageSize},{pageSize}");
            foreach (Customer customer in customersList)
            {
                Customers.Add(customer);
            }

            Page = page;
        }
    }
}
