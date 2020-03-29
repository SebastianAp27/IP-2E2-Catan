using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Logger
{
    public  sealed class EmailLogin
    {
        static Func<int> afterLogin;
        static Func<int>  afterCreatingAcc;
        static Func<int> afterResetingPass;
        public void subscribeToLoginSucceded(Func<int> action  )
        {
                afterLogin = action;
        }
        
        public void subscribeToAccountCreated( Func<int> action)
        {
            afterCreatingAcc = action;
        }

        public void subscribeToPasswordReset(Func<int> action)
        {
            afterRestingPass = action;
        }

        private EmailLogin() { }
        private static readonly object padlock = new object();
        private static EmailLogin instance = null;
        private Func<int> afterRestingPass;

        public static EmailLogin Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new EmailLogin();
                    }
                    return instance;
                }
            }
        }
        public async Task CreateNewAccountAsync(String email, String pass)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBBVQYk-GFc4InkQub-Z-stYing-81UUQc"));
            await authProvider.CreateUserWithEmailAndPasswordAsync(email, pass,"tavi", true);
            if (afterCreatingAcc != null)
                afterCreatingAcc();
        }

        public async Task SignInWithEmailAsync(String email, String pass)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBBVQYk-GFc4InkQub-Z-stYing-81UUQc"));
            await authProvider.SignInWithEmailAndPasswordAsync(email, pass); 
            if ( afterLogin != null)
                afterLogin();
        }

        public async Task EmailResetPassAsync(String email)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDITPuS64TxugEpwPLKU773Q1n-yy58-6k"));
            await authProvider.SendPasswordResetEmailAsync(email);
            if (afterResetingPass!= null)
                afterResetingPass();
        }
    }
}
