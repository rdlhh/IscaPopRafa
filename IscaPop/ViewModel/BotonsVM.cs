using IscaPop.Base;
using IscaPop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IscaPop.ViewModel
{
    public class BotonsVM : BaseViewModel
    {
        private Organisme org;
        public Organisme Org { get { return org; } set { SetProperty(ref org, value); } }
        internal void AssignaDades(Organisme organisme)
        {
            this.Org = organisme;
        }
    }
}
