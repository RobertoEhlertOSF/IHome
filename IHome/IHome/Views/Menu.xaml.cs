using IHome.Services;
using IHome.Views;
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
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuDetail());

            if (string.IsNullOrEmpty(Util.GetServerConfig()))
            {
                Detail.Navigation.PushAsync(new Config());
                IsPresented = false;
            }
        }

        private void GoControleAmbiente(object sender, System.EventArgs e) 
        {
            Detail.Navigation.PushAsync(new ControleAmbiente());
            IsPresented = false;
        }

        private void GoLuzes(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new Luzes());
            IsPresented = false;
        }

        private void GoConsumoEnergia(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new ConsumoEnergia());
            IsPresented = false;
        }

        private void GoEventos(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new Eventos());
            IsPresented = false;
        }

        private void GoConfig(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new Config());
            IsPresented = false;
        }

        private void GoSobre(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new Sobre());
            IsPresented = false;
        }

    }
}