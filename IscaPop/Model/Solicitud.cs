using SQLite;

namespace IscaPop.Model
{
    [Table("Solicitud")]
    public class Solicitud : Base.Base
    {
        private int id;
        [AutoIncrement, PrimaryKey]
        public int Id { get {return id; } set {SetProperty(ref id, value); } }

        private DateTime momemnto;


    }
}
