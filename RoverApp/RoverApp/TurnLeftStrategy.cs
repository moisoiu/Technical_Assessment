namespace RoverApp;

public sealed class TurnLeftStrategy : IMovementStrategy
{
    public void Move(RoverV2 rover)
    {
        rover.Direction = rover.Direction switch
        {
            DirectionEnum.North => DirectionEnum.West,
            DirectionEnum.West => DirectionEnum.South,
            DirectionEnum.South => DirectionEnum.East,
            DirectionEnum.East => DirectionEnum.North,
            _ => rover.Direction
        };
    }
}
