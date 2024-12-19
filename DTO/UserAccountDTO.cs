namespace DTO
{
    public class UserAccountDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserAccountDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
