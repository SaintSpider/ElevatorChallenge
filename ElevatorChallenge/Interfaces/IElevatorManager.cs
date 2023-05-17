namespace ElevatorChallenge.Interfaces
{
    public interface IElevatorManager
    {
        IElevator FindNearestElevator(int floor);
        void UpdateElevatorStatus();
    }
}