using Android.Util;
using IHome.Data;
using IHome.Models;
using IHome.Services;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IHome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControleAmbiente : ContentPage
    {
        public ControleAmbiente()
        {
            InitializeComponent();
            InitializeGraphs();
        }

        public async void InitializeGraphs()
        {
            ScrollView scroll = new ScrollView();
            StackLayout stack = new StackLayout();
            Label label = new Label()
            {
                Margin = 20,
                Text = "Consumo de Equipamentos",
                FontAttributes = FontAttributes.Bold,
                FontSize = 15,
                HorizontalTextAlignment = TextAlignment.Center
            };
            stack.Children.Add(label);

            RefreshView refresh = new RefreshView();
            ICommand atualizar = new Command(() =>
            {
                Atualizar();
                refresh.IsRefreshing = false;
            });

            refresh.Command = atualizar;

            List<Equipamento> equipamentos = await App.Database.GetEquipamentosAnalog();
            foreach (Equipamento equipamento in equipamentos)
            {
                SfCircularGauge circularGauge = new SfCircularGauge();
                Header header = new Header
                {
                    Text = equipamento.Nome,
                    ForegroundColor = Color.Black,
                    TextSize = 20
                };
                circularGauge.Headers.Add(header);
                ObservableCollection<Scale> scales = new ObservableCollection<Scale>();
                Scale scale = new Scale();
                Syncfusion.SfGauge.XForms.Range range = new Syncfusion.SfGauge.XForms.Range
                {
                    StartValue = equipamento.StartRange,
                    EndValue = equipamento.EndRange
                };
                scale.Ranges.Add(range);

                NeedlePointer needlePointer = new NeedlePointer();
                needlePointer.Value = string.IsNullOrEmpty(equipamento.Value.ToString()) ? 0 : equipamento.Value;
                scale.Pointers.Add(needlePointer);

                scales.Add(scale);
                circularGauge.Scales = scales;
                circularGauge.HeightRequest = 250;
                stack.Children.Add(circularGauge);
            }
            scroll.Content = stack;
            refresh.Content = scroll;
            this.Content = refresh;

        }

        protected async void Atualizar()
        {
            try
            {
                List<Equipamento> equipamentos = await App.Database.GetEquipamentosAnalog();
                foreach (Equipamento equipamento in equipamentos)
                {
                    string valor = ServiceIO.ActionIO(equipamento, true).Result;
                    equipamento.Value =  Double.Parse(valor) / 100;
                    await App.Database.SaveEquipamentoAsync(equipamento);
                }
                InitializeGraphs();
            }
            catch (Exception ex)
            {
                Log.Error("Getting temp", ex.Message);
            }
        }
    }
}