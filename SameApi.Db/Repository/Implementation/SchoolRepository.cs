using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model.LKP;

namespace SameApi.Db.Repository.Implementation
{
    public class SchoolRepository : BaseRepository<IApiSameDbContext, LKP_SchoolDao>, ISchoolRepository
    {
        private readonly IApiSameDbContext _dbContext;

        public SchoolRepository(IApiSameDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAndSaveAsync(LKP_SchoolDao entity)
        {
            _dbContext.Set<LKP_SchoolDao>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}