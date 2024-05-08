using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Model;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
    public interface ISaisonService
    {
        Task<bool> DeleteSeriesAsync(int id);
        Task<Season> UpdateSeriesAsync(int id, Season updatedSeries);
        Task<Season> CreateSeriesAsync(SeasonDto series);
        Task<Season> GetSeriesByIdAsync(int id);
        Task<List<Season>> GetAllSeriesAsync();
    }
}
