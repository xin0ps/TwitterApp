using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.PostNameSpace;
using Twitter.NotificationNamespace;
using Twitter.Usernamespace;
using System.ComponentModel.Design;

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
            private static List<Post> posts = new List<Post>();
            private static List<Notificaiton> notifications = new List<Notificaiton>();

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
            public static int countPosts()
            {
                return posts.Count;
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

            public List<Notificaiton> Notifications
            {
                get { return notifications; }
                set
                {
                  
                    notifications = value;
                }
            }
            static public void showPosts()
            {
                if (posts.Count != 0)
                {
                    foreach (var item in posts)
                    {
                        Console.WriteLine(item);
                    }
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Post yoxdur!");
                    Console.ReadKey();
                }
            }
            public Admin(string _username, string _email, string _password)
            {
                
                Username = _username;
                Email = _email;
                Password = _password;
               
             
            }

            public static void addNotifications(User user , string cont)
            {
                notifications.Add(new Notificaiton(cont));

            }
            public static void showNotifications()
            {
                if (notifications != null)
                {
                    foreach (var item in notifications)
                    {
                        Console.WriteLine(item + "\n");
                    }
                    return;
                }
                else { Console.WriteLine("Empty");
                    Console.ReadKey();
                         return;
                }


            }
            public static Post ViewPost(int id)
            {
                Console.Clear();
                foreach (var item in posts)
                {
                    if (item.Id == id)
                    {
                        
                        item.ViewCount++;
                        Console.WriteLine(item);
                        return item;




                    }
                    else
                    {
                        Console.WriteLine("Post movcud deyil!");
                        Console.ReadKey();
                        return null;
                    }
                   
                }
                return null;
            }

            public static Post LikePost(int id)
            {
               
                foreach (var item in posts)
                {
                    if (item.Id == id)
                    {

                       
                        
                       
                        Console.WriteLine("For like press [l]");
                        Console.WriteLine("For exit press another key");
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.L)
                        {
                            item.LikeCount++;
                            Console.WriteLine("Post Liked!");


                            Console.ReadKey();
                            return item;

                        }


                    }
                    else
                    {
                       
                        Console.ReadKey();
                        return null;
                    }

                }
                return null;
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