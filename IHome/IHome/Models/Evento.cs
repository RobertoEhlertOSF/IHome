using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHome.Models
{
    public class Evento
    {
        [PrimaryKey, AutoIncrement]
        public int IDEvento { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int IDEquipamento { get; set; }
        public bool CurrentState { get; set; }
    }
}
