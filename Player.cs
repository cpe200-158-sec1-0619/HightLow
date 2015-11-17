using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Player
    {
        public Player(String n)
        {
            name = n;
            playPile = new Pile();
            wonPile = new Pile();
            Score = 0;
        }
        public Card playCard()
        {
            if (playPile.getSize() == 0) useWonPile();
            if (playPile.getSize() > 0)
                return playPile.nextCard();
            return null;
        }
        public String getName()
        {
            return name;
        }
        public void collectCard(Card c)
        {
            wonPile.addCard(c);
        }
        public void collectCards(Pile p)
        {
            wonPile.addCards(p);
        }

        public void useWonPile()
        {
            playPile.clear();
            playPile.addCards(wonPile);
            wonPile.clear();
        }
        public int numCards()
        {
            return playPile.getSize() + wonPile.getSize();
        }
        public void KeepCard()
        {
            this.Score++;
        }
        public int getscore()
        {
            return this.Score;
        }
        private Pile playPile, wonPile;
        private String name;
        private int Score;

        }
    }
