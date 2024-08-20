using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera5834163
{
    public class LocalDbService
    {
        private const string DB_NAME = "demo_gasolinera.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            //Le indica al sistema que cree la tabla de nuestro contexto
            _connection.CreateTableAsync<TotalGas>();
        }

        //Metodo para listar los registros de la tabla
        public async Task<List<TotalGas>> GetTotalGas()
        {
            return await _connection.Table<TotalGas>().ToListAsync();
        }

        //Metodo para listar los registros por id
        public async Task<TotalGas> GetById(int id)
        {
            return await _connection.Table<TotalGas>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //Metodo para crear registros
        public async Task Create(TotalGas total)
        {
            await _connection.InsertAsync(total);
        }

        //Metodo para actualizar
        public async Task Update(TotalGas total)
        {
            await _connection.UpdateAsync(total);
        }

        //Metodo para eliminar
        public async Task Delete(TotalGas total)
        {
            await _connection.DeleteAsync(total);
        }
    }
    
}
