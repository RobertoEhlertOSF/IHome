using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms.Xaml;
using IHome.Models;

namespace IHome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsumoEnergia : ContentPage
    {
        public ConsumoEnergia()
        {
            InitializeComponent();
        }

        public static readonly SKColor TextColor = SKColors.Black;

        public static async Task<List<ChartEntry>> GetGraficos()
        {
            List<Equipamento> equipamentos = await App.Database.GetEquipamentosAsync();
            List<ChartEntry> charts = new List<ChartEntry>();
            foreach (var equip in equipamentos)
            {
                float consumo = (float)await App.Database.GetConsumoTotalPorMinuto(equip.ID);

                ChartEntry chart = new ChartEntry(consumo)
                {
                    Label = equip.Nome,
                    ValueLabel = consumo.ToString(),
                    Color = SKColor.Parse(equip.Cor),
                    TextColor = TextColor
                };
                charts.Add(chart);
            }
            return charts;
        }
        public async static Task<Chart[]> CreateBarChart()
        {
            return new Chart[]
            {
                new BarChart()
                {
                  Entries = await GetGraficos() ,
                  LabelTextSize = 35
                },
            };
        }
        protected async override void OnAppearing()
        {
            var charts = await CreateBarChart();
            this.chart1.Chart = charts[0];
        }
    }
}