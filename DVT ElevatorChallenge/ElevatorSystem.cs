using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DVT_ElevatorChallenge
{
    public class ElevatorSystem
    {
        private List<Elevator> elevators;
        private int floorCount;

        public ElevatorSystem(int elevatorCount, int floorCount, int elevatorCapacity)
        {
            elevators = new List<Elevator>();
            for (int i = 0; i < elevatorCount; i++)
            {
                Elevator elevator = new Elevator(elevatorCapacity);
                elevators.Add(elevator);
            }
            this.floorCount = floorCount;
        }

        public void CallElevator(int floor, int peopleCount)
        {
            int nearestElevatorIndex = FindNearestAvailableElevator(floor);
            if (nearestElevatorIndex != -1)
            {
                elevators[nearestElevatorIndex].AddDestinationFloor(floor, peopleCount);
                elevators[nearestElevatorIndex].SetFloorWithPeople(floor, peopleCount);
            }
            else
            {
                Console.WriteLine("No available elevators at the moment. Please try again later.");
            }
        }

        public void ShowElevatorStatus()
        {
            for (int i = 0; i < elevators.Count; i++)
            {
                Elevator elevator = elevators[i];
                Console.WriteLine("Elevator " + i + " - Current Floor: " + elevator.CurrentFloor);
                Console.WriteLine("Direction: " + elevator.Direction);
                Console.WriteLine("Is Moving: " + elevator.IsMoving);
                Console.WriteLine("Current Weight: " + elevator.CurrentWeight);
                Console.WriteLine();
            }
        }

        public int FindNearestAvailableElevator(int floor)
        {
            int nearestElevatorIndex = -1;
            int minDistance = int.MaxValue;

            for (int i = 0; i < elevators.Count; i++)
            {
                Elevator elevator = elevators[i];
                if (!elevator.IsMoving)
                {
                    int distance = Math.Abs(elevator.CurrentFloor - floor);
                    if (distance < minDistance)
                    {
                        nearestElevatorIndex = i;
                        minDistance = distance;
                    }
                }
            }

            return nearestElevatorIndex;
        }
    }
}
