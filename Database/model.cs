using System.ComponentModel;

namespace Database
{
	public class AllUserDataModel
	{
		public UserDataModel[] data { get; set;}
	}

	public class UserDataModel
	{
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string cardNum { get; set; }
		public int pin { get; set; }
		public double balance { get; set; }
	}

	public class updateUserModel
	{
		[DefaultValue(null)]
		public string firstname { get; set; }
		[DefaultValue(null)]
		public string lastname { get; set; }
		[DefaultValue(0)]
		public int pin { get; set; }
		[DefaultValue(0)]
		public double balance { get; set; }
	}
}