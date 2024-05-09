using back_wachify.Data.Model;
using back_wachify.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_wachify.Business_Logic_Layer.Model
{
	public class Commantire
	{

		[Key]
		public int Id { get; set; }

		[Required]
		public string? Contenu { get; set; }
		[Required]
		public int IdUser { get; set; }
		[Required]
		public int IdFilm { get; set; }



	}
}
