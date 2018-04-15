using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Practice exercise 18
/// Class Description   : Main program
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : April 15, 2018
/// Filename            : Program.cs
/// </summary>

namespace Graphs1
{
    class Program
    {
        private static Graph House { get; set; }
        private static string CurrentRoom { get; set; }

        static void Main(string[] args)
        {
            CurrentRoom = ("MASTER SUITE");

            House = new Graph();

            do                                                                              // Game loop
            {
                CurrentRoom = NavigateRooms(CurrentRoom);

            } while (CurrentRoom != "EXIT");

            Console.WriteLine("\nCongratulations, you have successfully escaped the house");
            Console.WriteLine("Press Enter to exit the game");

            Console.ReadLine();
        }

        /// <summary>
        /// The actual game code that navigates the graph
        /// </summary>
        /// <param name="currentRoom">The room the player is currently in</param>
        /// <returns>The room the player is going to</returns>
        private static string NavigateRooms(string currentRoom)
        {
            string requestedLocation = null;
            string returnValue = null;

            Console.WriteLine("You are currently in the " + currentRoom);            
            Console.WriteLine("Nearby are:");

            foreach (string room in House.GetAdjacentList(currentRoom))                     // Display adjacent rooms
            {
                Console.WriteLine("     " + room);
            }

            Console.WriteLine();
            bool validLocation = false;

            do
            {
                Console.Write("Where would you like to go next? : ");
                requestedLocation = Console.ReadLine().ToUpper();
                Console.WriteLine();
                                                                                            // If the room exists, or the entry is EXIT
                if (House.RoomExists(requestedLocation) || (requestedLocation.Equals("EXIT")))
                {
                    if (House.IsConnected(CurrentRoom, requestedLocation))                  // Test if the requested location is connected to the current location
                    {
                        returnValue = requestedLocation;
                        validLocation = true;
                    }
                    else
                    {
                        Console.WriteLine("You cannot go to the " + requestedLocation + " from the " + CurrentRoom + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("There is no " + requestedLocation + " in this house, please try again\n");
                }

            } while (!validLocation);

            return returnValue;
        }
    }
}
