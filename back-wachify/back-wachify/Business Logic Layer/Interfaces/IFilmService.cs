using back_wachify.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
	public interface IFilmService
	{
		Task<Film> AddFilm(IFormFile videoFile, IFormFile logoFile, [FromForm] string titre, [FromForm] string description, [FromForm] DateTime AnnéeDeSortie, [FromForm] string Durée, [FromForm] string Genre, [FromForm] Boolean isfree, [FromForm] int userid);

		IActionResult GetAllFilm();

		Task<IActionResult> GetFilmTitre(string titre);
		//Task<IActionResult> GetFilmbyidp(int idp );


		Task<IActionResult> UpdateFilm(IFormFile videoFile, IFormFile logoFile, [FromForm] int id, [FromForm] string titre, [FromForm] string description, [FromForm] DateTime AnnéeDeSortie, [FromForm] string Durée, [FromForm] string Genre, [FromForm] Boolean isfree);
		Task<IActionResult> DeleteFilm(int id);
	}
}
