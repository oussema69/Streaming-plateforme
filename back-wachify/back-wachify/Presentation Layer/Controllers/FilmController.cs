using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Business_Logic_Layer.Model;
using back_wachify.Business_Logic_Layer.Services;
using back_wachify.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace back_wachify.Presentation_Layer.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class FilmController : ControllerBase
	{
		private readonly IFilmService _filmService;

		public FilmController(IFilmService filmService)
		{
			_filmService = filmService;
		}

		[HttpPost("AddFilm")]
		public async Task<IActionResult>  AddFilm(IFormFile videoFile, IFormFile logoFile, [FromForm] string titre, [FromForm] string description, [FromForm] DateTime AnnéeDeSortie, [FromForm] string Durée, [FromForm] string Genre, [FromForm] bool isfree, [FromForm] int userid)
		{
			var AddFilm = await _filmService.AddFilm(videoFile, logoFile, titre, description, AnnéeDeSortie, Durée, Genre, isfree, userid);
			if (AddFilm != null)
			{
				return Ok(new { AddFilm = AddFilm });
			}
			else
			{
				return BadRequest(new { Message = AddFilm });
			}

		}

		[HttpGet("all")]
		//this methode return getallfilm
		public IActionResult GetAllFilms()
		{
			var films = _filmService.GetAllFilm();
			return Ok(films);
		}


		// GET: api/Uploadvedio/{fileName}
		//this methode return film par titre
		[HttpGet("{Titre}")]
		public async Task<IActionResult> GetFilmTitre(string Titre)
		{
			return await _filmService.GetFilmTitre(Titre);
		}


		// GET: api/Uploadvedio/{fileName}
		//this methode return film par titre
		/*[HttpGet("{idp}")]
		public async Task<IActionResult> GetFilmbyidp(int idp)
		{

			return await _filmService.GetFilmbyidp(idp);


		}*/


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFilm(int id)
		{
			return await _filmService.DeleteFilm(id);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateFilm(IFormFile videoFile, IFormFile logoFile, [FromForm] int id, [FromForm] string titre, [FromForm] string description, [FromForm] DateTime AnnéeDeSortie, [FromForm] string Durée, [FromForm] string Genre, [FromForm] bool isfree, [FromForm] int userid)
		{
			var film= await _filmService.UpdateFilm(videoFile, logoFile, titre, description, AnnéeDeSortie, Durée, Genre, isfree);

			return Ok(film);
		}



	}
}
