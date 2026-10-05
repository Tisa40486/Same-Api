using SameApi.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace SameApi.Model
{
    [Table("SameApi_Comment")]
    public class CommentDao : IModelDao
    {
        public int Id { get; set; }

        public int? UserDaoId { get; set; }
        public UserDao? UserDao { get; set; }

        public int? PostId { get; set; }
        public PostDao? Post { get; set; }

        public int? ParentCommentId { get; set; }
        public CommentDao? ParentComment { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }

        public int? LikesCount { get; set; } 
        public int? CommentsCount { get; set; } 

        public DateTime? CreatedAt { get; set; }
    }
}