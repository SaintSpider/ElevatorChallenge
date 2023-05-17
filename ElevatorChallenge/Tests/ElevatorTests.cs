using NUnit.Framework;
using ElevatorChallenge.Interfaces;
using ElevatorChallenge.Managers;

namespace ElevatorChallenge.Tests
{
    [TestFixture]
    public class ElevatorManagerTests
    {
        [Test]
        public void FindNearestElevator()
        {
            // Arrange
            int elevatorCount = 3;
            int elevatorCapacity = 8;
            IElevatorManager elevatorManager = new ElevatorManager(elevatorCount, elevatorCapacity);

            // Act
            IElevator nearestElevator = elevatorManager.FindNearestElevator(5);

            // Assert
            Assert.IsNotNull(nearestElevator);
            
        }

        [Test]
        public void UpdateElevatorStatus()
        {

                // Arrange
                int elevatorCount = 3;
                int elevatorCapacity = 8;
                IElevatorManager elevatorManager = new ElevatorManager(elevatorCount, elevatorCapacity);

            string expectedOutput = "Elevator 0: Current Floor - 1, Direction - None, Occupancy - 0/8" + Environment.NewLine +
                                    "Elevator 1: Current Floor - 1, Direction - None, Occupancy - 0/8" + Environment.NewLine +
                                    "Elevator 2: Current Floor - 1, Direction - None, Occupancy - 0/8" + Environment.NewLine;

            // Act
            string consoleOutput;
                using (StringWriter stringWriter = new StringWriter())
                {
                    Console.SetOut(stringWriter);

                    elevatorManager.UpdateElevatorStatus();

                    consoleOutput = stringWriter.ToString();
                }

                // Assert
                Assert.AreEqual(expectedOutput, consoleOutput);
            
        }


    }
}