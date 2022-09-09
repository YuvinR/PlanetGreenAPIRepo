namespace PlanetGreenTaskAPI.Models
{
    public class CredentialModel
    {
        public ClientSettings Credentials { get; set; }

        public partial class ClientSettings
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
