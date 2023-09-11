using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Twitter.Usernamespace
{
    internal class User
    {
        Guid id;
        public Guid Id
        {
            get { return id; }
        }

        private string? name = null;
        public string? Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                   throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
            }
        }

        private string? surname = null;
        public string? Surname
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                  throw new ArgumentException("Surname cannot be null or empty.");
                }
                surname = value;
            }
        }

        private int? age = null;
        public int? Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Invalid Age value.");
                }
                age = value;
            }
        }

        private string? email = null;
        public string? Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("Invalid Email value.");
                }
                email = value;
            }
        }

        private string? password = null;
        public string? Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password cannot be null or empty.");
                }
                password = value;
            }
        }

        public User(string userName, string userSurname, int? userAge, string userEmail, string userPassword)
        {
            id = Guid.NewGuid();
            Name = userName;
            Surname = userSurname;
            Age = userAge;
            Email = userEmail;
            Password = userPassword;
            SaveToJson();
        }

        public static void ReadJson()
        {
            string json = File.ReadAllText("User.json");
            Console.WriteLine(json);

            List<User> userList = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (User user in userList)
            {
                Console.WriteLine("User Name: " + user.Name);
            }
        }
        private void SaveToJson()
        {
            string filePath = "User.json";
            List<User> userList = LoadFromJson(filePath) ?? new List<User>();
            userList.Add(this);

          
            string json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(filePath, json);
        }

        public static List<User>? LoadFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    List<User> userList = JsonConvert.DeserializeObject<List<User>>(json);
                    return userList;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
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
            string? name;
            string? surname;
            int? age;
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

            try
            {
                User newuser = new User(name, surname, age, email, password);
                return newuser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return null;
            }
        }

        public override string ToString()
        {
            string txt=this.Name+" "+this.Surname+" "+this.Age+" "+ this.Email+" "+this.Password;
            return txt;
        }
    }
}