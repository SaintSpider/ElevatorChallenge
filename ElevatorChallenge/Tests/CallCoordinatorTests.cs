using ElevatorChallenge.Interfaces;
using ElevatorChallenge.Services;
using NUnit.Framework;
using Moq;

[TestFixture]
public class CallCoordinatorTests
{
    [Test]
    public void CallElevator_WhenNearestElevatorExists()
    {
        // Arrange
        int currentFloor = 3;
        int destinationFloor = 7;
        int numberOfPeople = 4;
        Mock<IElevatorManager> elevatorManagerMock = new Mock<IElevatorManager>();
        IElevator closestElevator = new Elevator(0, 10); 
        elevatorManagerMock.Setup(m => m.FindNearestElevator(currentFloor)).Returns(closestElevator);
        CallCoordinator callCoordinator = new CallCoordinator(elevatorManagerMock.Object);

        // Act
        callCoordinator.CallElevator(currentFloor, destinationFloor, numberOfPeople);

        // Assert
        elevatorManagerMock.Verify(m => m.FindNearestElevator(currentFloor), Times.Once());
    }

    [Test]
    public void CallElevator_WhenNoAvailableElevator()
    {
        // Arrange
        int currentFloor = 3;
        int destinationFloor = 7;
        int numberOfPeople = 4;
        Mock<IElevatorManager> elevatorManagerMock = new Mock<IElevatorManager>();
        elevatorManagerMock.Setup(m => m.FindNearestElevator(currentFloor)).Returns((IElevator)null);
        CallCoordinator callCoordinator = new CallCoordinator(elevatorManagerMock.Object);

        
        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);

            // Act
            callCoordinator.CallElevator(currentFloor, destinationFloor, numberOfPeople);

            // Assert
            string consoleOutput = stringWriter.ToString().Trim();
            Assert.AreEqual("No available elevators. Please try again later.", consoleOutput);
        }
    }
}