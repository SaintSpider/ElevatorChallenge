// ElevatorManager.cs
using ElevatorChallenge.Interfaces;
using ElevatorChallenge.Services;

namespace ElevatorChallenge.Managers
{
    public class ElevatorManager : IElevatorManager
    {
        private readonly List<IElevator> elevators;

        public ElevatorManager(int elevatorCount, int elevatorCapacity)
        {
            elevators = new List<IElevator>();
            for (var i = 0; i < elevatorCount; i++)
            {
                IElevator elevator = new Elevator(i, elevatorCapacity);
                elevators.Add(elevator);
            }
        }

        public IElevator FindNearestElevator(int floor)
        {
            IElevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (IElevator elevator in elevators)
            {

                int distance = Math.Abs(elevator.CurrentFloor - floor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestElevator = elevator;
                }

            }

            return nearestElevator;
        }

        public void UpdateElevatorStatus()
        {
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id}: Current Floor - {elevator.CurrentFloor}, Direction - {elevator.CurrentDirection}, Occupancy - {elevator.Occupancy}/{elevator.Capacity}");
            }
        }
    }
}