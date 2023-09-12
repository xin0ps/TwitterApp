using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Adminnamespace;
using Twitter.PostNameSpace;
using Twitter.Usernamespace;

namespace Twitter.Models.Start
{


        public class Menu
        {
            private static Admin admin = new Admin("admin", "rasulsha@code.edu.az", "admin");
          
           

            public static void menu()
        {
           
            

            
            string[] menu = { "Admin", "User" };

                int selectedIndex = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");


                string twitterArt = @"
                                     ___________       .__  __    __                 
                                     \__    ___/_  _  _|__|/  |__/  |_  ___________  
                                      |    |  \ \/ \/ /  \   __\   __\/ __ \_  __ \ 
                                      |    |   \     /|  ||  |  |  | \  ___/|  | \/ 
                                      |____|    \/\_/ |__||__|  |__|  \___  >__|    
                                      \/      
";
                Console.WriteLine(twitterArt);
                for (int i = 0; i < menu.Length; i++)
                    {
                        Console.ForegroundColor = i == selectedIndex ? ConsoleColor.Red : ConsoleColor.White;
                        Console.WriteLine($"\t\t\t\t\t\t\t{menu[i]}");
                    }

                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex = Math.Max(0, selectedIndex - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedIndex = Math.Min(menu.Length - 1, selectedIndex + 1);
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            if (selectedIndex == 0)
                            {
                            bool AdminIsIn = HandleAdminLogin();
                            while (AdminIsIn == true)
                            {
                                Console.Clear();
                                if (AdminIsIn)
                                {
                                    Console.WriteLine("[1]-Share Post\n[2]-Show all Posts\n[3]-See All Users\n[4]-Notifications\n[5]-Exit");
                                    string? secim = Console.ReadLine();
                                    if (secim == "1")
                                    {
                                        Console.Clear();
                                        Admin.addPost();
                                        Console.WriteLine("Press any key for continue...");
                                        Console.ReadKey();
                                    }
                                    else if (secim == "2")
                                    {
                                        Console.Clear();
                                        Admin.showPosts();
                                        Console.WriteLine("Press any key for continue...");
                                        Console.ReadKey();
                                    }
                                    else if (secim == "3")
                                    {
                                        Console.Clear();
                                        User.showAllUsers();
                                        Console.WriteLine("Press any key for continue...");
                                        Console.ReadKey();
                                    }
                                    else if (secim == "4")
                                    {
                                        Console.Clear();
                                        Admin.showNotifications();
                                        Console.WriteLine("Press any key for continue...");
                                        Console.ReadKey();
                                    }
                                    else if (secim == "5")
                                    {
                                        AdminIsIn = false;
                                    }
                                }
                            }
        

                            
                            }
                            else if (selectedIndex == 1)
                            {
                              HandleUserMenu();
                            }
                            break;
                    }
                }
            }

            private static bool HandleAdminLogin()
            {
                while (true)
                {
                    Console.WriteLine("Please Enter admin username:");
                    string? username = Console.ReadLine();
                    Console.WriteLine("Please Enter admin password:");
                    string? password = Console.ReadLine();

                    try
                    {
                        if (username == admin.Username && password == admin.Password)
                        {
                            return  true;
                            
                        }
                        else
                        {
                            throw new Exception("Username or password is incorrect.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
            return false;
            }

            private static void HandleUserMenu()
            {
                string[] userMenu = { "Sign in", "Sign up","Exit" };

                int selectedIndex = 0;
            bool run = true;
                while (run)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");

                    for (int i = 0; i < userMenu.Length; i++)
                    {
                        Console.ForegroundColor = i == selectedIndex ? ConsoleColor.Red : ConsoleColor.White;
                        Console.WriteLine($"\t\t\t\t\t\t\t{userMenu[i]}");
                    }
                    ConsoleKey key = Console.ReadKey().Key;


                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(userMenu.Length - 1, selectedIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (selectedIndex == 0)
                        {
                            User loginedUser = User.SignIn();
                            while (loginedUser != null)
                            {
                                if (loginedUser != null)
                                {
                                    Console.Clear();
                                    Console.WriteLine("[1]-Show Posts\n[2]-Exit");
                                    string? choose = Console.ReadLine();
                                    if (choose == "1")
                                    {
                                        Console.Clear();
                                        Admin.showPosts();
                                        if (Admin.countPosts() != 0)
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Enter id for view Post ([0]-for exit):");
                                                try
                                                {
                                                    int id = Convert.ToInt32(Console.ReadLine());
                                                    if(id == 0)
                                                    {
                                                        break;
                                                    }
                                                    Post post = Admin.ViewPost(id);
                                                    if (post != null)
                                                    {
                                                        Admin.addNotifications(loginedUser, $"{loginedUser.Name} {loginedUser.Surname} viewed your Post id: {post.Id}");
                                                        sendEmail.sendview(admin.Email, "Viewed Your Post ", $"{loginedUser.Name} {loginedUser.Surname} viewed your Post id: {post.Id}");
                                                        Post post1 = Admin.LikePost(id);
                                                        if (post1 != null)
                                                        {
                                                            Admin.addNotifications(loginedUser, $"{loginedUser.Name} {loginedUser.Surname} Liked your Post id: {post.Id}");
                                                            sendEmail.sendview(admin.Email, "Liked Your Post ", $"{loginedUser.Name} {loginedUser.Surname} Liked your Post id: {post.Id}");
                                                            break;
                                                        }
                                                        else { break; }
                                                    }

                                                    Console.ReadKey();
                                                }
                                                catch (Exception ex)
                                                {

                                                    Console.WriteLine(ex.Message);
                                                }
                                            }
                                        }
                                        else { Console.WriteLine("Post empty"); }

                                    }
                                    if (choose == "2") { break; }
                                }
                                else
                                {
                                    Console.WriteLine("User Not Found!");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else if (selectedIndex == 1)
                        {
                            User.SignUp();
                        }
                        else if (selectedIndex == 2)
                        {
                            run = false;
                        }
                        break;
                }

            }
            }
        }
    }

