namespace Ciber.Models.Request
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}
