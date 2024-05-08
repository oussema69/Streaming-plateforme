using back_wachify.Business_Logic_Layer.Model;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
    public interface ISerieRepository
    {
        Task<List<Series>> GetAllAsync();
        Task<Series> GetByIdAsync(int id);
        Task<Series> CreateAsync(Series series);
        Task<Series> UpdateAsync(int id, Series updatedSeries);
        Task<bool> DeleteAsync(int id);
    }
}
