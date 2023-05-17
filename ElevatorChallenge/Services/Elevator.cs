using System;
using System.Drawing;
using ElevatorChallenge.Interfaces;
using static ElevatorChallenge.Enums.Enums;

namespace ElevatorChallenge.Services;


public class Elevator : IElevator
{
    public int Id { get; }
    public int CurrentFloor { get; private set; }
    public CallDirection CurrentDirection { get; private set; }
    public int Capacity { get; private set; }
    public int Occupancy { get; private set; }



    public Elevator(int id, int capacity)
    {
        Id = id;
        CurrentFloor = 1;
        CurrentDirection = CallDirection.None;
        Capacity = capacity;
        Occupancy = 0;
    }

    public void GoToFloor(int destinationFloor)
    {
        if (CurrentFloor == destinationFloor)
        {
            Console.WriteLine("Elevator is already at the destination floor.");
            return;
        }

        if (CurrentFloor < destinationFloor)
            CurrentDirection = CallDirection.Up;
        else if (CurrentFloor > destinationFloor)
            CurrentDirection = CallDirection.Down;

        Console.WriteLine($"The elevator is moving {CurrentDirection}");

        while (CurrentFloor != destinationFloor)
        {
            switch (CurrentDirection)
            {
                case CallDirection.Up:
                    CurrentFloor++;
                    break;
                case CallDirection.Down:
                    CurrentFloor--;
                    break;
            }
            Console.WriteLine($"Current elevator floor: {CurrentFloor}");
        }

    }

    public void UpdateOccupancy(int numberOfPeople)
    {
        Occupancy = numberOfPeople;
    }





}