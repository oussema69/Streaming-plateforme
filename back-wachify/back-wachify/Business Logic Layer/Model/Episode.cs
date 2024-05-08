namespace back_wachify.Business_Logic_Layer.Model
{
    public class Episode
    {
        public int EpisodeID { get; set; } // Unique identifier for each episode
        public string Title { get; set; } // The title of the episode
        public string Description { get; set; } // A brief description of the episode
        public string VideoFilePath { get; set; } // Utilisé pour stocker le chemin du fichier vidéo sur le serveur
        public string LogoFilePath { get; set; } // Utilisé pour stocker le chemin du fichier logo sur le serveur


        public int EpisodeNumber { get; set; } // The episode number within the season
        public DateTime ReleaseDate { get; set; } // The date when the episode was released
        public int SeasonID { get; set; } 
        public Season? Season { get; set; } // Navigation property for the season

        // Additional properties or methods can be added here
    }
}
