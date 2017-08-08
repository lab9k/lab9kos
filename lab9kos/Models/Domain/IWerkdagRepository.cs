using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    interface IWerkdagRepository
    {
        List<Werkdag> GetByWeek(DateTime week);

        List<Werkdag> GetByGebruiker(Gebruiker gebruiker);

        void AddWerkDag(Werkdag werkdag);

        void SaveChanges();
    }
}
