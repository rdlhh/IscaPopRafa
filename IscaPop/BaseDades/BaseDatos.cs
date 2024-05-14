using IscaPop.Config;
using IscaPop.Model;
using SQLite;

namespace IscaPop.BaseDades
{
    public class BaseDatos
    {
        private static SQLiteAsyncConnection connection;


        static BaseDatos()
        {
            CreaTablasAsync();
        }

        public static SQLiteAsyncConnection GetConnection()
        {
            if (connection is not null)
            {
                return connection;
            }
            else
            {
                try
                {
                    connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return connection;
            }
        }
        public static void CreaTablasAsync()
        {
            GetConnection().DropTableAsync<Foto>().Wait();
            GetConnection().DropTableAsync<Material>().Wait();
            GetConnection().DropTableAsync<Organisme>().Wait();
            GetConnection().DropTableAsync<Solicitud>().Wait();

            GetConnection().CreateTableAsync<Foto>().Wait();
            GetConnection().CreateTableAsync<Material>().Wait();
            GetConnection().CreateTableAsync<Organisme>().Wait();
            GetConnection().CreateTableAsync<Solicitud>().Wait();

        }
    }
}

