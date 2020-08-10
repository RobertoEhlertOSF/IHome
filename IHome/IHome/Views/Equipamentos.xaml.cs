using IHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Equipamentos : ContentPage
    {
        public Equipamentos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetEquipamentosAsync();
        }

        async void CadastrarEquipamento(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) && !string.IsNullOrWhiteSpace(txtConsumoWatts.Text))
            {
                await App.Database.SaveEquipamentoAsync(new Equipamento
                {
                    Nome = txtNome.Text,
                    ConsumoWatts = Int32.Parse(txtConsumoWatts.Text),
                    State = false,
                    Pino = Int32.Parse(txtPino.Text)                    
                });
            }

            txtNome.Text = string.Empty;
            txtConsumoWatts.Text = string.Empty;
            txtPino.Text = string.Empty;
            listView.ItemsSource = await App.Database.GetEquipamentosAsync();

        }


    }
}