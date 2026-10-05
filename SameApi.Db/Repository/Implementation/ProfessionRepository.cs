using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model.LKP;

namespace SameApi.Db.Repository.Implementation
{
    public class ProfessionRepository : BaseRepository<IApiSameDbContext, LKP_ProfessionDao>, IProfessionRepository
    {
        private readonly IApiSameDbContext _dbContext;

        public ProfessionRepository(IApiSameDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAndSaveAsync(LKP_GenderDao entity)
        {
            _dbContext.Set<LKP_GenderDao>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}