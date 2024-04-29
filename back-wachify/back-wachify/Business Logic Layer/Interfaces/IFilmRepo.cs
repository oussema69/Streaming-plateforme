using back_wachify.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
	public interface IFilmRepo
	{

		Task<Film> AddFilm(IFormFile videoFile, IFormFile logoFile, [FromForm] string titre, [FromForm] string description, [FromForm] DateTime AnnéeDeSortie, [FromForm] string Durée, [FromForm] string Genre, [FromForm] Boolean isfree, [FromForm] int userid);

		List<Film> GetAllFilm();

		Task<Film> GetFilmByTitre(string Titre);

		//Task<Film> GetFilmByidpart(int  idp);

		Task<Film> GetFilmById(int id);



		Task<Film> UpdateFilm(IFormFile videoFile, IFormFile logoFile, [FromForm] string titre, [FromForm] string description, [FromForm] DateTime AnnéeDeSortie, [FromForm] string Durée, [FromForm] string Genre, [FromForm] Boolean isfree);
		Task DeleteFilm(int id );

	}
}
