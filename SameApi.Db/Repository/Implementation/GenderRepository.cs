using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model.LKP;

namespace SameApi.Db.Repository.Implementation
{
    public class GenderRepository : BaseRepository<IApiSameDbContext, LKP_GenderDao>, IGenderRepository
    {
        private readonly IApiSameDbContext _dbContext;

        public GenderRepository(IApiSameDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task AddAndSaveAsync(LKP_GenderDao entity)
        {
            _dbContext.Set<LKP_GenderDao>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}