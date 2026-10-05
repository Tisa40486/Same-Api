namespace SameApi.Dto
{
    public class UserResponse
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public int Age { get; set; }
        public required string Pseudo { get; set; }
        public required string Email { get; set; }
        public int NumberFollowers { get; set; }
        public DateTime CreateAt { get; set; }
        public GenderResponse? Gender { get; set; }
        public SchoolResponse? School { get; set; }
    }
}