namespace RoverApp;

public sealed class RoverV2
{
    public int X { get; set; }
    public int Y { get; set; }
    public DirectionEnum Direction { get; set; }

    private readonly MovementHandler _movementHandler;

    public RoverV2(int x, int y, DirectionEnum direction, MovementHandler movementHandler)
    {
        X = x;
        Y = y;
        Direction = direction;
        _movementHandler = movementHandler;
    }

    public void Move(params MovementEnum[] commands)
    {
        foreach (var command in commands)
        {
            _movementHandler.Handle(command, this);
        }
    }

    public string GetPosition()
    {
        return $"Rover Position: {X}, {Y}, {Direction}";
    }
}
