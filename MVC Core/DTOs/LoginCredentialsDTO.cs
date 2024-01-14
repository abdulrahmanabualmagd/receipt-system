namespace MVC_Core.DTOs
{
    public record LoginCredentialsDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
