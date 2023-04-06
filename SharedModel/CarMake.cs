using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SharedModel
{
    public class CarMake
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
