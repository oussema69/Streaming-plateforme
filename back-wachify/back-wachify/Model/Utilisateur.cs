using System.ComponentModel.DataAnnotations;

namespace back_wachify.Model
{
	public class Utilisateur
	{
		[Key]
		public int UtilisateurId { get; set; }

		[Required]
		public string Nom { get; set; }

		[Required]
		public string Email { get; set; }
	}
}
