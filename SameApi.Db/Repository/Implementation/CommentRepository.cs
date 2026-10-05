using Microsoft.EntityFrameworkCore;
using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model;

namespace SameApi.Db.Repository.Implementation
{
    public class CommentRepository : BaseRepository<IApiSameDbContext, CommentDao>, ICommentRepository
    {
        public CommentRepository(IApiSameDbContext context) : base(context)
        { }
    }
}