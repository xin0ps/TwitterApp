using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
    namespace Usernamespace
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
                        throw new ArgumentException("Name Null");
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
                        throw new ArgumentException("Surname Null");
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
                        throw new ArgumentException("Age Null");
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
                        throw new ArgumentException("Email Null");
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
                        throw new ArgumentException("Password null");
                    }
                    password = value;
                }
            }

            public User( string userName, string userSurname, int userAge, string userEmail, string userPassword)
            {
               
                id = Guid.NewGuid();
                Name = userName;
                Surname = userSurname;
                Age = userAge;
                Email = userEmail;
                Password = userPassword;
            }
        }
    }
}

