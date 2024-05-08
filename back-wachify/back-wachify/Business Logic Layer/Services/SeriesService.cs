using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Business_Logic_Layer.Model;
using back_wachify.Model;

namespace back_wachify.Business_Logic_Layer.Services
{
    public class SeriesService:ISeriesService
    {
        private readonly ISerieRepository _serieRepository;

        public SeriesService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public async Task<List<Series>> GetAllSeriesAsync()
        {
            return await _serieRepository.GetAllAsync();
        }

        public async Task<Series> GetSeriesByIdAsync(int id)
        {
            return await _serieRepository.GetByIdAsync(id);
        }

        public async Task<Series> CreateSeriesAsync(SeriesDto seriesdto)
        {
            var series = new Series()
            {
                Title = seriesdto.Title,
                Description = seriesdto.Description,
                realisateur = seriesdto.Realisateur,

                ReleaseDate = seriesdto.ReleaseDate,
                IsFree = seriesdto.IsFree,
                UserId=seriesdto.UserId,
                Genre = seriesdto.Genre,


            };
            return await _serieRepository.CreateAsync(series);
        }

        public async Task<Series> UpdateSeriesAsync(int id, Series updatedSeriesdto)
        {
            var updatedSeries = new Series()
            {
                Title = updatedSeriesdto.Title,
                Description = updatedSeriesdto.Description,
                realisateur = updatedSeriesdto.realisateur,

                ReleaseDate = updatedSeriesdto.ReleaseDate,
                IsFree= updatedSeriesdto.IsFree,
                Genre = updatedSeriesdto.Genre,


            };
            return await _serieRepository.UpdateAsync(id, updatedSeries);
        }

        public async Task<bool> DeleteSeriesAsync(int id)
        {
            return await _serieRepository.DeleteAsync(id);
        }
    }

}
