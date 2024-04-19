using System.ComponentModel.DataAnnotations;
using System.Data;


namespace MvcNews.Models
{
    public class NewsItem
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
        [Required(ErrorMessage = "Pole Tekst jest wymagane.")]
        [StringLength(140, MinimumLength = 5, ErrorMessage = "Długość Tekstu musi być od 5 do 140 znaków.")]
        public string Text { get; set; } = string.Empty;
        
        [Timestamp]
        public byte[]? RowVersion { get; set; }


    }
}
