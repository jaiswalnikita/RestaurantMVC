using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class PlayerAPI
    {
        [Key]
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public string? dob { get; set; }
        public string? primaryaddress { get; set; }
        public string? alternateaddress { get; set; }
        public string? officeaddress { get; set; }
        public int mobilenumber { get; set; }
        public string? email { get; set; }
        public string? driverslicense { get; set; }
        public string? passport { get; set; }

    }
}
