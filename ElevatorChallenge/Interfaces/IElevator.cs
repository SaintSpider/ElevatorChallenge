using static ElevatorChallenge.Enums.Enums;

namespace ElevatorChallenge.Interfaces
{
    public interface IElevator
    {
        int Id { get; }
        int CurrentFloor { get; }
        CallDirection CurrentDirection { get; }
        int Capacity { get; }
        int Occupancy { get; }

        void GoToFloor(int destinationFloor);
        void UpdateOccupancy(int numberOfPeople);

    }
}