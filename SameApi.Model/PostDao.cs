using SameApi.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace SameApi.Model
{
    [Table("SameApi_Post")]
    public class PostDao : IModelDao
    {
        public int Id { get; set; }
        public int? UserDaoId { get; set; }
        public UserDao? UserDao { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }

        public int? Likes_count { get; set; }
        public int? Comments_count { get; set; }

        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

    }
}
