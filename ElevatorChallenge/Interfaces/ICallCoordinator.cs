namespace ElevatorChallenge.Interfaces
{
    public interface ICallCoordinator
    {
        void CallElevator(int currentFloor, int destinationFloor, int numberOfPeople);
    }
}