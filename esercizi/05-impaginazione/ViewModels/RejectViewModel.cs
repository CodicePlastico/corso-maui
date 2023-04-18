using EsercizioImpaginazione.Model;
using System.Collections.ObjectModel;

namespace EsercizioImpaginazione.ViewModels
{
    public class RejectViewModel
    {
        readonly AdsClient adsClient;
        public RejectViewModel()
        {
            rejectList = new ObservableCollection<Reject>();
            adsClient = AdsClient.Instance;
            adsClient.RejectUpdated += AdsClient_RejectUpdated;
        }

        private void AdsClient_RejectUpdated(object sender, Model.Reject reject)
        {
            var existingReject = RejectList.FirstOrDefault(r => r.Reason == reject.Reason);
            
            if (existingReject is null)
            {
                var vmReject = new ViewModels.Reject()
                {
                    Reason = reject.Reason,
                    Counter = reject.Counter
                };
                RejectList.Add(vmReject);
            }
            else
            {
                existingReject.Counter = reject.Counter;
            }
        }

        private ObservableCollection<ViewModels.Reject> rejectList;
        public ObservableCollection<ViewModels.Reject> RejectList
        {
            get
            {
                return rejectList;
            }
        }
    }
}
