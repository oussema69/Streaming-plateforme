using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Business_Logic_Layer.Model;

namespace back_wachify.Business_Logic_Layer.Services
{
    public class SaisonService:ISaisonService
    {
        private readonly ISaisonRepository _seasonRepository;

        public SaisonService(ISaisonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<List<Season>> GetAllSeriesAsync()
        {
            return await _seasonRepository.GetAllAsync();
        }

        public async Task<Season> GetSeriesByIdAsync(int id)
        {
            return await _seasonRepository.GetByIdAsync(id);
        }

        public async Task<Season> CreateSeriesAsync(SeasonDto saisondto)
        {
            var saison = new Season()
            {
              SeasonNumber= saisondto.SeasonNumber,
              ReleaseDate =saisondto.ReleaseDate,
              SeriesID=saisondto.SeriesID,


    };
            return await _seasonRepository.CreateAsync(saison);
        }

        public async Task<Season> UpdateSeriesAsync(int id, Season updatedSeriesdto)
        {
            var updatedSeries = new Season()
            {
                SeasonNumber = updatedSeriesdto.SeasonNumber,
                ReleaseDate = updatedSeriesdto.ReleaseDate,
                SeriesID = updatedSeriesdto.SeriesID,


            };
            return await _seasonRepository.UpdateAsync(id, updatedSeries);
        }

        public async Task<bool> DeleteSeriesAsync(int id)
        {
            return await _seasonRepository.DeleteAsync(id);
        }
    }
}

