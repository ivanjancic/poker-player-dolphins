using Newtonsoft.Json.Linq;
using System;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState)
		{
			//TODO: Use this method to return the value You want to bet
			Console.Out.WriteLine(gameState["players"].ToString());
			foreach (JObject ply in gameState["players"])
            		{
        			 Console.Out.WriteLine(ply["name"]);
            		}
			return 150;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

