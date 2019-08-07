using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OneArmedGangster
{
    class Program
    {
        static Random rnd;
        static bool isPause = false;
        static int d1 = 0, d2 = 0, d3 = 0;
        static bool isExit = false;
        static int highscore = 0, turns = 0;

        static string CheckDigits()
        {
            // три одинаковых числа, два одинаковых числа, 
            // три единицы, три семерки, две единицы, имеется четверка
            if (d1 == d2 && d2 == d3 && d1 == d3)
            {
                highscore += 10;
                return "3 digits equal (+10)";
            }
            else if (d1 == d2 || d2 == d3 || d1 == d3)
            {
                highscore += 5;
                return "2 digits equal (+5)";
            }
            else if (d1 == 1 && d2 == 1 && d1 == 1)
            {
                highscore += 20;
                return "All digits equal 1 (+20)";
            }
            else if (d1 == 7 && d2 == 7 && d1 == 7)
            {
                highscore += 50;
                return "All digits equal 7 (+50)";
            }
            else if ((d1 == 1 && d2 == 1) || (d2 == 1 && d3 == 1) || (d1 == 1 && d3 == 1))
            {
                highscore += 15;
                return "Two digits equal 1 (+15)";
            }
            else if (d1 == 4 || d2 == 4 || d3 == 4)
            {
                highscore += 2;
                return "exist 4... (+2)";
            }
            else
                return "";
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            rnd = new Random();

            Thread t1 = new Thread(new ThreadStart(SpinDigit1));
            Thread t2 = new Thread(new ThreadStart(SpinDigit2));
            Thread t3 = new Thread(new ThreadStart(SpinDigit3));

            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("1) Press SpaceBar to stop/start rotarion;");
            Console.WriteLine("2) Press Enter to exit.");
            Console.WriteLine("Turns: " + turns);
            Console.WriteLine("Your hightscore: " + highscore);

            while (!isExit)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition(1, 5);
                Console.WriteLine("> {0}:{1}:{2} <", d1, d2, d3);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo k = Console.ReadKey();
                    switch (k.Key)
                    {
                        case ConsoleKey.Spacebar:
                            if (isPause)
                            {
                                Console.SetCursorPosition(0, 8);
                                Console.WriteLine("                           ");
                                isPause = false;
                            }
                            else
                            {
                                turns++;
                                Console.SetCursorPosition(7, 2);
                                Console.Write(turns);
                                Console.SetCursorPosition(0, 8);
                                Console.WriteLine(CheckDigits());
                                Console.SetCursorPosition(17, 3);
                                Console.Write(highscore);
                                isPause = true;
                            }
                            break;
                        case ConsoleKey.Enter:
                            isExit = true;
                            break;
                    }
                }
            }
        }

        static void SpinDigit1()
        {
            while (!isExit)
            {
                if (!isPause)
                    d1 = rnd.Next(0, 9);
                Thread.Sleep(25);
            }
        }

        static void SpinDigit2()
        {
            while (!isExit)
            {
                if (!isPause)
                    d2 = rnd.Next(0, 9);
                Thread.Sleep(30);
            }

        }

        static void SpinDigit3()
        {
            while (!isExit)
            {
                if (!isPause)
                    d3 = rnd.Next(0, 9);
                Thread.Sleep(35);
            }

        }
    }
}
