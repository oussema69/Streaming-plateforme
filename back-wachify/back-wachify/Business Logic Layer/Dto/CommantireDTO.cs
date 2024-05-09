using back_wachify.Data.Model;
using back_wachify.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_wachify.Business_Logic_Layer.Dto
{
	public class CommantireDTO
	{
		public int Id { get; set; }

		public string Contenu { get; set; }

		public int UserId { get; set; }

		public int FilmId { get; set; }
	}
}
