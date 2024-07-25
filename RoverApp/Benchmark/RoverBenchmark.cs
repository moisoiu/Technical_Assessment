using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RoverApp;

namespace Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class RoverBenchmark
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private RoverOld _roverOld;
    private Rover _rover;
    private RoverV2 _roverV2;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [GlobalSetup]
    public void Setup()
    {
        _roverOld = new RoverOld(0, 0, 'F');
        _rover = new Rover(0, 0, DirectionEnum.North);

        var strategies = new Dictionary<MovementEnum, IMovementStrategy>
            {
                { MovementEnum.Left, new TurnLeftStrategy() },
                { MovementEnum.Right, new TurnRightStrategy() },
                { MovementEnum.Forward, new MoveForwardStrategy() },
                { MovementEnum.Backward, new MoveBackwardStrategy() }
            };

        var movementHandler = new MovementHandler(strategies);

        _roverV2 = new RoverV2(0, 0, DirectionEnum.North, movementHandler);
    }

    [Benchmark]
    public string MoveAndGetPossition_RoverOld()
    {
        _roverOld.Move("FRFRFRF");
        return _roverOld.GetPosition();
    }


    [Benchmark]
    public string MoveAndGetPossition_Rover()
    {
        _rover.Move(MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward);
        return _rover.GetPosition();
    }

    [Benchmark]
    public string MoveAndGetPossition_RoverV2()
    {
        _roverV2.Move(MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward);
        return _rover.GetPosition();
    }
}
