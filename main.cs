using System;
using Utilities;

namespace Account
{
    class Program
    {
        public static void Main(string[] args)
        {
						//Initial check
            Console.WriteLine("Please select the action from options below...");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Access ATM");
            Console.WriteLine("3. Exit");
						Console.Write("Enter 1, 2 or 3: ");
						int choice = Convert.ToInt32(Console.ReadLine());

						switch (choice){
						case 1:
							CAccount.createAccount();
							break;
						case 2:
							CAccount.atmAccess();
							break;
						case 3:
							return;
						}
        }
    }
}

