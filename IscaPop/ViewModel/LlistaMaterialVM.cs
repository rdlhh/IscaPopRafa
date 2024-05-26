using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;
using System.Collections.ObjectModel;

namespace IscaPop.ViewModel
{
    public class LlistaMaterialVM : BaseViewModel
    {
        private Organisme organisme;
        public Organisme Organisme
        {
            get { return organisme; }
            set { SetProperty(ref organisme, value); }
        }

        private Material material;
        public Material Material
        {
            get { return material; }
            set { SetProperty(ref material, value);}
        }

        private ObservableCollection<Material> materials;
        public ObservableCollection<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }

        public LlistaMaterialVM(Organisme organisme)
        {
            Organisme = organisme;
            materials = new ObservableCollection<Material>(MaterialDAO.getMaterialOrgAsync(Organisme));
        }
        public void AssignaDades()
        {
            Materials = new ObservableCollection<Material> (Materials.OrderBy(m => m.nom));
        }

        public void AssignaDadesO(Organisme organisme)
        {
            Organisme = organisme;

        }

        internal void AssignaDadesM(Material material)
        {
            Material = material;
        }
    }
}
