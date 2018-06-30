using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Monopolio_RS232.Logica
{
    class PropiedadFactory
    {
        /*
            Este metodo carga el archivo de texto con las propiedades y sus
            respectivos datos, y devuelve un Diccionario formado por la 
            posicion y el Square correspondiente a la propiedad.
        */
        public static Dictionary<int, Square> GenerarTableroDeArchivo(string informacion)
        {
            var result = new Dictionary<int, Square>();

            string[] lineas = Properties.Resources.Propiedades.Split('\n');
            Trace.WriteLine(lineas.Length);
            foreach(var line in lineas)
            {
                // El formato de las lineas del archivo es:
                // Name, Position, Price, Rent, Group
                var split = line.Split(',');
                int posicion = Convert.ToInt32(split[1]);
                int precio = Convert.ToInt32(split[2]);
                int renta = Convert.ToInt32(split[3]);
                Group grupo = PropiedadFactory.StringToGroup(split[4].Trim());

                var propiedad = new HouseSquare(split[0], posicion, precio, renta, grupo);
                Trace.WriteLine(posicion);
                result.Add(propiedad.GetPosition(), propiedad);
            }

            return result;
        }

        private static Group StringToGroup(string groupStr)
        {
            switch (groupStr)
            {
                case "Purple":
                    return Group.PURPLE;

                case "Light-Blue":
                    return Group.LIGHT_BLUE;

                case "Violet":
                    return Group.VIOLET;

                case "Orange":
                    return Group.ORANGE;

                case "Red":
                    return Group.RED;

                case "Yellow":
                    return Group.YELLOW;

                case "Dark-Green":
                    return Group.DARK_GREEN;

                case "Dark-Blue":
                    return Group.DARK_BLUE;

                case "Utilities":
                    return Group.UTILITY;

                case "Railroad":
                    return Group.RAILROAD;

                default:
                    throw new ArgumentException("No concuerda con ningun grupo", "groupStr");
            }
        }
    }
}
