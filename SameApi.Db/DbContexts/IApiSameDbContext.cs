using Microsoft.EntityFrameworkCore;
using SameApi.Data.DbContexts;
using SameApi.Model;
using SameApi.Model.LKP;

namespace SameApi.Db.DbContexts
{
    public interface IApiSameDbContext : IBaseDbContext
    {
        public DbSet<UserDao> Users { get; set; }
        public DbSet<LKP_GenderDao> Genders { get; set; }
        public DbSet<LKP_SchoolDao> Schools { get; set; }
        public DbSet<LKP_ProfessionDao> Professions { get; set; }
        public DbSet<PostDao> Posts { get; set; }
        public DbSet<CommentDao> Comments { get; set; }
    }
}