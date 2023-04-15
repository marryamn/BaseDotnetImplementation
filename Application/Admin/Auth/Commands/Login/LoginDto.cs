namespace Application.Admin.Auth.Commands.Login
{
    public class LoginDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}