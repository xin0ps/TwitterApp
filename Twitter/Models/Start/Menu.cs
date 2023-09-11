using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Adminnamespace;
using Twitter.Usernamespace;

namespace Twitter.Models.Start
{


        public class Menu
        {
            private static Admin admin = new Admin("admin", "steptest226@gmail.com", "admin");
          
           

            public static void menu()
            {
                string[] menu = { "Admin", "User" };

                int selectedIndex = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");

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
                            if (AdminIsIn)
                            {
                                Admin.addPost();
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
                            if(loginedUser != null)
                            {
                                Admin.showPosts();
                                Console.ReadKey();
                            }
                            else { Console.WriteLine("Olmadii");
                                Console.ReadKey();
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

