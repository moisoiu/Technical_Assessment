
using RoverApp;

var rover = new Rover(0, 0, DirectionEnum.North);
rover.Move(MovementEnum.Left, MovementEnum.Right, MovementEnum.Right, MovementEnum.Forward, MovementEnum.Forward);
Console.WriteLine(rover.GetPosition());

Console.ReadLine();
