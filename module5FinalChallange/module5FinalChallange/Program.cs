using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace module5FinalChallange
{
    internal class Program
    {
        static int movementDelay = 200;
        static char playerChar = '@';
        static char foodAppearance = '*';
        static int playerX = 10;
        static int playerY = 10;
        static int foodX;
        static int foodY;
        static bool frozen = false;
        static int lastWindowWidth = Console.WindowWidth;
        static int lastWindowHeight = Console.WindowHeight;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GenerateFood();

            bool running = true;
            bool exitOnInvalidInput = true;
            bool speedBoostEnabled = true;

            while (running)
            {
                if (WindowResized())
                {
                    Console.Clear();
                    Console.WriteLine("Console was resized. Program exiting.");
                    break;
                }

                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(movementDelay);
                    continue;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char keyChar = char.ToLower(keyInfo.KeyChar);

                if (ShouldFreezePlayer())
                {
                    FreezeMovement();
                    continue;
                }

                running = MovePlayer(keyChar, exitOnInvalidInput, speedBoostEnabled);
                if (!running) break;

                if (IsFoodConsumed())
                {
                    ChangePlayerAppearance(foodAppearance);
                    GenerateFood();
                }

                Thread.Sleep(movementDelay);
            }
        }

        static bool WindowResized()
        {
            if (Console.WindowWidth != lastWindowWidth || Console.WindowHeight != lastWindowHeight)
            {
                lastWindowWidth = Console.WindowWidth;
                lastWindowHeight = Console.WindowHeight;
                return true;
            }
            return false;
        }

        static bool ShouldFreezePlayer()
        {
            // Simulate freeze condition (e.g., random chance)
            return frozen;
        }

        static void FreezeMovement()
        {
            Thread.Sleep(1000); // Freeze for 1 second
        }

        static bool MovePlayer(char key, bool exitOnInvalidInput, bool speedBoostEnabled)
        {
            int dx = 0, dy = 0;

            switch (key)
            {
                case 'w': dy = -1; break;
                case 's': dy = 1; break;
                case 'a': dx = -1; break;
                case 'd': dx = 1; break;
                case 'q': return false; // Quit
                default:
                    if (exitOnInvalidInput)
                        return false;
                    else
                        return true;
            }

            if (speedBoostEnabled)
                movementDelay = 100;
            else
                movementDelay = 200;

            playerX = Math.Max(0, Math.Min(Console.WindowWidth - 1, playerX + dx));
            playerY = Math.Max(0, Math.Min(Console.WindowHeight - 1, playerY + dy));

            Console.Clear();
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(playerChar);

            Console.SetCursorPosition(foodX, foodY);
            Console.Write(foodAppearance);

            return true;
        }

        static bool IsFoodConsumed()
        {
            return playerX == foodX && playerY == foodY;
        }

        static void ChangePlayerAppearance(char newAppearance)
        {
            playerChar = newAppearance;
        }

        static void GenerateFood()
        {
            Random rand = new Random();
            foodX = rand.Next(0, Console.WindowWidth);
            foodY = rand.Next(0, Console.WindowHeight);

            Console.SetCursorPosition(foodX, foodY);
            Console.Write(foodAppearance);
        }
    }
}
