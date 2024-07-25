
using RoverApp;

var rover = new Rover(0, 0, 'N');
rover.Move("LRMLRMLLLMMMM");
Console.WriteLine(rover.GetPosition());

Console.ReadLine();
