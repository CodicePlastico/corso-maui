using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiShowcase.Pages.Form;

public partial class LoginViewModel : ObservableValidator
{
    [Required(ErrorMessage = "Il campo Email è obbligatorio")]
    [EmailAddress(ErrorMessage = "Il campo Email non è un indirizzo valido")]
    [EmailAddressAtDomain("example.org")]
    [ObservableProperty]
    string email;

    [Required(ErrorMessage = "Il campo Password è obbligatorio")]
    [ObservableProperty]
    string password;

    [ObservableProperty]
    bool rememberMe;

    [ObservableProperty]
    string[] errors;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    bool isLoginCompleted;

    [RelayCommand]
    void ToggleRememberMe()
    {
        RememberMe = !RememberMe;
    }

    [RelayCommand]
    async Task Login()
    {
        ClearErrors();
        Errors = new string[0];

        ValidateAllProperties();

        IsLoginCompleted = false;
        
        if (HasErrors)
        {
            Errors = GetErrors().Select(v => v.ErrorMessage).ToArray();
        }
        else
        {
            IsBusy = true;

            if (await ValidateCredentials(Email, Password))
            {
                IsLoginCompleted = true;
                ClearForm();
            }
            else
            {
                Errors = new[] { "I dati di accesso non sono validi" };
            }

            IsBusy = false;
        }
    }

    async Task<bool> ValidateCredentials(string email, string password)
    {
        // Simula attesa di accesso al database
        await Task.Delay(1000);

        // Per semplicità, diamo il login per buono se la password è "password"
        return "password".Equals(password, StringComparison.InvariantCultureIgnoreCase);
    }

    void ClearForm()
    {
        Email = string.Empty;
        Password = string.Empty;
        RememberMe = false;
    }
}

public class EmailAddressAtDomainAttribute : ValidationAttribute
{
    private readonly string domain;

    public EmailAddressAtDomainAttribute(string domain)
    {
        this.domain = domain;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string emailAddress = value as string;
        if (!string.IsNullOrEmpty(emailAddress))
        {
            if (emailAddress.ToLower().EndsWith(domain))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"L'indirizzo email non appartiene al dominio {domain}");
            }
        }

        return ValidationResult.Success;
    }
}
