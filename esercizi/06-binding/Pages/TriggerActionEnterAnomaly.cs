using CommunityToolkit.Maui.Alerts;
using System.Threading.Tasks;

namespace EsercizioBinding.Pages
{
    public class TriggerActionEnterAnomaly : TriggerAction<Slider>
    {
        protected override void Invoke(Slider sender)
        {
            Toast.Make("Si trova in stato di anomalia").Show();
        }
    }
}
