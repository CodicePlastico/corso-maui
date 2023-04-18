using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioImpaginazione.Model
{
    public class AdsClient
    {
        readonly IReadOnlyList<Reject> rejectList;
        readonly Random random;

        private AdsClient()
        {
            random = new Random();

            rejectList = new List<Reject>
            {
                new Reject { Reason = "Tipo1" },
                new Reject { Reason = "Tipo2" },
                new Reject { Reason = "Tipo3" },
                new Reject { Reason = "Tipo4" },
                new Reject { Reason = "Tipo5" },
                new Reject { Reason = "Tipo5" },
            };

            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += GenerateReject;
            timer.Start();
        }

        public static AdsClient Instance { get; } = new AdsClient();

        private void GenerateReject(object sender, EventArgs e)
        {
            int randomIndex = random.Next(0, rejectList.Count);
            rejectList[randomIndex].Counter++;
            RejectUpdated?.Invoke(this, rejectList[randomIndex]);
        }

        public event EventHandler<Reject> RejectUpdated;
    }
}
