using DVT_ElevatorChallenge;

namespace ElevatorChallenge.UnitTests
{
    [TestFixture]
    public class ElevatorSystemTests
    {
        private ElevatorSystem elevatorSystem;

        [SetUp]
        public void Setup()
        {
            elevatorSystem = new ElevatorSystem(2, 10, 8);
        }

        [Test]
        public void Move_ElevatorMovesToDestinationFloor()
        {
            // Arrange
            var elevator = new Elevator(8);
            elevator.AddDestinationFloor(5,9);
            elevator.SetFloorWithPeople(5,3);
            elevator.AddDestinationFloor(2,8);
            elevator.SetFloorWithPeople(2,2);

            // Act
            elevator.Move(8);

            // Assert
            Assert.AreEqual(5, elevator.CurrentFloor);
            Assert.AreEqual(Direction.Stationary, elevator.Direction);
            Assert.AreEqual(3, elevator.CurrentWeight);
            Assert.IsFalse(elevator.IsMoving);       
        }


        [Test]
        public void FindNearestAvailableElevator_ReturnsNearestElevatorIndex()
        {
            elevatorSystem.CallElevator(5, 3);
            elevatorSystem.CallElevator(8, 2);

            var index = elevatorSystem.FindNearestAvailableElevator(7);
            Assert.AreEqual(1, index);
        }

        [Test]
        public void FindNearestAvailableElevator_ReturnsMinusOneIfNoAvailableElevators()
        {
            elevatorSystem.CallElevator(5, 3);
            elevatorSystem.CallElevator(8, 2);

            var index = elevatorSystem.FindNearestAvailableElevator(7);
            Assert.AreEqual(-1, index);
        }
    }
}