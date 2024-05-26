using IscaPop.BaseDades;
using IscaPop.Model;
using SQLiteNetExtensionsAsync.Extensions;

namespace IscaPop.Dao
{
    public class MaterialDAO
    {
        public MaterialDAO() { }

        public static List<Material> getMaterialOrgAsync(Organisme org) 
        { 
            List<Material> materials = new List<Material>();
            List<Material> materialsOrganisme = new List<Material>();
            materials = BaseDatos.GetConnection().GetAllWithChildrenAsync<Material>().Result;
            foreach (Material material in materials)
            {
                if(material.organisme.id == org.id)
                {
                    materialsOrganisme.Add(material);
                }
            }
            return materialsOrganisme;
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
