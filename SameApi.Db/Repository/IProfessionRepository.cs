using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model.LKP;

namespace SameApi.Db.Repository
{
   
    public interface IProfessionRepository : IBaseRepository<IApiSameDbContext, LKP_ProfessionDao>
    {


    }
}
