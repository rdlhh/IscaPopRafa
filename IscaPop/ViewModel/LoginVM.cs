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
    public class LoginVM : BaseViewModel
    {
        private OrganismeDAO organismeDAO;

        private Organisme _organisme;
        public Organisme Organisme
        {
            get { return _organisme; }
            set { SetProperty(ref _organisme, value); }
        }

        public LoginVM()
        {
            organismeDAO = new OrganismeDAO();
            //Organisme = organismeDAO.getOrganismeByEmail(email);

        }
    }
}
