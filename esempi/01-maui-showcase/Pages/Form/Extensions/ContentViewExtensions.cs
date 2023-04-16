namespace MauiShowcase.Pages.Form.Extensions
{
    public static class ContentViewExtensions
    {
        public static ContentPage GetPage(this ContentView contentView)
        {
            Element element = contentView;
            while (element is not ContentPage)
            {
                element = element.Parent;
            }

            return (ContentPage)element;
        }
    }
}
