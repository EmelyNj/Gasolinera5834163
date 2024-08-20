namespace Gasolinera5834163
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editTotalId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetTotalGas());

        }


        private async void TotalBtn_Clicked(object sender, EventArgs e)
        {
            if (_editTotalId == 0)
            {
                double LitrosporGalon = 3.78541;
                double tot, galones, preciolitros;
                galones = Convert.ToDouble(Entryprimernumero.Text);
                preciolitros = Convert.ToDouble(Entrysegundonumero.Text);

                double litros = galones * LitrosporGalon;
                tot = litros * preciolitros;

                labelresultado.Text = tot.ToString();

                //agrega cliente
                await _dbService.Create(new TotalGas
                {
                    Galones = Entryprimernumero.Text,
                    Litros = Entrysegundonumero.Text,

                    Total = labelresultado.Text
                }); ;
            }
            else
            {
                double LitrosporGalon = 3.78541;
                double tot, galones, preciolitros;
                galones = Convert.ToDouble(Entryprimernumero.Text);
                preciolitros = Convert.ToDouble(Entrysegundonumero.Text);

                double litros = galones * LitrosporGalon;
                tot = litros * preciolitros;

                labelresultado.Text = tot.ToString();

                //edita cliente
                await _dbService.Update(new TotalGas
                {
                    Id = _editTotalId,
                    Galones = Entryprimernumero.Text,
                    Litros = Entrysegundonumero.Text,
                    Total = labelresultado.Text
                });
                _editTotalId = 0;
            }
            Entryprimernumero.Text = string.Empty;
            Entrysegundonumero.Text = string.Empty;
            labelresultado.Text = string.Empty;

            listview.ItemsSource = await _dbService.GetTotalGas();

        }

        private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var total = (TotalGas)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editTotalId = total.Id;
                    Entryprimernumero.Text = total.Galones;
                    Entrysegundonumero.Text = total.Litros;
                    labelresultado.Text = total.Total;
                    break;

                case "Delete":
                    await _dbService.Delete(total);
                    listview.ItemsSource = await _dbService.GetTotalGas();
                    break;
            }
        }
    }

}
