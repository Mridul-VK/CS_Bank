using System;
using Database;
using Account;

namespace Utilities
{
	public class CAccount
	{
		public static void createAccount()
		{
				//Welcome Message
				Console.WriteLine("Hello! I'm an account creating wizard!");

				//1st Name
				Console.Write("Please enter your firstname: ");
				string firstname = Console.ReadLine();

				//last Name
				Console.Write("Please enter your lastname: ");
				string lastname = Console.ReadLine();

				//Expressing generosity 😉
				Console.WriteLine($"Well {firstname} {lastname}, You've a very cool name! 👌");

				//cardNumber
				string cardNum = CardNum.cardNumGen();
				Console.WriteLine("Your card number is generated. Memorise it or save it somewhere: " + cardNum);

				//Pin
				Console.Write("Please enter a pin: (4 digit only): ");
				int pin = Convert.ToInt32(Console.ReadLine().Substring(0, 4));

				//Initial deposit
				Console.Write("Please enter an initial deposit amount: ₹");
				double initialDeposit = Convert.ToDouble(Console.ReadLine());

				UserDataModel user = new UserDataModel()
				{
					firstname = firstname,
					lastname = lastname,
					cardNum = cardNum,
					pin = pin,
					balance = initialDeposit
				};

				Db.addUser(user);
		}

		public static void atmAccess()
		{
			Console.Write("Please enter your card number: ");
			string cardNum = Console.ReadLine();

			Console.Write("Please enter your pin: ");
			int pin = Convert.ToInt32(Console.ReadLine());
			
			Console.WriteLine("Please select the action from options below...");
			Console.WriteLine("1. Deposit");
			Console.WriteLine("2. Withdraw");
			Console.WriteLine("3. Show balance");
			Console.WriteLine("4. Exit");
			Console.Write("Enter 1, 2, 3 or 4: ");
			int choice = Convert.ToInt32(Console.ReadLine());
			
			switch(choice){
			case 1:
				try
				{
					AccountActions.deposit(cardNum, pin);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					return;
				}
				break;
			case 2:
				AccountActions.withdraw(cardNum, pin);
				break;
			case 3:
				AccountActions.showBalance(cardNum, pin);
				break;
			case 4:
				return;
			}

		}
		
	}
}