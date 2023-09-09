using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.PostNameSpace;

namespace Twitter
{
    namespace Adminnamespace
    {
        internal class Admin
        {
            Guid id;
            private string? username = null;
            private string? email = null;
            private string? password = null;
            private Post[]? posts = null;
            private string? notifications = null;

            public Guid Id
            {
                get { return id; }

            }
            public string? Username
            {
                get { return username; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Username Null");
                    }
                    username = value;
                }
            }

            public string? Email
            {
                get { return email; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Email Null");
                    }
                    email = value;
                }
            }

            public string? Password
            {
                get { return password; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Password Null");
                    }
                    password = value;
                }
            }

            public Post[] Post
            {
                get { return posts; }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Post null");
                    }
                    posts = value;
                }
            }

            public string? Notifications
            {
                get { return notifications; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Nofitications null");
                    }
                    notifications = value;
                }
            }

            public Admin(string _username, string _email, string _password, Post[] _posts)
            {
                
                Username = _username;
                Email = _email;
                Password = _password;
                Post = _posts;
             
            }
        }
    }
}