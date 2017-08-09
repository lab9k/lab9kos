using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public interface ITaakRepository
    {
        void AddTaak(Taak taak);

        void RemoveTaak(Taak taak);
        List<Taak> GetAllWithNiveau(TaakRealisatieNiveau niveau);
        IEnumerable<Taak> GetAll();
        void SaveChanges();
    }
}