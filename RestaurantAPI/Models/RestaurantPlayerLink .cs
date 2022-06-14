using MiNET;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class RestaurantPlayerLink
    {
      
        public int LinkID { get; set; }
        public int PlayerId { get; set; }
        public int RestaurantId { get; set; }
        public bool Favlist { get; set; }
    }
}
