namespace RoverApp;

public sealed class Rover
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public DirectionEnum Direction { get; private set; }

    public Rover(int x, int y, DirectionEnum direction)
    {
        X = x;
        Y = y;

        Direction = direction;
    }

    public void Move(params MovementEnum[] commands)
    {
        foreach (var command in commands)
        {
            switch (command)
            {
                case MovementEnum.Left:
                    TurnLeft();
                    break;
                case MovementEnum.Right:
                    TurnRight();
                    break;
                case MovementEnum.Forward:
                    MoveForward();
                    break;
                default:
                    break;
            }
        }
    }

    private void TurnLeft()
    {
        Direction = Direction switch
        {
            DirectionEnum.North => DirectionEnum.West,
            DirectionEnum.West => DirectionEnum.South,
            DirectionEnum.South => DirectionEnum.East,
            DirectionEnum.East => DirectionEnum.North,
            _ => Direction
        };
    }

    private void TurnRight()
    {
        Direction = Direction switch
        {
            DirectionEnum.North => DirectionEnum.East,
            DirectionEnum.East => DirectionEnum.South,
            DirectionEnum.South => DirectionEnum.West,
            DirectionEnum.West => DirectionEnum.North,
            _ => Direction
        };
    }

    private void MoveForward()
    {
        switch (Direction)
        {
            case DirectionEnum.North:
                Y += 1;
                break;
            case DirectionEnum.East:
                X += 1;
                break;
            case DirectionEnum.South:
                Y -= 1;
                break;
            case DirectionEnum.West:
                X -= 1;
                break;
        }
    }

    public string GetPosition()
    {
        return $"Rover Position: {X}, {Y}, {Direction}";
    }
}
