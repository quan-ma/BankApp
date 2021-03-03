using System;
using BankApp.Models;
using R = BankApp.Register;


namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {   
            System.Console.WriteLine("Welcome to MA Bank");
            System.Console.WriteLine("[1] Login \n [2] Register");
            R.myRegistration();


            // using (var ctx = new QuanDBContext())
            // {
            //     var user = new User()
            //     {
            //         FirstName = "Dwight",
            //         Lastname = "Schrute",
            //         Password = "password",
            //         Username = "Dwigt"
            //     };
            //     ctx.Add(user);
            //     ctx.SaveChanges();
            // }

            
        }
    }
}
