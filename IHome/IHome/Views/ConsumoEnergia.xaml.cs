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
                float consumo = (float)await App.Database.GetConsumoTotalPorHora(equip.ID);

                ChartEntry chart = new ChartEntry(consumo)
                {
                    Label = equip.Nome,
                    ValueLabel = consumo.ToString(),
                    Color = SKColor.Parse("#E52510"),
                    TextColor = TextColor
                };
                charts.Add(chart);
            }
            return charts;
        }
        public async static Task<Chart[]> CreateXamarinSample()
        {
           /* float consumoQuarto = (float)await App.Database.GetConsumoTotalPorHora(10);
            float consumoSala = (float)await App.Database.GetConsumoTotalPorHora(11);
            float consumoCozinha = (float)await App.Database.GetConsumoTotalPorHora(12);
            float consumoBanheiro = (float)await App.Database.GetConsumoTotalPorHora(13);

            List<ChartEntry> entries = new List<ChartEntry>();

            ChartEntry chart1 = new ChartEntry(consumoQuarto)
            {
                Label = "Lampada Quarto",
                ValueLabel = consumoQuarto.ToString(),
                Color = SKColor.Parse("#E52510"),
                TextColor = TextColor
            };
            ChartEntry chart2 = new ChartEntry(consumoBanheiro)
            {
                Label = "Lampada Banheiro",
                ValueLabel = consumoBanheiro.ToString(),
                Color = SKColor.Parse("#003791"),
                TextColor = TextColor
            };
            ChartEntry chart3 = new ChartEntry(consumoCozinha)
            {
                Label = "Lampada Cozinha",
                ValueLabel = consumoCozinha.ToString(),
                Color = SKColor.Parse("#107b10"),
                TextColor = TextColor
            };
            ChartEntry chart4 = new ChartEntry(consumoSala)
            {
                Label = "Lampada Sala",
                ValueLabel = consumoSala.ToString(),
                Color = SKColor.Parse("#B0E0E6"),
                TextColor = TextColor
            };

            entries.Add(chart1);
            entries.Add(chart2);
            entries.Add(chart3);
            entries.Add(chart4);

            /*var entries = new[]
            {
                new ChartEntry(consumoQuarto)
                {
                    Label = "Lampada Quarto",
                    ValueLabel = consumoQuarto.ToString(),
                    Color = SKColor.Parse("#E52510"),
                    TextColor = TextColor
                },
                new ChartEntry(consumoBanheiro)
                {
                    Label = "Lampada Banheiro",
                    ValueLabel = consumoBanheiro.ToString(),
                    Color = SKColor.Parse("#003791"),
                    TextColor = TextColor
                },
                new ChartEntry(consumoCozinha)
                {
                    Label = "Lampada Cozinha",
                    ValueLabel = consumoCozinha.ToString(),
                    Color = SKColor.Parse("#107b10"),
                      TextColor = TextColor
                },
                new ChartEntry(consumoSala)
                {
                    Label = "Lampada Sala",
                    ValueLabel = consumoSala.ToString(),
                    Color = SKColor.Parse("#B0E0E6"),
                    TextColor = TextColor
                }
            };*/

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
            var charts = await CreateXamarinSample();
            this.chart1.Chart = charts[0];
            //this.chart2.Chart = charts[1];
            //this.chart3.Chart = charts[2];
            //this.chart4.Chart = charts[3];
            //this.chart5.Chart = charts[4];
            //this.chart6.Chart = charts[5];
        }
    }
}