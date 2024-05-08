using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Model;
using back_wachify.Data;
using Microsoft.AspNetCore.Mvc;

namespace back_wachify.Data_Layer.Repositroy
{
    public class EpisodeRepository
    {
        private readonly ApplicationDbContext _context;
        public EpisodeRepository(ApplicationDbContext context) {
        _context = context;
        }
        private readonly string _uploadFolder = "UploadedVideos"; // Directory to store uploaded videos
        private readonly string _uploadLogo = "UploadedLogo"; // Directory to store uploaded videos


        public async Task<Episode> AddEpisode(IFormFile videoFile, IFormFile logoFile, EpisodeDTO episodedto)
        {
            try
            {
                if (videoFile == null || videoFile.Length == 0)
                {
                    throw new ArgumentException("No video file detected.");
                }
                // Create directory if it doesn't exist
                if (!Directory.Exists(_uploadFolder))
                {
                    Directory.CreateDirectory(_uploadFolder);
                }
                // Create directory if it doesn't exist logo
                if (!Directory.Exists(_uploadLogo))
                {
                    Directory.CreateDirectory(_uploadLogo);
                }

                // Generate unique file name to prevent naming conflicts
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + videoFile.FileName;
                var uniqueFileNamelogo = Guid.NewGuid().ToString() + "_" + logoFile.FileName;

                // Combine the upload folder path with the unique file name
                var filePath = Path.Combine(uniqueFileName);
                var filePathlogo = Path.Combine(uniqueFileNamelogo);

                // Save the video file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await videoFile.CopyToAsync(fileStream);

                }

                using (var fileStreamlogo = new FileStream(filePathlogo, FileMode.Create))
                {
                    await videoFile.CopyToAsync(fileStreamlogo);

                }
  
       

        var episode = new Episode
                {
                    VideoFilePath = filePath, // Ajustez selon comment vous voulez enregistrer le chemin
                    Title = episodedto.Title,
                    Description = episodedto.Description,
                    LogoFilePath = filePathlogo,
            EpisodeNumber = episodedto.EpisodeNumber,
                    ReleaseDate = episodedto.ReleaseDate,
            SeasonID = episodedto.SeasonID,
                  

                };
                _context.Episode.Add(episode); // Assurez-vous que votre DbSet s'appelle Films ou ajustez selon le nom réel
                await _context.SaveChangesAsync();
                // You may save the file path to a database or return it as response
                //var fileUrl = Path.Combine("~", filePath);

                return episode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
