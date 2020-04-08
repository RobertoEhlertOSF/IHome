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

        public static Chart[] CreateXamarinSample()
        {
            var entries = new[]
            {
                new ChartEntry(33.4f)
                {
                    Label = "Switch",
                    ValueLabel = "33.4M",
                    Color = SKColor.Parse("#E52510"),
                    TextColor = TextColor
                },
                new ChartEntry(95.1f)
                {
                    Label = "PS4",
                    ValueLabel = "95.1M",
                    Color = SKColor.Parse("#003791"),
                      TextColor = TextColor
                },
                new ChartEntry(42.3f)
                {
                    Label = "Xbox One",
                    ValueLabel = "42.3M",
                    Color = SKColor.Parse("#107b10"),
                      TextColor = TextColor
                },
                new ChartEntry(74.4f)
                {
                    Label = "3DS",
                    ValueLabel = "74.4M",
                    Color = SKColor.Parse("#E52510"),
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
                new PointChart()
                 {
                  Entries = entries ,
                  LabelTextSize = 35
                  },
                new LineChart()
                {
                    Entries = entries,
                    LineMode = LineMode.Straight,
                    LineSize = 8,
                    PointMode = PointMode.Square,
                    PointSize = 18,
                    LabelTextSize = 35
                },
                new DonutChart()
                { Entries = entries,
                  LabelTextSize = 35
                },
                new RadialGaugeChart()
                { Entries = entries ,
                  LabelTextSize = 35
                },
                new RadarChart()
                {
                  Entries = entries ,
                  LabelTextSize = 35
                },
            };
        }
        protected override void OnAppearing()
        {
            var charts = CreateXamarinSample();
            this.chart1.Chart = charts[0];
            this.chart2.Chart = charts[1];
            this.chart3.Chart = charts[2];
            this.chart4.Chart = charts[3];
            this.chart5.Chart = charts[4];
            this.chart6.Chart = charts[5];
        }
    }
}