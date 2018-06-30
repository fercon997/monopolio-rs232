using System;
using System.Collections.Generic;
using System.Text;

namespace Monopolio_RS232.Logica
{
    public abstract class Square
    {
        String name;

        public Square(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return name;
        }

        public abstract void doAction(Player player, Board board);
    }
}
