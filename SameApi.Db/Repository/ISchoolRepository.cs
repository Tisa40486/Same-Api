using Microsoft.EntityFrameworkCore;
using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model.LKP;

namespace SameApi.Db.Repository
{
    public interface ISchoolRepository : IBaseRepository<IApiSameDbContext, LKP_SchoolDao>
    { 
    }
}