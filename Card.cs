using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // Conversion output is limited to 512 chars while you are signed out
    // Please, sign in or register to get more...

    class Card
    {
        private int rank;
        private int suit;
        public Card(int r,int s)
        {
            rank = r;
            suit = s;
        }
        public int getRank()
        {
            return rank;
        }
        public int getSuit()
        {
            return suit;
        }
        public int compareTo(Object ob)
        {
            Card other = (Card)ob;
            int thisRank = this.getRank();
            int otherRank = other.getRank();
            return otherRank - thisRank;
        }
        public bool equals(Object ob)
        {
            if (ob is Card)
            {
                Card other = (Card)ob;
                return rank == other.rank && suit == other.suit;
            }
            else return false;
        }
        public override string ToString()
        {
            String val;
            String[] suitList = { "", "C", "D", "H", "S" };
            if (rank == 1) val = "Ace";
            else if (this.rank == 11) val = "Jack";
            else if (this.rank == 12) val = "Queen";
            else if (this.rank == 13) val = "King";
            else val = Convert.ToString(this.rank);
            String s = val + "of" + suitList[suit];
            for (int k = s.Length + 1; k <= 17; k++) s = s + " ";
            return s;
        }
    }


       
}