using Microsoft.EntityFrameworkCore;
using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model;

namespace SameApi.Db.Repository.Implementation
{
    public class UserRepository : BaseRepository<IApiSameDbContext, UserDao>, IUserRepository
    {
        public UserRepository(IApiSameDbContext context) : base(context)
        { }
        public override async Task<IEnumerable<UserDao>> GetAllAsync(bool withNoTracking = true)
        {
            IQueryable<UserDao> query = _context.Set<UserDao>();

            if (withNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.Include(user => user.GenderDao)
                              .Include(user => user.SchoolDao).ThenInclude(user => user.Professions) 
                              .Include(user => user.ProfessionDao)
                              .ToListAsync();
        }

        public override async Task<UserDao?> GetByIdAsync(int id, bool withNoTracking = true)
        {
            IQueryable<UserDao> query = _context.Set<UserDao>();

            if (withNoTracking)
                query = query.AsNoTracking();

            return await query.Include(user => user.GenderDao)
                              .Include(user => user.SchoolDao).ThenInclude(user => user.Professions)
                              .Include(user => user.ProfessionDao)
                                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}