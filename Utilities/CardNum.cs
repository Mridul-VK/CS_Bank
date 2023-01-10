using System;

namespace Utilities
{
	public class CardNum
	{
		public static string cardNumGen()
		{
				const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
				Random rndgen = new Random();
				string cardNum = "";
				for (int i = 0; i < 12; i++)
				{
						int rand = rndgen.Next(1, valid.Length);
						cardNum += valid[rand];
				}
				return cardNum;
		}
	}
}