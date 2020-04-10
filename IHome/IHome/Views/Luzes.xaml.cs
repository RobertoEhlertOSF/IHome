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
    public partial class Luzes : ContentPage
    {
        public Luzes()
        {
            InitializeComponent();
        }

        private void GoToEquipamentos(object sender, EventArgs eventArgs)
        {
            Navigation.PushModalAsync(new Equipamentos());
           
        }


        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            SwitchCell cell = (SwitchCell)sender;

            if (cell.On)
            {
                switch (cell.Text)
                {
                    case "Quarto":
                        btQuarto.BackgroundColor = Color.Yellow;
                        break;
                    case "Sala":
                        btSala.BackgroundColor = Color.Yellow;
                        break;
                    case "Cozinha":
                        btCozinha.BackgroundColor = Color.Yellow;
                        break;
                    case "Banheiro":
                        btBanheiro.BackgroundColor = Color.Yellow;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (cell.Text)
                {
                    case "Quarto":
                        btQuarto.BackgroundColor = Color.LightGray;
                        break;
                    case "Sala":
                        btSala.BackgroundColor = Color.LightGray;
                        break;
                    case "Cozinha":
                        btCozinha.BackgroundColor = Color.LightGray;
                        break;
                    case "Banheiro":
                        btBanheiro.BackgroundColor = Color.LightGray;
                        break;
                    default:
                        break;
                }
            }
        }

        private void BtLigarTudo_Clicked(object sender, EventArgs e)
        {
            btQuarto.BackgroundColor = Color.Yellow;
            btSala.BackgroundColor = Color.Yellow;
            btCozinha.BackgroundColor = Color.Yellow;
            btBanheiro.BackgroundColor = Color.Yellow;

            swQuarto.On = true;
            swSala.On = true;
            swCozinha.On = true;
            swBanheiro.On = true;
        }

        private void BtDesligarTudo_Clicked(object sender, EventArgs e)
        {
            btQuarto.BackgroundColor = Color.LightGray;
            btSala.BackgroundColor = Color.LightGray;
            btCozinha.BackgroundColor = Color.LightGray;
            btBanheiro.BackgroundColor = Color.LightGray;

            swQuarto.On = false;
            swSala.On = false;
            swCozinha.On = false;
            swBanheiro.On = false;
        }
    }
}