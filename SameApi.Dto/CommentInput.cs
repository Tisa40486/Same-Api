namespace SameApi.Dto
{
    public class CommentInput
    {
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? ParentCommentId { get; set; } 

    }
}