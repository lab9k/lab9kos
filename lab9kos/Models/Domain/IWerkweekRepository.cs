using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    interface IWerkweekRepository
    {
        List<Werkweek> GetByWeek(DateTime week);

        List<Werkweek> GetByGebruiker(Gebruiker gebruiker);

        void AddWerkDag(Werkweek werkdag);

        void SaveChanges();
    }
}