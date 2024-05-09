using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Model;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
	public interface ICommantireService
	{
		public Task<Commantire> AddCommantire(CommantireDTO commantire);
		Task<List<Commantire>> GetAllCommantires();
		Task<Commantire> GetCommantireparid(int id);
		Task<List<Commantire>> GetCommantireParIdVedio(int id);

		void DeleteCommantire(int id);
		Task<Commantire> UpdateCommantire(Commantire commantire);
	}
}
