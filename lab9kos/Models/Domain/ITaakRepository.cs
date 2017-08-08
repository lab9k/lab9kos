using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    interface ITaakRepository
    {
        void AddTaak(Taak taak);

        void RemoveTaak(Taak taak);
        List<Taak> GetAll();
        void SaveChanges();
    }
}
