using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CardDeck
    {
        public int numCard = 52;
        private Card[] deck;
        private int numCards;
        public CardDeck()
        { deck = new Card[52];
          fill();
        }
        public void shuffle()
        {
            for (int next = 0; next < numCards - 1; next++)
            {
                Random rnd = new Random();
                int r = rnd.Next(next, numCards - 1);
                Card temp = deck[next];
                deck[next] = deck[r];
                deck[r] = temp;
            }
        }
        public Card deal()
        {
            if (numCards == 0) return null;
            numCards--; return deck[numCards];
        }
        public int getSize()
        {
            return numCards;
        }
        private void fill()
        {
            int index = 0;
            for (int r = 1; r <= 13; r++)
            {
                for (int s = 1; s <= 4; s++)
                {
                    deck[index] = new Card(r, s);
                    index++;
                }
            }
                
            
            numCards = 52;
        }
        private static int myRandom(int low, int high)
        {
            Random rnd = new Random();
            int n = rnd.Next();
            return (int)((high + 1 - low) * n + low);
        }
    }
}
