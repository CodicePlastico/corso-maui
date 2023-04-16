using System.Diagnostics.Metrics;
using Windows.Networking;

namespace MauiShowcase.Pages.ThirdParty.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

