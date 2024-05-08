namespace back_wachify.Business_Logic_Layer.Dto
{
    public class SeriesDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Realisateur { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsFree { get; set; }
        public int UserId { get; set; }
        public string Genre { get; set; }



        // You can include other properties here if needed

        // Optionally, you can include a property to represent the related seasons
        // This property can be populated when needed, depending on your application logic
    }
}
