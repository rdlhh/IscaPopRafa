using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;

namespace IscaPop.ViewModel
{
    public class MaterialVM : BaseViewModel
    {
        private MaterialDAO materialDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        private Material _material;
        public Material Material { get { return _material; } set { SetProperty(ref _material, value); } }

        public MaterialVM()
        {
            materialDAO = new MaterialDAO();
            if(Material == null)
            {
                Material = new Material();
            }
        }
        internal void assignDadesOrganisme(Organisme org)
        {
            this.Organisme = org;
        }

        internal void assignDades(Material mat)
        {
            this.Material = mat;
        }

        internal void insertMaterial(Material material)
        {
            materialDAO.insertarMaterial(material);
        }

        internal void borrarMaterial()
        {
            materialDAO.deleteMaterial(this.Material);
        }

        internal void modMaterial()
        {
            materialDAO.modificarMaterial(this.Material);
        }
    }
}
