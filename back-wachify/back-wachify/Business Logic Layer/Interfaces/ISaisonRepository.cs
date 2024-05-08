using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Model;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
    public interface ISaisonRepository
    {
        Task<List<Season>> GetAllAsync();
        Task<Season> GetByIdAsync(int id);
        Task<Season> CreateAsync(Season series);
        Task<Season> UpdateAsync(int id, Season updatedSeries);
        Task<bool> DeleteAsync(int id);
    }
}
