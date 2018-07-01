using System;
using System.Drawing;

namespace Monopolio_RS232.Logica
{
    public class Player
    {
        int totalWalk = 0;
        int position = 0;
        int positionX = 34;//385;
        int positionY = 209;//385;
        Image image = Properties.Resources.player1;
        int id;
        String name;
        bool brokeout = false;
        Money money = new Money(5000);

        public Player(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetPositionX()
        {
            return positionX;
        }

        public void SetPoisitionX(int positionX)
        {
            this.positionX = positionX;
        }

        public void SetPoisitionY(int positionY)
        {
            this.positionY = positionY;
        }

        public int GetPositionY()
        {
            return positionY;
        }

        public Image GetImage()
        {
            return image;
        }

        public int getTotalWalk()
        {
            return this.totalWalk;
        }

        public int tossDie(Die die)
        {
            int face = die.getFace();
            Console.WriteLine(this.getName() + " toss a die... Face is " + face);
            return face;
        }

        public Money getMoney()
        {
            return money;
        }
        public int getCurrentPosition()
        {
            return this.position;
        }

        public void setPosition(int position)
        {
            this.position = position;
        }

        public void nextTurn()
        {
            this.totalWalk++;
        }

        public String getName()
        {
            return this.name;
        }

        public int getID()
        {
            return this.id;
        }

        public void setBrokeOut(bool brokeout)
        {
            this.brokeout = brokeout;
        }

        public bool isBrokeOut()
        {
            return this.brokeout;
        }

        /*
            Devuelve el id del jugador en forma de String binario 
        */
        public String GetIdAsString()
        {
            return Convert.ToString(this.id, 2).PadLeft(2, '0');
        }
    }
}
