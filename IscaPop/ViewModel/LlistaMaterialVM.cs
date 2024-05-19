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

        private ObservableCollection<Material> materials;
        public ObservableCollection<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }

        public LlistaMaterialVM(Organisme organisme)
        {
            Organisme = organisme;
            Task<List<Material>> l = MaterialDAO.getMaterialAsync();
            materials = new ObservableCollection<Material>(l.Result);
        }
        public void AssignaDades()
        {
            Materials = new ObservableCollection<Material> (Materials.OrderBy(m => m.nom));
        }

        public void AssignaDadesO(Organisme organisme)
        {
            Organisme = organisme;

        }
    }
}
