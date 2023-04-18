using CommunityToolkit.Maui.Alerts;

namespace EsercizioBinding.Pages
{
    public class TriggerActionExitAnomaly : TriggerAction<Slider>
    {
        protected override void Invoke(Slider sender)
        {
            Toast.Make("Ha recuperato dallo stato di anomalia").Show();
        }
    }
}
