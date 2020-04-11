using IHome.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHome.Data
{
    public class AppDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public AppDatabase(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite);
#if RESET
            _database.DropTableAsync<Evento>().Wait();
            _database.DropTableAsync<Equipamento>().Wait();
#endif
            _database.CreateTableAsync<Evento>().Wait();
            _database.CreateTableAsync<Equipamento>().Wait();
        }

        public Task<List<Equipamento>> GetEquipamentosAsync()
        {
            return _database.Table<Equipamento>().ToListAsync();
        }

        public Task<List<Evento>> GetEventosAsync()
        {
            return _database.Table<Evento>().ToListAsync();
        }

        public Task<Equipamento> GetEquipamentoAsync(int id)
        {
            return _database.Table<Equipamento>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<Evento> GetEventoAsync(int id)
        {
            return _database.Table<Evento>()
                            .Where(i => i.IDEvento == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Evento> GetEventoByEquipamentoID(int idEquip)
        {
            var evento = _database.Table<Evento>()
                            .Where(i => i.IDEquipamento == idEquip && i.EndDateTime == DateTime.MinValue)
                            .OrderByDescending(i => i.StartDateTime)
                            .FirstOrDefaultAsync();

            var datafim = evento.Result;

            return evento;
            
        }
        public Task<int> SaveEquipamentoAsync(Equipamento equipamento)
        {
            if (equipamento.ID > 0)
            {
                return _database.UpdateAsync(equipamento);
            }
            else
            {
                return _database.InsertAsync(equipamento);
            }
        }
        public Task<int> SaveEventosAsync(Evento evento)
        {
            if (evento.IDEvento > 0)
            {
                return _database.UpdateAsync(evento);
            }
            else
            {
                return _database.InsertAsync(evento);
            }
        }

        public Task<int> DeleteEquipamentoAsync(Equipamento equipamento)
        {
            return _database.DeleteAsync(equipamento);
        }
        public Task<int> DeleteEventoAsync(Evento evento)
        {
            return _database.DeleteAsync(evento);
        }
    }
}
