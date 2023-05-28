using System;
using System.Collections.Generic;

public enum Direction
{
    Up,
    Down,
    Stationary
}

namespace DVT_ElevatorChallenge
{
    

    public class Elevator
    {
        private int currentFloor;
        private bool isMoving;
        private Direction direction;
        private int capacity;
        private int currentWeight;
        private List<int> destinationFloors;
        private List<int> floorsWithPeople;

        public int CurrentFloor
        {
            get { return currentFloor; }
        }

        public bool IsMoving
        {
            get { return isMoving; }
        }

        public Direction Direction
        {
            get { return direction; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public int CurrentWeight
        {
            get { return currentWeight; }
        }

        public Elevator(int capacity)
        {
            currentFloor = 0;
            isMoving = false;
            direction = Direction.Stationary;
            this.capacity = capacity;
            currentWeight = capacity + 80; //Assumption being that each person weighs 80kg
            destinationFloors = new List<int>();
            floorsWithPeople = new List<int>();
        }

        public void AddDestinationFloor(int floor, int peopleCount)
        {
            destinationFloors.Add(floor);
            if (!isMoving)
            {
                isMoving = true;
                Move(peopleCount);
            }
        }

        public void SetFloorWithPeople(int floor, int peopleCount)
        {
            if (floor >= 0 && floor < floorsWithPeople.Count)
            {
                floorsWithPeople[floor] = peopleCount;
            }
            else if (floor == floorsWithPeople.Count)
            {
                floorsWithPeople.Add(peopleCount);
            }
        }

        public void Move(int peopleCount)
        {
            if (peopleCount <= capacity)
            {
                int destinationFloor = destinationFloors[0];

                if (destinationFloor > currentFloor)
                {
                    direction = Direction.Up;
                    Console.WriteLine("**Door Closing**");
                    Console.WriteLine("Going up...");
                    while (currentFloor < destinationFloor)
                    {
                        Thread.Sleep(1000); // 1-second delay
                        currentFloor++;
                        Console.WriteLine("Floor: " + currentFloor);
                    }
                }
                else if (destinationFloor < currentFloor)
                {
                    direction = Direction.Down;
                    Console.WriteLine("**Door Closing**");
                    Console.WriteLine("Going down...");
                    while (currentFloor > destinationFloor)
                    {
                        Thread.Sleep(1000); // 1-second delay
                        currentFloor--;
                        Console.WriteLine("Floor: " + currentFloor);
                        if (floorsWithPeople[currentFloor] > 0)
                        {
                            int pplCount = Math.Min(floorsWithPeople[currentFloor], capacity - currentWeight);
                            currentWeight += pplCount;
                            floorsWithPeople[currentFloor] -= pplCount;
                            Console.WriteLine("Picked up " + pplCount + " people");
                        }
                    }
                }

                Console.WriteLine("Reached destination floor: " + currentFloor);
                Console.WriteLine("**Door Opening**");

                direction = Direction.Stationary;
                destinationFloors.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Elevator at Max capacity: " + capacity);

            }



            isMoving = false;
        }
    }
}
