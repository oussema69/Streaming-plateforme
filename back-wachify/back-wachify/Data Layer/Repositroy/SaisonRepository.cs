using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Business_Logic_Layer.Model;
using back_wachify.Data;
using Microsoft.EntityFrameworkCore;

namespace back_wachify.Data_Layer.Repositroy
{
    public class SaisonRepository: ISaisonRepository
    {
        private readonly ApplicationDbContext _context;

        public SaisonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Season>> GetAllAsync()
        {
            return await _context.Season.ToListAsync();
        }

        public async Task<Season> GetByIdAsync(int id)
        {
            return await _context.Season.FindAsync(id);
        }

        public async Task<Season> CreateAsync(Season season)
        {
            _context.Season.Add(season);
            await _context.SaveChangesAsync();
            return season;
        }

        public async Task<Season> UpdateAsync(int id, Season updatedSeason)
        {
            var season = await _context.Season.FindAsync(id);
            if (season == null)
            {
                return null;
            }

            season.SeasonNumber = updatedSeason.SeasonNumber;
            season.ReleaseDate = updatedSeason.ReleaseDate;
            season.SeriesID = updatedSeason.SeriesID;

            await _context.SaveChangesAsync();
            return season;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var season = await _context.Season.FindAsync(id);
            if (season == null)
            {
                return false;
            }

            _context.Season.Remove(season);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
