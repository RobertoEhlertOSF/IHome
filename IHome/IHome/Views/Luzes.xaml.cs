using IHome.Models;
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

            //Quarto 10
            //Sala 11
            //Cozinha 12
            //Banheiro 13

            if (cell.On)
            {
                switch (cell.Text)
                {
                    case "Quarto":
                        btQuarto.BackgroundColor = Color.Yellow;
                        ServiceIO.LigarIO(10);
                        RegistrarEvento(10, true);
                        break;
                    case "Sala":
                        btSala.BackgroundColor = Color.Yellow;
                        ServiceIO.LigarIO(11);
                        RegistrarEvento(11, true);
                        break;
                    case "Cozinha":
                        btCozinha.BackgroundColor = Color.Yellow;
                        ServiceIO.LigarIO(12);
                        RegistrarEvento(12, true);
                        break;
                    case "Banheiro":
                        ServiceIO.LigarIO(15);
                        btBanheiro.BackgroundColor = Color.Yellow;
                        RegistrarEvento(15, true);
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
                        ServiceIO.DesligarIO(10);
                        RegistrarEvento(10, false);
                        break;
                    case "Sala":
                        btSala.BackgroundColor = Color.LightGray;
                        ServiceIO.DesligarIO(11);
                        RegistrarEvento(11, false);
                        break;
                    case "Cozinha":
                        btCozinha.BackgroundColor = Color.LightGray;
                        ServiceIO.DesligarIO(12);
                        RegistrarEvento(12, false);
                        break;
                    case "Banheiro":
                        btBanheiro.BackgroundColor = Color.LightGray;
                        ServiceIO.DesligarIO(15);
                        RegistrarEvento(15, false);
                        break;
                    default:
                        break;
                }
            }
        }

        public async void RegistrarEvento(int idEquip, bool sw)
        {
            if (sw)
            {
                DateTime ? valor = null;
                await App.Database.SaveEventosAsync(new Evento
                {
                    StartDateTime = DateTime.Now,
                    IDEquipamento = idEquip,
                    EndDateTime = valor.GetValueOrDefault()
                });
            }   
            else
            {
                var evento = await App.Database.GetEventoByEquipamentoID(idEquip);
                evento.EndDateTime = DateTime.Now;
                await App.Database.SaveEventosAsync(evento);
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