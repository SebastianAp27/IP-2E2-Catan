using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

using Firebase.Database;
using Firebase.Database.Query;

namespace testing
{

    // used for generating strings/users
    class MyRandom
    {

        Random random = new Random();
        private string alphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        // generate random alphanumeric string of given length
        public string String(int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
                sb.Append(alphaNumeric[random.Next(0, alphaNumeric.Length)]);

            return sb.ToString();
        }

        // generate random user object
        public User User()
        {
            return new User
            {
                UID = String(20),
                Username = String(10),
                HashedPass = String(10),
                Email = $"{String(10)}@{String(5)}.com"
            };
        }

    }

    class MainClass
    {

        public static void Main()
        {
            // establish connection to db
            FirebaseClient firebaseClient = new FirebaseClient("https://test-firebase-d905a.firebaseio.com/");

            // create array of users & userIDs
            MyRandom myRandom = new MyRandom();
            List<User> users = new List<User>();
            List<string> userUIDs = new List<string>();
            for (int i = 0; i < 5; i++) {
                User user = myRandom.User();
                users.Add(user);
                userUIDs.Add(user.UID);
            }

            // add generated users to DB;
            for (int i = 0; i < 5; i++)
                AddUser(firebaseClient, users[i]).Wait();

            // sleep 5s
            Thread.Sleep(5000);

            // delete generated users from DB;
            for (int i = 0; i < 5; i++)
                RemoveUser(firebaseClient, userUIDs[i]).Wait();


        }

        public static async Task AddUser(FirebaseClient dbConnection, User user)
        {

            await dbConnection.Child("Users")
                        .Child(user.UID)
                        .PutAsync(User.GetUIDLessUser(user));

        }

        public static async Task RemoveUser(FirebaseClient dbConnection, string UID)
        {
            await dbConnection.Child("Users")
                        .Child(UID)
                        .DeleteAsync();
        }

    }

}
