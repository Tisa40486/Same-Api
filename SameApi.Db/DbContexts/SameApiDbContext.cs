using Microsoft.EntityFrameworkCore;
using SameApi.Data.DbContexts;
using SameApi.Model;
using SameApi.Model.LKP;

namespace SameApi.Db.DbContexts
{
    public class SameApiDbContext : BaseDbContext, IApiSameDbContext
    {
        public SameApiDbContext(DbContextOptions<SameApiDbContext> options) : base(options)
        {
        }
        public DbSet<UserDao> Users { get; set; }
        public DbSet<LKP_GenderDao> Genders { get; set; }
        public DbSet<LKP_SchoolDao> Schools { get; set; }
        public DbSet<LKP_ProfessionDao> Professions { get; set; }
        public DbSet<PostDao> Posts { get; set; }
        public DbSet<CommentDao> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ... autre configuration ...
            modelBuilder.Entity<LKP_SchoolDao>()
                        .HasMany(school => school.Professions)
                        .WithMany(profession => profession.Schools);

            modelBuilder.Entity<LKP_GenderDao>().HasData(
               new LKP_GenderDao { Id = 1, Name = "Male" },
               new LKP_GenderDao { Id = 2, Name = "Female" },
               new LKP_GenderDao { Id = 3, Name = "Others" }
            );

            modelBuilder.Entity<LKP_ProfessionDao>().HasData(
                new LKP_ProfessionDao { Id = 1, Name = "Informaticien/ne CFC" },
                new LKP_ProfessionDao { Id = 2, Name = "Electronicien/ne CFC" },
                new LKP_ProfessionDao { Id = 3, Name = "Automaticien/ne CFC" },
                new LKP_ProfessionDao { Id = 4, Name = "Polymécanicien/ne CFC" },
                new LKP_ProfessionDao { Id = 5, Name = "Employé/e de commerce CFC" },
                new LKP_ProfessionDao { Id = 6, Name = "Gestionnaire du commerce de détail CFC" },
                new LKP_ProfessionDao { Id = 7, Name = "Dessinateur/trice en bâtiment CFC" },
                new LKP_ProfessionDao { Id = 8, Name = "Installateur/trice sanitaire CFC" },
                new LKP_ProfessionDao { Id = 9, Name = "Maçon/ne CFC" },
                new LKP_ProfessionDao { Id = 10, Name = "Graphiste CFC" },
                new LKP_ProfessionDao { Id = 11, Name = "Bijoutier/ère CFC" },
                new LKP_ProfessionDao { Id = 12, Name = "Assistant/e en soins et santé communautaire CFC" },
                new LKP_ProfessionDao { Id = 13, Name = "Assistant/e socio-éducatif/ve CFC" }
            );

            modelBuilder.Entity<LKP_SchoolDao>().HasData(
                new LKP_SchoolDao { Id = 1, Name = "CFPT - École d'informatique" },
                new LKP_SchoolDao { Id = 2, Name = "CFPC - École de Commerce Raymond-Uldry" },
                new LKP_SchoolDao { Id = 3, Name = "CFP Construction - Site André-De-Ternier" },
                new LKP_SchoolDao { Id = 4, Name = "CFP Construction - Site du Rhône" },
                new LKP_SchoolDao { Id = 5, Name = "CFP Arts - École d'arts appliqués" },
                new LKP_SchoolDao { Id = 6, Name = "CFPSa - Centre de Formation Professionnelle Santé" },
                new LKP_SchoolDao { Id = 7, Name = "CFPSo - Centre de Formation Professionnelle Social" },
                new LKP_SchoolDao { Id = 8, Name = "CFPT - École d'électronique et de mécanique" }
            );

            modelBuilder.Entity("LKP_ProfessionDaoLKP_SchoolDao").HasData(
                // Professions techniques
                new { SchoolsId = 1, ProfessionsId = 1 },
                new { SchoolsId = 8, ProfessionsId = 2 },
                new { SchoolsId = 8, ProfessionsId = 3 },
                new { SchoolsId = 8, ProfessionsId = 4 },

                // Professions commerciales
                new { SchoolsId = 2, ProfessionsId = 5 },
                new { SchoolsId = 2, ProfessionsId = 6 },

                // Professions de la construction
                new { SchoolsId = 3, ProfessionsId = 9 },
                new { SchoolsId = 3, ProfessionsId = 7 },
                new { SchoolsId = 4, ProfessionsId = 8 },

                // Professions artistiques
                new { SchoolsId = 5, ProfessionsId = 10 },
                new { SchoolsId = 5, ProfessionsId = 11 },

                // Professions santé & social
                new { SchoolsId = 6, ProfessionsId = 12 },
                new { SchoolsId = 7, ProfessionsId = 13 }
            );
        }
    }
}