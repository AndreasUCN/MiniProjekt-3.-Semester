namespace BlogWebAPI.DTO
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}