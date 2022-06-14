using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Repository;
using static RestaurantAPI.Models.Fvtplayerresturent;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class controlaapi : Controller
    {
        private readonly ResRepository repo;
        public controlaapi(ResRepository _repo)
        {
            this.repo = _repo;
        }
        [HttpGet]
        public List<PlayerAPI> PlayerIndex()
        {
            return repo.PlayerIndex();
        }
        [HttpPost]
        public bool PlayerCreate(PlayerAPI ply)
        {
            return repo.PlayerCreate(ply);
        }
        [HttpGet]
        public List<RestauranAPI> ResturantIndex()
        {
            return repo.ResturantIndex();
        }
        [HttpPost]
        public bool ResturantCreate(RestauranAPI res)
        {
            return repo.ResturantCreate(res);
        }
        [HttpGet("{name}")]
        public List<RestauranAPI>RetrieveResturant(string name)
        { 
            return repo.RetrieveResturant(name);
        }
        [HttpGet("{name}")]
        public List<PlayerAPI> RetrivePlayer(string name)
        {
            return (repo.RetrivePlayer(name));
        }
        //public IActionResult Mapping()
        //{
        //    return Ok(repo.Mapping());
        //}
        [HttpGet("{name}")]
        public List<string> FvtplayerList(string name)
        {
            return (repo.FvtplayerList(name));
        }
        [HttpGet("{name}")]
        public FvtplayerresturentList FvtplayIndex (string name)
        {
            var statuss = true;
            return (repo.FvtplayIndex(name, statuss));
        }

    }
}
