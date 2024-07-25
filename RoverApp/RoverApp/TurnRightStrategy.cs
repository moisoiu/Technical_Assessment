namespace RoverApp;

internal class TurnRightStrategy : IMovementStrategy
{
    public void Move(RoverV2 rover)
    {
        rover.Direction = rover.Direction switch
        {
            DirectionEnum.North => DirectionEnum.East,
            DirectionEnum.East => DirectionEnum.South,
            DirectionEnum.South => DirectionEnum.West,
            DirectionEnum.West => DirectionEnum.North,
            _ => rover.Direction
        };
    }
}
