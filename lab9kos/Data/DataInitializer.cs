using System.Threading.Tasks;
using lab9kos.Models;
using Microsoft.AspNetCore.Identity;

namespace lab9kos.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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