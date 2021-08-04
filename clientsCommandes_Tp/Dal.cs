using clientsCommandes_Tp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class EF
    {
        static internal clientsCommandesEntities db = new clientsCommandesEntities();
        static internal ObservableCollection<Client> GetClients()
        {
            db.Clients.Load();
            return db.Clients.Local;
        }
        static internal ObservableCollection<commande> GetCommandes()
        {
            db.commandes.Load();
            return db.commandes.Local;
        }
        static internal void SaveChanges()
        {
            db.SaveChanges();
        }
        static internal void Reload()
        {
            db.Dispose();
            db = new clientsCommandesEntities();
        }
    }
}
