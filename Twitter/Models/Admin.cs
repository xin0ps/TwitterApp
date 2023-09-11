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
            private Guid id;
            private string? username = null;
            private string? email = null;
            private string? password = null;
            static List<Post> posts = new List<Post>();
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

            public List<Post>? Post
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
            static public void showPosts()
            {
                foreach (var item in posts)
                {
                    Console.WriteLine(item);
                }
            }
            public Admin(string _username, string _email, string _password)
            {
                
                Username = _username;
                Email = _email;
                Password = _password;
               
             
            }
            public static void addPost()
            {
                Console.WriteLine("Write Your Post:");
                string? postText = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(postText))
                {
                    Console.WriteLine("Post is empty");
                    return;
                }

                Post newPost = new Post(postText);
                posts.Add(newPost);
                Console.WriteLine("Post Shared!");
            }
        }
    }
}