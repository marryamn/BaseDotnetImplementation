namespace Application.User.Auth.Login
{
    public class LoginDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}