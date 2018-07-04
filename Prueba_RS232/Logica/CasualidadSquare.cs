using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Monopolio_RS232.Logica
{
    class CasualidadSquare : Square
    {
        Random random;
        string[] manejados = { "00011", "00101", "01100", "01101" };

        public CasualidadSquare(String name, int positionX, int positionY) : base(name, positionX, positionY)
        {
            random = new Random();
        }

        public override int doAction(Player player, Board board)
        {
            int randIndex = random.Next(0, manejados.Length);
            
            AplicarAccion(player, manejados[randIndex]);
            
            return 0;
        }

        public static void AplicarAccion(Player player, string accion)
        {
            Trace.WriteLine("Ejecutando casualidad: " + accion);
            switch (accion) {
                // Jugador recibe 45 del banco
                case "00011":
                    player.getMoney().addMoney(45);
                    break;

                case "00101":
                    player.getMoney().addMoney(100);
                    break;

                case "01100":
                    player.getMoney().substractMoney(50);
                    break;

                case "01101":
                    player.getMoney().substractMoney(100);
                    break;
            }
        }
    }
}
