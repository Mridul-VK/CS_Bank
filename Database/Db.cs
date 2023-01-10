using System;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Database
{
    public class Db
    {
        //DB filepath
        private static string dbjsonPath = Path.Combine(Directory.GetCurrentDirectory(), "./Database/db.json");

        //Fetching all data from DB
        private static UserDataModel[] getAllUsers()
        {
            string fileContent = File.ReadAllText(dbjsonPath);
            UserDataModel[] data = JsonSerializer.Deserialize<AllUserDataModel>(fileContent).data;

            return data;
        }

        //get particular user
        public static UserDataModel getUser(string cardNum)
        {
            UserDataModel[] allUsers = getAllUsers();
            UserDataModel user = Array.Find(allUsers, (UserDataModel user) => { return user.cardNum == cardNum; });
            return user;
        }
			
        //Save user
        private static void saveUser(UserDataModel[] data)
        {
            AllUserDataModel CObj = new AllUserDataModel() { data = data };
            string jsonData = JsonSerializer.Serialize<AllUserDataModel>(CObj, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(dbjsonPath, jsonData);
        }

        //Adding Userdata to db
        public static void addUser(UserDataModel user)
        {
            UserDataModel[] allUsers = getAllUsers();
            UserDataModel[] data = allUsers.Append(user).ToArray();
            saveUser(data);
        }

				//Edit user data
        public static void updateUser(string cardNum, int pin, updateUserModel updatedUser)
        {
            UserDataModel user = getUser(cardNum);
						if (user == null) {
							throw new Exception("User Not Found!");
						}
            if (user.pin != pin)
            {
							throw new Exception("Invalid pin!");
            }

						UserDataModel User = new UserDataModel() {
							firstname = updatedUser.firstname != null ? updatedUser.firstname : user.firstname,
							lastname = updatedUser.lastname != null ? updatedUser.lastname : user.lastname,
							pin = updatedUser.pin != 0 ? updatedUser.pin : pin,
							cardNum = cardNum,
							balance = updatedUser.balance != 0 ? updatedUser.balance : user.balance
						};

            UserDataModel[] allUsers = getAllUsers();
            allUsers = Array.FindAll(allUsers, (UserDataModel user) => { return user.cardNum != cardNum; });
            UserDataModel[] data = allUsers.Append(User).ToArray();
						saveUser(data);
        }

				//Delete User
				public static void deleteUser(string cardNum, int pin)
				{
						UserDataModel user = getUser(cardNum);
						if (user == null) {
							throw new Exception("User Not Found!");
						}
            if (user.pin != pin)
            {
							throw new Exception("Invalid pin!");
            }

						UserDataModel[] allUsers = getAllUsers();
            UserDataModel[] data = Array.FindAll(allUsers, (UserDataModel user) => { return user.cardNum != cardNum; });
						saveUser(data);						
				}
		}
}