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
        public bool State { get; set; }
    }
}
