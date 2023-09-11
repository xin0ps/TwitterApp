using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Twitter.Models;

namespace Twitter.Usernamespace
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(string userName, string userSurname, int userAge, string userEmail, string userPassword)
        {
            Id = Guid.NewGuid();
            Name = userName;
            Surname = userSurname;
            Age = userAge;
            Email = userEmail;
            Password = userPassword;
            SaveToJson();
        }
        private void SaveToJson()
        {
            string filePath = "User.json";
            List<User> userList = LoadFromJson(filePath) ?? new List<User>();
            userList.Add(this);

          
            string json = JsonConvert.SerializeObject(userList,Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<User>? LoadFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    List<User?> userList = JsonConvert.DeserializeObject<List<User?>>(json);
                    return userList;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return null;
            }
        }

        public static void showAllUsers()
        {string filePath = "User.json";
            string json = File.ReadAllText(filePath);
            List<User?> userList = JsonConvert.DeserializeObject<List<User?>>(json);
            if (userList != null)
            {
                foreach (User user in userList)
                {
                    Console.WriteLine(user);
                }
            }
            else { Console.WriteLine("Users empty!"); }
            Console.ReadKey();
        }

        public static User? SignIn()
        {
            string? email;
            string? password;
            Console.WriteLine("Enter your email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();
            string filePath = "User.json";
            List<User>? userList = LoadFromJson(filePath);

            if (userList != null)
            {
                foreach (var user in userList)
                {
                    if (user.Email == email && user.Password == password)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public static User SignUp()
        {
            Random random = new Random();
            int rand = random.Next(100, 999);
            string? name;
            string? surname;
            int age;
            string? email;
            string? password;
            Console.WriteLine("Enter your Name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter your Surname:");
            surname = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();
            sendEmail.sendverification(email, "Verification", rand.ToString());
            Console.WriteLine("Enter your verification code(email):");
            string verify= Console.ReadLine();
            if(verify == null)
            {
                Console.WriteLine("verification code is wrong");
                return null;
            }
            if (verify == rand.ToString())
            {

                try
                {
                    User newuser = new User(name, surname, age, email, password);
                    Console.WriteLine("Sign up succesfully!");
                    Console.ReadKey();
                    return newuser;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    return null;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string txt="Id: "+this.Id+"\n"+"Name: "+this.Name+"\n"+"Surname: "+this.Surname+"\n"+"Age: "+this.Age+"\n"+"Email: "+ this.Email+"\n"+"Password: "+this.Password+"\n";
            return txt;
        }
    }
}