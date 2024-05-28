using IscaPop.Base;
using IscaPop.Dao;
using IscaPop.Model;

namespace IscaPop.ViewModel
{
    public class SolicitarMaterialVM : BaseViewModel
    {
        private MaterialDAO materialDAO;
        private SolicitudDAO solicitudDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        private Material _material;
        public Material Material { get { return _material; } set { SetProperty(ref _material, value); } }

        private Solicitud _solicitud;
        public Solicitud Solicitud { get { return _solicitud; } set { SetProperty(ref _solicitud, value); } }

        public SolicitarMaterialVM()
        {
            materialDAO = new MaterialDAO();
            solicitudDAO = new SolicitudDAO();
        }

        internal void assignDadesOrganisme(Organisme org)
        {
            this.Organisme = org;
        }

        internal void assignDades(Solicitud sol)
        {
            this.Solicitud = sol;
        }
        internal void assignDadesMaterial(Material material)
        {
            this.Material = material;
        }

        internal void insertSolicitud(Solicitud solicitud)
        {
            solicitudDAO.insertarSolicitud(solicitud);
        }

        public void modificarMaterial()
        {
            materialDAO.modificarMaterial(this.Material);
        }

    }
}
