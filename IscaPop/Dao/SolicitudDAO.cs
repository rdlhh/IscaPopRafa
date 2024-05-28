using IscaPop.BaseDades;
using IscaPop.Model;
using SQLiteNetExtensionsAsync.Extensions;

namespace IscaPop.Dao
{
    public class SolicitudDAO
    {
        public void insertarSolicitud(Solicitud solicitud)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(solicitud);
        }
    }
}
