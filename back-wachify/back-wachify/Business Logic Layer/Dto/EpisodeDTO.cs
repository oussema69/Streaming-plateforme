namespace back_wachify.Business_Logic_Layer.Dto
{
    public class EpisodeDTO
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public string VideoFilePath { get; set; }
        public string LogoFilePath { get; set; } // Utilisé pour stocker le chemin du fichier logo sur le serveur

        public int EpisodeNumber { get; set; } 
        public DateTime ReleaseDate { get; set; } 
        public int SeasonID { get; set; } 

    }


}
