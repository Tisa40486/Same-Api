using Microsoft.EntityFrameworkCore;
using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model;

namespace SameApi.Db.Repository.Implementation
{
    public class PostRepository : BaseRepository<IApiSameDbContext, PostDao>, IPostRepository
    {
        public PostRepository(IApiSameDbContext context) : base(context)
        { }

        public async Task<IEnumerable<PostDao>> GetPostByUserIdAsync(int userId, bool withNoTracking = true)
        {
            IQueryable<PostDao> query = _context.Set<PostDao>();

            if (withNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.Include(post => post.UserDao)
                              .Where(x => x.UserDaoId == userId)
                              .ToListAsync();
        }
    }
}
