namespace SameApi.Dto
{
    public class PostResponse
    {
        public int Id { get; set; }
        public int? UserDaoId { get; set; }
        public string? Title { get; set; }
        public string? content { get; set; }

        public int? likes_count { get; set; }
        public int? comments_count { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}