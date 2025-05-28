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
        static int windowWidth = Console.WindowWidth;
        static int windowHeight = Console.WindowHeight;

        static int playerX;
        static int playerY;

        static int foodX;
        static int foodY;

        // Player appearances for different states:
        // Normal '@', Freeze "(X_X)", Speed Boost "(^-^)"
        static string[] playerStates = { "@", "(X_X)", "(^-^)", "-" };
        // Food appearances - corresponding to player states after consumption
        static char[] foodTypes = { '*', '#', 'S', 'F' };

        static string currentPlayerAppearance;
        static char currentFoodAppearance;

        static int movementDelay = 200;
        static Random rand = new Random();

        // Freeze control
        static bool isFrozen = false;
        static int freezeDurationMs = 2000; // 2 seconds freeze
        static DateTime freezeEndTime;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            InitializeGame();

            bool running = true;
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
                char key = char.ToLower(keyInfo.KeyChar);

                // Check freeze before moving
                if (ShouldFreezePlayer())
                {
                    FreezeMovement();
                    continue; // Skip this iteration, no move allowed
                }

                // Pass true to exit on invalid input, enable speed boost check
                running = MovePlayer(key, exitOnInvalidInput: true, speedBoostEnabled: true);
                if (!running) break;

                if (IsFoodConsumed())
                {
                    HandleFoodConsumption();
                }

                Thread.Sleep(movementDelay);
            }
        }

        static void InitializeGame()
        {
            playerX = windowWidth / 2;
            playerY = windowHeight / 2;
            currentPlayerAppearance = playerStates[0]; // Normal by default

            Console.Clear();
            DrawAtPosition(playerX, playerY, currentPlayerAppearance);

            GenerateFood();
        }

        static bool WindowResized()
        {
            if (Console.WindowWidth != windowWidth || Console.WindowHeight != windowHeight)
            {
                windowWidth = Console.WindowWidth;
                windowHeight = Console.WindowHeight;
                return true;
            }
            return false;
        }

        static void GenerateFood()
        {
            do
            {
                foodX = rand.Next(0, windowWidth);
                foodY = rand.Next(0, windowHeight);
            } while (foodX == playerX && foodY == playerY);

            currentFoodAppearance = foodTypes[rand.Next(foodTypes.Length)];

            DrawAtPosition(foodX, foodY, currentFoodAppearance);
        }

        static void DrawAtPosition(int x, int y, string s)
        {
            if (x >= 0 && x < windowWidth && y >= 0 && y < windowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
        }

        // Overload for single char draw
        static void DrawAtPosition(int x, int y, char c)
        {
            DrawAtPosition(x, y, c.ToString());
        }

        static bool MovePlayer(char key, bool exitOnInvalidInput = false, bool speedBoostEnabled = false)
        {
            const string validKeys = "wasd";

            if (exitOnInvalidInput && !validKeys.Contains(key))
            {
                Console.WriteLine("Unsupported key pressed. Exiting...");
                return false;
            }

            // Erase old player position
            ClearPlayerFromPosition();

            int speed = 1;

            if (speedBoostEnabled && ShouldSpeedBoost())
            {
                // Speed boost = 3 units left/right movement
                speed = 3;
            }

            switch (key)
            {
                case 'w':
                    playerY = Math.Max(0, playerY - speed);
                    break;
                case 'a':
                    playerX = Math.Max(0, playerX - speed);
                    break;
                case 's':
                    playerY = Math.Min(windowHeight - 1, playerY + speed);
                    break;
                case 'd':
                    playerX = Math.Min(windowWidth - 1, playerX + speed);
                    break;
                default:
                    if (!exitOnInvalidInput)
                        return true;
                    return false;
            }

            // Redraw player at new position
            DrawAtPosition(playerX, playerY, currentPlayerAppearance);

            return true;
        }

        static bool IsFoodConsumed()
        {
            // For multi-char player appearance, check coordinates carefully.
            // Simplify: if player occupies (playerX .. playerX+len-1) and playerY == foodY
            // But to keep simple, only check playerX == foodX and playerY == foodY
            // You can enhance collision detection if needed.

            return playerX == foodX && playerY == foodY;
        }

        static void HandleFoodConsumption()
        {
            ChangePlayerAppearance(currentFoodAppearance);

            // If player is frozen, set freeze end time
            if (ShouldFreezePlayer())
            {
                isFrozen = true;
                freezeEndTime = DateTime.Now.AddMilliseconds(freezeDurationMs);
            }

            GenerateFood();
        }

        static void ChangePlayerAppearance(char food)
        {
            // Map food char to player state
            // '*' normal '@'
            // '#' freeze "(X_X)"
            // 'S' speed boost "(^-^)"
            // 'F' normal '-'

            switch (food)
            {
                case '*': currentPlayerAppearance = playerStates[0]; break;    // Normal '@'
                case '#': currentPlayerAppearance = playerStates[1]; break;    // Freeze "(X_X)"
                case 'S': currentPlayerAppearance = playerStates[2]; break;    // Speed boost "(^-^)"
                case 'F': currentPlayerAppearance = playerStates[3]; break;    // Normal '-'
                default: currentPlayerAppearance = playerStates[0]; break;
            }
        }

        static bool ShouldFreezePlayer()
        {
            if (currentPlayerAppearance == playerStates[1]) // "(X_X)"
            {
                // Check if still frozen
                if (isFrozen)
                {
                    if (DateTime.Now < freezeEndTime)
                        return true;

                    // Freeze expired
                    isFrozen = false;
                    // Reset to normal appearance after freeze ends
                    currentPlayerAppearance = playerStates[0];
                }
            }
            return false;
        }

        static void FreezeMovement()
        {
            // Just wait briefly to simulate freeze, actual blocking happens in main loop
            Thread.Sleep(100);
        }

        static bool ShouldSpeedBoost()
        {
            return currentPlayerAppearance == playerStates[2]; // "(^-^)"
        }

        static void ClearPlayerFromPosition()
        {
            // Clear previous player appearance, clear all chars if multi-char appearance

            // Because some appearances are multi-char strings, clear all those chars
            int length = currentPlayerAppearance.Length;

            for (int i = 0; i < length; i++)
            {
                int clearX = playerX + i;
                if (clearX >= 0 && clearX < windowWidth && playerY >= 0 && playerY < windowHeight)
                {
                    Console.SetCursorPosition(clearX, playerY);
                    Console.Write(' ');
                }
            }
        }
    }
    }

