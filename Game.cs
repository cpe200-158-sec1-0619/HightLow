using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Game
    {
        private Card[] temp1,temp2;
        private Player p1, p2;
        public void play()
        {
            CardDeck cd = new CardDeck();
            string n1, n2;
            Console.Write("What's player1 name ? : ");
            n1 = Console.ReadLine();
            Console.Write("What's player2 name ? : ");
            n2 = Console.ReadLine();
        

            cd.shuffle();
            p1 = new Player(n1);
            p2 = new Player(n2);
           while (cd.getSize() >= 2)
            {
                p1.collectCard(cd.deal());
                p2.collectCard(cd.deal());
            }
            p1.useWonPile();
            p2.useWonPile();
            Pile down = new Pile();
            int t = 0;
            while (p1.numCards()>0)
            {
                if (!enoughCards(1)) break;
                Card c1 = p1.playCard();
                Card c2 = p2.playCard();
                Console.WriteLine("\nTurn " + t + ": ");
                t++;
                Console.Write(p1.getName() + ": " + c1 + " ");
                Console.Write(p2.getName() + ": " + c2 + " ");
                if (c1.compareTo(c2) > 0)
                {
                    p1.KeepCard();
                }
                else if (c1.compareTo(c2) < 0)
                {
                    p2.KeepCard();
                }
                else
                {
                    temp1 = new Card[14];
                    temp2 = new Card[14];
                    temp1[0] = c1;
                    temp2[0] = c2;
                    down.clear();
                    down.addCard(c1);
                    down.addCard(c2);
                    bool done = false;
                    do
                    {
                        int num = c1.getRank();
                        if (!enoughCards(num))
                            break;
                        Console.Write("\nWar! Players put down ");
                        Console.WriteLine(num + " card(s).");
                        for (int m = 1; m <= num; m++)
                        {
                            c1 = p1.playCard();
                            c2 = p2.playCard();
                            temp1[m] = c1;
                            temp2[m] = c2;
                            down.addCard(c1);
                            down.addCard(c2);
                            
                        }
                        Console.Write(p1.getName() + ": " + c1 + " ");
                        Console.Write(p2.getName() + ": " + c2 + " ");
                        if (c1.compareTo(c2) == 0)
                        {
                            for (int m = num; m >= 0 ; m--)
                            {
                                p1.collectCard(temp1[m]);
                                p2.collectCard(temp2[m]);
                            }
                            done = true;
                        }
          
                        else if (c1.compareTo(c2) > 0)
                        {
                            for (int m = 1; m <= num+1; m++) { p1.KeepCard(); }
                                done = true;
                        }
                        else if (c1.compareTo(c2) < 0)
                        {
                            for (int m = 1; m <= num+1; m++) { p2.KeepCard(); }
                            done = true;
                        }
                    }
                    while (!done);
                }
                Console.WriteLine("Card "+ p1.getName()+ " : "+p1.numCards() + " And  Card " + p2.getName() + " : " + p2.numCards());
                Console.WriteLine(p1.getName()+" Score : "+p1.getscore() + " And "+p2.getName() + "  Score : "+ p2.getscore());
            }
        }
        public bool enoughCards(int n)
        {
            if (p1.numCards() < n || p2.numCards() < n)
            return false; return true;
        }
        public Player getWinner()
        {
            if (p1.getscore() > p2.getscore())
                return p1;
            else if (p2.getscore() > p1.getscore())
                return p2;
            else return null;
        }
    }
}
