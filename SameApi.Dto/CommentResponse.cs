namespace SameApi.Dto
{
    public class CommentResponse
    {
        public int? UserDaoId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int? LikesCount { get; set; }
        public int? CommentsCount { get; set; }

        public int? PostId { get; set; }
        public int? ParentCommentId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
