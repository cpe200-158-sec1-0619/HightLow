using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Pile
    {
        private Card[] pile;
        private int front, end;
        public Pile()
        {
            pile = new Card[52];
            front = 0;
            end = 0;
        }
        public int getSize()
        {
            return end - front;
        }
        public void clear()
        {
            front = 0; end = 0;
        }
        public void addCard(Card c)
        {
            pile[end] = c; end++;
        }
        public void addCards(Pile p)
        {
            while (p.getSize() > 0) addCard(p.nextCard());
        }

        public Card nextCard()
        {
            if (front == end)
                return null;
            Card c = pile[front];
            front++;
            return c;
        }

        }
    }
