﻿using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;

namespace IscaPop.ViewModel
{
    public class OrganismeVM : BaseViewModel
    {
        private OrganismeDAO orgDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        public OrganismeVM()
        {
            orgDAO = new OrganismeDAO();
        }

        internal void assignDades(Organisme org)
        {
            this.Organisme = org;
        }

        public void modificarOrganisme()
        {
            orgDAO.modificarOrganisme(this.Organisme);
        }

        public void eliminarOrganisme()
        {
            orgDAO.eliminarOrganisme(this.Organisme);
        }
    }
}
