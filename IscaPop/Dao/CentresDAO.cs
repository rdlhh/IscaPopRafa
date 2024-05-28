using IscaPop.BaseDades;
using IscaPop.Model;
using SQLiteNetExtensionsAsync.Extensions;

namespace IscaPop.Dao
{
    public class CentresDAO
    {
        public CentresDAO() { }

        public List<Centre> getAllCentres()
        {
            List<Centre> listaCentres = BaseDatos.GetConnection().GetAllWithChildrenAsync<Centre>().Result;
            return listaCentres;
        }

        public string buscarCuenta(string codigo)
        {
            Centre centre = BaseDatos.GetConnection().GetAllWithChildrenAsync<Centre>(o => o.codigo.Equals(codigo)).Result.FirstOrDefault();
            string nombre = centre.denominacion + " - " + centre.localidad;
            return nombre;
        }
    }
}
