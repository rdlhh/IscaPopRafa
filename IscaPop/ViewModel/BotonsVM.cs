using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;

namespace IscaPop.ViewModel
{
    public class BotonsVM : BaseViewModel
    {
        private OrganismeDAO organismeDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        public BotonsVM()
        {
            organismeDAO = new OrganismeDAO();
        }

        internal void assignDades(Organisme org)
        {
            this.Organisme = org;
        }
        internal void insertarOrganisme()
        {
            organismeDAO.insertarOrganisme(Organisme);
        }
    }
}
