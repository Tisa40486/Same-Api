using Microsoft.Extensions.DependencyInjection;
using SameApi.Db.DbContexts;
using SameApi.Db.Repository;
using SameApi.Db.Repository.Implementation;
using SameApi.Db.UnitOfWork;

namespace SameApi.Db
{
    public static class DbRegisterExtension
    {
        public static void RegisterSameApiDbContainer(this IServiceCollection services)
        {
            services.AddScoped<IApiSameDbContext, SameApiDbContext>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IApiSameUnitOfWork, SameApiUnitOfWork>();
        }
    }
}