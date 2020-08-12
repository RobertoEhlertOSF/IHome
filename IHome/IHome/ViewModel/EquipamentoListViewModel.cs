using IHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IHome.ViewModel
{
    public class EquipamentoListViewModel
    {
        public Task<List<Equipamento>> Equipamentos { get; set; }
        public ICommand ApagarEquipamento { get; private set; }
        public EquipamentoListViewModel()
        {
            this.Equipamentos = App.Database.GetEquipamentosAsync();

            ApagarEquipamento = new Command(async (equip) =>
            {
            var confirm =  await Application.Current.MainPage.DisplayAlert("Apagar", "Tem certeza que deseja apagar ?", "Sim", "Não");
                if (confirm)
                {
                    await App.Database.DeleteEquipamentoAsync(equip as Equipamento);
                }
            });
        }
        public List<string> TipoEquipamento
        {
            get
            {
                return Enum.GetNames(typeof(Equipamento)).Select(b => b.ToString()).ToList();
            }
        }
    }
}
