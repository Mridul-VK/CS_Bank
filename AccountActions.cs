using System;
using Database;

namespace Account
{
    public class AccountActions
    {

        public static void validation(UserDataModel user, int pin)
        {
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (Convert.ToInt32(Convert.ToString(pin).Substring(0,4)) != user.pin)
            {
                throw new Exception("Invalid Pin");
            }
        }
        
        public static void deposit(UserDataModel user, string cardNum, int pin)
        {
            Console.Write("Enter amount to be deposited: ₹");
            double amount = Convert.ToDouble(Console.ReadLine());

            updateUserModel newUser = new updateUserModel() { balance = user.balance + amount };

            Db.updateUser(cardNum, pin, newUser);

            Console.WriteLine("Cash deposit succesful 🎉");
        }

        public static void withdraw(UserDataModel user, string cardNum, int pin)
        {
            Console.Write("Enter amount to be withdrawn: ₹");
            double amount = Convert.ToDouble(Console.ReadLine());
            if (user.balance < amount)
            {
                throw new Exception("Insufficient balance!");

            }

            updateUserModel newUser = new updateUserModel() { balance = user.balance - amount };

            Db.updateUser(cardNum, pin, newUser);

            Console.WriteLine("Cash withdrawal succesful 🎉");
        }

        public static void showBalance(UserDataModel user, string cardNum, int pin)
        {
            Console.WriteLine("Your current balance is: " + user.balance);
        }
    }
}