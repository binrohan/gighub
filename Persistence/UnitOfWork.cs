using GigHub.Models;
using GigHub.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork
    {
        public ApplicationDbContext _context { get; }

        public GigRepository Gigs { get; private set; }
        public AttendanceRepository Attendances { get; set; }
        public GenreRepository Genres { get; set; }
        public FollowingRepository Followings { get; set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Genres = new GenreRepository(context);
            Followings = new FollowingRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}