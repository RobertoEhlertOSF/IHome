using IHome.Data;
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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetEquipamentosAsync();
        } 

        private async void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            var changed = ((SwitchCell)sender).BindingContext as Equipamento;
            //DisplayAlert("Selecionado", e.Value.ToString(), cancel: "OK");
            RegistrarEvento(changed.ID, e.Value);
            await ServiceIO.ActionIO(changed.Pino, e.Value);
            await App.Database.SaveEquipamentoAsync(changed);

            /*
            if (cell.On)
            {
                sender.

                switch (cell.Text)
                {
                    case "Quarto":
                        btQuarto.BackgroundColor = Color.Yellow;
                        await ServiceIO.ActionIO(10, EnumAction.ON);
                        RegistrarEvento(10, true);
                        break;
                    case "Sala":
                        btSala.BackgroundColor = Color.Yellow;
                        await ServiceIO.ActionIO(10, EnumAction.ON);
                        RegistrarEvento(11, true);
                        break;
                    case "Cozinha":
                        btCozinha.BackgroundColor = Color.Yellow;
                        await ServiceIO.ActionIO(10, EnumAction.ON);
                        RegistrarEvento(12, true);
                        break;
                    case "Banheiro":
                        await ServiceIO.ActionIO(10, EnumAction.ON);
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
                        await ServiceIO.ActionIO(10, EnumAction.OFF);
                        RegistrarEvento(10, false);
                        break;
                    case "Sala":
                        btSala.BackgroundColor = Color.LightGray;
                        await ServiceIO.ActionIO(10, EnumAction.OFF);
                        RegistrarEvento(11, false);
                        break;
                    case "Cozinha":
                        btCozinha.BackgroundColor = Color.LightGray;
                        await ServiceIO.ActionIO(10, EnumAction.OFF);
                        RegistrarEvento(12, false);
                        break;
                    case "Banheiro":
                        btBanheiro.BackgroundColor = Color.LightGray;
                        await ServiceIO.ActionIO(10, EnumAction.OFF);
                        RegistrarEvento(15, false);
                        break;
                    default:
                        break;
                }
            }*/
        }

        public async void RegistrarEvento (int idEquip, bool sw)
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
         /*   btQuarto.BackgroundColor = Color.Yellow;
            btSala.BackgroundColor = Color.Yellow;
            btCozinha.BackgroundColor = Color.Yellow;
            btBanheiro.BackgroundColor = Color.Yellow;

            swQuarto.On = true;
            swSala.On = true;
            swCozinha.On = true;
            swBanheiro.On = true;*/
        }

        private void BtDesligarTudo_Clicked(object sender, EventArgs e)
        {
            /*
            btQuarto.BackgroundColor = Color.LightGray;
            btSala.BackgroundColor = Color.LightGray;
            btCozinha.BackgroundColor = Color.LightGray;
            btBanheiro.BackgroundColor = Color.LightGray;

            swQuarto.On = false;
            swSala.On = false;
            swCozinha.On = false;
            swBanheiro.On = false;*/
        }
    }
}