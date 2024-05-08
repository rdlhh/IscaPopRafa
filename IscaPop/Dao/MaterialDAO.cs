using IscaPop.BaseDades;
using IscaPop.Model;
using SQLiteNetExtensionsAsync.Extensions;

namespace IscaPop.Dao
{
    public class MaterialDAO
    {
        public MaterialDAO() { }

        public void insertarMaterial(Material material)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(material);
        }
    }
}
