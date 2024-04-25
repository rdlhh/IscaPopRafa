using IscaPop.Config;
using SQLite;

namespace IscaPop.Model
{
    public class BaseDades
    {
        private static SQLiteAsyncConnection connection;
        public static SQLiteAsyncConnection GetConnection()
        {
            if (connection is not null)
            {
                return connection;
            }
            else
            {
                connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                return connection;
            }
        }

        static BaseDades()
        {
            CreaTaules();
            InsertaDades();
        }

        private static void CreaTaules()
        {
            GetConnection().DropTableAsync<Correu>().Wait();
            GetConnection().DropTableAsync<Foto>().Wait();
            GetConnection().DropTableAsync<Material>().Wait();
            GetConnection().DropTableAsync<Organisme>().Wait();

            GetConnection().CreateTableAsync<Correu>().Wait();
            GetConnection().CreateTableAsync<Foto>().Wait();
            GetConnection().CreateTableAsync<Material>().Wait();
            GetConnection().CreateTableAsync<Organisme>().Wait();
        }

        private async static void InsertaDades()
        {
            Material m1 = new Material {Nom = "Cadira", Stock = 5, Estat = "Perfecta", Descripcio = "Cadira normal color verd", Disponibilitat = true};
            Material m2 = new Material {Nom = "Taula laboratori", Stock = 3, Estat = "Perfecta", Descripcio = "Taula gran de laboratori de fusta", Disponibilitat = true};
            Material m3 = new Material {Nom = "Pisarra blanca", Stock = 2, Estat = "En bones condicions", Descripcio = "Pisarra blanca magnètica", Disponibilitat = true};
            await GetConnection().InsertAsync(m1);
            await GetConnection().InsertAsync(m2);
            await GetConnection().InsertAsync(m3);

            Organisme o1 = new Organisme {Codi = 46021290, Email = "46021290@edu.gva.es"};
            Organisme o2 = new Organisme {Codi = 46021320, Email = "46021320@edu.gva.es" };
            Organisme o3 = new Organisme {Codi = 46012094, Email = "46012094@edu.gva.es"};
            await GetConnection().InsertAsync(o1);
            await GetConnection().InsertAsync(o2);
            await GetConnection().InsertAsync(o3);
        }
    }
}
