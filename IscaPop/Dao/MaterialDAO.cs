using IscaPop.BaseDades;
using IscaPop.Model;
using SQLite;
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

        public List<Material> getMaterialesDeOrganisme(Organisme organisme)
        {
            List<Material> materials = new List<Material>();
            List<Material> materialsOfOrganisme = new List<Material>();
            materials = BaseDatos.GetConnection().GetAllWithChildrenAsync<Material>().Result;
            foreach (Material material in materials)
            {
                if (material.organisme.id == organisme.id)
                {
                    materialsOfOrganisme.Add(material);
                }
            }
            return materialsOfOrganisme;
        }

        public List<Material> getMaterialesNoOrganisme(string nom, string descripcio, string uso, EnumEstadoMaterial estat, Organisme organisme)
        {
            List<Material> listaMateriales = new List<Material>();
            List<Material> materials = BaseDatos.GetConnection().GetAllWithChildrenAsync<Material>(o => (o.nom.Contains(nom) || o.descripcio.Contains(descripcio) || o.uso.Contains(uso)) && o.estat <= estat).Result;
            foreach (Material material in materials)
            {
                if (material.organisme.id != organisme.id)
                {
                    listaMateriales.Add(material);
                }
            }
            return listaMateriales;
        }
    }
}
