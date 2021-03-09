using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BankApp.Models;
using FluentValidation.Results;
using System;

namespace BankApp
{
    public static class Register
    {
        public static void myRegistration()
        {
            using (var ctx = new QuanDBContext())
            {
                User u = new User();
                bool isValid = true;
                foreach (PropertyInfo pi in u.GetType().GetProperties().Where(property => !"Id".Contains(property.Name)))
                {
                    do
                    {
                        Console.WriteLine($"Enter {pi.Name}");
                        string input = pi.Name == "Password" ? HidePassword() : Console.ReadLine();
                        pi.SetValue(u, Convert.ChangeType(input, pi.PropertyType), null);
                        RegistrationValidation rv = new RegistrationValidation();
                        ValidationResult results = rv.Validate(u);
                        isValid = rv.CheckValidation(results);

                        if (pi.Name == "Username" && isValid)
                        {
                            isValid = rv.UniquenessCheck(input);
                        }
                        if (pi.Name == "Password" && isValid)
                        {
                            Console.WriteLine($"Confirm {pi.Name}");
                            string confirm = HidePassword();
                            isValid = rv.ConfirmPassword(input, confirm);
                        }
                    } while (!isValid);
                }
                ctx.Add(u);
                ctx.SaveChanges();
            }

        }
        public static string HidePassword()
        {
            string password = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            return password;
        }
    }
}