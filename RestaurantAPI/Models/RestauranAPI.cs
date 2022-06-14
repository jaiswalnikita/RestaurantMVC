using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class RestauranAPI
    {
        [Key]
        public int RestaurantId{ get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int ContactNumber { get; set; }
        public int hoursofoperation { get; set; }
    }
}
