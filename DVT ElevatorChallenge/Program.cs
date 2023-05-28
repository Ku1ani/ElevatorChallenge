using DVT_ElevatorChallenge;

class Program
{
    static void Main(string[] args)
    {
        int elevatorCount = 2;
        int floorCount = 10;
        int elevatorCapacity = 10;// Can carry up to 10 people making the weight limit 800 (Each person weighs 80kg)

        ElevatorSystem elevatorSystem = new ElevatorSystem(elevatorCount, floorCount, elevatorCapacity);

        while (true)
        {


            Console.WriteLine("Enter 'C' to call an elevator, 'S' for elevator status, or 'Q' to quit:");
            string input = Console.ReadLine();

            if (input.ToUpper() == "C")
            {
                Console.Write("Enter the floor number: ");
                int floor = int.Parse(Console.ReadLine());

                Console.Write("Enter the number of people waiting: ");
                int peopleCount = int.Parse(Console.ReadLine());

                elevatorSystem.CallElevator(floor, peopleCount);
            }
            else if (input.ToUpper() == "S")
            {
                elevatorSystem.ShowElevatorStatus();
            }
            else if (input.ToUpper() == "Q")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            Console.WriteLine();
        }
    }
}