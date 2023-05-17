using ElevatorChallenge.Interfaces;

namespace ElevatorChallenge.Services
{
    public class CallCoordinator : ICallCoordinator
    {
        private readonly IElevatorManager elevatorManager;

        public CallCoordinator(IElevatorManager elevatorManager)
        {
            this.elevatorManager = elevatorManager;
        }

        public void CallElevator(int currentFloor, int destinationFloor, int numberOfPeople)
        {
            IElevator closestElevator = elevatorManager.FindNearestElevator(currentFloor);

            if (closestElevator == null)
            {
                Console.WriteLine("No available elevators. Please try again later.");
                return;
            }

            // Moves elevator to current floor of person calling
            if (closestElevator.CurrentFloor != currentFloor)
            {
                closestElevator.GoToFloor(currentFloor);
            }

            // Moves elevator to destination floor
            if (closestElevator.CurrentFloor != destinationFloor)
            {
                closestElevator.GoToFloor(destinationFloor);
                closestElevator.UpdateOccupancy(numberOfPeople);
            }
        }
    }
}