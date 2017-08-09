using System.Collections.Generic;

namespace lab9kos.Models.Domain
{
    public interface IGebruikerRepository
    {
        Gebruiker GetById(long id);
        Gebruiker GetByEmail(string name);
        ICollection<Gebruiker> GetAll();
        void SaveChanges();
    }
}