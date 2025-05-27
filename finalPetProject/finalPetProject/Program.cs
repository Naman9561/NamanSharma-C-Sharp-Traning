using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalPetProject
{
    internal class Program
    {
        struct Animal
    {
        public string ID;
        public string species;
        public int age;
        public string physicalDescription;
        public string personalityDescription;
        public string name;
    }
        static void Main(string[] args)
        {

            Animal[] ourAnimals = new Animal[10];

            string readResult;
            string menuSelection = "";
            //
            while (menuSelection != "exit")
            {
                Console.Clear();
                Console.WriteLine("Contoso Pet Friends App");
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. List all of our current pet information");
                Console.WriteLine("2. Add a new animal friend to the ourAnimals array");
                Console.WriteLine("3. Ensure animal ages and physical descriptions are complete");
                Console.WriteLine("4. Ensure animal nicknames and personality descriptions are complete");
                Console.WriteLine("5-8. Under construction");
                Console.WriteLine("Enter a menu selection or type 'exit' to exit the program");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                switch (menuSelection)
                {
                    case "1":
                        Console.Clear();
                        for (int i = 0; i < ourAnimals.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(ourAnimals[i].ID))
                            {
                                Console.WriteLine($"ID: {ourAnimals[i].ID}");
                                Console.WriteLine($"Species: {ourAnimals[i].species}");
                                Console.WriteLine($"Age: {ourAnimals[i].age}");
                                Console.WriteLine($"Physical Description: {ourAnimals[i].physicalDescription}");
                                Console.WriteLine($"Personality: {ourAnimals[i].personalityDescription}");
                                Console.WriteLine($"Nickname: {ourAnimals[i].name}");
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        int animalIndex = -1;
                        for (int i = 0; i < ourAnimals.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(ourAnimals[i].ID))
                            {
                                animalIndex = i;
                                break;
                            }
                        }

                        if (animalIndex == -1)
                        {
                            Console.WriteLine("Our list is full. Please remove an animal before adding a new one.");
                            Console.ReadLine();
                            break;
                        }

                        Console.Write("Enter pet ID (e.g. d1, c4): ");
                        ourAnimals[animalIndex].ID = Console.ReadLine() ?? "";

                        Console.Write("Enter species (dog or cat): ");
                        ourAnimals[animalIndex].species = Console.ReadLine() ?? "";

                        Console.WriteLine("Pet added. Press Enter to return to menu.");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        bool dataUpdated = false;
                        for (int i = 0; i < ourAnimals.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(ourAnimals[i].ID))
                                continue;

                            while (ourAnimals[i].age == 0)
                            {
                                Console.Write($"Enter an age for ID #: {ourAnimals[i].ID}: ");
                                string? ageInput = Console.ReadLine();
                                if (int.TryParse(ageInput, out int age))
                                {
                                    ourAnimals[i].age = age;
                                    dataUpdated = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Age must be a number.");
                                }
                            }

                            while (string.IsNullOrWhiteSpace(ourAnimals[i].physicalDescription))
                            {
                                Console.Write($"Enter a physical description for ID #: {ourAnimals[i].ID} (size, color, gender, weight, housebroken): ");
                                string? descInput = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(descInput))
                                {
                                    ourAnimals[i].physicalDescription = descInput;
                                    dataUpdated = true;
                                }
                                else
                                {
                                    Console.WriteLine("Description cannot be empty.");
                                }
                            }
                        }

                        if (dataUpdated)
                        {
                            Console.WriteLine("\nAge and physical description fields are complete for all of our friends.");
                        }
                        else
                        {
                            Console.WriteLine("\nNo updates were needed. All age and description data is complete.");
                        }

                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        bool nicknameUpdated = false;
                        for (int i = 0; i < ourAnimals.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(ourAnimals[i].ID))
                                continue;

                            while (string.IsNullOrWhiteSpace(ourAnimals[i].name))
                            {
                                Console.Write($"Enter a nickname for ID #: {ourAnimals[i].ID}: ");
                                string? nameInput = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(nameInput))
                                {
                                    ourAnimals[i].name = nameInput;
                                    nicknameUpdated = true;
                                }
                                else
                                {
                                    Console.WriteLine("Nickname cannot be empty.");
                                }
                            }

                            while (string.IsNullOrWhiteSpace(ourAnimals[i].personalityDescription))
                            {
                                Console.Write($"Enter a personality description for ID #: {ourAnimals[i].ID} (likes or dislikes, tricks, energy level): ");
                                string? personalityInput = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(personalityInput))
                                {
                                    ourAnimals[i].personalityDescription = personalityInput;
                                    nicknameUpdated = true;
                                }
                                else
                                {
                                    Console.WriteLine("Personality description cannot be empty.");
                                }
                            }
                        }

                        if (nicknameUpdated)
                        {
                            Console.WriteLine("\nNickname and personality description fields are complete for all of our friends.");
                        }
                        else
                        {
                            Console.WriteLine("\nNo updates were needed. All nickname and personality data is complete.");
                        }

                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        break;

                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        Console.WriteLine("Feature under construction. Press Enter to continue.");
                        Console.ReadLine();
                        break;

                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
