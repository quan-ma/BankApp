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
                bool isValid;
                foreach (PropertyInfo pi in u.GetType().GetProperties().Where(property => !"Id".Contains(property.Name)))
                {
                    do
                    {
                        Console.WriteLine($"Enter {pi.Name}");
                        string input = Console.ReadLine();
                        pi.SetValue(u, Convert.ChangeType(input, pi.PropertyType), null);
                        RegistrationValidation rv = new RegistrationValidation();
                        ValidationResult results = rv.Validate(u);
                        isValid = rv.CheckValidation(results);

                        if (pi.Name == "Username" && isValid)
                        {
                            var unique = from user in ctx.Users
                                         where user.Username == input
                                         select user.Username.FirstOrDefault();

                            if (unique.Count() > 0)
                            {
                                Console.WriteLine("NOT UNIQUE, try again");
                                isValid = false;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (pi.Name == "Password" && isValid)
                        {
                            Console.WriteLine($"Confirm {pi.Name}");
                            string confirm = Console.ReadLine();
                            if(confirm != input)
                            {
                                Console.WriteLine($"{pi.Name} does not match, try again");
                                isValid = false;
                            }
                        }
                    } while (!isValid);
                }
                ctx.Add(u);
                ctx.SaveChanges();
            }

        }
    }
}