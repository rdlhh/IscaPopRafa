using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;
using System.Collections.ObjectModel;
using ThreadNetwork;

namespace IscaPop.ViewModel
{
    public class BuscarMaterialsVM : BaseViewModel
    {
        private ObservableCollection<Material> materials;
        public ObservableCollection<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }

        public BuscarMaterialsVM()
        {
            Task<List<Material>> ml = MaterialDAO.getMaterialAsync();
            Materials = new ObservableCollection<Material>(ml.Result);

        }

        public void filtra(string newTextValue)
        {
            Materials = new ObservableCollection<Material>(Materials.Where(m => m.nom.Contains(newTextValue)));
        }

        public void OrdenaPerNomAscendent()
        {
            Materials = new ObservableCollection<Material>(Materials.OrderBy(m => m.nom));
        }

        public void OrdenaPerNomDescendent()
        {
            Materials = new ObservableCollection<Material>(Materials.OrderByDescending(m => m.nom));
        }
    }
}
