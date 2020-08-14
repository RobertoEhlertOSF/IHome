using IHome.Models;
using SkiaSharp;
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

        Dictionary<string, string> cores = new Dictionary<string, string>
        {
            { "Amarelo", "#FFFF00"},
            { "Aqua",    "#00FFFF"},
            { "Azul",    "#0000FF"},
            { "Cinza",   "#808080"},
            { "Fucsia",  "#FF00FF"},
            { "Marrom",  "#800000"},
            { "Verde",   "#00FF00"},
            { "Vermelho","#FF0000"},
        };
        public Equipamentos()
        {
            InitializeComponent();

            foreach (string colorName in cores.Keys)
            {
                PckCor.Items.Add(colorName);
            }

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
                    Pino = Int32.Parse(txtPino.Text),
                    Tipo = PckTipo.SelectedItem.ToString(),
                    Cor = cores[PckCor.SelectedItem.ToString()]

                }) ;
            }

            txtNome.Text = string.Empty;
            txtConsumoWatts.Text = string.Empty;
            txtPino.Text = string.Empty;
            listView.ItemsSource = await App.Database.GetEquipamentosAsync();

        }


    }
}