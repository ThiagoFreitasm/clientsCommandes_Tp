using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class Commandes
    {
        static internal int UpdateCommandes()
        {
            if (Data.EF.db.commandes.Local.Where(c => (c.Prix <= 10)).Count() > 0)
            {
                Data.EF.Reload();
                return -1;
            }
            else
            {
                Data.EF.SaveChanges();
                return 0;
            }
        }
    }
}
