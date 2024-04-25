using SQLite;
using SQLiteNetExtensions.Attributes;


namespace IscaPop.Model
{
    [Table("Organisme")]
    public class Organisme : Base.Base
    {
        private int id;
        [AutoIncrement, PrimaryKey]
        public int Id { get { return id; } set { SetProperty(ref id, value); } }

        private int codi;
        public int Codi { get { return codi; } set { SetProperty(ref codi, value); } }

        private string email;
        public string Email { get { return email; } set { SetProperty(ref email, value); } }

        private string password;
        public string Password { get { return password; } set { SetProperty(ref password, value); } }

        private DateTime momento;
        public DateTime Momento { get; set; }

        [OneToMany]
        public List<Material> LlistaMaterials { get; set; }

        [OneToMany]
        public List<Solicitud> Solicitudes { get; set; }

        public Organisme() 
        {
            LlistaMaterials = new List<Material>();
        }
        public Organisme(int codi, string email)
        {
            Codi = codi;
            Email = email;
        }
    }
}
