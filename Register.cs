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
            List<string> dbUserNames = new List<string>();

            using (var ctx = new QuanDBContext())
            {
                dbUserNames = ctx.Users.Select(u => u.Username).ToList();
            }

            List<string> errors = new List<string>();
            User u = new User();

            do
            {
                foreach (PropertyInfo pi in u.GetType().GetProperties().Where(property => !"Id".Contains(property.Name)))
                {

                    Console.WriteLine($"Enter {pi.Name}");
                    string input = Console.ReadLine();
                    using (var ctx = new QuanDBContext())
                    {
                        if (pi.Name == "Username")
                        {
                            var unique = from user in ctx.Users
                                         where user.Username == input
                                         select user.Username.FirstOrDefault();
                            
                            if (unique.Count() > 0)
                            {
                                Console.WriteLine("NOT UNIQUE");
                            }
                            else
                            {
                                u.Username = input;
                            }
                        }
                    }



                }

                RegistrationValidation rv = new RegistrationValidation();

                ValidationResult results = rv.Validate(u);

                if (results.IsValid == false)
                {
                    foreach (ValidationFailure failure in results.Errors)
                    {
                        System.Console.WriteLine($"{failure.PropertyName}: {failure.ErrorMessage}");
                    }
                }
            } while (false); 

        }
    }
}