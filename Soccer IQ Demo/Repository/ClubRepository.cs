using Microsoft.EntityFrameworkCore;
using Soccer_IQ_Demo.Data;
using Soccer_IQ_Demo.Models;

namespace Soccer_IQ_Demo.Repository
{
    public class ClubRepository
    {


        ApplicationDbContext context=new ApplicationDbContext();
        public List<Club> GetAll(string? include = null)
        {
            return include == null ? context.Clubs.ToList() : context.Clubs.Include(include).ToList();


        }

        public Club GetById(int clubId)
        {
            return context.Clubs.Find(clubId);

        }

        public void Add(Club club) { 
            context.Clubs.Add(club);
        }
        public void Edit(Club club)
        {
            context.Clubs.Update(club);
        }

        public void Delete(Club club)
        {
            context.Clubs.Remove(club);
        }
        public void Commit()
        {
            context.SaveChanges();
        }



    }
}
