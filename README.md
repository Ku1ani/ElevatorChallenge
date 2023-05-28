# ElevatorChallenge
This application simulates the movement of elevators in a building. It is designed to provide a user interface through the console, allowing users to interact with the elevators.

Here's an overview of what the application does:

1. User Interaction:
   - The application prompts the user to input commands to interact with the elevators.
   - Users can call an elevator to a specific floor by specifying the floor number and the number of people waiting on that floor.
   - Users can also view the status of all elevators in the system.

2. Elevator System:
   - The application creates an elevator system with multiple elevators, specified by the `elevatorCount` parameter.
   - Each elevator has a capacity, expressed as the number of people it can carry, specified by the `elevatorCapacity` parameter.
   - The elevator system is initialized with a specified number of floors, specified by the `floorCount` parameter.

3. Elevator Movement and Status:
   - Each elevator is represented by an instance of the `Elevator` class.
   - The elevators can move between floors, simulate picking up people from floors, and reach destination floors.
   - The status of each elevator is displayed, including the current floor, direction of movement, whether it is moving or stationary, and the current weight (number of people) it is carrying.

4. Calling an Elevator:
   - When a user calls an elevator to a specific floor, the application determines the nearest available elevator.
   - If an available elevator is found, it is sent to the requested floor, and the number of people waiting on that floor is added to the elevator's current weight.

5. Displaying Elevator Status:
   - The application provides an option to display the status of all elevators in the system.
   - The status includes the current floor, direction, movement status, and current weight of each elevator.

6. Program Execution:
   - The program runs in a continuous loop until the user chooses to quit.
   - Users can input commands to call an elevator, view elevator status, or exit the program.

Overall, this application offers a simple simulation of an elevator system, allowing users to interact with the elevators, observe their movement, and manage the number of people waiting on different floors.


Instructions to run the application:

Clone the repository: On the GitHub website, navigate to the repository containing the console application.

Open the project in Visual Studio: Launch Visual Studio and go to File -> Open -> Project/Solution. Navigate to the cloned repository directory and select the solution file (usually ending with .sln) of your console application. Click "Open" to load the project.

Build the project: Once the project is opened in Visual Studio, go to Build -> Build Solution or press Ctrl + Shift + B to build the application. This step compiles the source code and generates the executable file.

Run the application. The application will run in the console window, and you can provide any necessary input or interact with the program as required.

Alternatively, you can run the application directly from the command prompt or terminal by navigating to the project's output directory (usually located inside the bin directory of the project) and executing the executable file.
