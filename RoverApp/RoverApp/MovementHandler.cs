namespace RoverApp;

public sealed class MovementHandler
{
    private readonly Dictionary<MovementEnum, IMovementStrategy> _strategies;

    public MovementHandler(Dictionary<MovementEnum, IMovementStrategy> strategies)
    {
        _strategies = strategies;
    }

    public void Handle(MovementEnum command, RoverV2 rover)
    {
        if (_strategies.TryGetValue(command, out var strategy))
        {
            strategy.Move(rover);
        }
    }
}
