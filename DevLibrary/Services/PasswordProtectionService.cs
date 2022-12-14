using System;

namespace DevLibrary
{
    public class PasswordProtection
    {
        public string PassNoEcho()
        {
            string pass = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        pass += key.KeyChar;

                    }
                    else
                    {
                        if (pass.Length > 0)
                        {
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");

                        }
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            return pass;
        }
        public string PassStars()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {

                        password = password.Substring(0, password.Length - 1);

                        int pos = Console.CursorLeft;

                        Console.SetCursorPosition(pos - 1, Console.CursorTop);

                        Console.Write(" ");

                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }
    }
}

