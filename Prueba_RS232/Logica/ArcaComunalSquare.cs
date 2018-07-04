using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Monopolio_RS232.Logica
{
    class ArcaComunalSquare : Square
    {
        private Random random;
        private string[] manejados = { "10000", "10101", "10110", "11111" };

        public ArcaComunalSquare(string name, int posicionX, int posicionY) : base(name, posicionX, posicionY)
        {
            random = new Random();
        }

        public override int doAction(Player player, Board board)
        {
            int randIndex = random.Next(0, manejados.Length);

            AplicarAccion(player, board, manejados[randIndex]);

            return 0;
        }

        public static void AplicarAccion(Player player, Board board, string accion)
        {
            Trace.WriteLine("Ejecutando casualidad: " + accion);
            switch (accion)
            {
                // Jugador paga 50 a cada jugador
                case "10000":
                    foreach(var pl in board.getPlayers())
                    {
                        player.getMoney().substractMoney(50);
                        pl.getMoney().addMoney(50);
                    }
                    break;

                case "10101":
                    player.getMoney().addMoney(150);
                    break;

                case "10110":
                    player.getMoney().substractMoney(15);
                    break;

                case "11111":
                    player.getMoney().addMoney(100);
                    break;
            }
        }
    }
}
