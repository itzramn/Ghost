using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost
{
    class Usuarios: logo
    {
        private string direccion = @"..\datos.txt"; //Direccion del archivo
        private ArrayList puntajes = new ArrayList();
        private string[,] datosUsuarios = new string[100, 2];
        private int contadorLineasTxt;
        private char[] delimiterChars = { ' ' };
        public string usuarioJugando;

        public Usuarios()
        {
            /*********************************
             SI NO EXISTE EL ARCHIVO, SE CREA
             *********************************/
            crearArchivo();
            leerTxt();
        }

        public void leerTxt()
        {
            limpiarMatriz();
            contadorLineasTxt = 0;
            string line;
            int numeros;

            StreamReader file = new StreamReader(direccion);

            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                for (int i = 0; i < words.Length; i++)
                {
                    datosUsuarios[contadorLineasTxt, i] = words[i];
                }
                numeros = int.Parse(datosUsuarios[contadorLineasTxt, 0]);
                puntajes.Add(numeros);
                contadorLineasTxt++;
            }
            file.Close();
            ordenarPuntajes();
            //Console.WriteLine("There were {0} lines.", contadorLineasTxt);
        }

        public void imprimirJugadores(int x, int y)
        {
            string lee;
            int lugar = 0;
            for (int i = (puntajes.Count - 1); i > 0; i--)
            {
                lugar++;
                lee = puntajes[i].ToString();
                for (int j = 0; j < puntajes.Count; j++)
                {
                    if (lee == datosUsuarios[j, 0])
                    {
                        Console.SetCursorPosition(x, y + lugar);
                        Console.WriteLine("{0}° {1} {2}", lugar, datosUsuarios[j, 0], datosUsuarios[j, 1]);
                    }
                }
            }
        }

        public void imprimirMejoresJugadores(int x, int y, int limiteJugadores, int posicionJugador)
        {
            string lee;
            int lugar = 0;
            int posicion = 0;
            leerTxt();

            for (int i = (puntajes.Count - 1); i > 0; i--)
            {
                lugar++;
                posicion = posicion + 3;
                if(lugar <= limiteJugadores)
                {
                    lee = puntajes[i].ToString();
                    for (int j = 0; j < puntajes.Count; j++)
                    {
                        if(posicionJugador == lugar)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (lee == datosUsuarios[j, 0])
                            {
                                dibujar(x, y + posicion);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(x + 1, y + posicion);
                                Console.WriteLine("{0}°  {1}  {2}", lugar, datosUsuarios[j, 0], datosUsuarios[j, 1]);
                                usuarioJugando = datosUsuarios[j, 1];
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            if (lee == datosUsuarios[j, 0])
                            {
                                dibujar(x, y + posicion);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x + 1, y + posicion);
                                Console.WriteLine("{0}°  {1}  {2}", lugar, datosUsuarios[j, 0], datosUsuarios[j, 1]);
                            }
                        }
                    }
                }
                else
                {
                }
            }
        }

        public void actualizarTxt()
        {
            eliminarArchivo();
            crearArchivo();
            StreamWriter sw = new StreamWriter(direccion, true, Encoding.ASCII);

            for (int i = 1; i < contadorLineasTxt; i++)
            {
                sw.Write("\n{0} {1}", datosUsuarios[i, 0],datosUsuarios[i, 1]);
            }
            sw.Close();
        }
        public void limpiarMatriz()
        {
            for (int i = 0; i < contadorLineasTxt; i++)
            {
                datosUsuarios[i, 0] = "";
                datosUsuarios[i, 1] = " ";
            }
            puntajes.Clear();
        }

        public void actulizarPuntaje(int puntaje, string nombre)
        {
            for (int i = 0; i < contadorLineasTxt; i++)
            {
                if (nombre == datosUsuarios[i, 1])
                {
                    datosUsuarios[i, 0] = puntaje.ToString();
                    datosUsuarios[i, 1] = nombre;
                }
            }
            actualizarTxt();
        }

        public void registrarUsuario(string nombre)
        {
            StreamWriter sw = new StreamWriter(direccion, true, Encoding.ASCII);
            sw.Write("\n0 {0}", nombre);
            sw.Close();
            leerTxt();
        }

        private void eliminarArchivo()
        {
            File.Delete(direccion);
        }

        private void ordenarPuntajes()
        {
            puntajes.Sort();
        }

        private void crearArchivo()
        {
            if (!File.Exists(direccion))
            {
                StreamWriter SW = new StreamWriter(direccion, true, Encoding.ASCII);
                SW.Write("0 AI");
                SW.Close();
            }
        }

        
    }
}
