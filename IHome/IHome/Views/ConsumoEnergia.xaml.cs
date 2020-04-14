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
        public async static Task<Chart[]> CreateXamarinSample()
        {

            float consumoQuarto = (float) await App.Database.GetConsumoTotalPorHora(10);
            float consumoSala = (float) await App.Database.GetConsumoTotalPorHora(11);
            float consumoCozinha = (float) await App.Database.GetConsumoTotalPorHora(12);
            float consumoBanheiro = (float) await App.Database.GetConsumoTotalPorHora(13);

            //Quarto 10
            //Sala 11
            //Cozinha 12
            //Banheiro 13

            var entries = new[]
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
            };

            return new Chart[]
            {
                new BarChart()
                {
                  Entries = entries ,
                  LabelTextSize = 35
                },
                //new PointChart()
                // {
                //  Entries = entries ,
                //  LabelTextSize = 35
                //  },
                //new LineChart()
                //{
                //    Entries = entries,
                //    LineMode = LineMode.Straight,
                //    LineSize = 8,
                //    PointMode = PointMode.Square,
                //    PointSize = 18,
                //    LabelTextSize = 35
                //},
                //new DonutChart()
                //{ Entries = entries,
                //  LabelTextSize = 35
                //},
                //new RadialGaugeChart()
                //{ Entries = entries ,
                //  LabelTextSize = 35
                //},
                //new RadarChart()
                //{
                //  Entries = entries ,
                //  LabelTextSize = 35
                //},
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