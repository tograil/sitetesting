using Microsoft.AspNet.Identity;

namespace Core.Domain.Profiles
{
    public class User : IUser
    {
        public int Id { get; set; }
        

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        string IUser<string>.Id => Id.ToString();

        public string UserName {
            get
            {
                return Email;
            }

            set
            {
                Email = value;
            }
        }
    }
}
