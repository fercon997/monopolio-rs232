using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Monopolio_RS232.Logica
{
    class HouseSquare: Square
    {
        int price;
        int owner = -1;

        public HouseSquare(String name, int price): base(name)
        {
            this.price = price;
        }

        public void setOwner(int owner)
        {
            this.owner = owner;
        }

        public int getPrice()
        {
            return this.price;
        }

        private Boolean NextBoolean()
        {
            Random rand = new Random();
            return rand.Next(100) % 2 == 0;
        }

        public override void doAction(Player player, Board board)
        {
            if (owner < 0)
            {
                Trace.WriteLine(player, player.getName() + ", do you want to buy " + getName() + "?");
                Random rand = new Random();
                if (NextBoolean())
                {
                    Trace.WriteLine(player, player.getName() + " buy " + getName() + " for " + price);
                    owner = player.getID();
                    player.getMoney().substractMoney(price);
                }
                else
                {
                    Trace.WriteLine(player, player.getName() + " don't want to buy " + getName());
                }
            }
            else
            {
                if (owner != player.getID())
                {
                    int lost = price * 70 / 100;
                    Trace.WriteLine(player, player.getName() + " lost " + lost + " money to " + board.getPlayer(owner).getName());
                    player.getMoney().substractMoney(lost);
                    board.getPlayer(owner).getMoney().addMoney(lost);
                }
            }
        }

        
    }
}
