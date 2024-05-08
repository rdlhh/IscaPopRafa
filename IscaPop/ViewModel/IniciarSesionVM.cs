using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;

namespace IscaPop.ViewModel
{
    public class IniciarSesionVM : BaseViewModel
    {
        private OrganismeDAO organismeDAO;
        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        public IniciarSesionVM()
        {
            organismeDAO = new OrganismeDAO();
        }
        internal void assignDades(Organisme org)
        {
            this.Organisme = org;
        }

        internal Organisme buscarCuenta(string email, string contraseña)
        {
            return organismeDAO.buscarCuenta(email, contraseña);
        }
    }
}
