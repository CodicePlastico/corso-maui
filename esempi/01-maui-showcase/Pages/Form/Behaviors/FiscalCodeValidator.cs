using CommunityToolkit.Maui.Behaviors;
using System.Text.RegularExpressions;

namespace MauiShowcase.Pages.Form.Behaviors
{
    public class FiscalCodeValidationBehavior : ValidationBehavior<string>
    {
        private static Regex regex = new("^[A-Z]{6}\\d{2}[A-Z]\\d{2}[A-Z]\\d{3}[A-Z]$", RegexOptions.IgnoreCase);
        protected override ValueTask<bool> ValidateAsync(string value, CancellationToken token)
        {
            return ValueTask.FromResult(regex.IsMatch(value ?? string.Empty));
        }
    }
}
