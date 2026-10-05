namespace CalculateurAge
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculerClicked(object sender, EventArgs e)
        {
            // Validation : on refuse un nom vide.
            if (string.IsNullOrWhiteSpace(entryNom.Text))
            {
                DisplayAlert("Erreur", "Entrez un nom", "OK");
                return;
            }

            if (!pickerDate.Date.HasValue)
            {
                DisplayAlert("Erreur", "Sélectionnez une date", "OK");
                return;
            }
            DateTime d = pickerDate.Date.Value;
            int age = DateTime.Today.Year - d.Year;
            // Si l'anniversaire n'est pas encore passé cette année, on retire une année.
            if (d.Date > DateTime.Today.AddYears(-age)) age--;

            // On écrit directement dans les contrôles
            lblResultat.Text = $"{entryNom.Text}, vous avez {age} ans";
            lblResultat.IsVisible = true;
        }
    }
}
