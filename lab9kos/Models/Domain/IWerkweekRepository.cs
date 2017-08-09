using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public interface IWerkweekRepository
    {
        List<Werkweek> GetByDate(DateTime date);

        List<Werkweek> GetByGebruiker(Gebruiker gebruiker);

        Werkweek GetById(long id);
        void AddWerkWeek(Werkweek werkweek);

        void SaveChanges();
    }
}