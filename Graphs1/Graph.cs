using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Practice exercise 18
/// Class Description   : Graph class
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : April 15, 2018
/// Filename            : Graph.cs
/// </summary>

namespace Graphs1
{
    class Graph
    {
        public Dictionary<string, List<string>> AdjacencyList { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Graph ()
        {
            AdjacencyList = new Dictionary<string, List<string>>();

            SetUpDefaultRooms();
        }

        /// <summary>
        /// Set up the default rooms list
        /// </summary>
        private void SetUpDefaultRooms()
        {
            AdjacencyList.Add(
                "ENTRANCE HALL",
                new List<string> {
                    "Bedroom 3",
                    "Living Room",
                    "Garage",
                    "Exit"
                }
            );

            AdjacencyList.Add(
                "BEDROOM 3",
                new List<string> {
                    "Bathroom 3",
                    "Entrance Hall"
                }
            );

            AdjacencyList.Add(
                "BATHROOM 3",
                new List<string> {
                    "Bedroom 3"
                }
            );

            AdjacencyList.Add(
                "GARAGE",
                new List<string> {
                    "Entrance Hall"
                }
            );

            AdjacencyList.Add(
                "LIVING ROOM",
                new List<string> {
                    "Hallway",                    
                    "Balcony",
                    "Dining Room",
                    "Entrance Hall"
                }
            );

            AdjacencyList.Add(
                "DINING ROOM",
                new List<string> {
                    "Living Room",
                    "Kitchen"
                }
            );

            AdjacencyList.Add(
                "KITCHEN",
                new List<string> {
                    "Dining Room"
                }
            );

            AdjacencyList.Add(
                "BALCONY",
                new List<string> {
                    "Living Room"
                }
            );

            AdjacencyList.Add(
                "HALLWAY",
                new List<string> {
                    "Living Room",
                    "Master Suite",
                    "Bedroom 2"
                }
            );

            AdjacencyList.Add(
                "MASTER SUITE",
                new List<string> {
                    "Hallway",
                    "Master Bathroom"
                }
            );

            AdjacencyList.Add(
                "MASTER BATHROOM",
                new List<string> {
                    "Master Suite"
                }
            );

            AdjacencyList.Add(
                "BEDROOM 2",
                new List<string> {
                    "Hallway",
                    "Bathroom 2"
                }
            );

            AdjacencyList.Add(
                "BATHROOM 2",
                new List<string> {
                    "Bedroom 2"
                }
            );            
        }

        /// <summary>
        /// Used to add new rooms to the graph
        /// </summary>
        /// <param name="roomName">Name of the room being added</param>
        /// <param name="connectedTo">Other rooms this room is connected to as a list of strings</param>
        public void AddRoom(string roomName, List<string> connectedTo)
        {
            if (AdjacencyList.ContainsKey(roomName))
            {
                Console.WriteLine("You cannot add a room with this name because one already exists");
            }
            else
            {
                AdjacencyList.Add(roomName, connectedTo);
            }
        }

        /// <summary>
        /// Get the list of rooms adjacent to the current room
        /// </summary>
        /// <param name="room">Current room</param>
        /// <returns>List of strings - all rooms adjacent to this room</returns>
        public List<string> GetAdjacentList(string room)
        {
            List<string> returnValue = new List<string>();

            if (AdjacencyList.ContainsKey(room))
            {
                foreach (string adjacentRoom in AdjacencyList[room])
                {
                    returnValue.Add(adjacentRoom);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Is this room connected to another room
        /// </summary>
        /// <param name="room1">First room</param>
        /// <param name="room2">Second room</param>
        /// <returns>bool value of if it is connected</returns>
        public bool IsConnected(string room1, string room2)
        {
            bool returnValue = false;

            if (AdjacencyList.ContainsKey(room1))                                           // Test if the room1 key exists
            {
                if ((AdjacencyList.ContainsKey(room2)) || (room2.Equals("EXIT")))           // Test if the room2 exists, or if it is EXIT
                {
                    if (AdjacencyList[room1].Contains(room2, StringComparer.OrdinalIgnoreCase))  // Test adjacency while ignoring case
                    {
                        returnValue = true;
                    }
                }    
                else
                {
                    Console.WriteLine("There is no " + room2 + " in this building");
                }
            }
            else
            {
                Console.WriteLine("There is no " + room1 + " in this building");
            }

            return returnValue;
        }

        /// <summary>
        /// Test if the provided room exists in the building
        /// </summary>
        /// <param name="roomName">Room to check for</param>
        /// <returns>true or false if the room exists or not</returns>
        public bool RoomExists(string roomName)
        {
            bool returnValue = false;

            if (AdjacencyList.ContainsKey(roomName))
            {
                returnValue = true;
            }

            return returnValue;
        }
    }
}
