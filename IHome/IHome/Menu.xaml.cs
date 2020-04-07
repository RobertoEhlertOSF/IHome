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
        }

        private void GoControleAmbiente(object sender, System.EventArgs e) 
        { 
        }

        private void GoLuzes(object sender, System.EventArgs e)
        {

        }

        private void GoConsumoEnergia(object sender, System.EventArgs e)
        {

        }

    }
}