using Newtonsoft.Json.Linq;
using System;
using System.Collections;

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
            int ourbet = 0;

            ArrayList cards = new ArrayList();

            foreach (JObject ply in gameState["players"])
            {
                Console.Out.WriteLine(ply["name"]);

                int curbet = int.Parse(ply["bet"].ToString());
                if (curbet > maxbet) maxbet = curbet;
                
                if (ply["name"].Equals("Dolpins"))
                {
                    ourbet = int.Parse(ply["bet"].ToString());
                    foreach (JObject card in ply["hole_cards"])
                    {
                        cards.Add(new Card(int.Parse(card["rank"].ToString()), card["suite"].ToString()));
                    }
                }

            }

            foreach (JObject card in gameState["community_cards"])
            {
                cards.Add(new Card(int.Parse(card["rank"].ToString()), card["suite"].ToString()));
            }


            //  estimacija
            bool guraj = false;

            if (maxbet < 500) guraj = true;
            foreach (Card card1 in cards)
            {
                foreach (Card card2 in cards)
                    if(card1!=card2)
                    {
                        if (card1.rank == card2.rank) guraj = true;
                    }


            }
            if (cards.Count == 2) guraj = true;
            //

            if (!guraj) return ourbet;
			return maxbet+10;
		}

        class Card
        {
            public int rank;
            public string suite;
            public Card(int rank, string suite)
            {
                this.rank = rank;
                this.suite = suite;
            }

            public override string ToString()
            {
                return string.Format("({0},{1})", rank,suite);
            }
        }

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

