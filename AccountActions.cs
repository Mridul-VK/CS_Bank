using System;
using Database;

namespace Account
{
    public class AccountActions
    {

        public static void deposit(string cardNum, int pin)
        {
            UserDataModel user = Db.getUser(cardNum);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (pin != user.pin)
            {
                throw new Exception("Invalid Pin");
            }

            Console.Write("Enter amount to be deposited: ₹");
            double amount = Convert.ToDouble(Console.ReadLine());

            updateUserModel newUser = new updateUserModel() { balance = user.balance + amount };

            Db.updateUser(cardNum, pin, newUser);

            Console.WriteLine("Cash deposit succesful 🎉");
        }

        public static void withdraw(string cardNum, int pin)
        {
            UserDataModel user = Db.getUser(cardNum);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (pin != user.pin)
            {
                throw new Exception("Invalid Pin");
            }

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

        public static double showBalance(string cardNum, int pin)
        {
            UserDataModel user = Db.getUser(cardNum);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (pin != user.pin)
            {
                throw new Exception("Invalid Pin");
            }

            return user.balance;
        }
    }
}