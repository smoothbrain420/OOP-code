<Query Kind="Program" />

namespace CMP1903M_A01_2223
{
    class Testing
    {
		static void Main(string[] args)
		{

		    // creates a new pack
		    Pack pack = new Pack();
			
		    // prompts the user to choose a shuffle type
		    Console.WriteLine("do you want to shuffle the pack?");
		    Console.WriteLine("enter 0 for no shuffle, 1 for Fisher-Yates shuffle, or 2 for riffle shuffle:");
		    int shuffleType = int.Parse(Console.ReadLine());

		    // shuffles the pack based on the user's choice
		    if (shuffleType == 1)
		    {
				//pack.PrintPackOrder();
		        Pack.fisherYatesShuffle();
				//pack.PrintPackOrder();
		    }
		    else if (shuffleType == 2)
		    {
				//pack.PrintPackOrder();
		        Pack.riffleShuffle();
				//pack.PrintPackOrder();
		    }

		    // deals one card
		    Card card1 = Pack.deal();
		    Console.WriteLine("dealt card: " + card1);

		    // deals a specified number of cards
		    int numCards = 5;
		    Console.WriteLine("dealing " + numCards + " cards...");
		    var cards = Pack.dealCard(numCards);
		    foreach (Card card in cards)
		    {
		        Console.WriteLine(card);
		    }
		}
	}





	class Card
    {
        public string Suit { get; set; } // The suit of the card
        public int Number { get; set; } // The number of the card

        // constructors for creating a new Card instance
        public Card(string suit, int number)
        {
            Suit = suit;
            Number = number;
        }

        // overrides ToString method to print card information as a string
        public override string ToString()
        {
            return Number + " of " + Suit;
        }
    }

    // defines the Pack class
    class Pack
    {
        private static List<Card> cards = new List<Card>(); // List of cards in the pack
        private static int numCardsDealt = 0; // Number of cards that have been dealt

        // constructors for creating a new Pack instance with 52 cards
        public Pack()
        {
            // creates a new pack with 52 cards
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            int[] numbers = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            foreach (string suit in suits)
            {
                foreach (int number in numbers)
                {
                    cards.Add(new Card(suit, number));
                }
            }
        }
		//public void PrintPackOrder()
		//{
		    //foreach (Card card in cards)
		    //{
		        //Console.WriteLine(card);
		    //}
		//}

        // the method for shuffling the cards in the pack using Fisher-Yates shuffle algorithm
        public static void fisherYatesShuffle()
        {
            Random rand = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }

        // the method for shuffling the cards in the pack using riffle shuffle algorithm
        public static void riffleShuffle()
        {
            Random rand = new Random();
            List<Card> half1 = cards.GetRange(0, cards.Count / 2);
            List<Card> half2 = cards.GetRange(cards.Count / 2, cards.Count / 2);

            cards.Clear();

            while (half1.Count > 0 && half2.Count > 0)
            {
                if (rand.NextDouble() < 0.5)
                {
                    cards.Add(half1[0]);
                    half1.RemoveAt(0);
                }
                else
                {
                    cards.Add(half2[0]);
                    half2.RemoveAt(0);
                }
            }

            cards.AddRange(half1);
            cards.AddRange(half2);
        }
        // the method for dealing one card from the pack
        public static Card deal()
        {
            if (numCardsDealt >= cards.Count)
            {
                throw new IndexOutOfRangeException("no more cards in the pack");
            }

            Card card = cards[numCardsDealt];
            numCardsDealt++;
            return card;
        }
		
        public static List<Card> dealCard(int numCards)
        {
            // creates a new list to hold the dealt cards
            List<Card> dealtCards = new List<Card>();

            // deals the specified number of cards from the pack
            for (int i = 0; i < numCards; i++)
            {
                // checks if the pack is empty
                if (cards.Count == 0)
                {
                    Console.WriteLine("the pack is empty.");
                    break;
                }

                // deals the top card from the pack and add it to the dealt cards list
                Card dealtCard = cards[0];
                cards.RemoveAt(0);
                dealtCards.Add(dealtCard);
            }
			
            // returns the list of dealt cards
            return dealtCards;
        }
    }
	

}
	