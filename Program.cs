using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    internal class Program
    {
        static void LAB(int[,] labirint)
        {
            var x = 0;
            var y = 0;
            Console.SetCursorPosition(42, 1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"                      ИГРА ЛАБИРИТ
                                              Выполнила: Смирнова Кристина, группа ИП-20-3.
                                                       Упраление: W - Вверх
                                                                  S - Вниз
                                                                  D - Вправо
                                                                  A - Влево
                                            Цель: дойти вашим персонажем до конца лабиринта(♥)");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < labirint.GetLength(0); i++, ++y)
            {
                for (int j = 0; j < labirint.GetLength(1); j++, ++x)
                {
                    Console.SetCursorPosition(x, y);
                    if (labirint[i, j] == 1)
                    {
                        Console.Write("█");
                    }
                    if (labirint[i, j] == 3)
                    {
                        Console.Write("♥");
                    }
                }
                x = 0;
            }
            Console.ResetColor();
        }
        static void hod(int[,] labirint, int x, int y, bool prov)
        {
            if (prov)
            {
                Console.Clear();
                LAB(labirint);
                Console.SetCursorPosition(x, y);
                Console.Write("☻");
                Console.SetCursorPosition(55, 0);
            }
            else
            {
                Console.Clear();
                LAB(labirint);
                Console.SetCursorPosition(x, y);
                Console.Write("☺");
                Console.SetCursorPosition(55, 15);
                Console.Write("Вы уперлись в стену!");
            }
        }
        static void finish(int[,] labirint, int x, int y)
        {
            Console.Clear();
            LAB(labirint);
            Console.SetCursorPosition(x, y);
            Console.Write("☺");
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("Вы прошли лабиринт!");
        }

        static void Main(string[] args)
        {
           
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);

            int[,] labirint =
            {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,2,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,1},
            {1,0,1,1,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,0,1},
            {1,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1},
            {1,0,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,0,1,0,1},
            {1,0,1,0,0,0,1,0,0,0,1,0,1,0,0,0,1,0,0,0,1},
            {1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1},
            {1,0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,1},
            {1,0,1,1,1,0,1,1,1,1,1,1,1,0,1,1,1,0,1,0,1},
            {1,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,1},
            {1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,0,1,1,1,0,1},
            {1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1},
            {1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1},
            {1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1},
            {1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            {1,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,1},
            {1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1},
            {1,0,0,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,1},
            {1,0,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1},
            {1,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,3,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };

            LAB(labirint);
            var x = 1;
            var y = 1;
            Console.SetCursorPosition(x, y);
            Console.Write("☺");
            var GameOver = false;
            while (!GameOver)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case ('w'):
                        if (labirint[--y, x] == 1)
                        {
                            ++y;
                            hod(labirint, x, y, false);
                        }
                        else
                        if (labirint[--y, x] == 0)
                        {
                            hod(labirint, x, y, true);
                        }
                        else 
                        {
                            finish(labirint, x, y);

                        }
                        break;

                    case ('s'):
                        if (labirint[++y, x] == 1)
                        {
                            --y;
                            hod(labirint, x, y, false);
                        }
                        else
                        if (labirint[++y, x] == 0)
                        {
                            hod(labirint, x, y, true);
                        }
                        else
                        {
                            finish(labirint, x, y);

                        }
                        break;

                    case ('a'):
                        if (labirint[y, --x] == 1)
                        {
                            ++x;
                            hod(labirint, x, y, false);
                        }
                        else
                        if (labirint[y, --x] == 0)
                        {
                            hod(labirint, x, y, true);
                        }
                        else
                        {
                            finish(labirint, x, y);

                        }
                        break;

                    case ('d'):
                        if (labirint[y, ++x] == 1)
                        {
                            --x;
                            hod(labirint, x, y, false);
                        }
                        else
                        if (labirint[y, ++x] == 0)
                        {
                            hod(labirint, x, y, true);
                        }
                        else
                        {
                            finish(labirint, x, y);

                        }
                        break;
                    default:
                        Console.Clear();
                        LAB(labirint);
                        Console.SetCursorPosition(x, y);
                        Console.Write("☺");
                        break;
                }
            }
            Console.ReadKey();

        }
    }
}
