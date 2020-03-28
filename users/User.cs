using System;
namespace testing
{
    public class User
    {

        public string UID { get; set; }
        public string Username { get; set; }
        public string HashedPass { get; set; }
        public string Email { get; set; }

        public static User GetUIDLessUser(User user)
        {
            return new User
            {
                Username = user.Username,
                HashedPass = user.HashedPass,
                Email = user.Email
            };
        }

    }

}
