using Microsoft.EntityFrameworkCore;
using Soccer_IQ_Demo.Data;
using Soccer_IQ_Demo.Models;

namespace Soccer_IQ_Demo.Repository
{
    public class PlayerStatRepository
    {


        ApplicationDbContext context = new ApplicationDbContext();
        public List<PlayerStat> GetAll(string? include = null)
        {
            return include == null ? context.PlayerStats.ToList() : context.PlayerStats.Include(include).ToList();


        }

        public PlayerStat GetById(int playerStatId)
        {
            return context.PlayerStats.Find(playerStatId);

        }

        public void Add(PlayerStat playerstat)
        {
            context.PlayerStats.Add(playerstat);
        }
        public void Edit(PlayerStat playerstat)
        {
            context.PlayerStats.Update(playerstat);
        }

        public void Delete(PlayerStat playerstat)
        {
            context.PlayerStats.Remove(playerstat);
        }
        public void Commit()
        {
            context.SaveChanges();
        }

    }
}
