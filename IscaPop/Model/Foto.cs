using SQLite;
using SQLiteNetExtensions.Attributes;

namespace IscaPop.Model
{
    [Table("Foto")]
    public class Foto : Base.Base
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; } }
        
        [ForeignKey(typeof(Material))]
        public int idMaterial { get; set; }
        [ManyToOne]
        public Material Material { get; set; }

        public Foto() { }
    }
}
