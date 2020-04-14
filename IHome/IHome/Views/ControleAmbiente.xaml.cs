using Android.Util;
using IHome.Services;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        protected async void Atualizar(object sender, EventArgs args)
        {
            try
            {
                cgnUmidade.Value = Double.Parse(await ServiceIO.GetUmidade()) / 100;
                cgnTemperatura.Value = Double.Parse(await ServiceIO.GetTemperatura())/100;
            }
            catch (Exception ex)
            {
                Log.Error("Getting temp", ex.Message);
            }
        }
    }
}