using SQLite;
using SQLiteNetExtensions.Attributes;

namespace IscaPop.Model
{
    [Table("Material")]
    public class Material : Base.Base
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; } }

        private string nom;
        public string Nom { get { return nom; } set { nom = value; } }

        private int stock;
        public int Stock { get {  return stock; } set {  stock = value; } }

        private string estat;
        public string Estat { get {  return estat; } set {  estat = value; } }

        private string descripcio;
        public string Descripcio { get {  return descripcio; } set {  descripcio = value; } }

        private Boolean disponibilitat;
        public Boolean Disponibilitat {  get { return disponibilitat; } set {  disponibilitat = value; } }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Foto> LlistaFotos { get; set; }

        [ForeignKey(typeof(Organisme))]
        public int idOrganisme { get; set; }
        [ManyToOne]
        public Organisme Organisme { get; set; }

        public Material() 
        {
            LlistaFotos = new List<Foto>();
        }

        public Material(int id, string nom, int stock, string estat, string descripcio, bool disponibilitat)
        {
            Id = id;
            Nom = nom;
            Stock = stock;
            Estat = estat;
            Descripcio = descripcio;
            Disponibilitat = disponibilitat;
        }
    }
}
