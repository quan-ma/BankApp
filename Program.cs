using System;
using BankApp.Models;
using R = BankApp.Register;


namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string selection;
            do
            {
                System.Console.WriteLine("Welcome to MA Bank");
                System.Console.WriteLine("[1] Login \n[2] Register \n[0] Exit");
                selection = Console.ReadLine();
                if (selection == "1")
                {
                    //Login
                }
                if (selection == "2")
                {
                    R.myRegistration();
                }
            } while(selection != "0");





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
