using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskFourProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // the ourAnimals array will store the following:
            string animalSpecies = "";
            string animalID = "";
            string animalAge = "";
            string animalPhysicalDescription = "";
            string animalPersonalityDescription = "";
            string animalNickname = "";

            // variables that support data entry
            int maxPets = 8;
            string readResult;
            string menuSelection = "";

            // array used to store runtime data, there is no persisted data
            string[,] ourAnimals = new string[maxPets, 6];

            // populate the ourAnimals array with sample data using a switch statement
            for (int i = 0; i < maxPets; i++)
            {
                switch (i)
                {
                    case 0:
                        animalSpecies = "dog";
                        animalID = "d1";
                        animalAge = "2";
                        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                        animalNickname = "lola";
                        break;

                    case 1:
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "loki";
                        break;

                    case 2:
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "friendly";
                        animalNickname = "Puss";
                        break;

                    case 3:
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "?";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        break;

                    default:
                        animalSpecies = "";
                        animalID = "";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        break;
                }

                // store data into ourAnimals array
                ourAnimals[i, 0] = animalSpecies;
                ourAnimals[i, 1] = animalID;
                ourAnimals[i, 2] = animalAge;
                ourAnimals[i, 3] = animalPhysicalDescription;
                ourAnimals[i, 4] = animalPersonalityDescription;
                ourAnimals[i, 5] = animalNickname;
            }

            // Display simple menu
            Console.WriteLine("Welcome to the Pet App!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Display all animals");
            Console.WriteLine("2. Exit");

            // Read and safely handle user input
            readResult = Console.ReadLine();

            if (readResult != null)
            {
                menuSelection = readResult;
            }

            Console.WriteLine($"You selected option: {menuSelection}");
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

        }
    }
}
