using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Monopolio_RS232.Logica
{
    public enum Group
    {
        PURPLE, LIGHT_BLUE, VIOLET, ORANGE,
        RED, YELLOW, DARK_GREEN, DARK_BLUE,
        UTILITY, RAILROAD
    }

    class HouseSquare: Square
    {
        private int price;
        private int position;
        private int rent;
        private Group group;
        private int owner = -1;
        private int positionX;
        private int positionY;

        public HouseSquare(string name, int price, int positionX, int positionY): base(name, positionX, positionY)
        {
            this.price = price;
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public HouseSquare(string name, int position, int price, int rent, Group group, int positionX, int positionY): base(name, positionX, positionY)
        {
            this.price = price;
            this.position = position;
            this.rent = rent;
            this.group = group;
            this.positionX = positionX;
            this.positionY = positionY;
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

        public override int doAction(Player player, Board board)
        {
            if (owner < 0)
            {
                Trace.WriteLine(player, player.getName() + ", do you want to buy " + getName() + "?");

                DialogResult dialogResult = MessageBox.Show("Quieres comprar esta propiedad?\nPrecio: " + price, this.getName(), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //if (player.getMoney().getMoney() - price < 0)
                    //{
                    Trace.WriteLine("RESTANDO DINERO");
                    Trace.WriteLine(player.getMoney().getMoney());
                        player.getMoney().substractMoney(price);
                    Trace.WriteLine(player.getMoney().getMoney());

                    owner = player.getID();
                        Trace.WriteLine(player, player.getName() + " compró la casa");
                        return 1;
                    //} 
                }
                else if (dialogResult == DialogResult.No)
                {
                    Trace.WriteLine(player, player.getName() + " NO compró la casa");
                    return 0;
                }

                //Random rand = new Random();
                //if (NextBoolean())
                //{
                //    Trace.WriteLine(player, player.getName() + " buy " + getName() + " for " + price);
                //    owner = player.getID();
                //    player.getMoney().substractMoney(price);
                //}
                //else
                //{
                //    Trace.WriteLine(player, player.getName() + " don't want to buy " + getName());
                //}
                Trace.WriteLine("Esto se está ejecutando?");
                return 0;
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
                return 3;
            }
        }

        public int GetPosition()
        {
            return this.position;
       }
    }
}
