namespace lab9kos.Models.Domain
{
    public interface IGebruikerRepository
    {
        Gebruiker GetByEmail(string name);
    }
}