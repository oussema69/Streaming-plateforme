using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Model;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
    public interface ISeriesService
    {
        Task<bool> DeleteSeriesAsync(int id);
        Task<Series> UpdateSeriesAsync(int id, Series updatedSeries);
        Task<Series> CreateSeriesAsync(SeriesDto series);
        Task<Series> GetSeriesByIdAsync(int id);
        Task<List<Series>> GetAllSeriesAsync();
    }
}
