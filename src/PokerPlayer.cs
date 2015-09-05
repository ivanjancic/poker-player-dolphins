using Newtonsoft.Json.Linq;
using System;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{

		public static readonly string VERSION = "Dolphins player";

		public static int BetRequest(JObject gameState)
		{
            //TODO: Use this method to return the value You want to bet
            Console.Out.WriteLine(gameState.ToString());

            int maxbet=0;

            foreach (JObject ply in gameState["players"])
            {
                Console.Out.WriteLine(ply["name"]);
                int curbet = int.Parse(ply["bet"].ToString());
                if (curbet > maxbet) maxbet = curbet;
            }
			return maxbet+10;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}

	}
}

