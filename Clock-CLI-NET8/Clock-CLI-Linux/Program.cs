using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Clock_CLI
{
    internal class Program
    {
        static int lastWidth = Console.WindowWidth;
        static int lastHeight = Console.WindowHeight;

        static void Main(string[] args)
        {
            RunClock();
        }

        private static void RunClock()
        {

            while (true)
            {
                // リサイズ検知
                if (Console.WindowWidth != lastWidth ||
                    Console.WindowHeight != lastHeight)
                {
                    Console.Clear();
                    lastWidth = Console.WindowWidth;
                    lastHeight = Console.WindowHeight;
                }

                GetTime();
                Console.SetCursorPosition(0, 0);
            }
        }

        static void DrawProgressBar(double percent)
        {
            int barWidth = 100;
            int filled = (int)(percent / 100 * barWidth);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Progress: [" + percent.ToString("0.0000") + "%]");

            Console.ResetColor();
            Console.Write(" [");
            for (int i = 0; i < barWidth; i++)
            {
                if (i < filled)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.ResetColor();
            Console.Write("] ");
        }

        private static void GetTime()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Clock-CLI");

            DateTime localTime = DateTime.Now;
            string hour = DateTime.Now.ToString("HH");
            string minute = DateTime.Now.ToString("mm");
            string sec = DateTime.Now.ToString("ss");
            string millisec = DateTime.Now.ToString("fff");
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");

            DateTime utc = DateTime.UtcNow;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixSeconds = (long)(utc - epoch).TotalSeconds;
            long unixMillis = (long)(utc - epoch).TotalMilliseconds;

            string[] bigDigits = { "　　　　　　\r\n　＃＃　　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n　＃＃　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n　　＃　　　\r\n　＃＃　　　\r\n　　＃　　　\r\n　　＃　　　\r\n　　＃　　　\r\n　　＃　　　\r\n　　＃　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n　＃＃　　　\r\n＃　　＃　　\r\n　　　＃　　\r\n　　＃　　　\r\n　＃　　　　\r\n＃　　　　　\r\n＃＃＃＃　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n　＃＃　　　\r\n＃　　＃　　\r\n　　　＃　　\r\n　＃＃　　　\r\n　　　＃　　\r\n＃　　＃　　\r\n　＃＃　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n　　＃＃　　\r\n　　＃＃　　\r\n　＃　＃　　\r\n　＃　＃　　\r\n＃　　＃　　\r\n＃＃＃＃＃　\r\n　　　＃　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n＃＃＃＃　　\r\n＃　　　　　\r\n＃＃＃　　　\r\n　　　＃　　\r\n　　　＃　　\r\n＃　　＃　　\r\n　＃＃　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n　＃＃　　　\r\n＃　　＃　　\r\n＃　　　　　\r\n＃＃＃　　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n　＃＃　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n＃＃＃＃　　\r\n　　　＃　　\r\n　　＃　　　\r\n　　＃　　　\r\n　＃　　　　\r\n　＃　　　　\r\n　＃　　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n　＃＃　　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n　＃＃　　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n　＃＃　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　", "　　　　　　\r\n　＃＃　　　\r\n＃　　＃　　\r\n＃　　＃　　\r\n　＃＃＃　　\r\n　　　＃　　\r\n＃　　＃　　\r\n　＃＃　　　\r\n　　　　　　\r\n　　　　　　\r\n　　　　　　" };
            string[][] bigDigitsLines = new string[10][];
            string[] colon = new string[]
            {
                "　　　　　　",
                "　　　　　　",
                "　＃＃　　　",
                "　　　　　　",
                "　　　　　　",
                "　　　　　　",
                "　　　　　　",
                "　＃＃　　　",
                "　　　　　　",
                "　　　　　　",
                "　　　　　　"
            };
            string[] slash = new string[]
            {
                "　　　＃　　",
                "　　　＃　　",
                "　　＃　　　",
                "　　＃　　　",
                "　＃　　　　",
                "　＃　　　　",
                "＃　　　　　",
                "＃　　　　　",
                "　　　　　　",
                "　　　　　　",
                "　　　　　　"
            };

            for (int i = 0; i < 10; i++)
            {
                bigDigitsLines[i] = bigDigits[i].Split(new[] { "\r\n" }, StringSplitOptions.None);
            }

            Console.ResetColor();
            Console.WriteLine("\n\nTime is");

            int lines = bigDigitsLines[0].Length;

            for (int line = 0; line < lines; line++)
            {
                // 時
                for (int d = 0; d < hour.Length; d++)
                {
                    if (DateTime.Now.Hour == 3 && DateTime.Now.Minute == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    int n = hour[d] - '0';
                    Console.Write(bigDigitsLines[n][line]);
                }

                // コロン
                Console.ResetColor();
                Console.Write(colon[line]);

                // 分
                for (int d = 0; d < minute.Length; d++)
                {
                    if (DateTime.Now.Minute == 39)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (DateTime.Now.Hour == 3 && DateTime.Now.Minute == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (DateTime.Now.Minute == 3 && DateTime.Now.Second == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    int n = minute[d] - '0';
                    Console.Write(bigDigitsLines[n][line]);
                }

                // コロン
                Console.ResetColor();
                Console.Write(colon[line]);

                // 秒
                for (int d = 0; d < sec.Length; d++)
                {
                    if (DateTime.Now.Second == 39)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (DateTime.Now.Minute == 3 && DateTime.Now.Second == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    int n = sec[d] - '0';
                    Console.Write(bigDigitsLines[n][line]);
                }

                // コロン
                Console.ResetColor();
                Console.Write(colon[line]);

                // ミリ秒
                for (int d = 0; d < millisec.Length; d++)
                {
                    Console.ResetColor();
                    int n = millisec[d] - '0';
                    Console.Write(bigDigitsLines[n][line]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n\nDate is");

            for (int line = 0; line < lines; line++)
            {
                // 年
                for (int d = 0; d < year.Length; d++)
                {
                    int n = year[d] - '0';
                    Console.Write(bigDigitsLines[n][line]);
                }

                // スラッシュ
                Console.ResetColor();
                Console.Write(slash[line]);

                // 月
                for (int d = 0; d < month.Length; d++)
                {
                    if (DateTime.Now.Month == 3 && DateTime.Now.Day == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    int n = month[d] - '0';
                    Console.Write(bigDigitsLines[n][line]);
                }

                // スラッシュ
                Console.ResetColor();
                Console.Write(slash[line]);

                // 日
                for (int d = 0; d < day.Length; d++)
                {
                    if (DateTime.Now.Month == 3 && DateTime.Now.Day == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    int n = day[d] - '0';
                    Console.Write(bigDigitsLines[n][line]);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n");
            Console.WriteLine($"Local Time: {localTime}");
            Console.WriteLine($"UTC Time: {localTime.ToUniversalTime()}");
            Console.WriteLine($"Unix Time: {unixSeconds} sec \n {unixMillis} ms");
            Console.WriteLine($"Timezone: {TimeZoneInfo.Local.DisplayName} + {TimeZoneInfo.Local.StandardName}");

            double percent =
                DateTime.Now.TimeOfDay.TotalSeconds /
                TimeSpan.FromDays(1).TotalSeconds * 100;
            Console.WriteLine("\nToday's Progress:");
            DrawProgressBar(percent);
        }
    }
}
