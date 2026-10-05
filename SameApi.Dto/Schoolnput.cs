namespace SameApi.Dto
{
    public class Schoolnput
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<int> ProfessionIds { get; set; } = new();
    }
}
