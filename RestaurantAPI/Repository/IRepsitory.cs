using Microsoft.EntityFrameworkCore;
using MiNET;
using RestaurantAPI.Models;
using static RestaurantAPI.Models.Fvtplayerresturent;

namespace RestaurantAPI.Repository
{
    public interface IRepsitory
    {
        List<PlayerAPI> PlayerIndex();
        bool PlayerCreate(PlayerAPI emp);

        List<RestauranAPI> ResturantIndex();
        bool ResturantCreate(RestauranAPI res);

        List<RestauranAPI> RetrieveResturant(string name);
        List<PlayerAPI> RetrivePlayer(string name);

        List<string> FvtplayerList(string name);
        FvtplayerresturentList FvtplayIndex(string name, bool status = true);
    }
    public abstract class ResAbs : IRepsitory
    {

        public abstract List<PlayerAPI> PlayerIndex();
        public abstract bool PlayerCreate(PlayerAPI emp);
        public abstract List<RestauranAPI> ResturantIndex();
        public abstract bool ResturantCreate(RestauranAPI res);

        public abstract List<RestauranAPI> RetrieveResturant(string name);
        public abstract List<PlayerAPI> RetrivePlayer(string name);
        public abstract List<string> FvtplayerList(string name);
        public abstract FvtplayerresturentList FvtplayIndex(string name, bool status = true);
    }
    public class ResRepository : ResAbs
    {
        private readonly ClassContext db;
        private readonly object item;
        public ResRepository(ClassContext db)
        {
            this.db = db;
        }
        public override List<PlayerAPI> PlayerIndex()
        {
            return db.tblplayer.ToList();
        }
        public override bool PlayerCreate(PlayerAPI bin)
        {

            if (bin == null)
            {
                return false;
            }
            else
            {
                if (bin.PlayerId == 0)
                {
                    db.tblplayer.Add(bin);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    db.Entry(bin).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
        }
        public override List<RestauranAPI> ResturantIndex()
        {
            return db.tblresturent.ToList();
        }
        public override bool ResturantCreate(RestauranAPI res)
        {

            if (res == null)
            {
                return false;
            }
            else
            {
                if (res.RestaurantId == 0)
                {
                    db.tblresturent.Add(res);
                    db.SaveChanges();
                    return true;
                }
                else

                {
                    db.Entry(res).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
        }
        public override List<RestauranAPI> RetrieveResturant(string name)
        {
            var obj = db.tblresturent.Where(models => models.Name == name).ToList();
            return obj;
        }
        public override List<PlayerAPI> RetrivePlayer(string name)
        {
            var obj = db.tblplayer.Where(models => models.Name == name).ToList();
            return obj;
        }
       
        public override List<string> FvtplayerList(string name)
        {
            List<string> ListRest = new List<string>();
            var playerId = db.tblplayer.Where(x => x.Name == name).FirstOrDefault().PlayerId;
            var res = (from a in db.tblmapping
                       where a.PlayerId == playerId
                       select new RestauranAPI
                       {
                           RestaurantId = a.RestaurantId,
                       }
                       ).ToList();

            foreach (RestauranAPI item in res)
            {
                var adder = db.tblresturent.Where(x => x.RestaurantId == item.RestaurantId).FirstOrDefault().Name;
                ListRest.Add(adder);
            }
            return ListRest;
        }
        public override FvtplayerresturentList FvtplayIndex(string name, bool status = true)
        {
            FvtplayerresturentList ress = new FvtplayerresturentList();

            var playerDetail = db.tblplayer.Where(x => x.Name == name).ToList();
            if (playerDetail != null)
            {
                var playerID = playerDetail.FirstOrDefault().PlayerId;

                var resDetail = (from map in db.tblmapping
                                 join res in db.tblresturent
                                 on map.RestaurantId equals res.RestaurantId
                                 where map.PlayerId == playerID
                                 select new RestauranAPI
                                 {
                                     RestaurantId = map.RestaurantId,
                                     Name = res.Name
                                 }).ToList();

                ress.Playerdetail = playerDetail;
                ress.Restaurantdetail = resDetail;
            }
            return ress;


        }
    }
}


    
