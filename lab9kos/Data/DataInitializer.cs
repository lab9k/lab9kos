using System.Threading.Tasks;
using lab9kos.Models;
using lab9kos.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace lab9kos.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Gebruiker> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                //TODO add data


                _context.SaveChanges();
            }
        }
    }
}