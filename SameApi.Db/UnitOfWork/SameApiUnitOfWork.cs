using SameApi.Db.DbContexts;
using SameApi.Db.Repository;

namespace SameApi.Db.UnitOfWork
{
    public class SameApiUnitOfWork : IApiSameUnitOfWork
    {
        public IApiSameDbContext Context  { get; }
        public IUserRepository UserRepository { get; }
        public IGenderRepository GenderRepository { get; }
        public IProfessionRepository ProfessionRepository { get; }
        public ISchoolRepository SchoolRepository { get; }
        public IPostRepository PostRepository { get; }
        public ICommentRepository CommentRepository { get; }

        public SameApiUnitOfWork(
            IApiSameDbContext context,
            IUserRepository repository,
            IGenderRepository genderRepository,
            IProfessionRepository professionRepository,
            ISchoolRepository schoolRepository,
            IPostRepository postRepository,
            ICommentRepository commentRepository)
        {
            Context = context;
            UserRepository = repository;
            GenderRepository = genderRepository;
            ProfessionRepository = professionRepository;
            SchoolRepository = schoolRepository;
            PostRepository = postRepository;
            CommentRepository = commentRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}