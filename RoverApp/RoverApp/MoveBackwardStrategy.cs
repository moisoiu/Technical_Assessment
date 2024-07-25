namespace RoverApp;

internal class MoveBackwardStrategy : IMovementStrategy
{
    public void Move(RoverV2 rover)
    {
        switch (rover.Direction)
        {
            case DirectionEnum.North:
                rover.Y -= 1;
                break;
            case DirectionEnum.East:
                rover.X -= 1;
                break;
            case DirectionEnum.South:
                rover.Y += 1;
                break;
            case DirectionEnum.West:
                rover.X += 1;
                break;
        }
    }
}
