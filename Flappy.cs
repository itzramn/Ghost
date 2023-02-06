using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ghost
{
    class Flappy
    {
        int Width { set; get; }
        int Height { set; get; }
        Board board;
        Ghost ghost;
        Wall wall1;
        Wall wall2;
        Wall wall3;
        int puntos;
        logo logo = new logo();

        public Flappy(int width, int height)
        {
            Width = width;
            Height = height;
        }
        void Setup()
        {
            board = new Board(Width, Height);
            ghost = new Ghost(Height, Height / 2);
            wall1 = new Wall(35, Width, Height);
            wall2 = new Wall(60, Width, Height);
            wall3 = new Wall(85, Width, Height);
            puntos = 0;
            board.Write();
            Console.SetCursorPosition((Width / 2) - 4, Height + 2);
            Console.Write("Puntuación: ");
            ghost.Write();
            wall1.Move();
            wall2.Move();
            wall3.Move();

        }
        public void Run(string nombreJugador)
        {
            Usuarios usuarios = new Usuarios();
            Console.Clear();
            Setup();
            Console.ReadKey(true);
            while (ghost.Y < Height && ghost.Y > 1)
            {

                if (wall1.X == ghost.X || wall2.X == ghost.X || wall3.X == ghost.X)
                {
                    puntos++;
                }
                if (((ghost.X >= wall1.X - 2 && ghost.X <= wall1.X + 2) && (ghost.Y <= wall1.Y - 1 || ghost.Y >= wall1.Y + 3))
                    || ((ghost.X >= wall2.X - 2 && ghost.X <= wall2.X + 2) && (ghost.Y <= wall2.Y - 1 || ghost.Y >= wall2.Y + 3))
                    || ((ghost.X >= wall3.X - 2 && ghost.X <= wall3.X + 2) && (ghost.Y <= wall3.Y - 1 || ghost.Y >= wall3.Y + 3)))
                {
                    usuarios.actulizarPuntaje(puntos, nombreJugador);
                    Console.Beep();
                    logo.gameOver();
                    break;
                }
                ghost.Logic();
                wall1.Move();
                wall2.Move();
                wall3.Move();
                board.endBoard();////////////////////
                Console.SetCursorPosition((Width / 2) + 8, Height + 2);
                //Console.SetCursorPosition(0, 0);
                Console.Write(puntos);
                Thread.Sleep(300);
                //Cambio de escenario
                if (puntos == 5)
                {
                    Console.SetCursorPosition(3, 3);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    StreamReader archivo3 = new StreamReader(@"Escenario\1.txt");
                    string linea3 = "";
                    ArrayList arrText3 = new ArrayList();
                    while (linea3 != null)
                    {
                        linea3 = archivo3.ReadLine();
                        if (linea3 != null)
                            arrText3.Add(linea3);
                    }
                    archivo3.Close();
                    foreach (string salida in arrText3)
                        Console.WriteLine(salida);
                }


                if (puntos == 10)
                {
                    Console.SetCursorPosition(3, 3);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    StreamReader archivo2 = new StreamReader(@"Escenario\2.txt");
                    string linea2 = "";
                    ArrayList arrText2 = new ArrayList();
                    while (linea2 != null)
                    {
                        linea2 = archivo2.ReadLine();
                        if (linea2 != null)
                            arrText2.Add(linea2);
                    }
                    archivo2.Close();
                    foreach (string salida in arrText2)
                        Console.WriteLine(salida);
                }

                if (puntos == 15)
                {
                    Console.SetCursorPosition(3, 3);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    StreamReader archivo3 = new StreamReader(@"Escenario\3.txt");
                    string linea3 = "";
                    ArrayList arrText3 = new ArrayList();
                    while (linea3 != null)
                    {
                        linea3 = archivo3.ReadLine();
                        if (linea3 != null)
                            arrText3.Add(linea3);
                    }
                    archivo3.Close();
                    foreach (string salida in arrText3)
                        Console.WriteLine(salida);
                }

            }
        }

    }

    class Wall
    {
        public int X { set; get; }
        public int Y { set; get; }
        Random random;
        int boardWidth; 
        int boardHeight;

        public Wall(int x, int boardWidth,int boardHeight)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            random = new Random();
            X = x;
            Y = random.Next(3, boardHeight - 2 );
            Thread.Sleep(10);
        }
        public void Move()
        {
            Write("\0");
            X--;
            Write();
            if(X - 2 <= 0)
            {
                X = 75;
                Y = random.Next(3, boardHeight - 2);
            }
        }
        void Write() //Obstaculos
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if(X-2 >= 1 && X + 2 <= boardWidth-1)
            {
                for(int i = 1; i < Y - 2; i++)
                {
                    Console.SetCursorPosition(X-2, i);
                    Console.Write("│");
                    Console.SetCursorPosition(X + 2, i);
                    Console.Write("│");
                }
                for (int i = boardHeight; i > Y + 2; i--)
                {
                    Console.SetCursorPosition(X - 2, i);
                    Console.Write("│");
                    Console.SetCursorPosition(X + 2, i);
                    Console.Write("│");
                }
                for (int i = X-1; i < X + 2; i++)
                {
                    Console.SetCursorPosition(i, Y+3);
                    Console.Write("─");
                    Console.SetCursorPosition(i, Y-2);
                    Console.Write("─");
                }
                Console.SetCursorPosition(X + 2, Y - 2);
                Console.Write("┘");
                Console.SetCursorPosition(X -2, Y- 2);
                Console.Write("└");
                Console.SetCursorPosition(X + 2, Y + 3);
                Console.Write("┐");
                Console.SetCursorPosition(X-2, Y + 3);
                Console.Write("┌");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        void Write(string str)
        {
            if (X - 2 >= 1 && +2 <= boardWidth - 1)
             {
                for (int i = 1; i < Y - 2; i++)
                {
                    Console.SetCursorPosition(X - 2, i);
                    Console.Write(str);
                    Console.SetCursorPosition(X + 2, i);
                    Console.Write(str);
                }
                for (int i = boardHeight; i > Y + 2; i--)
                {
                    Console.SetCursorPosition(X - 2, i);
                    Console.Write(str);
                    Console.SetCursorPosition(X + 2, i);
                    Console.Write(str);
                }
                for (int i = X - 1; i < X + 2; i++)
                {
                    Console.SetCursorPosition(i, Y + 2);
                    Console.Write(str);
                    Console.SetCursorPosition(i, Y - 2);
                    Console.Write(str);
                }
                Console.SetCursorPosition(X + 2, Y - 2);
                Console.Write(str);
                Console.SetCursorPosition(X - 2, Y - 2);
                Console.Write(str);
                Console.SetCursorPosition(X + 2, Y + 2);
                Console.Write(str);
                Console.SetCursorPosition(X - 2, Y - 2);
                Console.Write(str);
            }
        }
    }
  
    class Ghost
    {
        public int X { set; get; }
        public int Y { set; get; }
        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;
        public Ghost(int x, int y)
        {
            X = x;
            Y = y;
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
        }
        void input()
        {
         if(Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
        public void Logic()
        {
            input();
            if(consoleKey == ConsoleKey.Spacebar)
            {
                Up();
            }
            else
            {
                Down();
            }
            // Dar función al bonton de salida (F2)
            if (consoleKey == ConsoleKey.F2)
            {
                Environment.Exit(1);
            }
            consoleKey = ConsoleKey.A;
        }
        void Up()
        {
            Write("\0");
            Y--;
            Write();
        }
        void Down()
        {
            Write("\0");
            Y++;
            Write();
        }
        public void Write() //Personaje
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(X, Y - 1);
            Console.Write("     ▀▀▄");
            Console.SetCursorPosition(X - 1, Y - 1);
            Console.Write("   ▄▀▀");
            Console.SetCursorPosition(X, Y);
            Console.Write("      ■ █");
            Console.SetCursorPosition(X - 1, Y);
            Console.Write(" ▄▀  ■");
            Console.SetCursorPosition(X + 2, Y + 1);
            Console.Write("   ▀ ▄▀");
            Console.SetCursorPosition(X + 1, Y + 1);
            Console.Write("▀▄");
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write(" ▀▀▀▀");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(X, Y - 1);
            Console.Write("▄");
            Console.SetCursorPosition(X - 1, Y - 1);
            Console.Write("▄");
            Console.SetCursorPosition(X - 1, Y);
            Console.Write("▀");
            Console.SetCursorPosition(X, Y);
            Console.Write("▀");
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        public void Write(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(X, Y - 1);
            Console.Write("         ");
            Console.SetCursorPosition(X - 1, Y - 1);
            Console.Write("         ");
            Console.SetCursorPosition(X, Y);
            Console.Write("         ");
            Console.SetCursorPosition(X - 1, Y);
            Console.Write("         ");
            Console.SetCursorPosition(X + 2, Y + 1);
            Console.Write("        ");
            Console.SetCursorPosition(X + 1, Y + 1);
            Console.Write("         ");
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write("         ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public class Board
    {
        public int Height { set; get; }
        public int Width { set; get; } 
        public Board ()
        {
            Height = 20;
            Width = 80;
        }
        public Board(int width,int height)
        {
            Width = width;
            Height = height;
        }
        public void Write()
        {
            for(int i =1; i<= Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            for (int i = 1; i <= Width; i++)
            {
                Console.SetCursorPosition(i, Height + 1);
                Console.Write("─");
            }
            for (int i = 1; i <= Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
            }
            endBoard();
            Console.SetCursorPosition(0, 0);
            Console.Write("┌"); 
            Console.SetCursorPosition(Width + 1, 0);
            Console.Write("┐");
            Console.SetCursorPosition(0, Height +1);
            Console.Write("└"); 
            Console.SetCursorPosition(Width + 1, Height + 1);
            Console.Write("┘");
        }
        public void endBoard()
        {
            for (int i = 1; i <= Height; i++)
            {
                Console.SetCursorPosition(Width + 1, i);
                Console.Write("│");
            }
            
        }
    }
}
