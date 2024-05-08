using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_wachify.Business_Logic_Layer.Model
{
    public class Series
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeriesID { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string realisateur { get; set; }
        public DateTime ReleaseDate { get; set; } 
        public List<Season>? Seasons { get; set; }
        public bool IsFree { get; set; }
        public int UserId { get; set; }
        public string Genre { get; set; }




    }


}
