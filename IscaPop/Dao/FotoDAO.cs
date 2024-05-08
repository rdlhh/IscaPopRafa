using IscaPop.BaseDades;
using IscaPop.Model;
using SQLiteNetExtensionsAsync.Extensions;

namespace IscaPop.Dao
{
    public class FotoDAO
    {
        public FotoDAO() { }

        public void insertarFoto(Foto foto)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(foto);
        }
    }
}
