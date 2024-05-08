namespace back_wachify.Business_Logic_Layer.Model
{
    public class Season
    {
        public int SeasonID { get; set; } // Unique identifier for each season
        public int SeasonNumber { get; set; } // The season number
        public DateTime ReleaseDate { get; set; } // The date when the season was released
        public List<Episode>? Episodes { get; set; } // List of episodes belonging to the season
        public int SeriesID { get; set; } // Foreign key referencing the series to which the season belongs
        public Series Series { get; set; } 

    }
}
