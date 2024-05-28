using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IscaPop.ViewModel
{
    public class BuscarMaterialVM : BaseViewModel
    {
        private MaterialDAO materialDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        public BuscarMaterialVM()
        {
            materialDAO = new MaterialDAO();
        }

        internal void assignDadesOrganisme(Organisme org)
        {
            this.Organisme = org;
        }
    }
}
