using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Business_Logic_Layer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace back_wachify.Business_Logic_Layer.Services
{
	public class CommantireService : ICommantireService
	{
		private readonly ICommantireRepo _commantireRepo;

		public CommantireService(ICommantireRepo commantireRepo)
		{
			_commantireRepo = commantireRepo;
		}
		public async Task<Commantire> AddCommantire(CommantireDTO commantire)
		{

			var com = new Commantire
			{

				Id = commantire.Id,
				Contenu = commantire.Contenu,
				IdUser=commantire.UserId,
				IdFilm=commantire.FilmId,

			};
		   var come=await _commantireRepo.AddCommantire(com);
			return come;

		}

		public async Task<List<Commantire>> GetAllCommantires()
		{
			return await _commantireRepo.GetAllCommantires();
		}


		public async Task<Commantire> GetCommantireparid(int id)
		{
			try
			{
				return await _commantireRepo.GetCommantireparid(id);
			}
			catch (Exception ex) { 
			 throw new Exception(ex.Message);
			}

		}


		public async Task<List<Commantire>> GetCommantireParIdVedio(int id)
		{
			return await _commantireRepo.GetCommantireParIdVedio(id);

		}
		public void DeleteCommantire(int id)
		{
		_commantireRepo.DeleteCommantire(id);

		}






		public async Task<Commantire> UpdateCommantire(Commantire commantire)
		{
			try
			{
				var existingCommantire = await _commantireRepo.GetCommantireparid(commantire.Id);

				if (existingCommantire == null)
				{
					throw new InvalidOperationException("Commantire not found");
				}

				existingCommantire.Contenu = commantire.Contenu;
				existingCommantire.IdUser = commantire.IdUser;
				existingCommantire.IdFilm = commantire.IdFilm;

				await _commantireRepo.UpdateCommantire(existingCommantire);

				return existingCommantire;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error updating Commantire: {ex.Message}");
			}
		}

	}
}
