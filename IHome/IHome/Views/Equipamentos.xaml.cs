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
        Dictionary<string, string> sensores = new Dictionary<string, string>
        {
            { "Sensor de Chuva"       ,    "GETCHUVA"},
            { "Sensor de Luz"         ,       "GETLUZ"},
            { "Sensor de Temperatura" ,      "GETTEMP"},
            { "Sensor de Umidade"     ,   "GETUMIDADE"}

        };
        public Equipamentos()
        {
            InitializeComponent();

            foreach (string colorName in cores.Keys)
            {
                PckCor.Items.Add(colorName);
            }

            foreach (string sensor in sensores.Keys)
            {
                PckSensor.Items.Add(sensor);
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetEquipamentosAsync();
        }

        async void CadastrarEquipamento(object sender, EventArgs e)
        {
            Equipamento equipamento = new Equipamento();

            equipamento.Nome = txtNome.Text;
            equipamento.ConsumoWatts = string.IsNullOrEmpty(txtConsumoWatts.Text) ? 0 : Int32.Parse(txtConsumoWatts.Text);
            equipamento.State = false;
            equipamento.Pino = string.IsNullOrEmpty(txtPino.Text) ? -1 : Int32.Parse(txtPino.Text);
            equipamento.Tipo = PckTipo.SelectedItem.ToString();
            equipamento.Cor = PckCor.SelectedIndex == -1 ? "0" : cores[PckCor.SelectedItem.ToString()];
            equipamento.StartRange = string.IsNullOrEmpty(txtStartRange.Text) ? 0 : Int32.Parse(txtStartRange.Text);
            equipamento.EndRange = string.IsNullOrEmpty(txtEndRange.Text) ? 0 : Int32.Parse(txtEndRange.Text);
            equipamento.Value= 0;
            equipamento.Sensor = PckSensor.SelectedIndex == -1 ? "0" : sensores[PckSensor.SelectedItem.ToString()];
            await App.Database.SaveEquipamentoAsync(equipamento);

            txtNome.Text = string.Empty;
            txtConsumoWatts.Text = string.Empty;
            txtPino.Text = string.Empty;
            PckCor.SelectedIndex = -1;
            PckTipo.SelectedIndex = -1;
            txtPino.Text = string.Empty;
            txtStartRange.Text = string.Empty;
            txtEndRange.Text = string.Empty;

            listView.ItemsSource = await App.Database.GetEquipamentosAsync();



        }


    }
}