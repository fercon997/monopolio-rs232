﻿using System;

namespace Monopolio_RS232.Logica
{
    public class Die
    {
        public int getFace()
        {
            Random rand = new Random();
            int face = rand.Next(1,6);
            return face;
        }
    }
}
