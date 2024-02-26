using System.ComponentModel.DataAnnotations;

namespace back_wachify.Model
{
	public class Film
	{
		[Key]
		public int Id { get; set; }
		public string VideoFilePath { get; set; } // Utilisé pour stocker le chemin du fichier vidéo sur le serveur
		public string Name { get; set; }
		public string Description { get; set; }

		public Film (string videoFilePath, string name,string description)
		{
			VideoFilePath = videoFilePath;
			Name = name;
			Description = description;
		}

	}
}
