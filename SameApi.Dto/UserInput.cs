namespace SameApi.Dto
{
    public class UserInput
    {
        public DateTime? Birthdate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Pseudo { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? GenderId { get; set; }
        public int? SchoolId { get; set; }
        public int? ProfessionId { get; set; }
    }
}