using System.Collections.Generic;

namespace lab9kos.Models.Domain
{
    public interface IGebruikerRepository
    {
        Gebruiker GetByEmail(string name);
        ICollection<Gebruiker> GetAll();
        void SaveChanges();
    }
}