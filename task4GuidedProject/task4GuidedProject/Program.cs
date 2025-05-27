using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4GuidedProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Sample data for pets: [0]id, [1]species, [2]age, [3]name, [4]physicalDescription, [5]personalityDescription, [6]suggestedDonation
            string[,] ourAnimals = new string[,]
            {
            { "1", "dog", "5", "Max", "medium size, golden fur", "friendly and active", "50" },
            { "2", "cat", "3", "Whiskers", "small size, gray fur", "quiet and shy", "30" },
            { "3", "dog", "2", "Bella", "small size, golden fur", "playful and energetic", "45" },
            { "4", "dog", "7", "Rex", "large size, black fur", "calm and protective", "60" },
            { "5", "bird", "1", "Tweety", "small, yellow feathers", "chirpy and lively", "15" }
            };

            int maxPets = ourAnimals.GetLength(0);

            string userChoice = "";
            string readResult = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Pet Adoption Center");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. List all pets");
                Console.WriteLine("2. Display all dogs with a specified characteristic");
                Console.WriteLine("Exit. Exit the program");
                Console.Write("Enter choice: ");
                userChoice = Console.ReadLine();

                switch (userChoice.ToLower())
                {
                    case "1":
                        Console.WriteLine("\nList of all pets:");
                        for (int i = 0; i < maxPets; i++)
                        {
                            Console.WriteLine($"{ourAnimals[i, 3]} ({ourAnimals[i, 1]}) - Age: {ourAnimals[i, 2]}, Suggested donation: ${ourAnimals[i, 6]}");
                        }
                        Console.WriteLine("\nPress the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "2":
                        // Display all dogs with a specified characteristic
                        string dogCharacteristic = "";

                        // Prompt user until a non-empty input is provided
                        while (dogCharacteristic == "")
                        {
                            Console.WriteLine("\nEnter one desired dog characteristic to search for");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                dogCharacteristic = readResult.ToLower().Trim();
                            }
                        }

                        bool noMatchesDog = true;  // Assume no matches initially
                        string dogDescription = "";

                        // Loop through all animals to find dogs and search descriptions
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 1].ToLower().Contains("dog"))
                            {
                                // Combine physical and personality descriptions
                                dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];

                                // Search for characteristic in combined description
                                if (dogDescription.ToLower().Contains(dogCharacteristic))
                                {
                                    Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                                    Console.WriteLine(dogDescription);

                                    noMatchesDog = false;
                                }
                            }
                        }

                        if (noMatchesDog)
                        {
                            Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
                        }

                        Console.WriteLine("\nPress the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "exit":
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("\nPress the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;
                }

            } while (userChoice.ToLower() != "exit");
            Console.ReadLine();
        }
    }
}
