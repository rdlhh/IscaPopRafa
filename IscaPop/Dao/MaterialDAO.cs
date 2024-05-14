using IscaPop.BaseDades;
using IscaPop.Model;
using SQLiteNetExtensionsAsync.Extensions;

namespace IscaPop.Dao
{
    public class MaterialDAO
    {
        public MaterialDAO() { }

        public void getMaterial(Material material) 
        { 
            BaseDatos.GetConnection().GetChildrenAsync(material);
        }
        public void insertarMaterial(Material material)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(material);
        }

        public void modificarMaterial(Material material) 
        {
            BaseDatos.GetConnection().UpdateWithChildrenAsync(material);
        }
        public void deleteMaterial(Material material)
        {
            BaseDatos.GetConnection().DeleteAsync(material);
        }
    }
}
