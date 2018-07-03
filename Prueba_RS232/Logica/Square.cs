using System;
using System.Collections.Generic;
using System.Text;

namespace Monopolio_RS232.Logica
{
    public abstract class Square
    {
        String name;
        int positionX;
        int positionY;

        public Square(String name, int positionX, int positionY)
        {
            this.name = name;
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public String getName()
        {
            return name;
        }

        public int GetPositionX()
        {
            return positionX;
        }

        public int GetPositionY()
        {
            return positionY;
        }

        public abstract int doAction(Player player, Board board);
    }
}
