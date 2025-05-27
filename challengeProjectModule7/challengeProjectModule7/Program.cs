using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challengeProjectModule7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Define the animal data: type, nickname, ID, physical description, personality, full description
            string[,] ourAnimals = new string[4, 6]
            {
            { "dog", "lola", "d1", "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.", "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.", "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken. loves to have her belly rubbed and likes to chase her tail. gives lots of kisses." },
            { "dog", "gus", "d2", "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.", "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.", "large reddish-brown male golden retriever weighing about 85 pounds. housebroken. loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs." },
            { "cat", "whiskers", "c1", "small gray tabby cat.", "shy at first, but loves laps and yarn.", "small gray tabby cat. shy at first, but loves laps and yarn." },
            { "cat", "mittens", "c2", "black and white spotted cat.", "very talkative and loves head scratches.", "black and white spotted cat. very talkative and loves head scratches." }
            };

            bool exitApp = false;

            while (!exitApp)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
                Console.WriteLine(" 1. List all of our current pet information");
                Console.WriteLine(" 2. Display all dogs with a specified characteristic");
                Console.WriteLine("\nEnter your selection number (or type Exit to exit the program)");

                string menuSelection = Console.ReadLine()?.ToLower();

                switch (menuSelection)
                {
                    case "1":
                        Console.WriteLine("\nListing all current pet information:\n");
                        for (int i = 0; i < ourAnimals.GetLength(0); i++)
                        {
                            Console.WriteLine($"Type: {ourAnimals[i, 0]}");
                            Console.WriteLine($"Nickname: {ourAnimals[i, 1]}");
                            Console.WriteLine($"ID: {ourAnimals[i, 2]}");
                            Console.WriteLine($"Physical Description: {ourAnimals[i, 3]}");
                            Console.WriteLine($"Personality: {ourAnimals[i, 4]}\n");
                        }
                        Console.WriteLine("Press the Enter key to continue");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("\nEnter dog characteristics to search for separated by commas:");
                        string searchInput = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(searchInput))
                        {
                            Console.WriteLine("No search terms provided. Returning to menu.");
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        }

                        // Clean and sort search terms
                        string[] searchTerms = searchInput.ToLower()
                                                          .Split(',')
                                                          .Select(term => term.Trim())
                                                          .Where(term => term.Length > 0)
                                                          .Distinct()
                                                          .OrderBy(term => term)
                                                          .ToArray();

                        if (searchTerms.Length == 0)
                        {
                            Console.WriteLine("No valid search terms entered. Returning to menu.");
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        }

                        bool anyMatchFound = false;

                        // Begin dog search
                        for (int i = 0; i < ourAnimals.GetLength(0); i++)
                        {
                            if (ourAnimals[i, 0].ToLower() == "dog")
                            {
                                string nickname = ourAnimals[i, 1];
                                string id = ourAnimals[i, 2];
                                string physicalDescription = ourAnimals[i, 3];
                                string personalityDescription = ourAnimals[i, 4];
                                string fullDescription = ourAnimals[i, 5].ToLower();

                                bool matchForThisDog = false;

                                foreach (string term in searchTerms)
                                {
                                    // Spinner animation with countdown
                                    string[] spinnerIcons = { "/", "-", "\\", "|" };
                                    for (int countdown = 2; countdown >= 0; countdown--)
                                    {
                                        foreach (string icon in spinnerIcons)
                                        {
                                            Console.Write($"\rsearching our dog Nickname: {nickname} for {term} {icon} {countdown}   ");
                                            System.Threading.Thread.Sleep(100);
                                        }
                                    }

                                    Console.WriteLine(); // Finish animation

                                    if (fullDescription.Contains(term))
                                    {
                                        Console.WriteLine($"Our dog Nickname: {nickname} matches your search for {term}");
                                        matchForThisDog = true;
                                        anyMatchFound = true;
                                    }
                                }

                                if (matchForThisDog)
                                {
                                    Console.WriteLine($"\nNickname: {nickname} (ID #: {id})");
                                    Console.WriteLine($"Physical description: {physicalDescription}");
                                    Console.WriteLine($"Personality: {personalityDescription}\n");
                                }
                            }
                        }

                        if (!anyMatchFound)
                        {
                            Console.WriteLine($"\nNone of our dogs are a match for: {string.Join(", ", searchTerms)}\n");
                        }

                        Console.WriteLine("Press the Enter key to continue");
                        Console.ReadLine();
                        break;

                    case "exit":
                        exitApp = true;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }

            Console.WriteLine("Thank you for using the Contoso PetFriends app. Goodbye!");

        }
    }
}
