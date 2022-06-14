using MiNET;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Fvtplayerresturent
    {
        public Fvtplayerresturent()
        {
            Playerdetail = new PlayerAPI();
            Restaurantdetail = new RestauranAPI();
            Fav = new RestaurantPlayerLink();
        }
        public PlayerAPI Playerdetail { get; set; }
        public RestauranAPI Restaurantdetail { get; set; }

        public RestaurantPlayerLink Fav { get; set; }
        public class FvtplayerresturentList
        {
            public List<PlayerAPI> Playerdetail { get; set; }
            public List<RestauranAPI> Restaurantdetail { get; set; }
            public List<RestaurantPlayerLink> Fav { get; set; }
        }
    }

   
}
