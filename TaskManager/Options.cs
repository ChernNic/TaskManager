using System;

namespace TaskManager
{
    static class Options
    {
        public static void DisplayOption(int selectedIndex, string[] options , int offset = 0)
        {
            Console.ResetColor();
            if (selectedIndex == 0)
            {
                Console.SetCursorPosition(0, selectedIndex + offset);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(options[selectedIndex]);

                Console.SetCursorPosition(0, selectedIndex + offset + 1);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(options[selectedIndex + 1]);

            }
            else
            {
                Console.SetCursorPosition(0, selectedIndex + offset - 1);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(options[selectedIndex - 1]);

                Console.SetCursorPosition(0, selectedIndex + offset);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(options[selectedIndex]);

                Console.SetCursorPosition(0, selectedIndex + offset + 1);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    Console.WriteLine(options[selectedIndex + 1]);
                }
                catch (Exception)
                {
                    Console.ResetColor();
                }
            }
        }
    }
}
