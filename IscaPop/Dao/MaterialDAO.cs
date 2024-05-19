using IscaPop.BaseDades;
using IscaPop.Model;
using SQLiteNetExtensionsAsync.Extensions;

namespace IscaPop.Dao
{
    public class MaterialDAO
    {
        public MaterialDAO() { }

        public static Task<List<Material>> getMaterialAsync() 
        { 
            return BaseDatos.GetConnection().Table<Material>().ToListAsync();
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
