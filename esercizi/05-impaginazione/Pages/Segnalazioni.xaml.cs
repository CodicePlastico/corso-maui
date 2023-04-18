namespace EsercizioImpaginazione.Pages;

public partial class Segnalazioni : ContentPage
{
	public Segnalazioni()
	{
		InitializeComponent();
	}

    private void Save(object sender, EventArgs e)
    {
		if (NomeRequired.IsValid)
		{
			var shiftDate = ShiftDate.Date;
			string segnalazioni = Notes.Text;
			TimeSpan shiftStart = ShiftStart.Time;
			TimeSpan shiftEnd = ShiftEnd.Time;
		}

		// fai qualcosa con i dati raccolti
    }
}