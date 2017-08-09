using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public interface IWerkweekRepository
    {
        List<Werkweek> GetByWeek(int week);

        List<Werkweek> GetByGebruiker(Gebruiker gebruiker);

        Werkweek GetById(long id);
        void AddWerkDag(Werkweek werkdag);

        void SaveChanges();
    }
}