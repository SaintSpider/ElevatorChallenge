using System;
using System.Runtime;
using System.Runtime.Intrinsics.Arm;
using ElevatorChallenge.Constants;
using ElevatorChallenge.Interfaces;
using ElevatorChallenge.Managers;
using ElevatorChallenge.Services;

namespace ElevatorChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'quit' to exit the program.");

            IElevatorManager elevatorManager = new ElevatorManager(BuildingConstants.TotalElevators, BuildingConstants.TotalCapacity);
            ICallCoordinator callCoordinator = new CallCoordinator(elevatorManager);


            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter the current floor: ");
                string currentFloorInput = Console.ReadLine();

                if (currentFloorInput.ToLower() == "quit")
                    break;

                if (!int.TryParse(currentFloorInput, out int currentFloor))
                {
                    Console.WriteLine("Invalid input. Please enter a valid floor number.");
                    continue;
                }

                Console.WriteLine("Enter the destination floor: ");
                string destinationFloorInput = Console.ReadLine();

                if (destinationFloorInput.ToLower() == "quit")
                    break;

                if (!int.TryParse(destinationFloorInput, out int destinationFloor))
                {
                    Console.WriteLine("Invalid input. Please enter a valid floor number.");
                    continue;
                }

                Console.WriteLine("Enter the number of people: ");
                string numberOfPeopleInput = Console.ReadLine();

                if (numberOfPeopleInput.ToLower() == "quit")
                    break;

                if (!int.TryParse(numberOfPeopleInput, out int numberOfPeople))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of people.");
                    continue;
                }

                if (numberOfPeople > BuildingConstants.TotalCapacity)
                {
                    Console.WriteLine($"The elevator can only accommodate {BuildingConstants.TotalCapacity} people.");
                    continue;
                }

                callCoordinator.CallElevator(currentFloor, destinationFloor, numberOfPeople);
                elevatorManager.UpdateElevatorStatus();
            }
        }
    }
}