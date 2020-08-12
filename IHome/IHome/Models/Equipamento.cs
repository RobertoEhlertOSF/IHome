using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHome.Models
{
    public class Equipamento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
        public double ConsumoWatts { get; set; }
        public int Pino { get; set; }
        public bool State { get; set; }
        public string Tipo { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}W Pin:{3} - {4}", ID, Nome, ConsumoWatts, Pino, Tipo);
        }
    }
    public enum Tipo
    {
        Entrada = 1,
        Saida = 2,
        Analogico = 3
    }

}
