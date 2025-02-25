using Microsoft.EntityFrameworkCore;
using Soccer_IQ_Demo.Data;
using Soccer_IQ_Demo.Models;

namespace Soccer_IQ_Demo.Repository
{
    public class PlayerRepository
    {

        ApplicationDbContext context = new ApplicationDbContext();
        public List<Player> GetAll(string? include = null)
        {
            return include == null ? context.Players.ToList() : context.Players.Include(include).ToList();


        }

        public Player GetById(int playerId)
        {
            return context.Players.Find(playerId);

        }

        public void Add(Player player)
        {
            context.Players.Add(player);
        }
        public void Edit(Player player)
        {
            context.Players.Update(player);
        }

        public void Delete(Player player)
        {
            context.Players.Remove(player);
        }
        public void Commit()
        {
            context.SaveChanges();
        }

    }
}
