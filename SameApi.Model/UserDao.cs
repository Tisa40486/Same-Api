using SameApi.Data.Model;
using SameApi.Model.LKP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SameApi.Model
{
    [Table("SameApi_User")]
    public class UserDao : IModelDao
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int Age { get ; set; }
        public DateTime? Birthdate { get; set; }
        public required string Pseudo { get; set; }
        public required string? FirstName { get; set; }
        public required string? LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int NumberFollowers { get; set; }
        public DateTime CreateAt { get; set; }

        public int? GenderDaoId { get; set; }
        public LKP_GenderDao? GenderDao { get; set; }

        public int? SchoolDaoId { get; set; }
        public LKP_SchoolDao? SchoolDao { get; set; }

        public int? ProfessionDaoId { get; set; }
        public LKP_ProfessionDao? ProfessionDao { get; set; }
    }
}