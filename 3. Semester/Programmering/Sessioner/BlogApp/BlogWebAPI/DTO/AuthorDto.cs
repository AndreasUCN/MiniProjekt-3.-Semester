namespace BlogWebAPI.DTO
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string BlogTitle { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string OldPassword { get; set; } = String.Empty;
    }
}
